using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PolicyProject.Data;
using PolicyProject.Dtos.Policydto;
using PolicyProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyProject.Services.PolicyServices
{
    public class PolicyService : IPolicyservice
    {
        private readonly PolicyProjectContext _context;
        private readonly IMapper _mapper;
        public PolicyService(PolicyProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<PolicyDto>> AddPolicy(PolicyDto policy)
        {
            ServiceResponse<PolicyDto> res = new ServiceResponse<PolicyDto>();
            Policy pl = _mapper.Map<Policy>(policy);
            await _context.Policy.AddAsync(pl);
            await _context.SaveChangesAsync();
            res.Data = _mapper.Map<PolicyDto>(pl);
            return res;
        }

        public async Task<ServiceResponse<ICollection<PolicyDto>>> DeletePolicy(int id)
        {
            ServiceResponse<ICollection<PolicyDto>> res = new ServiceResponse<ICollection<PolicyDto>>();
            try
            {
                Policy policy = await _context.Policy.FirstOrDefaultAsync(pl => pl.PolicyId == id);
                if (policy != null)
                {
                    _context.Policy.Remove(policy);
                    await _context.SaveChangesAsync();
                    res.Data = (_context.Policy.Select(pl => _mapper.Map<PolicyDto>(pl))).ToList();
                }
                else
                {
                    res.Success = false;
                    res.Message = "Policy not found";
                }


            }
            catch (System.Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;


            }

            return res;

        }

        public async Task<ServiceResponse<ICollection<PolicyDto>>> GetAllPolicies()
        {
            ServiceResponse<ICollection<PolicyDto>> res = new ServiceResponse<ICollection<PolicyDto>>();
            List<Policy> policyList = await _context.Policy.Include(pt => pt.PolicyType).ToListAsync();
            res.Data = (policyList.Select(pl => _mapper.Map<PolicyDto>(pl))).ToList();
            return res;
        }

        public async Task<ServiceResponse<PolicyDto>> GetPolicy(int id)
        {
            ServiceResponse<PolicyDto> res = new ServiceResponse<PolicyDto>();
            Policy p = await _context.Policy.Include(p => p.PolicyType).FirstOrDefaultAsync(p => p.PolicyId == id);
            if (p != null)
            {
                res.Data = _mapper.Map<PolicyDto>(p);

            }
            else
            {
                res.Success = false;
                res.Message = "Policy does not exist";
            }
            return res;
        }

        public async Task<ServiceResponse<ICollection<PolicyDto>>> GetPolicy(string PolicyName)
        {
            ServiceResponse<ICollection<PolicyDto>> res = new ServiceResponse<ICollection<PolicyDto>>();
            List<Policy> policyList = await _context.Policy.Include(p => p.PolicyType).Where(p => p.PolicyName.ToLower().Contains(PolicyName.Trim().ToLower())).ToListAsync();
            if (policyList != null)
            {
                res.Data = (policyList.Select(pl => _mapper.Map<PolicyDto>(pl))).ToList();

            }
            else
            {
                res.Success = false;
                res.Message = "Policy does not exist";
            }
            return res;
        }

        public async Task<ServiceResponse<PolicyDto>> UpdatePolicy(PolicyDto policy)
        {
            ServiceResponse<PolicyDto> res = new ServiceResponse<PolicyDto>();
            try
            {
                Policy p = await _context.Policy.FirstOrDefaultAsync(p => p.PolicyId == policy.PolicyId);
                if (p != null)
                {
                    p.PolicyName = policy.PolicyName;
                    p.PolicyTypeId = policy.PolicyTypeId;
                    p.StartDate = policy.StartDate;
                    p.Duration = policy.Duration;
                    p.InitialDeposite = policy.InitialDeposite;
                    p.TermsPerYear = policy.TermsPerYear;
                    p.TermsAmount = policy.TermsAmount;
                    await _context.SaveChangesAsync();
                    res.Data = _mapper.Map<PolicyDto>(p);
                }
                else
                {
                    throw new System.Exception("Policy does not exist");
                }

            }
            catch (System.Exception ex)
            {

                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }
    }
}
