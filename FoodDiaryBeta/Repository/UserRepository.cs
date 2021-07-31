using FoodDiaryBeta.Models;
using FoodDiaryBeta.Models.DBObjects;
using FoodDiaryBeta.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace FoodDiaryBeta.Repository
{
    public class UserRepository
    //GetAllUsers()
    //GetUserByID
    //InsertUser
    //UpdateUser
    //DeleteUser
    {
        // injectam container-ul ORM / Data Context-ul
        private Models.DBObjects.FoodDiaryBetaModelsDataContext dbContext;

        //instantiem data context-ul
        public UserRepository()
        {
            this.dbContext = new Models.DBObjects.FoodDiaryBetaModelsDataContext();
        }

        //injectam un dbContext pentru a face repository-ul testabil
        public UserRepository(Models.DBObjects.FoodDiaryBetaModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //map ORM model to Model object - mapper method
        //mapam modelul ORM(din Repository?) pe Model(obiectul din clasa high level)
        private UserModel MapDbObjectToModel(Models.DBObjects.User dbUser)
        {
            UserModel userModel = new UserModel();

            if (dbUser != null)
            {
                userModel.ID = dbUser.Id;
                userModel.Email = dbUser.Email;
                userModel.DOB = dbUser.DOB;
                userModel.Weigth = dbUser.Weigth;
                userModel.Height = dbUser.Height;
                userModel.Gender = dbUser.Gender;
                userModel.Meals = dbUser.Meals;

                return userModel;
            }
            return null;
        }

        //map Model object to ORM model - mapper method
        //mapam Modelul(Clasa) pe ORM(din Repository?)
        private Models.DBObjects.User MapModelToDbObject(UserModel userModel)
        {
            Models.DBObjects.User dbUserModel = new Models.DBObjects.User();

            if (userModel != null)
            {
                dbUserModel.Id = userModel.ID;
                dbUserModel.Email = userModel.Email;
                dbUserModel.DOB = userModel.DOB;
                dbUserModel.Weigth = userModel.Weigth;
                dbUserModel.Height = userModel.Height;
                dbUserModel.Gender = userModel.Gender;
                dbUserModel.Meals = userModel.Meals;

                return dbUserModel;
            }
            return null;
        }

        ////implementam metoda care va incarca date in ViewModel
        //public UserMealsViewModel GetUserMeals(Guid userID)
        //{
        //    UserMealsViewModel userMealsViewModel = new UserMealsViewModel()


        //    User user = FoodDiaryBetaModelsDataContext.Users.FirstOrDefault(x => x.Id == user);
        //    if (user != null))
        //    {
        //        userMealsViewModel.Email = user.Email;
        //        IQueryable<Meal> userMeals = FoodDiaryBetaModelsDataContext.Meals.Where(x => x.ID == userID);
        //        foreach (MealModel dbMealModel in userMeals)
        //        {
        //            Models.MealModel mealModel = new Models.MealModel();
        //            mealModel.ID = dbMealModel.ID;
        //            mealModel.ID = dbMealModel.ID;
        //        }
        //    }
        //    return userMealsViewModel;
        //}

        public List<UserModel> GetAllUsers()
        {
            List<UserModel> userList = new List<UserModel>();

            foreach (Models.DBObjects.User dbUser in dbContext.Users)
            {
                userList.Add(MapDbObjectToModel(dbUser));
            }
            return userList;
        }

        public UserModel GetUserByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Users.FirstOrDefault(x => x.Id == ID));
        }

        public void InsertUser(UserModel userModel)
        {

            userModel.ID = Guid.NewGuid();  //generate new ID for every new record
            dbContext.Users.InsertOnSubmit(MapModelToDbObject(userModel));   //add to ORM layer
            dbContext.SubmitChanges();   //commit to db
        }

        public void UpdateUser(UserModel userModel)
        {
            //get existing record to update
            Models.DBObjects.User existingUser = dbContext.Users.FirstOrDefault(x => x.Id == userModel.ID);

            if (existingUser != null)
            {
                //map updated values with keeping the ORM object reference
                existingUser.Id = userModel.ID;
                existingUser.Email = userModel.Email;
                existingUser.DOB = userModel.DOB;
                existingUser.Weigth = userModel.Weigth;
                existingUser.Height = userModel.Height;
                existingUser.Gender = userModel.Gender;
                existingUser.Meals = userModel.Meals;

                dbContext.SubmitChanges();
            }
        }
        public void DeleteUser(Guid ID)
        {
            //get existing record to delete
            Models.DBObjects.User userToDelete = dbContext.Users.FirstOrDefault(x => x.Id == ID);

            if (userToDelete != null)
            {
                dbContext.Users.DeleteOnSubmit(userToDelete);   //mark for deletion
                dbContext.SubmitChanges();    //commit to db
            }
        }
    }
}