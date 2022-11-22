using Microsoft.EntityFrameworkCore;
using PolicyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyProject.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly PolicyProjectContext _context;

        public AuthRepository(PolicyProjectContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            ServiceResponse<string> res = new ServiceResponse<string>();
            User user = await _context.User.FirstOrDefaultAsync(u => u.Email == email);
            if (user==null)
            {
                res.Success = false;
                res.Message = "email does not exist";

            }
            else if (!VerifyPassword(password,user.PasswordHash,user.PasswordSalt))
            {
                res.Success = false;
                res.Message = "Wrong password";
            }
            else
            {
                res.Data = user.Id.ToString();
            }
            return res;

        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> res = new ServiceResponse<int>();

            if(await UserExist(user.Email) )
            {
                res.Success = false;
                res.Message = "This Email already exist";
                return res;
            }
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

        public void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPassword(string password,byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < password.Length; i++)
                {
                    if (passHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
