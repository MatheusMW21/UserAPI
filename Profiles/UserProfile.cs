using AutoMapper;
using UsersAPI.Data.DTOs;
using UsersAPI.Models;

namespace UsersAPI.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDTO, User>();
    }
}
