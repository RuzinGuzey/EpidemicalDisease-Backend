namespace EpidemicalDisease.Domain.Entities
{
    public class DiseaseAnalysis
    {
        public int Id { get; set; }
        public int MedicalCenterId { get; set; }
        public MedicalCenter MedicalCenter { get; set; } = null!;
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public DateTime AnalysisAppointment { get; set; }
        public DateTime? AnalysisDate { get; set; }
        public bool AnalysisResult { get; set; }
        public string? Notes { get; set; }
    }
}
