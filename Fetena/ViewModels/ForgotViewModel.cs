using System.ComponentModel.DataAnnotations;

namespace Fetena.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}