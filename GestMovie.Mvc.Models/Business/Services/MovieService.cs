using IDalRepository = GestMovie.Mvc.Models.Data.Repositories.IMovieRepository;
using DalService = GestMovie.Mvc.Models.Data.Services.MovieService;

using GestMovie.Mvc.Models.Business.Entities;
using GestMovie.Mvc.Models.Business.Repositories;
using GestMovie.Mvc.Models.Business.Mappers;
using MovieFromDal = GestMovie.Mvc.Models.Data.Entities;

namespace GestMovie.Mvc.Models.Business.Services
{
    public class MovieService : IMovieRepository
    {
        private readonly IDalRepository _repository;

        public MovieService(IDalRepository repository)
        {
            _repository = repository;
        }

        public int Delete(int idMovie)
        {
            return _repository.Delete(idMovie);
        }

        public IEnumerable<Movie> Get()
        {
            return _repository.Get().Select(m => m.ToBll());
        }

        public Movie GetOne(int idMovie)
        {
            return _repository.GetOne(idMovie).Select(m => m.ToBll()).First();
        }

        public Movie Insert(Movie movie)
        {
            return _repository.Insert(movie.ToDal()).ToBll();
        }

        public bool Update(MovieFromDal.Movie movie)
        {
            return _repository.Update(movie);
        }
    }
}
