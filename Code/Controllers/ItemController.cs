using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
	public class ItemController : Controller
	{
		private readonly ApplicationDbContext _db;

		public ItemController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<Item> objList = _db.Items;
			return View(objList);
		}

		// GET-Create
		public IActionResult Create()
		{
			return View();
		}

		// POST-Create -
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Item obj)
		{
			_db.Items.Add(obj);
			_db.SaveChanges(); //save to db
			return RedirectToAction("Index");
		}
	}
}
