using Microsoft.EntityFrameworkCore;
using ProfileManagement.DBModel;
using System;

namespace ProfileManagement
{
    public class PMDbContext : DbContext
    {
        protected DbContext dbContext { get; }

        public PMDbContext(DbContextOptions<PMDbContext> options)
            : base(options)
        {
            try
            {
                Database.EnsureDeleted();
            }
            catch(Exception exception)
            {
                Console.WriteLine( exception.ToString() );
            }
            finally
            {
                Database.EnsureCreated();
            }
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
        */

        //Configure Relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Handling Many to many relationship without having a primary key in RoleUser Table - Start
            /*
            modelBuilder.Entity<RoleUser>()
                .HasKey(t => new { t.Role, t.User });

            modelBuilder.Entity<RoleUser>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.RoleUsers)
                .HasForeignKey(pt => pt.User);

            modelBuilder.Entity<RoleUser>()
                .HasOne(pt => pt.Role)
                .WithMany(t => t.RoleUsers)
                .HasForeignKey(pt => pt.Role);
            */
            //Handling Many to many relationship without having a primary key in RoleUser Table - End
        }

        //List of Models
        public DbSet<Address>       Address { get; set; }
        public DbSet<Experience>    Experience { get; set; }
        public DbSet<Phone>         Phone { get; set; }
        public DbSet<Profile>       Profile { get; set; }
        public DbSet<Roles>         Roles { get; set; }
        public DbSet<Users>         Users { get; set; }
        public DbSet<RoleUser>      RoleUser { get; set; }
    }
}
