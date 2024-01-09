namespace EpidemicalDisease.Application.Dtos
{
    public class VaccineDto
    {
        public int Id { get; set; }
        public int MedicalCenterId { get; set; }
        public int VaccineTypeId { get; set; }
        public int PersonId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime? VaccineDate { get; set; }
        public string? Notes { get; set; }
    }
}
