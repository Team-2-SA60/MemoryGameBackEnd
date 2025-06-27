using Microsoft.Build.Framework;

namespace MemoryGameBackEnd.Models;

public class UserLoginBindingModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}