namespace EpidemicalDisease.Domain.Entities
{
    public class MedicalCenter
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
    }
}
