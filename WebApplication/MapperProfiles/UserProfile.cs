using AutoMapper;
using Domain.Entity;
using WebApplication.Models;

namespace WebApplication.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateAccountViewModel, User>()
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.Email));
        }
    }
}