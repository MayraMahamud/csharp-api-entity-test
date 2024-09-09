using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DTOPatientResponse
    {
        public int Id { get; set; }


        public string FullName { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
