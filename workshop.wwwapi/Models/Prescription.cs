namespace workshop.wwwapi.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public List<PrescriptionMedicine> PrescriptionMedicines { get; set; } 
    }
}
