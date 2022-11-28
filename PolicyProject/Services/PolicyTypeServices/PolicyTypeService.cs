using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PolicyProject.Data;
using PolicyProject.Dtos.PolicyType;
using PolicyProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyProject.Services.PolicyTypeServices
{
    public class PolicyTypeService : IPolicyTypeService
    {
        private readonly PolicyProjectContext _context;
        private readonly IMapper _mapper;

        public PolicyTypeService(PolicyProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<PolicyTypeDto>>> AddPolicyType(PolicyTypeDto newPolicyType)
        {
            ServiceResponse<List<PolicyTypeDto>> res = new ServiceResponse<List<PolicyTypeDto>>();
            PolicyType pt = _mapper.Map<PolicyType>(newPolicyType);
            await _context.PolicyType.AddAsync(pt);
            await _context.SaveChangesAsync();
            res.Data = (_context.PolicyType.Select(p => _mapper.Map<PolicyTypeDto>(p))).ToList();
            return res;

        }

        public async Task<ServiceResponse<List<PolicyTypeDto>>> DeletePolicyType(int id)
        {
            ServiceResponse<List<PolicyTypeDto>> res = new ServiceResponse<List<PolicyTypeDto>>();
            try
            {
                PolicyType policyType = await _context.PolicyType.FirstOrDefaultAsync(pt => pt.Id == id);
                if (policyType != null)
                {
                    _context.PolicyType.Remove(policyType);
                    await _context.SaveChangesAsync();
                    res.Data = (_context.PolicyType.Select(pt => _mapper.Map<PolicyTypeDto>(pt))).ToList();
                }
                else
                {
                    res.Success = false;
                    res.Message = "Policy type not found";
                }


            }
            catch (System.Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;


            }

            return res;

        }

        public async Task<ServiceResponse<List<PolicyTypeDto>>> GetAllPolicyType()
        {
            ServiceResponse<List<PolicyTypeDto>> res = new ServiceResponse<List<PolicyTypeDto>>();
            List<PolicyType> policyTypeList = await _context.PolicyType.ToListAsync();
            res.Data = (policyTypeList.Select(pt => _mapper.Map<PolicyTypeDto>(pt))).ToList();
            return res;

        }

        public async Task<ServiceResponse<PolicyTypeDto>> GetPolicyTypeById(int id)
        {
            ServiceResponse<PolicyTypeDto> res = new ServiceResponse<PolicyTypeDto>();
            PolicyType policyType = await _context.PolicyType.FirstOrDefaultAsync(pt => pt.Id == id);
            if (policyType == null)
            {
                res.Success = false;
                res.Message = "Policy Type Not Present In DB!!";
            }
            else
            {
                res.Data = _mapper.Map<PolicyTypeDto>(policyType);
            }
            return res;
        }

        public async Task<ServiceResponse<PolicyTypeDto>> UpdatePolicyType(PolicyTypeDto updatePolicyType)
        {
            ServiceResponse<PolicyTypeDto> res = new ServiceResponse<PolicyTypeDto>();
            try
            {
                PolicyType policyType = await _context.PolicyType.FirstOrDefaultAsync(pt => pt.Id == updatePolicyType.Id);
                if (policyType != null)
                {
                    policyType.Name = updatePolicyType.Name;
                    await _context.SaveChangesAsync();
                    res.Data = _mapper.Map<PolicyTypeDto>(policyType);
                }
                else
                {
                    res.Success = false;
                    res.Message = "Policy type not found";
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
