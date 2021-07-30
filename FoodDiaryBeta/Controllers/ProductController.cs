using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDiaryBeta.Controllers
{
    public class ProductController : Controller
    {
        //adaugam referinta catre repository
        private Repository.ProductRepository productRepository = new Repository.ProductRepository();

        // GET: Product
        public ActionResult Index()
        {
            //incarcam lista de anunturi
            List<Models.ProductModel> products = productRepository.GetAllProducts();

            //incarcam View-ul cu lista de modele
            return View("Index", products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View("CreateProduct");
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //instantiem modelul
                Models.ProductModel productModel = new Models.ProductModel();

                //incarcam datele in model
                UpdateModel(productModel);

                //apelam resursa care salveaza datele
                productRepository.InsertProduct(productModel);


                return RedirectToAction("Index");
            }
            catch
            {
                //redirect catre view-ul curent in caz de erori/exceptii(pentru afisarea mesajului)
                return View("CreateProduct");
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
