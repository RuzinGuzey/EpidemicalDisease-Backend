namespace EpidemicalDisease.Domain.Entities
{
    public class FamiliarPerson
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public int FamiliarId { get; set; }
        public Person Familiar { get; set; } = null!;
    }
}
