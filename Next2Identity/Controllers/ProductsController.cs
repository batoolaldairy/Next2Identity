using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Next2Identity.Data;
using Next2Identity.Models;
using System.Data;

namespace Next2Identity.Controllers
{
    public class ProductsController : Controller
    {
        private Next2DbContext db;
        public ProductsController(Next2DbContext _db)
        {
            db= _db;
            
        }


        [HttpGet]
        public IActionResult AllProducts()
        {

            return View(db.products.Include(x=>x.category));

        }
  
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateProduct()
        {
            ViewBag.allcat = new SelectList(db.categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("AllProducts");
            }
            return View(product);
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("AllProducts");
            }
            var data = db.products.Find(id);
            if (data == null)
            {
                return RedirectToAction("AllProducts");
            }
            return View(data);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Update(product);
                db.SaveChanges();
                return RedirectToAction("AllProducts");
            }
            return View(product);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("AllProducts");
            }
            var data = db.products.Find(id);
            if (data == null)
            {
                return RedirectToAction("AllProducts");
            }
            return View(data);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]

        public IActionResult Delete(Product product)
        {
            var data = db.products.Find(product.Id);
            if (data == null)
            {
                return RedirectToAction("AllProducts");
            }
            db.products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("AllProducts");
        }
       
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("AllProducts");
            }
            var data = db.products.Find(id);
            if (data == null)
            {
                return RedirectToAction("AllProducts");
            }
            return View(data);
        }
    }
}
