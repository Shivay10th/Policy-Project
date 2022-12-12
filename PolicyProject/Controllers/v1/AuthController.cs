using Microsoft.AspNetCore.Mvc;
using PolicyProject.Data;
using PolicyProject.Dtos.User;
using PolicyProject.Models;
using Serilog;
using System;
using System.Threading.Tasks;

namespace PolicyProject.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            // todo: remove role from request
            ServiceResponse<int> res = await _authRepository.Register(new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DOB = request.DOB,
                ContactNo = request.ContactNo,
                Email = request.Email,
                Role = request.Role,
                Salary = request.Salary,
                Pan = request.Pan,
                EmployerType = request.EmployerType,
                EmployerName = request.EmployerName,

            }, request.Password);
            if (!res.Success)
            {
                Log.Warning("{email} register at {now} Failed", request.Email, DateTime.Now);

                return BadRequest(res);
            }
            Log.Information("{email} register at {now} Success", request.Email, DateTime.Now);

            return Ok(res);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto req)
        {

            ServiceResponse<string> res = await _authRepository.Login(req.Email, req.Password);
            if (!res.Success)
            {
                Log.Warning("{email} logged in at {now} Failed", req.Email, DateTime.Now);
                return BadRequest(res);
            }
            Log.Information("{email} logged in at {now} Success", req.Email, DateTime.Now);
            return Ok(res);
        }
    }
}
