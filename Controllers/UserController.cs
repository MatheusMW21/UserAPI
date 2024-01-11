using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.DTOs;
using UsersAPI.Models;
using UsersAPI.Services;

namespace UsersAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private RegisterService _registerService;

    public UserController(RegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost]
    public async Task<IActionResult> UserRegister(CreateUserDTO dto)
    {
        await _registerService.Register(dto);
        return Ok("User registered");
    }
}
