using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Next2Identity.Data;
using Next2Identity.Models;
using System.Data;

namespace Next2Identity.Controllers
{
    public class CategoriesController : Controller
    {
        private Next2DbContext db;
        public CategoriesController(Next2DbContext _db)
        {
            db= _db;
            
        }

        [HttpGet]
        public IActionResult AllCategories()
        {

            return View(db.categories);

        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateCategory()
        {
            
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateCategory(Category category)
        {
            
            if (ModelState.IsValid)
            {


                if (db.categories.Any(a => a.CategoryName!.Equals(category.CategoryName)))
                {
                    ModelState.AddModelError("", "Category is Already Exist");
                    
                   
                }
                else
                {
                    db.categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction(nameof(AllCategories));

                }

            }
            return View(category);
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(AllCategories));
            }
            var data = db.categories.Find(id);
            if (data == null)
            {
                return RedirectToAction(nameof(AllCategories));
            }
            return View(data);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.categories.Update(category);
                db.SaveChanges();
                return RedirectToAction(nameof(AllCategories));
            }
            return View(category);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(AllCategories));
            }
            var data = db.categories.Find(id);
            if (data == null)
            {
                return RedirectToAction(nameof(AllCategories));
            }
            return View(data);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]

        public IActionResult Delete(Category category)
        {
            var data = db.categories.Find(category.CategoryId);
            if (data == null)
            {
                return RedirectToAction(nameof(AllCategories));
            }
            db.categories.Remove(data);
            db.SaveChanges();
            return RedirectToAction(nameof(AllCategories));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(AllCategories));
            }
            var data = db.categories.Find(id);
            if (data == null)
            {
                return RedirectToAction(nameof(AllCategories));
            }
            return View(data);
        }

        public IActionResult Checkrepate()
        {
            
            
            
           return View();
        }
       
    }
}

    

