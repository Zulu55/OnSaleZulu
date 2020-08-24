using System.ComponentModel.DataAnnotations;

namespace OnSalePrep.Web.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
