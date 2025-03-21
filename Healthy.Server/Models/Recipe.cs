﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Healthy.Server.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// szöveges id generálás
        public string RecipeID { get; set; }
        public float SumProtein { get; set; }
        public float SumCarb { get; set; }
        public float SumFat { get; set; }
        public float SumCalorie { get; set; }

        public string PhotoID { get; set; }
        [ForeignKey("PhotoID")]
        public virtual Photo Photo { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<MealRecipes> MealRecipes { get; set; }
        public virtual ICollection<RecipeFoods> RecipeFoods { get; set; }
    }
}
