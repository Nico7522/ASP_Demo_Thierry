using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestMovie.Mvc.Models.Business.Entities
{
    public class Movie
    {
        public int Id { get; init; }
        public string Nom { get; set; }
        public int Annee { get; set; }
        public string Realisateur { get; set; }

        public Movie(string nom, int annee, string realisateur)
        {
            Nom = nom;
            Annee = annee;
            Realisateur = realisateur;
        }

        internal Movie(int id, string nom, int annee, string realisateur)
            : this(nom, annee, realisateur)
        {
            Id = id;
        }
    }
}
