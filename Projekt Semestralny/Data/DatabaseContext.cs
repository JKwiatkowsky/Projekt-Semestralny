using Microsoft.EntityFrameworkCore;
using ProjektSemestralny.Models;

namespace ProjektSemestralny
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<CompletedService> CompletedServices { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=JKWIATKOWSKY\\SQLEXPRESS;Database=Fryzjer;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("staliKlienci");
            modelBuilder.Entity<Customer>().Property(c => c.IdKlienta).HasColumnName("idKlienta");
            modelBuilder.Entity<Customer>().Property(c => c.Imie).HasColumnName("imie");
            modelBuilder.Entity<Customer>().Property(c => c.Nazwisko).HasColumnName("nazwisko");
            modelBuilder.Entity<Customer>().Property(c => c.NrTelefonu).HasColumnName("nrTelefonu");

            modelBuilder.Entity<Appointment>().ToTable("Appointments");
            modelBuilder.Entity<Appointment>().Property(a => a.Id).HasColumnName("id");
            modelBuilder.Entity<Appointment>().Property(a => a.CustomerId).HasColumnName("customerId");
            modelBuilder.Entity<Appointment>().Property(a => a.Date).HasColumnName("date");

            modelBuilder.Entity<CompletedService>().ToTable("CompletedServices");
            modelBuilder.Entity<CompletedService>().Property(cs => cs.Id).HasColumnName("id");
            modelBuilder.Entity<CompletedService>().Property(cs => cs.ServiceId).HasColumnName("serviceId");
            modelBuilder.Entity<CompletedService>().Property(cs => cs.CustomerId).HasColumnName("customerId");
            modelBuilder.Entity<CompletedService>().Property(cs => cs.CompletionDate).HasColumnName("completionDate");

            modelBuilder.Entity<Service>().ToTable("Services");
            modelBuilder.Entity<Service>().Property(s => s.Id).HasColumnName("id");
            modelBuilder.Entity<Service>().Property(s => s.Name).HasColumnName("name");
            modelBuilder.Entity<Service>().Property(s => s.Price).HasColumnName("price");
        }
    }
}
