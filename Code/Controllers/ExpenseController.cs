﻿using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
	public class ExpenseController : Controller
	{
		private readonly ApplicationDbContext _db;

		public ExpenseController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<Expense> objList = _db.Expenses;
			return View(objList);
			//return View();
		}

		// GET-Create
		public IActionResult Create()
		{
			return View();
		}

		// POST-Create -
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Expense obj)
		{
			if(ModelState.IsValid)//check if valid --serverside validation
			{
				_db.Expenses.Add(obj);
				_db.SaveChanges(); //save to db
				return RedirectToAction("Index");

			}
			return View(obj);

		}

		// GET-Delete --send the user to the other page no httppost
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db.Expenses.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);

		}

		// POST-Delete -
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? id) //must hv unique name
		{
			var obj = _db.Expenses.Find(id);
			if(obj == null)
			{
				return NotFound();
			}
			_db.Expenses.Remove(obj);
			_db.SaveChanges(); //save to db
			return RedirectToAction("Index");

		}

		// GET-Update
		public IActionResult Update(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db.Expenses.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);

		}

		// POST-Update -
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Expense obj)
		{
			if (ModelState.IsValid)//check if valid --serverside validation
			{
				_db.Expenses.Update(obj);
				_db.SaveChanges(); //save to db
				return RedirectToAction("Index");

			}
			return View(obj);

		}

	}
}

