using FoodDiaryBeta.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDiaryBeta.Controllers
{
    public class MealController : Controller
    {
        //adaugam referinta catre repository
        private Repository.MealRepository mealRepository = new Repository.MealRepository();

        // GET: Meal
        public ActionResult Index()
        {
            //incarcam lista de meals
            List<Models.MealModel> meals = mealRepository.GetAllMeals();

            //incarcam view-ul cu lista de modele
            return View("Index", meals);
        }

        // GET: Meal/Details/5
        public ActionResult Details(int id)
        {
            return View("CreateMeal");
        }

        // GET: Meal/Create
        public ActionResult Create()
        {
            return View("CreateMeal");
        }

        // POST: Meal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                // instantiem modelul
                Models.MealModel mealModel = new Models.MealModel();

                //incarcam datele in model
                UpdateModel(mealModel);

                //apelam resursa care salveaza datele
                mealRepository.InsertMeal(mealModel);


                return RedirectToAction("Index");
            }
            catch
            {
                //redirect catre view-ul curent in caz de erori/exceptii(pentru afisarea mesajului)
                return View("CreateMeal");
            }
        }

        // GET: Meal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Meal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Meal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Meal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
