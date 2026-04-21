using MovieCatalogApp.Models;

namespace MovieCatalogApp.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        void Save();
    }
}