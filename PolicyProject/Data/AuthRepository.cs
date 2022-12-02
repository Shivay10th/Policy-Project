using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PolicyProject.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PolicyProject.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly PolicyProjectContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(PolicyProjectContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            ServiceResponse<string> res = new ServiceResponse<string>();
            User user = await _context.User.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                res.Success = false;
                res.Message = "email does not exist";

            }
            else if (!VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                res.Success = false;
                res.Message = "Wrong password";
            }
            else
            {
                res.Data = CreateJWTToken(user);
            }
            return res;

        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> res = new ServiceResponse<int>();

            if (await UserExist(user.Email))
            {
                res.Success = false;
                res.Message = "This Email already exist";
                return res;
            }
            double salaryInYrInLac = (user.Salary * 12)/100000;
            if (salaryInYrInLac <= 5)
                user.EmployerType = "A";
            else if (salaryInYrInLac <= 10)
                user.EmployerType = "B";
            else if (salaryInYrInLac <= 15)
                user.EmployerType = "C";
            else if (salaryInYrInLac<=30)
                user.EmployerType = "D";
            else
                user.EmployerType = "E";



            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            res.Data = user.Id;
            return res;
        }

        public async Task<bool> UserExist(string email)
        {
            bool consist = await _context.User.AnyAsync(u => u.Email.ToLower() == email.ToLower());
            if (consist)
            {
                return true;
            }
            return false;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < password.Length; i++)
                {
                    if (passHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public string CreateJWTToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)
                );

            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = cred
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
