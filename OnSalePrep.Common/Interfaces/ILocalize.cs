using System.Globalization;

namespace OnSalePrep.Common.Interfaces
{
    namespace Soccer.Prism.Interfaces
    {
        public interface ILocalize
        {
            CultureInfo GetCurrentCultureInfo();

            void SetLocale(CultureInfo ci);
        }
    }
}
