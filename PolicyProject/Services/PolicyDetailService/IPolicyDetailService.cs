using PolicyProject.Dtos.PolicyDetailDto;
using PolicyProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolicyProject.Services.PolicyDetailService
{
    public interface IPolicyDetailService
    {
        Task<ServiceResponse<ICollection<GetPolicyDetailDto>>> GetAllPolicyDetails();
        Task<ServiceResponse<ICollection<GetPolicyDetailDto>>> GetAllPolicyDetailsOfAUser(int userId);
        Task<ServiceResponse<GetPolicyDetailDto>> RemovePolicyDetail(int userId, int detailId);
        Task<ServiceResponse<GetPolicyDetailDto>> UpdatePolicyDetailStatus(int detailId, UpdateStatusDto status);
        Task<ServiceResponse<GetPolicyDetailDto>> RequestPolicy(PostPolicyDetailDto Policy);
    }
}
