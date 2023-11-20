using GestMovie.Mvc.Models.Business.Entities;
using MovieFromDAL = GestMovie.Mvc.Models.Data.Entities;
using GestMovie.Mvc.Models.Forms;

namespace GestMovie.Mvc.Models.Mappers
{
    internal static class Mappers
    {

        internal static MovieDetailsForm MapperToMovieDetails(this Movie m)
        {
            return new MovieDetailsForm
            {
                Id = m.Id,
                Nom = m.Nom,
                Annee = m.Annee,
                Realisateur = m.Realisateur,

            };
        }

        internal static MovieFromDAL.Movie MapperToMovie(this UpdateMovieForm m)
        {
            return new MovieFromDAL.Movie
            {
                Id = m.Id,
                Nom = m.Nom,
                Annee = m.Annee,
                Realisateur = m.Realisateur
            };
        }
        internal static UpdateMovieForm MapperToUpdateMovieForm(this Movie m) {

            return new UpdateMovieForm
            {
                Nom = m.Nom,
                Annee = m.Annee,
                Realisateur = m.Realisateur
            };
        }
    }
}
