using AutoMapper;
using PolicyProject.Dtos.PolicyType;
using PolicyProject.Models;

namespace PolicyProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PolicyType, PolicyTypeDto>();
            CreateMap<PolicyTypeDto, PolicyType>();
        }
    }
}
