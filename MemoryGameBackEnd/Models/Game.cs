using System.ComponentModel.DataAnnotations;

namespace MemoryGameBackEnd.Models;

public class Game
{
    public int Id { get; set; }
    public User? User { get; set; }
    [Required]
    public int? UserId { get; set; }

    [Required]
    [DataType(DataType.Duration)]
    public int? CompletionTime { get; set; }

    [DataType(DataType.Date)]
    public DateTime? Date { get; set; }
}