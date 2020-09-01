using System.Collections.Generic;
using OnSalePrep.Common.Models;

namespace OnSalePrep.Prism.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<PaymentMethod> GetPaymentMethods();
    }
}
