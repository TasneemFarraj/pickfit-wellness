using AutoMapper;
using FITTNESS.Dtos.UserDtos;
using FITTNESS.Data.Models;
using FITTNESS.Dtos.CredDtos;
using FITTNESS.Repository.IRepo;
using FITTNESS.Repository.Repo;

namespace FITTNESS.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var MapConfig = new MapperConfiguration(M =>
            {

                M.CreateMap<User, UserDto>().ReverseMap();
                M.CreateMap<User, LoginDto>().ReverseMap();
                M.CreateMap<User, WriteUserDto>().ReverseMap();

                M.CreateMap<Home, WriteHomeDto>().ReverseMap();
                M.CreateMap<Home, ReadHomeDto>().ReverseMap();

                M.CreateMap<Certificate, WriteCertificateDto>().ReverseMap();
                M.CreateMap<Certificate, ReadCertificateDto>().ReverseMap();

                M.CreateMap<FrequentlyQuestion, WriteFrequentlyQuestionDto>().ReverseMap();
                M.CreateMap<FrequentlyQuestion, ReadFrequentlyQuestionDto>().ReverseMap();
                
                M.CreateMap<InformationCard, WriteInformationCardDto>().ReverseMap();
                M.CreateMap<InformationCard, ReadInformationCardDto>().ReverseMap();

                M.CreateMap<ProfileUser, WriteProfileUserDto>().ReverseMap();
                M.CreateMap<ProfileUser, ReadProfileUserDto>().ReverseMap();

                M.CreateMap<PalateImg, WritePalateImgDto>().ReverseMap();
                M.CreateMap<PalateImg, ReadPalateImgDto>().ReverseMap();

                M.CreateMap<PalateIngredient, WritePalateIngredientDto>().ReverseMap();
                M.CreateMap<PalateIngredient, ReadPalateIngredientDto>().ReverseMap();

                M.CreateMap<PalateNutrition, WritePalateNutritionDto>().ReverseMap();
                M.CreateMap<PalateNutrition, ReadPalateNutritionDto>().ReverseMap();

                M.CreateMap<PalateRecipe, WritePalateRecipeDto>().ReverseMap();
                M.CreateMap<PalateRecipe, ReadPalateRecipeDto>().ReverseMap();

                M.CreateMap<PalatePrepare, WritePalatePrepareDto>().ReverseMap();
                M.CreateMap<PalatePrepare, ReadPalatePrepareDto>().ReverseMap();

                M.CreateMap<Palate1, WritePalate1Dto>().ReverseMap();
                M.CreateMap<Palate1, ReadPalate1Dto>().ReverseMap();

                M.CreateMap<Appointment, WriteAppointmentDto>().ReverseMap();
                M.CreateMap<Appointment, ReadAppointmentDto>().ReverseMap();

            });
            return MapConfig.CreateMapper();
        }
    }
}

