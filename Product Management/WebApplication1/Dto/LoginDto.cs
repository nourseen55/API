using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class LoginDto
    {
        [Required]
        public string username { get; set; }
        [Required]

        public string password { get; set; }
    }
}
