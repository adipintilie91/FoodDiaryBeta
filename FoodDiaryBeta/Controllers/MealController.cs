using FoodDiaryBeta.Models;
using FoodDiaryBeta.Models.DBObjects;
using FoodDiaryBeta.Repository;
using Microsoft.AspNet.Identity;
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
        [Authorize(Roles = "User, Admin")]
        public ActionResult Index()
        {
            //incarcam lista de 
            List<Models.MealModel> meals = mealRepository.GetAllMeals();

            //incarcam view-ul cu lista de modele
            return View("Index", meals);
        }

        // GET: Meal/Details/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Details(Guid id)
        {
            //incarcam modelul pe baza id-ului
            Models.MealModel mealModel = mealRepository.GetMealByID(id);

            //incarcam view-ul pe baza modelului incarcat
            return View("MealDetails",mealModel);
        }


        //adaugam referinta catre repository MealType
        //private MealTypeRepository mealTypeRepository = new MealTypeRepository();
        private ProductRepository productRepository = new ProductRepository();


        // GET: Meal/Create
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create()
        {

            var products = productRepository.GetAllProducts();
            SelectList lst = new SelectList(products, "ID", "ProductName", "Calories");
            ViewData["product"] = lst;

            return View("Create");
        }

        // POST: Meal/Create
        [Authorize(Roles = "User, Admin")]
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

                //if (User.Identity.IsAuthenticated) // daca avem utilizator logat
                //{
                //    mealModel.ID = User.Identity.GetUserId();

                //}


                //apelam resursa care salveaza datele
                mealRepository.InsertMeal(mealModel);


                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                //redirect catre view-ul curent in caz de erori/exceptii(pentru afisarea mesajului)

                return View("Create");
            }
        }

        // GET: Meal/Edit/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit(Guid id)
        {
            //incarcarea datelor din db
            Models.MealModel mealModel = mealRepository.GetMealByID(id);

            //incarcarea viewului prin trimitere model incarcat cu date
            return View("EditMeal", mealModel);
        }

        // POST: Meal/Edit/5
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                //instantiem modelul
                Models.MealModel mealModel = new Models.MealModel();

                //incarcam datele in model
                UpdateModel(mealModel);

                //apelam resursa care salveaza datele
                mealRepository.UpdateMeal(mealModel);

                //redirectionare catre index in caz de succes
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditMeal");
            }
        }

        // GET: Meal/Delete/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Delete(Guid id)
        {
            //incarcam datele in model din db
            Models.MealModel mealModel = mealRepository.GetMealByID(id);

            //incarcam view-ul cu modelul atasat
            return View("Delete", mealModel);
        }

        // POST: Meal/Delete/5
        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                //apelam repository care sterge datele
                mealRepository.DeleteMeal(id);
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
