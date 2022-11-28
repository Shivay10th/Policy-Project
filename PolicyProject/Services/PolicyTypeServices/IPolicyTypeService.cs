using PolicyProject.Dtos.PolicyType;
using PolicyProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolicyProject.Services.PolicyTypeServices
{
    public interface IPolicyTypeService
    {
        Task<ServiceResponse<List<PolicyTypeDto>>> GetAllPolicyType();
        Task<ServiceResponse<PolicyTypeDto>> GetPolicyTypeById(int id);
        Task<ServiceResponse<List<PolicyTypeDto>>> AddPolicyType(PolicyTypeDto policyType);
        Task<ServiceResponse<PolicyTypeDto>> UpdatePolicyType(PolicyTypeDto updateCharacter);
        Task<ServiceResponse<List<PolicyTypeDto>>> DeletePolicyType(int id);
    }
}
