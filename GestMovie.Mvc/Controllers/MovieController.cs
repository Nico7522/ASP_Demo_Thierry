using GestMovie.Mvc.Models.Business.Entities;
using GestMovie.Mvc.Models.Business.Repositories;
using GestMovie.Mvc.Models.Business.Services;
using GestMovie.Mvc.Models.Forms;
using GestMovie.Mvc.Models.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            return View(_repository.Get().Select(m => new DisplayLightMovie() { Id = m.Id, Nom = m.Nom, Annee = m.Annee }));
        }

        public IActionResult Details(int id)
        {
            MovieDetailsForm movie = _repository.GetOne(id).MapperToMovieDetails();
            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            Console.WriteLine("idc", id);
            if (_repository.Delete(id) > 0)
            {
                ViewBag.Message = "Supprimé avec succès";
                return View();

            }
            else
            {
                ViewBag.Message = "Une erreur s'est produite";

                return View();
            }
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

        public IActionResult Edit(int id) {

            UpdateMovieForm form = _repository.GetOne(id).MapperToUpdateMovieForm();
            return View(form);
        }

        [HttpPost]
        public IActionResult Edit(UpdateMovieForm form)
        {
         
            if (ModelState.IsValid && _repository.Update(form.MapperToMovie(), form.Id))
            {
                ViewBag.Message = "Les changement on été appliqué";
                return View();
            }
            ViewBag.Message = "Erreur";
            return View();

        }
    }
}
