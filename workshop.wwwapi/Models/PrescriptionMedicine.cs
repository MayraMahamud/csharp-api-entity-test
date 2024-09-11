﻿namespace workshop.wwwapi.Models
{
    public class PrescriptionMedicine
    {
        public int Id { get; set; } 
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public int MedicineId { get; set; } 
        public Medicine Medicine { get; set; }  
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
