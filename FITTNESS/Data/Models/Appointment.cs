using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITTNESS.Data.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        [ForeignKey(nameof(InformationCardId))]
        public int InformationCardId { get; set; }
        public InformationCard? InformationCard { get; set; }
    }
}
