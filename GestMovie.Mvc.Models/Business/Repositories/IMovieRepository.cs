using GestMovie.Mvc.Models.Business.Entities;

namespace GestMovie.Mvc.Models.Business.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Get();
        Movie GetOne(int idMovie);
        Movie Insert(Movie movie);
        int Delete(int idMovie);
    }
}
