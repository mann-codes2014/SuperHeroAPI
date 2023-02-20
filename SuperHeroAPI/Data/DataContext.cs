using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext { 

         // requires using Microsoft.Extensions.Configuration;
    private readonly IConfiguration Configuration;
    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options) {
            Configuration = configuration;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Database"));
        }
        public DbSet<SuperHero> SuperHeros { get; set; }
    }
}
