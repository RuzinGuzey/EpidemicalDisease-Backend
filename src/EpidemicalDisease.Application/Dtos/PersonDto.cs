namespace EpidemicalDisease.Application.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public int TC { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
    }
}
