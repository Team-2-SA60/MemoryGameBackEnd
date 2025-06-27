using MemoryGameBackEnd.data;
using MemoryGameBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemoryGameBackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly MemoryGameBackEndContext _context;

    public GameController(MemoryGameBackEndContext context)
    {
        _context = context;
    }

    // GET api/Game/top10?daysAgo=
    // Get the top 10 games (ordered by least completion times)
    [HttpGet]
    [Route("top10")]
    public ActionResult<List<GameDto>> FindTopGames(int daysAgo)
    {
        if (daysAgo == 0)
        {
            return GameDto.ConvertList(FindAllTimeTopGames());
        }
        
        var fromDate = DateTime.Today.AddDays(-daysAgo);

        var games = _context.Games
            .Where(g => g.Date >= fromDate)
            .OrderBy(g => g.CompletionTime)
            .Take(10)
            .Include(g => g.User)
            .ToList();

        return GameDto.ConvertList(games);
    }
    
    // POST api/Game/create
    // Create newly completed games
    [HttpPost]
    [Route("create")]
    public ActionResult<GameDto> CreateGame(Game game)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _context.Games.Add(game);
        _context.SaveChanges();

        return CreatedAtAction(nameof(FindGame), new { id = game.Id }, new GameDto(game));
    }
    
    // GET api/Game/find/{id}
    // For testing purpose. Find the first game by gameId
    [HttpGet]
    [Route("find/{id}")]
    public ActionResult<GameDto> FindGame(int id)
    {
        var game = _context.Games
            .Include(g => g.User)
            .FirstOrDefault(g => g.Id == id);

        if (game == null) return NotFound();

        return new GameDto(game);
    }

    private List<Game> FindAllTimeTopGames()
    {
        return _context.Games
            .Include(g => g.User)
            .OrderBy(g => g.CompletionTime)
            .Take(10)
            .ToList();
    }
}