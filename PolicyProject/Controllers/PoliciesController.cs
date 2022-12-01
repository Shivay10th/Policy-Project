using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolicyProject.Data;
using PolicyProject.Dtos.Policydto;
using PolicyProject.Models;
using PolicyProject.Services.PolicyServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class PoliciesController : ControllerBase
    {
        private readonly PolicyProjectContext _context;
        private readonly IPolicyservice _policyservice;

        public PoliciesController(PolicyProjectContext context, IPolicyservice policyservice)
        {
            _context = context;
            _policyservice = policyservice;
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

        // PUT: api/Policies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicy(int id, PolicyDto policy)
        {
            ServiceResponse<PolicyDto> res = await _policyservice.UpdatePolicy(policy);
            if (res.Success)
            {

                return Ok(res);
            }
            return BadRequest(res);
        }

        // POST: api/Policies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostPolicy(PolicyDto policy)
        {
            ServiceResponse<PolicyDto> res = await _policyservice.AddPolicy(policy);
            return Ok(res);
        }

        // DELETE: api/Policies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            ServiceResponse<ICollection<PolicyDto>> res = await _policyservice.DeletePolicy(id);
            if (res.Success)
            {

                return Ok(res);
            }
            return BadRequest(res);
        }

        private bool PolicyExists(int id)
        {
            return _context.Policy.Any(e => e.PolicyId == id);
        }
    }
}
