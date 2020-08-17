using System;
using System.ComponentModel.DataAnnotations;

namespace OnSalePrep.Common.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://onsaleprepweb.azurewebsites.net/images/noimage.png"
            : $"https://onsale.blob.core.windows.net/categories/{ImageId}";
    }
}
