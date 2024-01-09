namespace EpidemicalDisease.Domain.Entities
{
    public class Vaccine
    {
        public int Id { get; set; }
        public int MedicalCenterId { get; set; }
        public MedicalCenter MedicalCenter { get; set; } = null!;
        public int VaccineTypeId { get; set; }
        public VaccineType VaccineType { get; set; } = null!;
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public DateTime AppointmentDate { get; set; }
        public DateTime? VaccineDate { get; set; }
        public string? Notes { get; set; }


    }
}
