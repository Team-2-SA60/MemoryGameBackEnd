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

    // Get the top 10 games (ordered by least completion times)
    [HttpGet]
    public ActionResult<List<Game>> FindTopGames()
    {
        return _context.Games
            .FromSql($"SELECT * FROM Games g ORDER BY g.CompletionTime ASC LIMIT 10")
            .Include(g => g.User)
            .ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Game> FindGame(int id)
    {
        var game = _context.Games
            .Include(g => g.User)
            .FirstOrDefault(g => g.Id == id);

        if (game == null) return NotFound();

        return game;
    }

    // Post request to add newly completed games
    [HttpPost]
    public ActionResult<Game> AddGame(Game game)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _context.Games.Add(game);
        _context.SaveChanges();

        return CreatedAtAction(nameof(FindGame), new { id = game.Id }, game);
    }
}