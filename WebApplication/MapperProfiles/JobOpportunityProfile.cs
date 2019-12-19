using AutoMapper;
using Domain.Entity;
using WebApplication.Models;

namespace WebApplication.MapperProfiles
{
    public class JobOpportunityProfile : Profile
    {
        public JobOpportunityProfile()
        {
            CreateMap<JobOpportunityViewModel, JobOpportunity>();
            CreateMap<JobOpportunity, JobOpportunityViewModel>();
        }
    }
}