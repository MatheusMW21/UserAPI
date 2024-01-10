using AutoMapper;
using UsersAPI.Data.DTOs;
using UsersAPI.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDTO, User>()
            .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => false)); // Ou qualquer valor padrão desejado
    }
}
