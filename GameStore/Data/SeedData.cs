using GameStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>());

            if (context == null || context.Games == null)
            {
                throw new NullReferenceException(
                    "Null ApplicationDbContext or Game DbSet");
            }

            if (context.Games.Any())
            {
                return;
            }

            context.Games.AddRange(
                new Game
                (
                    Guid.NewGuid(),
                    "EA SPORTS FC 2024",
                    "SPORTS",
                    89.99m,
                    new DateOnly(2023, 9, 22),
                    DateTime.Now,
                    "A fantastic RPG adventure.",
                    "Electronic Arts"
                ),
                new Game
                (
                    Guid.NewGuid(),
                    "League of Legends",
                    "MOBA",
                    0.00m,
                    new DateOnly(2009, 10, 27),
                    DateTime.Now,
                    "A fantastic RPG adventure.",
                    "Riot Games"
                ),
                new Game
                (
                    Guid.NewGuid(),
                    "Bloons TD 6",
                    "STRATEGY",
                    13.79m,
                    new DateOnly(2018, 12, 18),
                    DateTime.Now,
                    "A fantastic RPG adventure.",
                    "Ninja Kiwi"
                ),
                new Game
                (
                    Guid.NewGuid(),
                    "Counter-Strike 2",
                    "FPS",
                    0.00m,
                    new DateOnly(2012, 8, 21),
                    DateTime.Now,
                    "A fantastic RPG adventure.",
                    "Valve"
                ),
                new Game
                (
                    Guid.NewGuid(),
                    "Super Smash Bros. Ultimate",
                    "FIGHTER",
                    59.99m,
                    new DateOnly(2018, 12, 7),
                    DateTime.Now,
                    "A fantastic RPG adventure.",
                    "Masahiro Sakurai, Sora Ltd., BANDAI NAMCO Studios, Nintendo Entertainment Planning & Development"
                )
            );

            context.SaveChanges();
        }
    }
}