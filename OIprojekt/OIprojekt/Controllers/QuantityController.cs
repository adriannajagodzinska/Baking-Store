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

namespace OIprojekt.Controllers
{
    public class QuantityController : Controller
    {
        private PrzepisyContext db = new PrzepisyContext();

        // GET: Quantity
        public ActionResult Index(string sortOrder)
        {
            var quantities = db.Quantities.Include(q => q.Ingredient).Include(q => q.Measurement).Include(q => q.Recipe);
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CalorieSortParm = sortOrder == "Calories" ? "calories_desc" : "Calories";
            var quantities1 = from s in quantities
                          select s;
            switch (sortOrder)
            {
                case "name_desc":
                    quantities1 = quantities1.OrderByDescending(s => s.Recipe.RecipeName);
                    break;
                case "Date":
                    quantities1 = quantities1.OrderBy(s => s.IngredientQuantity);
                    break;
                case "date_desc":
                    quantities1 = quantities1.OrderByDescending(s => s.IngredientQuantity);
                    break;
                case "Calories":
                    quantities1 = quantities1.OrderBy(s => s.Ingredient.IngredientName);
                    break;
                case "calories_desc":
                    quantities1 = quantities1.OrderByDescending(s => s.Ingredient.IngredientName);
                    break;
                default:
                    quantities1 = quantities1.OrderBy(s =>s.Recipe.RecipeName);
                    break;
            }
            
            return View(quantities1.ToList());
        }

        // GET: Quantity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quantity quantity = db.Quantities.Find(id);
            if (quantity == null)
            {
                return HttpNotFound();
            }
            return View(quantity);
        }

        // GET: Quantity/Create
        public ActionResult Create()
        {
            ViewBag.IngredientID = new SelectList(db.Ingredients, "IngredientID", "IngredientName");
            ViewBag.MeasurementID = new SelectList(db.Measurements, "MeasurementID", "MeasurementName");
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName");

            return View();
        }

        // POST: Quantity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuantityID,RecipeID,IngredientQuantity,IngredientID,MeasurementID")] Quantity quantity, Quantity quantity1)
        {         
            if (ModelState.IsValid)
            {
               
                    ObliczKalorie(quantity);
                    db.Quantities.Add(quantity);
                    db.SaveChanges();
                    RedirectToAction("Index", "Recipe");

                    ObliczKalorie(quantity1);
                    DodajDummy(quantity1);
                    db.SaveChanges();
                    RedirectToAction("Index", "Recipe");
                    DeleteConfirmed(quantity1.QuantityID);
                
                // db.SaveChanges();
                //db.Quantities.Remove(quantity);
                //db.SaveChanges();

                return RedirectToAction("Index", "Recipe");
            }
            ViewBag.IngredientID = new SelectList(db.Ingredients, "IngredientID", "IngredientName", quantity.IngredientID);
            ViewBag.MeasurementID = new SelectList(db.Measurements, "MeasurementID", "MeasurementName", quantity.MeasurementID);
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName", quantity.RecipeID);
            return View(quantity);
           
        }
        public ActionResult DodajDummy([Bind(Include = "QuantityID,RecipeID,IngredientQuantity,IngredientID,MeasurementID")] Quantity quantity)
        {
            //var lista = db.Quantities;
            quantity.IngredientID = 22;
            quantity.MeasurementID = 1;
            quantity.IngredientQuantity = 0;
            Recipe recipe = db.Recipes.Where(x => x.RecipeID == quantity.RecipeID).SingleOrDefault();

            if ((quantity.IngredientID == 22) && (quantity.RecipeID == recipe.RecipeID))
            {
                db.Quantities.Add(quantity);
                db.SaveChanges();
            }
            return RedirectToAction("Create");
        }
        public ActionResult ObliczKalorie(Quantity quantity)
        {
            var lista = db.Quantities;
            Recipe recipe = db.Recipes.Where(x => x.RecipeID == quantity.RecipeID).SingleOrDefault();
            Ingredient ingredient = db.Ingredients.Where(x => x.IngredientID == quantity.IngredientID).SingleOrDefault();
            Measurement measurement = db.Measurements.Where(x => x.MeasurementID == quantity.MeasurementID).SingleOrDefault();

            // var qu_in = lista.Where(x => x.IngredientID == ingredient.IngredientID).Select(z => z.IngredientQuantity);
            var listaprzepisów = db.Recipes;
            var zapisanie = listaprzepisów.Where(x => x.RecipeID == quantity.RecipeID);
            var suma = lista.Where(x => x.RecipeID == recipe.RecipeID);
            decimal sum = 0;
            // bool czymozna = listaprzepisów.Where(x => x.RecipeID == quantity.RecipeID).Select(x => x.Calories).Any();
            var sztuka = lista.Where(x => x.MeasurementID == 2);
            //  if (d == 0)
            // {
            // sum = suma.DefaultIfEmpty().Sum(o => (o.IngredientQuantity * ingredient.CaloriesQuantity) / 100);

//            if (quantity.MeasurementID == 2)
//            {


//                var obliczeniedlasztuki = suma.Where(x => x.MeasurementID == 2).Where(o => o.IngredientID == o.Ingredient.IngredientID)
//.Select(o => (o.IngredientQuantity * o.Ingredient.CaloriesQuantity));

//                sum = obliczeniedlasztuki.DefaultIfEmpty().Sum();
//            }
//            else
//            {


                var obliczenie = suma.Where(o => o.IngredientID == o.Ingredient.IngredientID)
   .Select(o => (o.IngredientQuantity * o.Ingredient.CaloriesQuantity) / 100);
                sum = obliczenie.DefaultIfEmpty().Sum();



            //sum = suma.Where(o => o.IngredientID == o.Ingredient.IngredientID).Select(o => (o.IngredientQuantity * o.Ingredient.CaloriesQuantity) / 100)Sum();
            // 
            // d = sum + d;
            //  }

            //var dummy = lista.Where(x => x.IngredientID == 22);
            //foreach (var item in dummy)
            //{
            //    db.Quantities.Add(item);
            //}


            //db.SaveChanges();

            //if((quantity.IngredientID==22)&&(quantity.RecipeID==recipe.RecipeID))
            //{
            //    db.Quantities.Add(quantity);
            //}

            foreach (var item in zapisanie)
            {
                item.Calories = sum;
            }
            return RedirectToAction("Index", "Recipe");
        }
        //--------DLA SZTUKI------DZIAŁA.
        public ActionResult ObliczKalorieDlaSztuki(Quantity quantity)
        {
            var lista = db.Quantities;
            Recipe recipe = db.Recipes.Where(x => x.RecipeID == quantity.RecipeID).SingleOrDefault();
            Ingredient ingredient = db.Ingredients.Where(x => x.IngredientID == quantity.IngredientID).SingleOrDefault();
            Measurement measurement = db.Measurements.Where(x => x.MeasurementID == quantity.MeasurementID).SingleOrDefault();

            // var qu_in = lista.Where(x => x.IngredientID == ingredient.IngredientID).Select(z => z.IngredientQuantity);
            var listaprzepisów = db.Recipes;
            var zapisanie = listaprzepisów.Where(x => x.RecipeID == quantity.RecipeID);
            var suma = lista.Where(x => x.RecipeID == recipe.RecipeID);
            decimal sum = 0;
            decimal sum1 = 0;

           // if (quantity.MeasurementID == 1)
          // {


                var obliczenie = suma.Where(o => o.IngredientID == o.Ingredient.IngredientID).Where(x => x.MeasurementID == 1)
   .Select(o => (o.IngredientQuantity * o.Ingredient.CaloriesQuantity) / 100);
           sum = obliczenie.DefaultIfEmpty().Sum();
           // }
           // if(quantity.MeasurementID==2)
           // {


                obliczenie = suma.Where(o => o.IngredientID == o.Ingredient.IngredientID).Where(x => x.MeasurementID == 2)
.Select(o => (o.IngredientQuantity * o.Ingredient.CaloriesQuantity));

           sum1 = obliczenie.DefaultIfEmpty().Sum();
           // }
            // sum = obliczenie.DefaultIfEmpty().Sum();
            decimal sumalaczna = (sum + sum1);

            //sum = suma.Where(o => o.IngredientID == o.Ingredient.IngredientID).Select(o => (o.IngredientQuantity * o.Ingredient.CaloriesQuantity) / 100)Sum();
            // 
            // d = sum + d;
            //  }

            //var dummy = lista.Where(x => x.IngredientID == 22);
            //foreach (var item in dummy)
            //{
            //    db.Quantities.Add(item);
            //}


            //db.SaveChanges();

            //if((quantity.IngredientID==22)&&(quantity.RecipeID==recipe.RecipeID))
            //{
            //    db.Quantities.Add(quantity);
            //}

            foreach (var item in zapisanie)
            {
                    item.Calories = sumalaczna;
            }
            return RedirectToAction("Index");
        }
        // GET: Quantity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quantity quantity = db.Quantities.Find(id);
            if (quantity == null)
            {
                return HttpNotFound();
            }
            ViewBag.IngredientID = new SelectList(db.Ingredients, "IngredientID", "IngredientName", quantity.IngredientID);
            ViewBag.MeasurementID = new SelectList(db.Measurements, "MeasurementID", "MeasurementName", quantity.MeasurementID);
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName", quantity.RecipeID);
            return View(quantity);
        }

        // POST: Quantity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuantityID,RecipeID,IngredientQuantity,IngredientID,MeasurementID")] Quantity quantity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quantity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IngredientID = new SelectList(db.Ingredients, "IngredientID", "IngredientName", quantity.IngredientID);
            ViewBag.MeasurementID = new SelectList(db.Measurements, "MeasurementID", "MeasurementName", quantity.MeasurementID);
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName", quantity.RecipeID);
            return View(quantity);
        }

        // GET: Quantity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quantity quantity = db.Quantities.Find(id);
            if (quantity == null)
            {
                return HttpNotFound();
            }
            return View(quantity);
        }

        // POST: Quantity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quantity quantity = db.Quantities.Find(id);

            var lista = db.Quantities;
            Recipe recipe = db.Recipes.Where(x => x.RecipeID == quantity.RecipeID).SingleOrDefault();
            var suma = lista.Where(x => x.RecipeID == recipe.RecipeID);
            var obliczenie = suma.Where(o => o.IngredientID == o.Ingredient.IngredientID).Where(o => o.QuantityID == id)
.Select(o => (o.IngredientQuantity * o.Ingredient.CaloriesQuantity) / 100);
            var listaprzepisów = db.Recipes;
            var zapisanie = listaprzepisów.Where(x => x.RecipeID == quantity.RecipeID);
            decimal sum = obliczenie.DefaultIfEmpty().Sum();
            foreach (var item in zapisanie)
            {
                item.Calories = item.Calories - sum;
            }
            db.Quantities.Remove(quantity);

            db.SaveChanges();
            return RedirectToAction("Index");


            //-------------------------------DLA SZTUK------------------------------

            //            var lista = db.Quantities;
            //            Recipe recipe = db.Recipes.Where(x => x.RecipeID == quantity.RecipeID).SingleOrDefault();


            //            // var qu_in = lista.Where(x => x.IngredientID == ingredient.IngredientID).Select(z => z.IngredientQuantity);

            //            var suma = lista.Where(x => x.RecipeID == recipe.RecipeID);
            //            decimal sum = 0;
            //            decimal sum1 = 0;

            //            // if (quantity.MeasurementID == 1)
            //            // {
            //           var obliczenie = suma.Where(o => o.QuantityID == id).Where(o => o.MeasurementID == 2).Where(o => o.IngredientID == o.Ingredient.IngredientID)
            //.Select(o => (o.IngredientQuantity * o.Ingredient.CaloriesQuantity));

            //            sum1 = obliczenie.DefaultIfEmpty().Sum();

            //             obliczenie = suma.Where(o => o.QuantityID == id).Where(o => o.MeasurementID == 1).Where(o => o.IngredientID == o.Ingredient.IngredientID)
            //.Select(o => (o.IngredientQuantity * o.Ingredient.CaloriesQuantity) / 100);
            //            sum = obliczenie.DefaultIfEmpty().Sum();
            //            // }
            //            // if (quantity.MeasurementID == 2)
            //            // {



            //            // }
            //            // sum = obliczenie.DefaultIfEmpty().Sum();
            //            var listaprzepisów = db.Recipes;
            //            var zapisanie = listaprzepisów.Where(x => x.RecipeID == quantity.RecipeID);
            //            decimal sumalaczna = (sum + sum1);



            //foreach (var item in zapisanie)
            //{
            //    item.Calories = item.Calories - sumalaczna;
            //}
            //return RedirectToAction("Index");
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
