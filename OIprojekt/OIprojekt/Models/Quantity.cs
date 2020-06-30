using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OIprojekt.Models
{
    public class Quantity
    {
        public int QuantityID { get; set; }
        [Required]
        public int RecipeID { get; set; }
        [Required(ErrorMessage = "Wymagane określenie ilości składnika w gramach lub sztuce.")]
        [Range(0,1000000, ErrorMessage ="Wartość nie może być ujemna.")]
        [DisplayName("Ilość g/szt")]
        public decimal IngredientQuantity { get; set; }
        [Required(ErrorMessage = "Wymagany wybór składnika.")]
        public int IngredientID { get; set; }
        [Required(ErrorMessage = "Wymagane określenie miary.")]
        public int MeasurementID { get; set; }
        public virtual Measurement Measurement { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}