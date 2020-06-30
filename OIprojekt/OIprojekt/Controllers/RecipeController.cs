using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OIprojekt.DAL;
using OIprojekt.Models;
using PagedList;

namespace OIprojekt.Controllers
{
    public class RecipeController : Controller
    {
        private PrzepisyContext db = new PrzepisyContext();

        // GET: Recipe
        public ActionResult Index(string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CalorieSortParm = sortOrder == "Calories" ? "calories_desc" : "Calories";
            var recipes = from s in db.Recipes
                           select s;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    recipes = recipes.Where(s => s.RecipeName.Contains(searchString)
            //                           || s.Sources.Contains(searchString));
            //}
            switch (sortOrder)
            {
                case "name_desc":
                    recipes = recipes.OrderByDescending(s => s.RecipeName);
                    break;
                case "Date":
                    recipes = recipes.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    recipes = recipes.OrderByDescending(s => s.Date);
                    break;
                case "Calories":
                    recipes = recipes.OrderBy(s => s.Calories);
                    break;
                case "calories_desc":
                    recipes = recipes.OrderByDescending(s => s.Calories);
                    break;
                default:
                    recipes = recipes.OrderBy(s => s.RecipeName);
                    break;
            }
           return View(recipes.ToList());
        }
        public ActionResult RecipeInfo(int id)
        {
            List<Recipe> RecipeInfo = db.Recipes.Where(x => x.RecipeID == id).ToList();
            return View(RecipeInfo);
        }
            // GET: Recipe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }
        [Route("{Quantity}/{DodajSkladnik}/{id}")]
        public ActionResult DodajSkladnik(int? id, Quantity quantity1)
        {

            //var noweid = db.Quantities.Where(x => x.RecipeID == id);
            //// var ajdi=db.R
            //Quantity quantity = db.Quantities.Find(noweid);
            var noweid = db.Recipes.Where(x => x.RecipeID == id);
            //var noweid = db.Quantities.Where(x => x.RecipeID == idprzepisu);
            Quantity quantity = db.Quantities.Find(id);
            //var groupedData = db.Quantities.Where(x => x.RecipeID == id).ToList();
            return View(quantity);
        }
        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeID,RecipeName,Sources,Preparation,Date,Calories")] Recipe recipe)
        {
            DateTime data = recipe.Date;
            if (ModelState.IsValid && data<=DateTime.Today)
            {
                recipe.Calories = 0;                                                               
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (data > DateTime.Today)
            {
                ViewBag.ErrorData("Nie można dodać daty z przyszłości");
            }
            return View(recipe);
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeID,RecipeName,Sources,Preparation,Date,Calories")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Recipe recipe = db.Recipes.Find(id);
                db.Recipes.Remove(recipe);
                db.SaveChanges();
            }
            catch {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
