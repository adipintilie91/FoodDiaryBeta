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
        [Authorize(Roles = "User, Admin")]
        public ActionResult Index()
        {
            //incarcam lista de produse
            List<Models.ProductModel> products = productRepository.GetAllProducts();

            //incarcam View-ul cu lista de modele
            return View("Index", products);
        }

        // GET: Product/Details/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Details(Guid id)
        {
            //incarcam modelul pe baza Id-ului
            Models.ProductModel productModel = productRepository.GetProductByID(id);

            //incarcam view-ul pe baza modelului incarcat
            return View("ProductDetails", productModel);
        }

        // GET: Product/Create
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create()
        {
            return View("CreateProduct");
        }

        // POST: Product/Create
        [Authorize(Roles = "User, Admin")]
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
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit(Guid id)
        {
            //incarcarea datelor din db
            Models.ProductModel productModel = productRepository.GetProductByID(id);

            //incarcarea view-ului prin trimitere model incarcat cu date
            return View("EditProduct", productModel);
        }

        // POST: Product/Edit/5
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                //instantiem modelul
                Models.ProductModel productModel = new Models.ProductModel();

                //incarcam datele in model
                UpdateModel(productModel);

                //apelam resursa care salveaza datele
                productRepository.UpdateProduct(productModel);

                //returnam view-ul catre index in caz de succes
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditProduct");
            }
        }

        // GET: Product/Delete/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Delete(Guid id)
        {
            //incarcam datele in model din db
            Models.ProductModel productModel = productRepository.GetProductByID(id);

            //incarcam view-ul cu modelul atasat
            return View("DeleteProduct",productModel);
        }

        // POST: Product/Delete/5
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //apelam repository care sterge datele
                productRepository.DeleteProduct(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteProduct");
            }
        }
    }
}
