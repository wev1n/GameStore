using GameStore.Contracts;
using GameStore.Data;
using GameStore.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public IEnumerable<GameDTO> GetGames([FromQuery] string? name)
        {
            IEnumerable<Game> games = string.IsNullOrEmpty(name)
                ? _context.Games.ToList()
                : _context.Games.Where(x => x.Name == name);

            IEnumerable<GameDTO> gameDtos = games.Select(x => new GameDTO
            (
                id: x.Id,
                name: x.Name,
                genre: x.Genre,
                price: x.Price,
                releaseDate: x.ReleaseDate
            ));

            return gameDtos;
        }

        [HttpGet("{name}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GameDTO), 200)]
        [ProducesResponseType(404)]
        public ActionResult<GameDTO> GetGameByName(string name)
        {
            var game = _context.Games.FirstOrDefault(x => x.Name == name);

            if (game == null)
            {
                return NotFound();
            }

            var gameDto = new GameDTO
            (
                id: game.Id,
                name: game.Name,
                genre: game.Genre,
                price: game.Price,
                releaseDate: game.ReleaseDate
            );

            return gameDto;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GameDTO), 201)]
        [ProducesResponseType(400)]
        public ActionResult<GameDTO> CreateGame(CreateGameRequest request)
        {
            var game = new Game
            (
                id: request.Id,
                name: request.Name,
                genre: request.Genre,
                price: request.Price,
                releaseDate: request.ReleaseDate,
                createdAt: request.CreatedAt,
                description: request.Description,
                publisher: request.Publisher
            );

            _context.Games.Add(game);
            _context.SaveChanges();

            var gameDto = new GameDTO
            (
                id: game.Id,
                name: game.Name,
                genre: game.Genre,
                price: game.Price,
                releaseDate: game.ReleaseDate
            );

            return CreatedAtAction(
                nameof(CreateGame),
                new { id = game.Id },
                gameDto
            );
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult DeleteGame(Guid id)
        {
            var game = _context.Games.FirstOrDefault(x => x.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            _context.SaveChanges();

            return NoContent();
        }
    }
}