using Microsoft.EntityFrameworkCore;
using System.Numerics;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.ToListAsync();
        }

        public async Task <Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.FindAsync(id);  
  
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.FindAsync(id);

        }



        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
      

        public async Task<Patient> CreatePatient(Patient patient)
        {
            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();
            //return new Patient { Id = patient.Id };
            return new Patient { Id = patient.Id,  };

        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();
            return new Doctor { Id = doctor.Id, };

        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        //public async Task<Appointment> GetAppointmentById()
        //{
        //    return await _databaseContext.Appointments.FindAsync(1, 1);


        //}

        public async Task<List<Appointment>> GetAppointmentsByDoctorId(int id)
        {
            //return await _databaseContext.Appointments.
            return await _databaseContext.Appointments.Where(a => a.DoctorId == id).ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByPatientId(int id)
        {
            //return await _databaseContext.Appointments.
            return await _databaseContext.Appointments.Where(a => a.PatientId == id).ToListAsync();


        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _databaseContext.Appointments.FindAsync(1, 1);
        }


        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            _databaseContext.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();
            return new Appointment {PatientId = appointment.PatientId, DoctorId = appointment.DoctorId, Booking = appointment.Booking, };

        }


    }
}
