using Microsoft.AspNetCore.Mvc;
using Movie_Lab.Models;
using Movie_Lab.Services;
using System.Diagnostics;

namespace Movie_Lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieService _movieService;

        public HomeController(MovieService movieService, ILogger<HomeController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieSearchForm()
        {
            return View("MovieSearch");
        }

        [HttpPost]
        public async Task<IActionResult> MovieSearchResults(string Title)
        {
           var movieTitle = await _movieService.GetMovieTitle(Title);
           var model = new MovieViewModel();
           model.Title = movieTitle;
           return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}