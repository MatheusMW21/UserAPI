using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersAPI.Data.DTOs;
using UsersAPI.Models;

namespace UsersAPI.Services
{
    public class RegisterService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;

        public RegisterService(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task Register(CreateUserDTO dto)
        {
            if (dto.Email != dto.EmailConfirmed)
            {
                throw new ArgumentException("Email and ConfirmEmail do not match.");
            }

            User user = _mapper.Map<User>(dto);
            user.Email = dto.Email;

            IdentityResult resultado = await _userManager.CreateAsync(user, dto.Password);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }

        }
    }
}