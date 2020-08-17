using Microsoft.AspNetCore.Http;
using OnSalePrep.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnSalePrep.Web.Models
{
    public class CategoryViewModel : Category
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
