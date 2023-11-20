using GestMovie.Mvc.Models.Business.Entities;
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
    }
}
