using FoodDiaryBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDiaryBeta.Repository
{
    public class ProductRepository
        //GetProductByID
        //UpdateProduct
        //DeleteProduct

    {
        //injectam container-ul ORM / Data Contextul
        private Models.DBObjects.FoodDiaryBetaModelsDataContext dbContext;

        //instantiem dataContext-ul
        public ProductRepository()
        {
            dbContext = new Models.DBObjects.FoodDiaryBetaModelsDataContext();
        }

        //injectam un dbContext pentru a face repository-ul testabil
        public ProductRepository(Models.DBObjects.FoodDiaryBetaModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //map ORM Model to Model object - mapper method
        //mapam modelul ORM pe Clasa
        private ProductModel MapDbObjectToModel(Models.DBObjects.Product dbProduct)
        {
            ProductModel productModel = new ProductModel();
            if (dbProduct!=null)
            {
                productModel.ID = dbProduct.ID;
                productModel.ProductName = dbProduct.ProductName;
                productModel.Calories = dbProduct.Calories;

                return productModel;
            }
            return null;
        }

        //map Model object to ORM model - mapper method
        //mapam Modelul(Clasa) pe ORM
        private Models.DBObjects.Product MapModelToDbObject(ProductModel productModel)
        {
            Models.DBObjects.Product dbProductModel = new Models.DBObjects.Product();

            if (productModel!=null)
            {
                dbProductModel.ID = productModel.ID;
                dbProductModel.ProductName = productModel.ProductName;
                dbProductModel.Calories = productModel.Calories;

                return dbProductModel;
            }
            return null;
        }
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> productList = new List<ProductModel>();

            foreach (Models.DBObjects.Product dbProduct in dbContext.Products)
            {
                productList.Add(MapDbObjectToModel(dbProduct));
            }
            return productList;
        }

        public ProductModel GetProductByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Products.FirstOrDefault(x => x.ID == ID));
        }

        public void InsertProduct(ProductModel productModel)
        {
            productModel.ID = Guid.NewGuid(); // generate new ID for the new record
            dbContext.Products.InsertOnSubmit(MapModelToDbObject(productModel)); // add to ORM layer
            dbContext.SubmitChanges(); //commit to DB

        }


        public void UpdateProduct(ProductModel productModel)
        {
            //get existing record to update
            Models.DBObjects.Product existingProduct = dbContext.Products.FirstOrDefault(x => x.ID == productModel.ID);

            if (existingProduct!= null)
            {
                //map updated values with keeping the ORM object reference
                existingProduct.ID = productModel.ID;
                existingProduct.ProductName = productModel.ProductName;
                existingProduct.Calories = productModel.Calories;

                dbContext.SubmitChanges();  //commit to db
            }
        }

        public void DeleteProduct(Guid ID)
        {
            //get existing record to delete
            Models.DBObjects.Product productToDelete = dbContext.Products.FirstOrDefault(x => x.ID == ID);

            if (productToDelete!=null)
            {
                dbContext.Products.DeleteOnSubmit(productToDelete); //mark for deletion
                dbContext.SubmitChanges();   // commit to db
            }

        }
    }
}