using System.Collections.Generic;
using OnSalePrep.Common.Models;

namespace OnSalePrep.Prism.Helpers
{
    public class CombosHelper : ICombosHelper
    {

        public IEnumerable<PaymentMethod> GetPaymentMethods()
        {
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>
            {
                new PaymentMethod { Id = 1, Name = Languages.Cash },
                new PaymentMethod { Id = 2, Name = Languages.PayPal },
                new PaymentMethod { Id = 3, Name = Languages.PSE }
            };

            return paymentMethods;
        }
    }
}
