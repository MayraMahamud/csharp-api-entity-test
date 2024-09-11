using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Doctor>().HasMany(k => k.Appointments);
            modelBuilder.Entity<Patient>().HasMany(k => k.Appointments);
            modelBuilder.Entity<Appointment>().HasKey(dp => new { dp.DoctorId, dp.PatientId });
            //modelBuilder.Entity<Doctor>().HasKey(k => k.Id);
            //modelBuilder.Entity<Patient>().HasKey(k => k.Id);


            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
               new { Id = 1, FullName = "Nigel Sibbert" }
              




           );

            modelBuilder.Entity<Doctor>().HasData(
             
               new { Id = 1, FullName = "Mayra Mahamud" }

           );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment (){Booking = DateTime.UtcNow, DoctorId= 1, PatientId= 1}
             

           );

            modelBuilder.Entity<Prescription>().HasData(
               new Prescription() { Id = 1, AppointmentId = 1 }


          );
            modelBuilder.Entity<PrescriptionMedicine>().HasData(
              new PrescriptionMedicine() { Id = 1, PrescriptionId = 1, MedicineId = 1 , Quantity = 1, Notes = "important"}


         );
            modelBuilder.Entity<Medicine>().HasData(
              new Medicine() { Id = 1, Name = "Alvedon" }


         );



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "Database");
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }
        public DbSet<Medicine> Medicines { get; set; }



    }
}
