using OnSalePrep.Common.Entities;
using OnSalePrep.Web.Data.Entities;
using OnSalePrep.Web.Models;
using System;
using System.Threading.Tasks;

namespace OnSalePrep.Web.Helpers
{
    public interface IConverterHelper
    {
        Category ToCategory(CategoryViewModel model, Guid imageId, bool isNew);

        CategoryViewModel ToCategoryViewModel(Category category);

        Task<Product> ToProductAsync(ProductViewModel model, bool isNew);

        ProductViewModel ToProductViewModel(Product product);
    }
}
