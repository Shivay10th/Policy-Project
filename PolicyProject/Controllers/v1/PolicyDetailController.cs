using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolicyProject.Dtos.PolicyDetailDto;
using PolicyProject.Models;
using PolicyProject.Services.PolicyDetailService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PolicyProject.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/policyrequest")]
    [ApiController]
    [Authorize]
    public class PolicyDetailController : ControllerBase
    {
        private readonly IPolicyDetailService _policydetailservice;
        private readonly ILogger<PoliciesController> _logger;

        public PolicyDetailController(IPolicyDetailService policydetailservice, ILogger<PoliciesController> logger)
        {
            _policydetailservice = policydetailservice;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]

        public async Task<ActionResult<List<GetPolicyDetailDto>>> GetAllPolicyDetails()
        {
            var res = await _policydetailservice.GetAllPolicyDetails();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetPolicyDetailDto>>> GetAllPolicyDetailsOfUser(int id)
        {
            var res = await _policydetailservice.GetAllPolicyDetailsOfAUser(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetPolicyDetailDto>>> AddPolicyDetail(PostPolicyDetailDto policyDetailDto)
        {
            ServiceResponse<GetPolicyDetailDto> res = new ServiceResponse<GetPolicyDetailDto>();
            res = await _policydetailservice.RequestPolicy(policyDetailDto);
            if (res.Success)
            {
                _logger.LogWarning("New Policy Request added By UserId{id} at {now}", policyDetailDto.UserId, DateTime.Now);

                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }


        }

        [HttpDelete("{userId}/{detailId}")]
        public async Task<ActionResult<ServiceResponse<GetPolicyDetailDto>>> Remove(int userId, int detailId)
        {
            ServiceResponse<GetPolicyDetailDto> res = await _policydetailservice.RemovePolicyDetail(userId, detailId);
            if (res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPut("{detailId}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ServiceResponse<GetPolicyDetailDto>>> UpdateStatus(int detailId, UpdateStatusDto updatePolicyStatusDto)
        {
            ServiceResponse<GetPolicyDetailDto> res = new ServiceResponse<GetPolicyDetailDto>();
            res = await _policydetailservice.UpdatePolicyDetailStatus(detailId, updatePolicyStatusDto);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);


        }
    }
}
