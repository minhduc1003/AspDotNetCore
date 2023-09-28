using System.ComponentModel.DataAnnotations;

namespace test.Models.Dto
{
    public class RegionActionDto
    {
        [Required]
        [MinLength(3,ErrorMessage = "min 3 character")]
        [MaxLength(3, ErrorMessage = "max 3 character")]
        public string Code { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "min 3 character")]
        [MaxLength(3, ErrorMessage = "max 3 character")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
