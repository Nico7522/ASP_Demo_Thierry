using DalMovie = GestMovie.Mvc.Models.Data.Entities.Movie;
using BllMovie = GestMovie.Mvc.Models.Business.Entities.Movie;

namespace GestMovie.Mvc.Models.Business.Mappers
{
    internal static class Mappers
    {
        internal static DalMovie ToDal(this BllMovie entity)
        {
            return new DalMovie()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Annee = entity.Annee,
                Realisateur = entity.Realisateur
            };
        }

        internal static BllMovie ToBll(this DalMovie entity)
        {
            return new BllMovie(entity.Id, entity.Nom, entity.Annee, entity.Realisateur);
        }
    }
}
