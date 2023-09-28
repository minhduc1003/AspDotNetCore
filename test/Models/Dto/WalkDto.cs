namespace test.Models.Dto
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUlr { get; set; }

        public RegionsDto Regions { get; set; }
        public DifficultyDto Difficulty { get; set; }
    }
}
