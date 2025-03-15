using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Healthy.Server.Models
{
    public class MealRecipes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// szöveges id generálás
        public string MealRecipeID { get; set; }

        public string MealEntryID { get; set; }
        [ForeignKey("MealEntryID")]
        public virtual MealEntries MealEntry { get; set; }

        public string RecipeID { get; set; }
        [ForeignKey("RecipeID")]
        public virtual Recipe Recipe { get; set; }

        // Hány adag (float, mert részarányos is lehet)
        public float Quantity { get; set; }
    }
}
