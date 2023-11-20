using GestMovie.Mvc.Models.Data.Entities;

namespace GestMovie.Mvc.Models.Data.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Get();
        IEnumerable<Movie> GetOne(int idMovie);
        Movie Insert(Movie movie);

        int Delete(int idMovie);
    }
}
