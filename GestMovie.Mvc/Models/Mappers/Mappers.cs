using MovieFromDAL = GestMovie.Mvc.Models.Data.Entities;
using GestMovie.Mvc.Models.Forms;
using GestMovie.Mvc.Models.Business.Entities;

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

        internal static Movie MapperToMovie(this UpdateMovieForm m)
        {
            return new Movie(m.Nom, m.Annee, m.Realisateur);
           
        }
        internal static UpdateMovieForm MapperToUpdateMovieForm(this Movie m) {

            return new UpdateMovieForm
            {
                Id = m.Id,
                Nom = m.Nom,
                Annee = m.Annee,
                Realisateur = m.Realisateur
            };
        }
    }
}
