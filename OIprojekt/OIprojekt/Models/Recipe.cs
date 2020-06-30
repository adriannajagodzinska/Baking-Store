using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OIprojekt.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        // [Required]
        [Required]
        [StringLength(300, ErrorMessage = "Długość nie może przekraczać 300 znaków.")]
        [DisplayFormat(NullDisplayText = "Przepis musi mieć nazwę.")]
        public string RecipeName { get; set; }

        [StringLength(400, ErrorMessage ="Długość nie może przekraczać 400 znaków.")]
        [DisplayFormat(NullDisplayText = "-")]
        public string Sources { get; set; }

        public string Preparation { get; set; }
        // [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public decimal? Calories { get; set; }
        public virtual ICollection<Quantity> Quantities { get; set; }
    }
}