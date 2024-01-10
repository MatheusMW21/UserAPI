using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.DTOs;
using UsersAPI.Models;

namespace UsersAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public UserController(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> UserRegister(CreateUserDTO dto)
    {
        if(dto.Email != dto.EmailConfirmed)
        {
            return BadRequest(new { Message = "Email and ConfirmEmail do not match." });
        }

        User user = _mapper.Map<User>(dto);
        user.Email = dto.Email;

        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        if (result.Succeeded)
        {
            return Ok("User registered");
        }else
        {
            var errors = result.Errors.Select(e => e.Description).ToList();
            return BadRequest(new { Message = "Failed to create user",  Errors = errors });
        }
    }
}
