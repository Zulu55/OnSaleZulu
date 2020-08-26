using OnSalePrep.Common.Responses;
using OnSalePrep.Prism.Helpers;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class ProductTabbedPageViewModel : ViewModelBase
    {
        public ProductTabbedPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.Product;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("product"))
            {
                var product = parameters.GetValue<ProductResponse>("product");
                Title = product.Name;
            }
        }
    }
}
