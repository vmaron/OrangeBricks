using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Controllers.Account.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}