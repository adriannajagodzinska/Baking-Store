using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OIprojekt.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Długość nie może przekraczać 200 znaków.")]
        //[DisplayFormat(NullDisplayText = "Przepis musi mieć nazwę.")]
        public string IngredientName { get; set; }
        //[Required]
        [Required(ErrorMessage = "Wymagane określenie wartości kalorii.")]
        [Range(0, 1000000, ErrorMessage = "Wartość nie może być ujemna.")]
        [DisplayName("Wartość kaloryczna kcal/g")]
        public int CaloriesQuantity { get; set; }
        //  [Required]
    }
}