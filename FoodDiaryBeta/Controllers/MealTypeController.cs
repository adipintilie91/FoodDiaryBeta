using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDiaryBeta.Controllers
{
    public class MealTypeController : Controller
    {
        //adaugam referinta catre repository
        private Repository.MealTypeRepository mealTypeRepository = new Repository.MealTypeRepository();

        // GET: MealType
        public ActionResult Index()
        {
            //incarcam lista de anunturi
            List<Models.MealTypeModel> mealTypes = mealTypeRepository.GetAllMealTypes();

            return View("Index", mealTypes);
        }

        // GET: MealType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MealType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MealType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MealType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MealType/Edit/5
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

        // GET: MealType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MealType/Delete/5
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
