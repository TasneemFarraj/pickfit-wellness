using FITTNESS.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace FITTNESS.Data.Models
{
    public class InformationCard
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Addrres { get; set; }
        public string Email { get; set; }
        public string WorkingDay { get; set; }
        public string OpenHour { get; set; }
        public string CloseHour { get; set; }
        public string Rating { get; set; }
        public string Img { get; set; }
        public SpecialistTypeEnum SpecialistType { get; set; }
        public bool IsActive { get; set; }
    }
}
