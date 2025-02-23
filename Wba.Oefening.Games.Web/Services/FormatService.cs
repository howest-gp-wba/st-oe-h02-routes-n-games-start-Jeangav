using System.Text;
using Wba.Oefening.Games.Core.Entities;

namespace Wba.Oefening.Games.Web.Services
{
    public class FormatService : IFormatService
    {
        public string FormatGameInfo(Game game)
        {
            string content = $"<ul>" +
                $"<li>Id: {game?.Id ?? 0}</li>" +
                $"<li>Title:<a href='/games/{game.Id}'>{game?.Title ?? "<NoTitle>"}</a></li>" +
                $"<li>Developer: <a href='/developers/{game.Developer.Id}'>{game?.Developer?.Name ?? "<NoName>"}</a></li>" +
                $"<li>Rating: {game?.Rating ?? 0}</li>" +
                $"</ul";
            return content;
        }

        public string FormatGameInfo(IEnumerable<Game> games)
        {
            string content = "";
            foreach (Game game in games)
            {
                content += FormatGameInfo(game);
            }
            return content;
        }

        // private methods
        public string FormatDeveloperInfo(Developer developer)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul>");
            stringBuilder.Append($"<li>Name: {developer.Name}</li>");


            stringBuilder.Append("</ul>");
            return stringBuilder.ToString();
        }

        public string FormatDeveloperInfo(IEnumerable<Developer> developers)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Developer developer in developers)
            {
                stringBuilder.Append(FormatDeveloperInfo(developer));
            }


            return stringBuilder.ToString();
        }
    }
}
