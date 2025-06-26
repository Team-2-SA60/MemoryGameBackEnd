namespace MemoryGameBackEnd.Models;

public class UserDTO
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public bool? IsPremium { get; set; }
    public byte[]? AvatarImage { get; set; }

    public UserDTO(User user)
    {
        Id = user.Id;
        Username = user.Username;
        IsPremium = user.IsPremium;
        AvatarImage = user.AvatarImage;
    }
}