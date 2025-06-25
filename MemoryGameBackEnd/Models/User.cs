using System.ComponentModel.DataAnnotations;

namespace MemoryGameBackEnd.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public bool IsPremium { get; set; } = false;
    
    public byte[]? AvatarImage { get; set; }
}