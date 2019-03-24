using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.system.winform.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = "AppDb.db",
                    ForeignKeys = true
                }.ConnectionString
            }, true)
        {            
        }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Registration>()                
                .HasMany(p => p.Images)
                .WithRequired(p => p.Registration)
                .HasForeignKey(p => p.RegistrationId);

            modelBuilder.Entity<Registration>()
                .HasMany(p => p.Parkings)
                .WithRequired(p => p.Registration)
                .HasForeignKey(p => p.RegistrationId);

            modelBuilder.Entity<Registration>().ToTable("Registration");
            modelBuilder.Entity<RegistrationImage>().ToTable("RegistrationImage");
            modelBuilder.Entity<Parking>().ToTable("Parking");


        }

        public DbSet<Registration> Registrations { get; set; }
        public DbSet<RegistrationImage> RegistrationImages { get; set; }
        public DbSet<Parking> Parkings { get; set; }
    }
}
