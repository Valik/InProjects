using System.ComponentModel.DataAnnotations;

namespace InProjects.Business.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nickname { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [MinLength(6)]
        public string ConfirmPassword { get; set; }
    }
}