using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolicyProject.Dtos.PolicyTypedto;
using PolicyProject.Models;
using PolicyProject.Services.PolicyTypeServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolicyProject.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/policy/category")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class PolicyTypeController : ControllerBase
    {
        private readonly IPolicyTypeService _policyTypeService;

        public PolicyTypeController(IPolicyTypeService policyTypeService)
        {
            _policyTypeService = policyTypeService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _policyTypeService.GetAllPolicyType());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolicyTypeById(int id)
        {
            ServiceResponse<PolicyTypeDto> res = await _policyTypeService.GetPolicyTypeById(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);

        }
        [HttpPost]
        public async Task<IActionResult> AddPolicyTypeBy(PolicyTypeDto newPolicyType)
        {
            ServiceResponse<List<PolicyTypeDto>> res = await _policyTypeService.AddPolicyType(newPolicyType);
            return Ok(res);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicyTypeBy(int id)
        {
            ServiceResponse<List<PolicyTypeDto>> res = await _policyTypeService.DeletePolicyType(id);
            if (res.Success)
            {

                return Ok(res);
            }
            return BadRequest(res);

        }
        [HttpPut]
        public async Task<IActionResult> UpdatePolicyTypeBy(PolicyTypeDto updatedPolicyType)
        {
            ServiceResponse<PolicyTypeDto> res = await _policyTypeService.UpdatePolicyType(updatedPolicyType);
            if (res.Success)
            {

                return Ok(res);
            }
            return BadRequest(res);

        }
    }
}
