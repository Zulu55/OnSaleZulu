using System.Collections.ObjectModel;
using OnSalePrep.Common.Entities;
using OnSalePrep.Common.Responses;
using OnSalePrep.Prism.Helpers;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class AddToCartPageViewModel : ViewModelBase
    {
        private ProductResponse _product;
        private ObservableCollection<ProductImage> _images;
        private bool _isRunning;
        private bool _isEnabled;

        public AddToCartPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.AddToCart;
            IsEnabled = true;
            Quantity = 1;
        }

        public float Quantity { get; set; }

        public string Remarks { get; set; }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

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
    }
}
