using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDiaryBeta.Models
{
    public class MealModel
    {
        public Guid ID { get; set; }

        public Guid IDUser { get; set; }

        //[Required(ErrorMessage = "Mandatory field")]
        public DateTime MealDate { get; set; }

        public int IDMealType { get; set; }

        //public MealTypesEnum MealTypesEnum {get;set;}

        public Guid IDProduct { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public int QTY { get; set; }

    }

    //public enum MealTypesEnum
    //{ 
    //    Breakfast = 0,
    //    Lunch = 1,
    //    Dinner = 2
    //}
}