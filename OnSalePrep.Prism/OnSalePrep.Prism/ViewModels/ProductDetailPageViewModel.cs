using OnSalePrep.Common.Entities;
using OnSalePrep.Common.Responses;
using OnSalePrep.Prism.Helpers;
using OnSalePrep.Prism.Views;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace OnSalePrep.Prism.ViewModels
{
    public class ProductDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ProductResponse _product;
        private ObservableCollection<ProductImage> _images;
        private DelegateCommand _addToCartCommand;

        public ProductDetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = Languages.Details;
        }

        public DelegateCommand AddToCartCommand => _addToCartCommand ?? (_addToCartCommand = new DelegateCommand(AddToCartAsync));

        public ObservableCollection<ProductImage> Images
        {
            get => _images;
            set => SetProperty(ref _images, value);
        }

        public ProductResponse Product
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("product"))
            {
                Product = parameters.GetValue<ProductResponse>("product");
                Images = new ObservableCollection<ProductImage>(Product.ProductImages);
            }
        }

        private async void AddToCartAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "product", _product }
            };

            await _navigationService.NavigateAsync(nameof(AddToCartPage), parameters);
        }
    }
}
