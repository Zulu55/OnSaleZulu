using System;
using System.ComponentModel.DataAnnotations;

namespace OnSalePrep.Common.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://onsaleprepweb.azurewebsites.net/images/noimage.png"
            : $"https://onsale.blob.core.windows.net/products/{ImageId}";
    }
}