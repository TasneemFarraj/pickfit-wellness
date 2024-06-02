using System.ComponentModel.DataAnnotations;

namespace FITTNESS.Data.Models
{
    public class PalateRecipe
    {
        [Key]
        public int Id { get; set; }
        public string PreparationTime { get; set; }
        public string CookingTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string DifficultyLevel { get; set; }
    }
}
