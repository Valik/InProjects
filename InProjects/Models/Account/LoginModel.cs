using System.ComponentModel.DataAnnotations;

namespace InProjects.Models.Account
{
    public class LoginModel
    {
        [Required]
        [MaxLength(50)]
        public string NickOrEmail { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public string Message { get; set; }
    }
}