using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        //Task<IEnumerable<Patient>> GetPatientById(int id);
        Task<Patient> GetPatientById(int id);
        Task <Patient> CreatePatient(Patient patient);
       
        
        Task<Doctor> CreateDoctor(Doctor doctor);
        Task<Doctor> GetDoctorById(int id);
        Task<IEnumerable<Doctor>> GetDoctors();


        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(int id);
        Task<List<Appointment>> GetAppointmentsByDoctorId(int id);
        Task<List<Appointment>> GetAppointmentsByPatientId(int id);
        Task<Appointment> CreateAppointment(Appointment appointment);




    }
}
