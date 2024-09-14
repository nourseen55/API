using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class RegisterDto
    {
        [Required]
        public string username { get; set; }
        [Required]

        public string password { get; set; }
        [Compare("password")]
        public string confirmedpassword { get; set; }
        public string email { get; set; }

    }
}
