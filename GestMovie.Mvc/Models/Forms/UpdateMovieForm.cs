using System.ComponentModel.DataAnnotations;

namespace GestMovie.Mvc.Models.Forms
{
    public class UpdateMovieForm
    {

        public int Id { get; set; }
        public string Nom { get; set; }
        
        public int Annee { get; set; }
      
        public string Realisateur { get; set; }
    }
}
