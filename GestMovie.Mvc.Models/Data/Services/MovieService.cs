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

        public IEnumerable<Movie> GetOne(int idMovie)
        {
            _connection.Open();
            return _connection.ExecuteReader("SELECT * FROM MOVIE WHERE Id = @id", r => r.ToMovie(), new { id = idMovie });
        }

        public Movie Insert(Movie movie)
        {
            //Logique de connexion à la source de données (Js, Object, Db, ...)           
            _connection.Open();
            movie.Id = (int)_connection.ExecuteScalar("INSERT INTO Movie (Nom, Annee, Realisateur) OUTPUT inserted.Id VALUES (@Nom, @Annee, @Realisateur)", new { movie.Nom, movie.Annee, movie.Realisateur })!;
            return movie;
        }

        public int Delete(int idMovie)
        {
            int isDeleted;
            _connection.Open();
            isDeleted = (int)_connection.ExecuteNonQuery("DELETE FROM MOVIE WHERE Id = @id", new { id = idMovie })!;
            return isDeleted;
        }

        public bool Update(Movie movie)
        {
            _connection.Open();

            _connection.ExecuteNonQuery("UPDATE Movie SET Nom = @nom, Annee = @annee, realisateur = @realisateur WHERE Id = @id", new { movie.Nom, movie.Annee, movie.Realisateur, movie.Id });
            return true;
        }
    }
}
