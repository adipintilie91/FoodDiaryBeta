using FoodDiaryBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDiaryBeta.ViewModels
{
    public class UserMealsViewModel
    {
        public string Email { get; set; }
        public List<MealModel> Meals = new List<MealModel>();
    }
}