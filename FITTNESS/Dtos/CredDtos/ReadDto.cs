using FITTNESS.Data.Enum;

namespace FITTNESS.Dtos.CredDtos
{
    public class ReadHomeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class ReadCertificateDto
    {
        public int Id { get; set; }
        public string Img { get; set; }
    }
    public class ReadFrequentlyQuestionDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
    public class ReadInformationCardDto
    {
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

    }
    public class ReadProfileUserDto
    {
        public int Id { get; set; }
        public string Img { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
    public class ReadPalateImgDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
    }
    public class ReadPalateIngredientDto
    {
        public int Id { get; set; }
        public string item_1 { get; set; }
        public string item_2 { get; set; }
        public string item_3 { get; set; }
        public string item_4 { get; set; }
        public string item_5 { get; set; }
        public string item_6 { get; set; }
        public string item_7 { get; set; }
    }
    public class ReadPalateNutritionDto
    {
        public int Id { get; set; }
        public string Fats { get; set; }
        public string Protein { get; set; }
        public string Carbohydrates { get; set; }
        public string Calories { get; set; }
    }
    public class ReadPalateRecipeDto
    {
        public int Id { get; set; }
        public string PreparationTime { get; set; }
        public string CookingTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string DifficultyLevel { get; set; }
    }
    public class ReadPalatePrepareDto
    {
        public int Id { get; set; }
        public string step_1 { get; set; }
        public string step_2 { get; set; }
        public string step_3 { get; set; }
        public string step_4 { get; set; }
        public string step_5 { get; set; }
        public string step_6 { get; set; }
        public string step_7 { get; set; }
    }
    public class ReadPalate1Dto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
    }

    public class ReadAppointmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public ReadInformationCardDto InformationCard { get; set; }

    }
}

