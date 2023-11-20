using GestMovie.Mvc.Models.Data.Entities;

namespace GestMovie.Mvc.Models.Data.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Get();
        Movie Insert(Movie movie);
    }
}
