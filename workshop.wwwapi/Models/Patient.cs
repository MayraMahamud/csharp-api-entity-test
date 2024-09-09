using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    [Table("patient")]

    public class Patient
    {
        [Column("id")]

        public int Id { get; set; }
        [Column("fullName")]

        public string FullName { get; set; }

        [Column("patient_appointments")]
        [JsonIgnore]
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
