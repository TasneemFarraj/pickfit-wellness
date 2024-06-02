using System.ComponentModel.DataAnnotations;

namespace FITTNESS.Data.Models
{
    public class PalateImg
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
    }
}
