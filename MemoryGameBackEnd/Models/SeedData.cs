using MemoryGameBackEnd.data;
using Microsoft.EntityFrameworkCore;

namespace MemoryGameBackEnd.Models;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MemoryGameBackEndContext(
                   serviceProvider.GetRequiredService<DbContextOptions<MemoryGameBackEndContext>>()))
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new List<User>
            {
                new User { Username = "Adrian", Password = "a", IsPremium = true },
                new User { Username = "GY", Password = "a", IsPremium = false },
                new User { Username = "CY", Password = "a", IsPremium = true },
                new User { Username = "KS", Password = "a", IsPremium = false },
                new User { Username = "Freeuser", Password = "free", IsPremium = true },
                new User { Username = "Paiduser", Password = "paid", IsPremium = false },
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var now = DateTime.UtcNow;
            var games = new List<Game>
            {
                // Adrian
                new Game { UserId = users[0].Id, CompletionTime = 75, Date = now.AddDays(-4) },
                new Game { UserId = users[0].Id, CompletionTime = 65, Date = now.AddDays(-2) },
                new Game { UserId = users[0].Id, CompletionTime = 80, Date = now.AddHours(-10) },

                // GY
                new Game { UserId = users[1].Id, CompletionTime = 120, Date = now.AddDays(-3) },
                new Game { UserId = users[1].Id, CompletionTime = 95, Date = now.AddDays(-1) },

                // CY
                new Game { UserId = users[2].Id, CompletionTime = 70, Date = now.AddDays(-7) },
                new Game { UserId = users[2].Id, CompletionTime = 60, Date = now.AddDays(-5) },
                new Game { UserId = users[2].Id, CompletionTime = 50, Date = now.AddHours(-4) },

                // KS
                new Game { UserId = users[3].Id, CompletionTime = 110, Date = now.AddDays(-6) },
                new Game { UserId = users[3].Id, CompletionTime = 130, Date = now.AddHours(-2) }
            };

            context.AddRange(games);
            context.SaveChanges();
        }
    }
}