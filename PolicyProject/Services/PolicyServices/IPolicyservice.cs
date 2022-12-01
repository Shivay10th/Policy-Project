using PolicyProject.Dtos.Policydto;
using PolicyProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolicyProject.Services.PolicyServices
{
    public interface IPolicyservice
    {
        Task<ServiceResponse<ICollection<PolicyDto>>> GetAllPolicies();
        Task<ServiceResponse<PolicyDto>> GetPolicy(int id);
        Task<ServiceResponse<ICollection<PolicyDto>>> GetPolicy(string PolicyName);
        Task<ServiceResponse<ICollection<PolicyDto>>> DeletePolicy(int id);
        Task<ServiceResponse<PolicyDto>> UpdatePolicy(PolicyDto policy);
        Task<ServiceResponse<PolicyDto>> AddPolicy(PolicyDto Policy);
    }
}
