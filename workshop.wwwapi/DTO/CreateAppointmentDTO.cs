namespace workshop.wwwapi.DTO
{
    public class CreateAppointmentDTO
    {
        //public int Id { get; set; }
        public DateTime Booking { get; set; }


        public int DoctorId { get; set; }


        public int PatientId { get; set; }
    }
}
