using System.ComponentModel.DataAnnotations;

namespace OnSalePrep.Common.Request
{
    public class EmailRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
