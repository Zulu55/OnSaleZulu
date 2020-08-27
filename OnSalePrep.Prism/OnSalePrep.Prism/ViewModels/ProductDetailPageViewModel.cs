using OnSalePrep.Common.Entities;
using OnSalePrep.Common.Responses;
using OnSalePrep.Prism.Helpers;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace OnSalePrep.Prism.ViewModels
{
    public class ProductDetailPageViewModel : ViewModelBase
    {
        private ProductResponse _product;
        private ObservableCollection<ProductImage> _images;

        public ProductDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.Details;
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
