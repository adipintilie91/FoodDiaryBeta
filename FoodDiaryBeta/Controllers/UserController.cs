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
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            //incarcam lista de users
            List<Models.UserModel> users = userRepository.GetAllUsers();

            return View("Index", users);
        }

        // GET: User/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(Guid id)
        {
            //incarcam modelul pe baza id-ului
            Models.UserModel userModel = userRepository.GetUserByID(id);

            //incarcam view-ul pe baza modelului incarcat
            return View("UserDetails", userModel);
        }

        // GET: User/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View("CreateUser");
        }

        // POST: User/Create
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            //incarcarea datelor din db
            Models.UserModel userModel = userRepository.GetUserByID(id);

            return View("EditUser", userModel);
        }

        // POST: User/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                //instantiem modelul
                Models.UserModel userModel = new Models.UserModel();

                //incarcam datele in model
                UpdateModel(userModel);

                //apelam resursa care salveaza datele
                userRepository.UpdateUser(userModel);

                //redirectionare catre index in caz de succes
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditUser");
            }
        }

        // GET: User/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            //incarcam datele in model din DB
            Models.UserModel userModel = userRepository.GetUserByID(id);

            //incarcam view-ul cu modelul atasat
            return View("DeleteUser",userModel);
        }

        // POST: User/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //apelam repository care sterge datele
                userRepository.DeleteUser(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteUsert");
            }
        }
    }
}
