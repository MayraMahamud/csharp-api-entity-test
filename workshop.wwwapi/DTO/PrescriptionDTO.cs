namespace workshop.wwwapi.DTO
{
    public class PrescriptionDTO
    {
        public string AppointmentId { get; set; }
        public List<PrescriptionMedicineDTO> Medicines { get; set; }
    }
}
