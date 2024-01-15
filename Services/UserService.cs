using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersAPI.Data.DTOs;
using UsersAPI.Models;

namespace UsersAPI.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public UserService(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Register(CreateUserDTO dto)
        {
            if (dto.Email != dto.EmailConfirmed)
            {
                throw new ArgumentException("Email and ConfirmEmail do not match.");
            }

            User user = _mapper.Map<User>(dto);
            user.Email = dto.Email;

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }

        }

        public async Task<string> Login(LoginUserDTO dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Falha ao logar na conta");
            }

            var user = await _signInManager.UserManager.FindByNameAsync(dto.Username);

            if (user == null)
            {
                throw new ApplicationException("Usuário não encontrado após autenticação bem-sucedida.");
            }

            var token = _tokenService.GenerateToken(user);

            return token;
        }

    }
}