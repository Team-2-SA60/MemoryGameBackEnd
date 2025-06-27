namespace MemoryGameBackEnd.Models;

public class GameDto
{
    public int? GameId { get; set; }
    public int? UserId { get; set; }
    public string? Username { get; set; }
    public int? CompletionTime { get; set; }
    public byte[]? AvatarImage { get; set; }

    public GameDto(Game game)
    {
        GameId = game.Id;
        UserId = game.UserId;
        Username = game.User?.Username;
        CompletionTime = game.CompletionTime;
        AvatarImage = game.User?.AvatarImage;
    }

    public static List<GameDto> ConvertList(List<Game> games)
    {
        var gameDtos = new List<GameDto>();
        foreach (var game in games)
        {
            gameDtos.Add(new GameDto(game));
        }
        return gameDtos;
    }
}