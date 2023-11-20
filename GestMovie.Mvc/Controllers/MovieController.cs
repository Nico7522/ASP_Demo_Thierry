using GestMovie.Mvc.Models.Business.Entities;
using GestMovie.Mvc.Models.Business.Repositories;
using GestMovie.Mvc.Models.Business.Services;
using GestMovie.Mvc.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestMovie.Mvc.Controllers
{
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private IMovieRepository _repository;
        public MovieController(ILogger<MovieController> logger, IMovieRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.Get().Select(m => new DisplayLightMovie() { Nom = m.Nom, Annee = m.Annee }));
        }

        //Retourner le formulaire
        public IActionResult Create()
        {
            return View();
        }

        //Traiter le formulaire
        [HttpPost]
        public IActionResult Create(CreateMovieForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            Movie movie = new Movie(form.Nom, form.Annee, form.Realisateur);

            movie = _repository.Insert(movie);

            _logger.LogInformation($"Nouveau film inséré {movie.Id} : {movie.Nom}");

            return RedirectToAction("Index");
        }
    }
}
