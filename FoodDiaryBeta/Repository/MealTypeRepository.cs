using FoodDiaryBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDiaryBeta.Repository
{
    public class MealTypeRepository
    {
        //injectam containerul ORM/Data Contextul
        private Models.DBObjects.FoodDiaryBetaModelsDataContext dbContext;

        //instantiem data context-ul
        public MealTypeRepository()
        {
            dbContext = new Models.DBObjects.FoodDiaryBetaModelsDataContext();
        }

        //injectam un dbContext pentru a face Repository-ul testabil
        public MealTypeRepository(Models.DBObjects.FoodDiaryBetaModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //map ORM Model to Model object - mapper method
        //mapam modelul ORM(din Repository) pe Model

        private MealTypeModel MapDbObjectToModel(Models.DBObjects.MealType dbMealType)
        {
            MealTypeModel mealTypeModel = new MealTypeModel();

            if (dbMealType != null)
            {
                mealTypeModel.IDMealType = dbMealType.Id;
                mealTypeModel.MealTypeName = dbMealType.MealTypeName;

                return mealTypeModel;
            }
            return null;
        }

        //map Model object to ORM model - mapper method
        //mapam Modelul(Clasa) pe ORM

        private Models.DBObjects.MealType MapModelToDbObject(MealTypeModel mealTypeModel)
        {
            Models.DBObjects.MealType dbMealType = new Models.DBObjects.MealType();

            if (dbMealType != null)
            {
                dbMealType.Id = mealTypeModel.IDMealType;
                dbMealType.MealTypeName = mealTypeModel.MealTypeName;

                return dbMealType;
            }
            return null;
        }

        public List<MealTypeModel> GetAllMealTypes()
        {
            List<MealTypeModel> mealTypeList = new List<MealTypeModel>();
            foreach (Models.DBObjects.MealType dbMealType in dbContext.MealTypes)
            {
                mealTypeList.Add(MapDbObjectToModel(dbMealType));
            }

            return mealTypeList;
        }

        public MealTypeModel GetMealTypeById(int ID)
        {
            return MapDbObjectToModel(dbContext.MealTypes.FirstOrDefault(x => x.Id == ID));
        }

        public void InsertMealType(MealTypeModel mealTypeModel)
        {
            dbContext.MealTypes.InsertOnSubmit(MapModelToDbObject(mealTypeModel));   //add to ORM layer
            dbContext.SubmitChanges();   //commit to db
        }

        public void UpdateMealType(MealTypeModel mealTypeModel)
        {
            //get existing record to update
            Models.DBObjects.MealType existingMealType = dbContext.MealTypes.FirstOrDefault(x => x.Id == mealTypeModel.IDMealType);

            if (existingMealType != null)
            {
                //map updated values with keeping the ORM object reference
                existingMealType.Id = mealTypeModel.IDMealType;
                existingMealType.MealTypeName = mealTypeModel.MealTypeName;

                dbContext.SubmitChanges();
            }
        }
        public void DeleteMealType(int ID)
        {
            //get existing record to delete
            Models.DBObjects.MealType mealTypeToDelete = dbContext.MealTypes.FirstOrDefault(x => x.Id == ID);

            if (mealTypeToDelete != null)
            {
                dbContext.MealTypes.DeleteOnSubmit(mealTypeToDelete);   //mark for deletion
                dbContext.SubmitChanges();    //commit to db
            }
        }
    }
}