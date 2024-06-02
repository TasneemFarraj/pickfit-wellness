using System.ComponentModel.DataAnnotations;

namespace FITTNESS.Data.Models
{
    public class ProfileUser
    {
        [Key]
        public int Id { get; set; }
        public string Img { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

    }
}

