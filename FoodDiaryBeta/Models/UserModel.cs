using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDiaryBeta.Models
{
    public class UserModel
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        //[StringLength(250, ErrorMessage = "Text too long (max. 250 chars)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        //[StringLength(250, ErrorMessage = "Text too long (max. 250 chars)")]
        public double Weigth { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        //[StringLength(250, ErrorMessage = "Text too long (max. 250 chars)")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Gender GenderSelection { get; set; }

        public Guid? Meals { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}