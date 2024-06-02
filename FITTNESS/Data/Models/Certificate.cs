using System.ComponentModel.DataAnnotations;

namespace FITTNESS.Data.Models
{
    public class Certificate
    {
        [Key]
        public int Id { get; set; }
        public string Img { get; set; }
    }
}
