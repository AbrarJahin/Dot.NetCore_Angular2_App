using Microsoft.EntityFrameworkCore;
using ProfileManagement.DBModel;


namespace ProfileManagement
{
    public class PMDbContext : DbContext
    {
        protected DbContext dbContext { get; }

        public PMDbContext(DbContextOptions<PMDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            //context.Database.Migrate();

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=.\pm.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Work done while creating model like seeding
        }
        */

        //List of Models
        public DbSet<Profile> Profile { get; set; }
    }
}
