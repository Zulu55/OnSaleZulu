using Newtonsoft.Json;
using OnSalePrep.Common.Helpers;
using OnSalePrep.Common.Responses;
using OnSalePrep.Prism.Views;
using Prism.Commands;
using Prism.Navigation;

namespace OnSalePrep.Prism.ItemViewModels
{
    public class ProductItemViewModel : ProductResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectProductCommand;

        public ProductItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectProductCommand => _selectProductCommand ?? (_selectProductCommand = new DelegateCommand(SelectProductAsync));

        public float Quantity { get; set; }

        public string Remarks { get; set; }

        public decimal Value => (decimal)Quantity * Price;

        private async void SelectProductAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "product", this }
            };

            Settings.Product = JsonConvert.SerializeObject(this);
            await _navigationService.NavigateAsync(nameof(ProductTabbedPage), parameters);
        }
    }
}
 