using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Filmy.Models;

namespace Filmy.Controllers
{
    public class FilmController : Controller
    {

        private static IList<Film> films = new List<Film>
        {
            new Film() {Id = 1, Title = "Batman", Description = "Movie 1 description", Rate = 4},
            new Film() {Id = 2, Title = "Kot w butach", Description = "Movie 2 description", Rate = 5},
            new Film() {Id = 3, Title = "Avengers", Description = "Movie 3 description", Rate = 2}
        };

        // GET: FilmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(film=> film.Id==id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {

            film.Id = films.Count + 1;
            films.Add(film);
            return RedirectToAction("Index");
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(films.FirstOrDefault(film => film.Id == id));
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film film)
        {
            Film filmToEdit = films.FirstOrDefault(film => film.Id == id);

            filmToEdit.Title = film.Title;
            filmToEdit.Description = film.Description;
            filmToEdit.Rate = film.Rate;

            return RedirectToAction("Index");
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(films.FirstOrDefault(film => film.Id == id));
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Film film, int id)
        {
            Film filmToRemove = films.FirstOrDefault(x => x.Id == id);
            films.Remove(filmToRemove);
            return RedirectToAction("Index");
        }
    }
}
