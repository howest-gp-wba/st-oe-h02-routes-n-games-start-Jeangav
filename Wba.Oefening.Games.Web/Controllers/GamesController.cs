using Microsoft.AspNetCore.Mvc;
using System.Text;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Core.Repositories;
using Wba.Oefening.Games.Web.Services;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameRepository _gameRepository;
        private readonly FormatService _formatService;

        public GamesController()
        {
            _gameRepository = new GameRepository();
            _formatService = new FormatService();
        }

        /*
        private string FormatGameInfo(Game game)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul>");
            stringBuilder.Append($"<li><a href = '/games/{game.Id}'> Name: {game.Title} </a></li>");
            stringBuilder.Append($"<li><a href = '/developers/{game.Developer.Id}'>Developer: {game.Developer.Name}</a></li>");
            stringBuilder.Append($"<li>Rating: {game.Rating}</li>");
            stringBuilder.Append("</ul>");
            return stringBuilder.ToString();
        }

        private string FormatGameInfo(IEnumerable<Game> games)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Game game in games) 
            {
                stringBuilder.Append(FormatGameInfo(game));
            }


            return stringBuilder.ToString();
        }
        */


        /**
         * show the info of one game
         */
        public IActionResult ShowGame(int id)
        {
            //get the game using the id(FirstOrDefault)
            var game = _gameRepository
                .GetGames()
                .FirstOrDefault(g => g.Id == id);
            //check if null
            if (game == null)
            {
                return NotFound();
            }
            //return content => FormatGameInfo(Game)
            var title = game.Title;
            return Content(_formatService.FormatGameInfo(game), "text/html");
        }

        public IActionResult Index()
        {
            //get the games
            var games = _gameRepository.GetGames();
            //pass to the Format method
            //and return to the client
            return Content(_formatService.FormatGameInfo(games), "text/html");
        }
    }
}
