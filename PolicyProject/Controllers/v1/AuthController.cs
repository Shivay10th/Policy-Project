using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolicyProject.Data;
using PolicyProject.Dtos.User;
using PolicyProject.Models;
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
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthRepository authRepository, ILogger<AuthController> logger)
        {
            _authRepository = authRepository;
            _logger = logger;
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
                _logger.LogError("{email} register at {now} Failed", request.Email, DateTime.Now);

                return BadRequest(res);
            }
            _logger.LogInformation("{email} register at {now} Success", request.Email, DateTime.Now);

            return Ok(res);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto req)
        {

            ServiceResponse<string> res = await _authRepository.Login(req.Email, req.Password);
            if (!res.Success)
            {
                _logger.LogWarning("{email} logged in at {now} Failed", req.Email, DateTime.Now);
                return BadRequest(res);
            }
            _logger.LogInformation("{email} logged in at {now} Success", req.Email, DateTime.Now);
            return Ok(res);
        }
    }
}
