namespace test.Models.Domain
{
    public class Walks
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUlr { get; set; }
        public Guid RegionsId { get; set; }
        public Guid DifficultyId { get; set; }
        public Regions Regions { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
