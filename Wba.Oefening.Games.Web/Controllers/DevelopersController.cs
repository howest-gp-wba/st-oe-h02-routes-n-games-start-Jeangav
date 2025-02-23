using Microsoft.AspNetCore.Mvc;
using System.Text;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Core.Repositories;
using Wba.Oefening.Games.Web.Services;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class DevelopersController : Controller
    {

        private readonly DeveloperRepository _developerRepository;
        private readonly FormatService _formatService;

        public DevelopersController()
        {
            _developerRepository = new DeveloperRepository();
            _formatService = new FormatService();
        }
        public IActionResult Index()
        {
            string content = "<h4>Developers</h4>";
            content += _formatService.FormatDeveloperInfo(_developerRepository.GetDevelopers());
            return Content(content, "text/html");
        }

        public IActionResult ShowDeveloper(int id)
        {
            var developer = _developerRepository.GetDevelopers()
                .FirstOrDefault(g => g.Id == id);
            // check for null => 404
            if (developer == null)
            {
                return NotFound();
            }
            //return content => FormatDeveloperInfo(Developer)
            string content = "<h4>Developer info</h4>";
            content += _formatService.FormatDeveloperInfo(developer);
            return Content(content, "text/html");
        }

        
    }
}
