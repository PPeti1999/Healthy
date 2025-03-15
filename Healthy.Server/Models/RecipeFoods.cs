using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Healthy.Server.Models
{
    public class RecipeFoods
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// szöveges id generálás
        public string RecipeFoodID { get; set; }
        public string RecipeID { get; set; }
        [ForeignKey("RecipeID")]
        public virtual Recipe Recipe { get; set; }

        public string FoodID { get; set; }
        [ForeignKey("FoodID")]
        public virtual Food Food { get; set; }

        // Mennyiség grammban
        public float Quantity { get; set; }
    }
}
