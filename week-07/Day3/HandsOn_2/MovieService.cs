using MovieCatalogApp.Models;
using MovieCatalogApp.Repository;

namespace MovieCatalogApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;

        public MovieService(IMovieRepository repo)
        {
            _repo = repo;
        }

        public List<Movie> GetMovies()
        {
            return _repo.GetAll();
        }

        public Movie GetMovie(int id)
        {
            return _repo.GetById(id);
        }

        public void CreateMovie(Movie movie)
        {
            _repo.Add(movie);
            _repo.Save();
        }

        public void EditMovie(Movie movie)
        {
            _repo.Update(movie);
            _repo.Save();
        }

        public void RemoveMovie(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}