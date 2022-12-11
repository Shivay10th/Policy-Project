using AutoMapper;
using PolicyProject.Dtos.PolicyDetailDto;
using PolicyProject.Dtos.Policydto;
using PolicyProject.Dtos.PolicyTypedto;
using PolicyProject.Dtos.User;
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
            //Policy Detail 
            CreateMap<PolicyDetail, GetPolicyDetailDto>();
            CreateMap<PostPolicyDetailDto, PolicyDetail>();
            //User Dto
            CreateMap<User, GetUserDto>();
        }
    }
}
