using web_1.Models;
using Microsoft.EntityFrameworkCore;
using web_1.Models.airline.Models;

namespace web_1.Context
{
    public class ApplicationDBContext : DbContext
    {

        public DbSet<Sefer> Sefers { get; set; }
        public DbSet<Sehir> Sehirs { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Firma> Firmas { get; set; } // Correct the property name
        public DbSet<Havalimani> Havalimanis { get; set; }
        public DbSet<Rezervasyon> Rezervasyons { get; set; }
        public DbSet<Koltuklar> Koltuklars { get; set; }

       






        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public ApplicationDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Sefer>()
                .HasOne(s => s.Firma)
                .WithMany(f => f.Seferler)
                .HasForeignKey(s => s.firma_id)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Havalimani>()
               .HasOne(s => s.Sehir)
               .WithMany(f => f.Havalimanis)
               .HasForeignKey(s => s.sehir_id)
               .OnDelete(DeleteBehavior.Cascade);


            // Configure the one-to-many relationship
            modelBuilder.Entity<Koltuklar>()
                .HasOne(k => k.rezervasyon)
                .WithMany(r => r.Koltuklars)
                .HasForeignKey(k => k.rezervasyon_id)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if needed

      



            //modelBuilder.Entity<Havalimani>()
            //   .HasOne(s => s.Sehir)
            //   .WithMany(f => f.Havalimanis)
            //   .HasForeignKey(s => s.sehir_id)
            //   .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
        
       
    }
}
