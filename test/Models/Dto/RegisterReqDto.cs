using System.ComponentModel.DataAnnotations;

namespace test.Models.Dto
{
    public class RegisterReqDto
    {
        [Required]
        public string userName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string[] Role { get; set; }
    }
}
