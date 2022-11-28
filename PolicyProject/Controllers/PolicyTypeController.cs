using Microsoft.AspNetCore.Mvc;
using PolicyProject.Dtos.PolicyType;
using PolicyProject.Models;
using PolicyProject.Services.PolicyTypeServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolicyProject.Controllers
{
    [Route("api/policy/category")]
    [ApiController]
    public class PolicyTypeController : ControllerBase
    {
        private readonly IPolicyTypeService _policyTypeService;

        public PolicyTypeController(IPolicyTypeService policyTypeService)
        {
            _policyTypeService = policyTypeService;
        }
        [HttpGet]
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
        public async Task<IActionResult> GetAddPolicyTypeBy(PolicyTypeDto newPolicyType)
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
