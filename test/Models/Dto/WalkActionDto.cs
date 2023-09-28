namespace test.Models.Dto
{
    public class WalkActionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUlr { get; set; }
        public Guid RegionsId { get; set; }
        public Guid DifficultyId { get; set; }
    }
}
