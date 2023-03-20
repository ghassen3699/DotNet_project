using firstDotNetApplication.Data;
using firstDotNetApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace firstDotNetApplication.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ApplicationDbContext _db;


        // Generer Constructeur 
        public CategorieController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var CategorieObject = _db.Categories.ToList();
            return View(CategorieObject);
        }


        public IActionResult CreateCategorie()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult CreateCategorie(Categorie formData)
		{
            if (formData.Name == "Ghassen")
            {
                ModelState.AddModelError("name", "Enter your correct name");
            }

            if (ModelState.IsValid)
            {
				_db.Categories.Add(formData);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
            return View(formData);
            
		}

        public IActionResult EditCategorie(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categorieFromDB = _db.Categories.Find(id);

            if (categorieFromDB == null)
            {
                return NotFound();
            }
            return View(categorieFromDB);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategorie(Categorie formData)
        {
            if (ModelState.IsValid)
            {
                var obj = _db.Categories.Update(formData);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formData);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategorie(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}
