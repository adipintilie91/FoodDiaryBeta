using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDiaryBeta.Controllers
{
    public class UserController : Controller
    {
        //adaugam referinta catre repository
        private Repository.UserRepository userRepository = new Repository.UserRepository();

        // GET: User
        public ActionResult Index()
        {
            //incarcam lista de users
            List<Models.UserModel> users = userRepository.GetAllUsers();

            return View("Index", users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View("CreateUser");
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                //instantiem modelul
                Models.UserModel userModel = new Models.UserModel();

                //incarcam datele in model
                UpdateModel(userModel);

                //apelam resursa care salveaza datele
                userRepository.InsertUser(userModel);

                return RedirectToAction("Index");
            }
            catch
            {
                //redirect catre view-ul curent in caz de erori/exceptii(pentru afisarea mesajului)
                return View("CreateUser");
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
