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

            CreateMap<UserCompany, UserPreviewViewModel>()
                .ForMember(o => o.Email, opts => opts.MapFrom(src => src.User.Email))
                .ForMember(o => o.Id, opts => opts.MapFrom(src => src.User.Id))
                .ForMember(o => o.Name, opts => opts.MapFrom(src => src.User.Name));
        }
    }
}