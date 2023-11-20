using System.ComponentModel.DataAnnotations;

namespace GestMovie.Mvc.Models.Forms
{
#nullable disable
    public class CreateMovieForm
    {
        [Required]
        [MinLength(1)]
        public string Nom { get; set; }
        [Required]
        public int Annee { get; set; }
        [Required]
        [MinLength(1)]
        public string Realisateur { get; set; }
    }
}
