using AutoMapper;
using PolicyProject.Dtos.Policydto;
using PolicyProject.Dtos.PolicyTypedto;
using PolicyProject.Models;

namespace PolicyProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Policy type profile
            CreateMap<PolicyType, PolicyTypeDto>();
            CreateMap<PolicyTypeDto, PolicyType>();

            //Policy Profile
            CreateMap<Policy, PolicyDto>();
            CreateMap<PolicyDto, Policy>();
        }
    }
}
