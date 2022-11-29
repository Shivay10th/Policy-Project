using Microsoft.AspNetCore.Mvc;
using PolicyProject.Data;
using PolicyProject.Dtos.User;
using PolicyProject.Models;
using System.Threading.Tasks;

namespace PolicyProject.Controllers
{
    [Route("api/[controller]")]
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
            ServiceResponse<int> res = await _authRepository.Register(new Models.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DOB = request.DOB,
                ContactNo = request.ContactNo,
                Email = request.Email,
                Salary = request.Salary,
                Pan = request.Pan,
                EmployerType = request.EmployerType,
                EmployerName = request.EmployerName,

            }, request.Password);
            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto req)
        {

            ServiceResponse<string> res = await _authRepository.Login(req.Email, req.Password);
            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
    }
}
