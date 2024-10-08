﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    [Table("doctor")]

    public class Doctor
    {
        [Column("id")]

        public int Id { get; set; }
        [Column("fullName")]

        public string FullName { get; set; }

        [Column("doctor_appointments")]
        [JsonIgnore]
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
