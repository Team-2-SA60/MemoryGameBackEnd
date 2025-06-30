using System.ComponentModel.DataAnnotations;

namespace MemoryGameBackEnd.Models;

public class Advertisement
{
    public int Id { get; set; }
    [Required]
    public byte[]? Image { get; set; }
}