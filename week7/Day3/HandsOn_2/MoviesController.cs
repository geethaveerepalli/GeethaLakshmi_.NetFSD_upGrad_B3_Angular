using Microsoft.AspNetCore.Mvc;
using MovieCatalogApp.Models;
using MovieCatalogApp.Services;

namespace MovieCatalogApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetMovies());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _service.CreateMovie(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_service.GetMovie(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _service.EditMovie(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_service.GetMovie(id));
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.RemoveMovie(id);
            return RedirectToAction("Index");
        }
    }
}