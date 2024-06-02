using System.ComponentModel.DataAnnotations;

namespace FITTNESS.Data.Models
{
    public class PalateNutrition
    {
        [Key]
        public int Id { get; set; }
        public string Fats { get; set; }
        public string Protein { get; set; }
        public string Carbohydrates { get; set; }
        public string Calories { get; set; }

    }
}
