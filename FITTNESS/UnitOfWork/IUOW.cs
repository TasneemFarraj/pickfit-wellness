using FITTNESS.Repository.IRepo;
using FITTNESS.Repository.IRepo;
using FITTNESS.Repository.Repo;

namespace FITTNESS.UnitOfWork
{
    public interface IUOW 
    {
        public IUserRepository User { get; set; }
        public IHomeRepository Home { get; set; }
        public ICertificateRepository Certificate { get; set; }
        public IFrequentlyQuestionRepository FrequentlyQuestion { get; set; }
        public IInformationCardRepository InformationCard { get; set; }
        public IProfileUserRepository ProfileUser { get; set; }
        public IPalateImgRepository PalateImg { get; set; }
        public IPalateIngredientRepository PalateIngredient { get; set; }
        public IPalateNutritionRepository PalateNutrition { get; set; }
        public IPalateRecipeRepository PalateRecipe { get; set; }
        public IPalatePrepareRepository PalatePrepare { get; set; }
        public IPalate1Repository Palate1 { get; set; }
        public IAppointmentRepository Appointment { get; set; }


    }
}
