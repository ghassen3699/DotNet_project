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
            _db.Categories.Add(formData);
            _db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
