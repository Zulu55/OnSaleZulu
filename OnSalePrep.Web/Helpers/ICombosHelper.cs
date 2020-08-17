using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace OnSalePrep.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboCategories();
    }
}
