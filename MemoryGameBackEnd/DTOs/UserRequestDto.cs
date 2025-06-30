using Microsoft.Build.Framework;

namespace MemoryGameBackEnd.DTOs;

public class UserRequestDto
{
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
}