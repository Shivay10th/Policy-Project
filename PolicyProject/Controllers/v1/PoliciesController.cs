using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolicyProject.Data;
using PolicyProject.Dtos.Policydto;
using PolicyProject.Models;
using PolicyProject.Services.PolicyServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolicyProject.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class PoliciesController : ControllerBase
    {
        private readonly PolicyProjectContext _context;
        private readonly IPolicyservice _policyservice;
        private readonly ILogger<PoliciesController> _logger;

        public PoliciesController(PolicyProjectContext context, IPolicyservice policyservice, ILogger<PoliciesController> logger)
        {
            _context = context;
            _policyservice = policyservice;
            _logger = logger;
        }

        // GET: api/Policies
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicy()
        {
            ServiceResponse<ICollection<PolicyDto>> res = await _policyservice.GetAllPolicies();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        // GET: api/Policies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
            ServiceResponse<PolicyDto> res = await _policyservice.GetPolicy(id);
            if (res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
        [AllowAnonymous]
        [HttpGet("search/{name}")]
        public async Task<ActionResult> GetPolicy(string name)
        {
            ServiceResponse<ICollection<PolicyDto>> res = await _policyservice.GetPolicy(name);
            if (res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicy(int id, PolicyDto policy)
        {
            policy.PolicyType = null;
            ServiceResponse<PolicyDto> res = await _policyservice.UpdatePolicy(policy);
            if (res.Success)
            {

                return Ok(res);
            }
            return BadRequest(res);
        }


        [HttpPost]
        public async Task<IActionResult> PostPolicy(PolicyDto policy)
        {
            policy.PolicyType = null;
            ServiceResponse<PolicyDto> res = await _policyservice.AddPolicy(policy);
            _logger.LogInformation("New Policy Resgistered at {now}", DateTime.Now);

            return Ok(res);
        }

        // DELETE: api/Policies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            ServiceResponse<ICollection<PolicyDto>> res = await _policyservice.DeletePolicy(id);
            if (res.Success)
            {
                _logger.LogWarning("Policy with Id:{id} Deleted at {now} ", id, DateTime.Now);

                return Ok(res);
            }
            return BadRequest(res);
        }


    }
}
