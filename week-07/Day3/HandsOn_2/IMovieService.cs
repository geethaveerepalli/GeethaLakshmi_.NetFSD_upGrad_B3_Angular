using MovieCatalogApp.Models;

namespace MovieCatalogApp.Services
{
    public interface IMovieService
    {
        List<Movie> GetMovies();
        Movie GetMovie(int id);
        void CreateMovie(Movie movie);
        void EditMovie(Movie movie);
        void RemoveMovie(int id);
    }
}