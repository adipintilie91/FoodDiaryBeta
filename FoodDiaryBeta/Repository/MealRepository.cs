using FoodDiaryBeta.Models;
using FoodDiaryBeta.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace FoodDiaryBeta.Repository
{
    public class MealRepository
        //GetAllMeals
        //GetMealsByMealDate
        //InsertMeal
        //UpdateMeal
        //DeleteMeal

    {
        //injectam container-ul ORM / Data Context-ul
        private Models.DBObjects.FoodDiaryBetaModelsDataContext dbContext;

        //instantiem data context-ul
        public MealRepository()
        {
            dbContext = new Models.DBObjects.FoodDiaryBetaModelsDataContext();
        }

        //injectam un dbContext pentru a face repository-ul testabil
        public MealRepository(Models.DBObjects.FoodDiaryBetaModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //map ORM Model to Model Object - mapper method
        //mapam modelul ORM pe Model/Clasa
        private MealModel MapDbObjectToModel(Models.DBObjects.Meal dbMeal)
        {
            MealModel mealModel = new MealModel();

            if (dbMeal != null)
            {
                mealModel.ID = dbMeal.ID;
                mealModel.IDUser = dbMeal.IDUser;
                mealModel.MealDate = dbMeal.MealDate;
                mealModel.IDMealType = dbMeal.IDMealType;
                mealModel.IDProduct = dbMeal.IDProduct;
                mealModel.QTY = dbMeal.QTY;

                return mealModel;
            }
            return null;
        }

        //map Model object to ORM Model - mapper method
        //mapam Modelul(clasa) pe ORM)
        private Models.DBObjects.Meal MapModelToDbObject(MealModel mealModel)
        {
            Models.DBObjects.Meal dbMealModel = new Models.DBObjects.Meal();
            if (mealModel != null)
            {
                dbMealModel.ID = mealModel.ID;
                dbMealModel.IDUser = mealModel.IDUser;
                dbMealModel.MealDate = mealModel.MealDate;
                dbMealModel.IDMealType = mealModel.IDMealType;
                dbMealModel.IDProduct = mealModel.IDProduct;
                dbMealModel.QTY = mealModel.QTY;

                return dbMealModel;
            }
            return null;
        }

        public List<MealModel> GetAllMeals()
        {
            List<MealModel> mealList = new List<MealModel>();

            foreach (Models.DBObjects.Meal dbMeal in dbContext.Meals)
            {
                mealList.Add(MapDbObjectToModel(dbMeal));
            }
            IQueryable<MealModel> list = mealList.AsQueryable();

            return mealList;
        }

        public MealModel GetMealByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Meals.FirstOrDefault(x => x.ID == ID));
        }

        public List<MealModel> GetMealsByMealDate(DateTime dateTime)
        {

            List<MealModel> mealList = new List<MealModel>();
            foreach (Models.DBObjects.Meal dbMeal in dbContext.Meals.Where(x => x.MealDate == dateTime))
            {
                mealList.Add(MapDbObjectToModel(dbMeal));
            }
            return mealList;
        }

        public void InsertMeal(MealModel mealModel)
        {
            mealModel.ID = Guid.NewGuid(); // generate a new ID for the new record
            dbContext.Meals.InsertOnSubmit(MapModelToDbObject(mealModel)); // add to ORM
            dbContext.SubmitChanges(); //commit to DB
        }

        public void UpdateMeal(MealModel mealModel)
        {
            //get existing record to update
            Models.DBObjects.Meal existingMeal = dbContext.Meals.FirstOrDefault(x => x.ID == mealModel.ID);
            if (existingMeal != null)
            {
                //map updated values, keeping the ORM Object reference
                existingMeal.ID = mealModel.ID;
                existingMeal.IDUser = mealModel.IDUser;
                existingMeal.MealDate = mealModel.MealDate;
                existingMeal.IDMealType = mealModel.IDMealType;
                existingMeal.IDProduct = mealModel.IDProduct;
                existingMeal.QTY = mealModel.QTY;

                dbContext.SubmitChanges(); //commit to db
            }
        }

        public void DeleteMeal(Guid ID)
        {
            //get existing record to delete
            Models.DBObjects.Meal mealToDelete = dbContext.Meals.FirstOrDefault(x => x.ID == ID);
            if (mealToDelete != null)
            {
                dbContext.Meals.DeleteOnSubmit(mealToDelete); //mark for deletion
                dbContext.SubmitChanges(); //commmit to db
            }
        }




    }
}