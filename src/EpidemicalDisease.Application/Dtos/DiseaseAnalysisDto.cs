namespace EpidemicalDisease.Application.Dtos
{
    public class DiseaseAnalysisDto
    {
        public int Id { get; set; }
        public int MedicalCenterId { get; set; }
        public int PersonId { get; set; }
        public DateTime AnalysisAppointment { get; set; }
        public DateTime? AnalysisDate { get; set; }
        public bool AnalysisResult { get; set; }
        public string? Notes { get; set; }
    }
}
