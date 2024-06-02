using FITTNESS.Repository.IRepo;
using FITTNESS.Data.Models;
using FITTNESS.Repository.Repo;
using FITTNESS.Repository.IRepo;

namespace FITTNESS.UnitOfWork;
public class UOW : IUOW

{
    public UOW 
        (IUserRepository user, IHomeRepository home, ICertificateRepository certificate, IFrequentlyQuestionRepository frequentlyQuestion,
        IInformationCardRepository informationcard, IProfileUserRepository profileuser, IPalateImgRepository palateimg, IPalateIngredientRepository ingredient,
        IPalateNutritionRepository nutrition, IPalateRecipeRepository recipe, IPalatePrepareRepository prepare, IPalate1Repository palate1, IAppointmentRepository appointment)
    {
        User = user;
        Home = home;
        Certificate = certificate;
        FrequentlyQuestion = frequentlyQuestion;
        InformationCard = informationcard;
        ProfileUser = profileuser;
        PalateImg = palateimg;
        PalateIngredient = ingredient;
        PalateNutrition = nutrition;
        PalateRecipe = recipe;
        PalatePrepare = prepare;
        Palate1 = palate1;
        Appointment = appointment;
    }
    public IUserRepository User { get; set; }
    public IHomeRepository Home { get ; set; }
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


