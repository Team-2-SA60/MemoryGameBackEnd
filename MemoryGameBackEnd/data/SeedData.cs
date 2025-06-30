using MemoryGameBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryGameBackEnd.data;

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
                new User { Username = "Adrian", Password = "a", IsPremium = true, AvatarImage = File.ReadAllBytes("SeedImages/dog.png")},
                new User { Username = "GY", Password = "a", IsPremium = false, AvatarImage = File.ReadAllBytes("SeedImages/chikawa.jpg") },
                new User { Username = "CY", Password = "a", IsPremium = true, AvatarImage = File.ReadAllBytes("SeedImages/gopher.jpg") },
                new User { Username = "KS", Password = "a", IsPremium = false, AvatarImage = File.ReadAllBytes("SeedImages/cat.jpg") },
                new User { Username = "Freeuser", Password = "free", IsPremium = true, AvatarImage = File.ReadAllBytes("SeedImages/dog.png") },
                new User { Username = "Paiduser", Password = "paid", IsPremium = false, AvatarImage = File.ReadAllBytes("SeedImages/kiwi.jpg") },
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var now = DateTime.UtcNow;
            var games = new List<Game>
            {
                // Adrian
                new Game { UserId = users[0].Id, CompletionTime = 75, Date = now.AddDays(-2) },
                new Game { UserId = users[0].Id, CompletionTime = 65, Date = now.AddDays(-8) },
                new Game { UserId = users[0].Id, CompletionTime = 80, Date = now.AddDays(-32) },

                // GY
                new Game { UserId = users[1].Id, CompletionTime = 120, Date = now.AddDays(-3) },
                new Game { UserId = users[1].Id, CompletionTime = 95, Date = now.AddDays(-35) },

                // CY
                new Game { UserId = users[2].Id, CompletionTime = 70, Date = now.AddDays(-5) },
                new Game { UserId = users[2].Id, CompletionTime = 60, Date = now.AddDays(-14) },
                new Game { UserId = users[2].Id, CompletionTime = 50, Date = now.AddHours(-31) },

                // KS
                new Game { UserId = users[3].Id, CompletionTime = 110, Date = now.AddDays(-6) },
                new Game { UserId = users[3].Id, CompletionTime = 130, Date = now.AddHours(-15) }
            };

            context.AddRange(games);
            context.SaveChanges();

            var adverts = new List<Advertisement>
            {
                new Advertisement { Image = File.ReadAllBytes("SeedImages/advert1.png") }
            };
            
            context.AddRange(adverts);
            context.SaveChanges();
        }
    }
}