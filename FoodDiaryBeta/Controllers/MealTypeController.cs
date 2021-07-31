using FoodDiaryBeta.Models;
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
            //incarcam modelul pe baza id-ului
            MealTypeModel mealTypeModel = mealTypeRepository.GetMealTypeById(id);

            //incarcam view-u lpe baza modelului incarcat
            return View("DetailsMealType",mealTypeModel);
        }

        // GET: MealType/Create
        public ActionResult Create()
        {
            return View("CreateMealType");
        }

        // POST: MealType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //instantiem modelul
                Models.MealTypeModel mealTypeModel = new Models.MealTypeModel();

                //incarcam datele in model
                UpdateModel(mealTypeModel);

                //apelam resursa care salveaza datele
                mealTypeRepository.InsertMealType(mealTypeModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateMealType");
            }
        }

        // GET: MealType/Edit/5
        public ActionResult Edit(int id)
        {
            //Incarcarea datelor din db
            MealTypeModel mealTypeModel = mealTypeRepository.GetMealTypeById(id);

            //incarcarea viewului prin trimitere model incarcat cu date
            return View("EditMealType", mealTypeModel);
        }

        // POST: MealType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                //instantiem modelul
                MealTypeModel mealTypeModel = new MealTypeModel();

                //incarcam datele in model
                UpdateModel(mealTypeModel);

                //apelam resursa care salveaza datele
                mealTypeRepository.UpdateMealType(mealTypeModel);

                //redirect to Index in case of Success
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditMealType");
            }
        }

        // GET: MealType/Delete/5
        public ActionResult Delete(int id)
        {
            //incarcam datele in model din db
            MealTypeModel mealTypeModel = mealTypeRepository.GetMealTypeById(id);

            //incarcam viewul cu modelul atasat
            return View("DeleteMealType", mealTypeModel);
        }

        // POST: MealType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //apelam repository care sterge datele
                mealTypeRepository.DeleteMealType(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteMealType");
            }
        }
    }
}
