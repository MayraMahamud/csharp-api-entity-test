using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("appointment")]
    public class Appointment
    {
        public int Id { get; set; }
        [Column("booking")]
        public DateTime Booking { get; set; }
        [Column("doctorId")]

        public int DoctorId { get; set; }
        [Column("patientId")]

        public int PatientId { get; set; }

        public List<Prescription> Prescriptions { get; set; }

    }
}
