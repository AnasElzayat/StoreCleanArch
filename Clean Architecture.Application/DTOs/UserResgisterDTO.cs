
using System.ComponentModel.DataAnnotations;


namespace Clean_Architecture.Application.DTOs
{
    public class UserResgisterDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
