using GestMovie.Mvc.Models.Data.Entities;
using GestMovie.Mvc.Models.Data.Mappers;
using GestMovie.Mvc.Models.Data.Repositories;
using System.Data.Common;
using System.Data.SqlClient;
using Tools.Ado;

namespace GestMovie.Mvc.Models.Data.Services
{
    public class MovieService : IMovieRepository
    {
        private readonly DbConnection _connection;

        public MovieService(DbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Movie> Get()
        {
            _connection.Open();
            return _connection.ExecuteReader("SELECT Id, Nom, Annee, Realisateur FROM Movie;", r => r.ToMovie(), null);
        }

        public Movie Insert(Movie movie)
        {
            //Logique de connexion à la source de données (Js, Object, Db, ...)           
            _connection.Open();
            movie.Id = (int)_connection.ExecuteScalar("INSERT INTO Movie (Nom, Annee, Realisateur) OUTPUT inserted.Id VALUES (@Nom, @Annee, @Realisateur)", new { movie.Nom, movie.Annee, movie.Realisateur })!;
            return movie;
        }
    }
}
