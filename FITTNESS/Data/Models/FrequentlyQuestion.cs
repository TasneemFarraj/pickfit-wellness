using System.ComponentModel.DataAnnotations;

namespace FITTNESS.Data.Models
{
    public class FrequentlyQuestion
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
