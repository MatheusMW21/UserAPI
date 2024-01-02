using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.DTOs;

namespace UsersAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult UserRegister(CreateUserDTO dto)
    {
        throw new NotImplementedException();
    }
}
