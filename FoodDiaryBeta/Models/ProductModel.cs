using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDiaryBeta.Models
{
    public class ProductModel
    {
        public Guid ID { get; set; }

        //[Required(ErrorMessage = "Mandatory field")]
        //[StringLength(250, ErrorMessage = "Text too long (max. 250 chars)")]
        public string ProductName { get; set; }

       // [Required(ErrorMessage = "Mandatory field")]
        //[StringLength(250, ErrorMessage = "Text too long (max. 250 chars)")]
        public int Calories { get; set; }

    }
}