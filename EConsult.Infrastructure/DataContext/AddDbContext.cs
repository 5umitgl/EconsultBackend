using Econsult.Domain.Entities;
using EConsult.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Econsult.Infrastructure.DataContext
{
    public class AddDbContext:DbContext
    {
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<NewUser> NewUser { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<MedicalRecord> MedicalRecord { get; set; }
        public AddDbContext(DbContextOptions<AddDbContext> option) : base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.DoctorId);

            modelBuilder.Entity<Address>()
                .HasKey(a => a.AddressId);

            modelBuilder.Entity<Patient>()
                .HasKey(f => f.PatientId);

            modelBuilder.Entity<NewUser>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<Appointment>()
                .HasKey(ap => ap.AppointmentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
