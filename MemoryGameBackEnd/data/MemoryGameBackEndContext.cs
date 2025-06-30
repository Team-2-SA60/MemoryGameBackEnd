using MemoryGameBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryGameBackEnd.data;

public class MemoryGameBackEndContext : DbContext
{
    public MemoryGameBackEndContext(DbContextOptions<MemoryGameBackEndContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Game> Games { get; set; } = null!;
    public DbSet<Advertisement> Advertisements { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .HasOne(game => game.User)
            .WithMany()
            .HasForeignKey(game => game.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}