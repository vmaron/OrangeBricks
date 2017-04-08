using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class ContactAgentViewModel
    {
        [Required]
        public int PropertyId { get; set; }

        public string StreetName { get; set; }

        [Display(Name = "Your Name")]
        [Required]
        public string BuyerName { get; set; }

        [Display(Name = "Email")]
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Required]
        public string Phone { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}