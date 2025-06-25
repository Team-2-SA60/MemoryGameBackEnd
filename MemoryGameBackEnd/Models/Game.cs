using System.ComponentModel.DataAnnotations;

namespace MemoryGameBackEnd.Models;

public class Game
{
    public int Id { get; set; }
    [Required]
    public User? User { get; set; }
    public int UserId { get; set; }
    
    [DataType(DataType.Duration)]
    public int CompletionTime { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
}