using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PolicyProject.Data;
using PolicyProject.Dtos.PolicyDetailDto;
using PolicyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyProject.Services.PolicyDetailService
{
    public class PolicyDetailService : IPolicyDetailService
    {
        private readonly PolicyProjectContext _context;
        private readonly IMapper _mapper;

        public PolicyDetailService(PolicyProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ICollection<GetPolicyDetailDto>>> GetAllPolicyDetails()
        {
            ServiceResponse<ICollection<GetPolicyDetailDto>> res = new ServiceResponse<ICollection<GetPolicyDetailDto>>();
            List<PolicyDetail> dataList = await (_context.PolicyDetails.Include(pd => pd.Policy).Include(pd => pd.User)).ToListAsync();
            res.Data = dataList.Select(pd => _mapper.Map<GetPolicyDetailDto>(pd)).ToList();
            return res;
        }

        public async Task<ServiceResponse<ICollection<GetPolicyDetailDto>>> GetAllPolicyDetailsOfAUser(int id)
        {
            ServiceResponse<ICollection<GetPolicyDetailDto>> res = new ServiceResponse<ICollection<GetPolicyDetailDto>>();
            List<PolicyDetail> dataList = await _context.PolicyDetails.Where(p => p.UserId == id).Include(p => p.Policy).ToListAsync();
            res.Data = dataList.Select(pd => _mapper.Map<GetPolicyDetailDto>(pd)).ToList();
            return res;
        }

        public async Task<ServiceResponse<GetPolicyDetailDto>> RemovePolicyDetail(int userId, int detailId)
        {
            ServiceResponse<GetPolicyDetailDto> res = new ServiceResponse<GetPolicyDetailDto>();
            try
            {
                PolicyDetail policyDetail = await _context.PolicyDetails.FirstOrDefaultAsync(pd => pd.UserId == userId && pd.PolicyDetailId == detailId);

                if (policyDetail != null)
                {
                    _context.PolicyDetails.Remove(policyDetail);
                    await _context.SaveChangesAsync();
                    res.Data = _mapper.Map<GetPolicyDetailDto>(policyDetail);
                }
                else
                    throw new Exception("Something went wrong while removing data!!");
            }
            catch (System.Exception ex)
            {

                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<ServiceResponse<GetPolicyDetailDto>> RequestPolicy(PostPolicyDetailDto policyDetailDto)
        {
            ServiceResponse<GetPolicyDetailDto> res = new ServiceResponse<GetPolicyDetailDto>();
            try
            {
                PolicyDetail policyDetail = _mapper.Map<PolicyDetail>(policyDetailDto);
                await _context.PolicyDetails.AddAsync(policyDetail);
                await _context.SaveChangesAsync();
                res.Data = _mapper.Map<GetPolicyDetailDto>(policyDetail);
            }
            catch (System.Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;

        }

        public async Task<ServiceResponse<GetPolicyDetailDto>> UpdatePolicyDetailStatus(int detailId, UpdateStatusDto status)
        {
            ServiceResponse<GetPolicyDetailDto> res = new ServiceResponse<GetPolicyDetailDto>();
            try
            {
                PolicyDetail policyDetail = await _context.PolicyDetails.FirstOrDefaultAsync(pd => pd.PolicyDetailId == detailId);
                policyDetail.Status = status.Status;
                await _context.SaveChangesAsync();
                res.Data = _mapper.Map<GetPolicyDetailDto>(policyDetail);

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
