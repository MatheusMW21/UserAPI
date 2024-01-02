using Microsoft.AspNetCore.Identity;

namespace UsersAPI.Models;

public class User : IdentityUser
{
    public DateTime Birthday { get; set; }
    public User(): base()
    {
        
    }
}
