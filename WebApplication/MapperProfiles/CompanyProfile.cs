using AutoMapper;
using Domain.Entity;
using WebApplication.Models;

namespace WebApplication.MapperProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyViewModel, Company>();
            CreateMap<Company, CompanyViewModel>();
        }
    }
}