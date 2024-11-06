using AutoMapper;
using Identity.Application.Auth.Register.Commands;
using Identity.Application.Shared.Dtos;
using Identity.Domain.Entities;

namespace Identity.Application.Auth;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<ApplicationUser, UserDto>();
        CreateMap<RegisterCommand, ApplicationUser>();
    }
}
