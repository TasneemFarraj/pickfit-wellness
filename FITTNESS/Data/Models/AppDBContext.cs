using Microsoft.EntityFrameworkCore;
using FITTNESS.Data.Models;

namespace FITTNESS.Data.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }
        public DbSet<ProfileUser> ProfileUser { get; set; }
        public DbSet<PalateRecipe> PalateRecipe { get; set; }
        public DbSet<PalatePrepare> PalatePrepare { get; set; }
        public DbSet<PalateNutrition> PalateNutrition { get; set; }
        public DbSet<PalateIngredient> PalateIngredient { get; set; }
        public DbSet<PalateImg> PalateImg { get; set; }
        public DbSet<Palate1> Palate1 { get; set; }
        public DbSet<Home> Home { get; set; }
        public DbSet<FrequentlyQuestion> FrequentlyQuestion { get; set; }
        public DbSet<Certificate> Certificate { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<InformationCard> InformationCard { get; set; }

    }
}
