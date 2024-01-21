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

        [HttpGet]
        public IActionResult MovieNightForm()
        {
            return View("MovieNightSearch");
        }

        [HttpPost]
        public async Task<IActionResult> MovieSearchResults(string Title)
        {
           var movieTitle = await _movieService.GetMovieTitle(Title);
           var movieReleased = await _movieService.GetMovieReleased(Title);
           var movieActors = await _movieService.GetMovieActors(Title);
           var movieDirector = await _movieService.GetMovieDirector(Title);
           var moviePoster = await _movieService.GetMoviePoster(Title);

           var model = new Movie();
           model.Title = movieTitle;
           model.Released = movieReleased;
           model.Actors = movieActors;
           model.Director = movieDirector;
           model.Poster = moviePoster;

           if (ModelState.IsValid)
           {
             return View(model);
           }
           return View("Error");
            
        }

        [HttpPost]
        public async Task<IActionResult> MovieNight(string Title1, string Title2, string Title3)
        {
            var movieTitle1 = await _movieService.GetMovieTitle(Title1);
            var movieReleased1 = await _movieService.GetMovieReleased(Title1);
            var movieActors1 = await _movieService.GetMovieActors(Title1);
            var movieDirector1 = await _movieService.GetMovieDirector(Title1);
            var moviePoster1 = await _movieService.GetMoviePoster(Title1);

            var model1 = new Movie();
            model1.Title = movieTitle1;
            model1.Released = movieReleased1;
            model1.Actors = movieActors1;
            model1.Director = movieDirector1;
            model1.Poster = moviePoster1;

            var movieTitle2 = await _movieService.GetMovieTitle(Title2);
            var movieReleased2 = await _movieService.GetMovieReleased(Title2);
            var movieActors2 = await _movieService.GetMovieActors(Title2);
            var movieDirector2 = await _movieService.GetMovieDirector(Title2);
            var moviePoster2 = await _movieService.GetMoviePoster(Title2);

            var model2 = new Movie();
            model2.Title = movieTitle2;
            model2.Released = movieReleased2;
            model2.Actors = movieActors2;
            model2.Director = movieDirector2;
            model2.Poster = moviePoster2;

            var movieTitle3 = await _movieService.GetMovieTitle(Title3);
            var movieReleased3 = await _movieService.GetMovieReleased(Title3);
            var movieActors3 = await _movieService.GetMovieActors(Title3);
            var movieDirector3 = await _movieService.GetMovieDirector(Title3);
            var moviePoster3 = await _movieService.GetMoviePoster(Title3);

            var model3 = new Movie();
            model3.Title = movieTitle3;
            model3.Released = movieReleased3;
            model3.Actors = movieActors3;
            model3.Director = movieDirector3;
            model3.Poster = moviePoster3;

            List<Movie> movies = new List<Movie>();
            movies.Add(model1);
            movies.Add(model2);
            movies.Add(model3);

            if (ModelState.IsValid)
            {
                return View("MovieNight", movies);
            }
            return View("Error");

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