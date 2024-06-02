using FITTNESS.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace FITTNESS.Dtos.CredDtos
{
    public class WriteHomeDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }

    }
    public class WriteCertificateDto
    {
        public int? Id { get; set; }
        public IFormFile Img { get; set; }
    }
    public class WriteFrequentlyQuestionDto
    {
        public int? Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
    public class WriteInformationCardDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Name is *required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is *required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits long")]
        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Phone number must start with '07' and be followed by 8 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is *required")]
        public string Addrres { get; set; }

        [Required(ErrorMessage = "Email is *required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Working Day is *required")]
        public string WorkingDay { get; set; }

        [Required(ErrorMessage = "Open Hour is *required")]
        public string OpenHour { get; set; }

        [Required(ErrorMessage = "Close Hour is *required")]
        public string CloseHour { get; set; }

        public string Rating { get; set; }

        public IFormFile Img { get; set; }

        public SpecialistTypeEnum SpecialistType { get; set; }
    }

    public class WriteProfileUserDto
    {
        public int? Id { get; set; }

        public IFormFile Img { get; set; }

        [Required(ErrorMessage = "Full Name is *required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is *required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is *required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits long")]
        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Phone number must start with '07' and be followed by 8 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is *required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Country is *required")]
        public string Country { get; set; }
    }   
    public class WritePalateImgDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public IFormFile Img { get; set; }
    }
    public class WritePalateIngredientDto
    {
        public int? Id { get; set; }
        public string item_1 { get; set; }
        public string item_2 { get; set; }
        public string item_3 { get; set; }
        public string item_4 { get; set; }
        public string item_5 { get; set; }
        public string item_6 { get; set; }
        public string item_7 { get; set; }
    }
    public class WritePalateNutritionDto
    {
        public int? Id { get; set; }
        public string Fats { get; set; }
        public string Protein { get; set; }
        public string Carbohydrates { get; set; }
        public string Calories { get; set; }
    }
    public class WritePalateRecipeDto
    {
        public int? Id { get; set; }
        public string PreparationTime { get; set; }
        public string CookingTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string DifficultyLevel { get; set; }

    }
    public class WritePalatePrepareDto
    {
        public int? Id { get; set; }
        public string step_1 { get; set; }
        public string step_2 { get; set; }
        public string step_3 { get; set; }
        public string step_4 { get; set; }
        public string step_5 { get; set; }
        public string step_6 { get; set; }
        public string step_7 { get; set; }
    }
    public class WritePalate1Dto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IFormFile Img { get; set; }
    }

    public class WriteAppointmentDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is *required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits long")]
        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Phone number must start with '07' and be followed by 8 digits")]

        public string PhoneNumber { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int InformationCardId { get; set; }
    }



}
