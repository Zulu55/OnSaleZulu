using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnSalePrep.Common.Entities;
using OnSalePrep.Common.Helpers;
using OnSalePrep.Common.Models;
using OnSalePrep.Common.Responses;
using OnSalePrep.Prism.Helpers;
using OnSalePrep.Prism.Views;
using Prism.Commands;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
public class AddToCartPageViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private ProductResponse _product;
    private ObservableCollection<ProductImage> _images;
    private bool _isRunning;
    private bool _isEnabled;
    private DelegateCommand _addToCartCommand;

    public AddToCartPageViewModel(INavigationService navigationService)
        : base(navigationService)
    {
        _navigationService = navigationService;
        Title = Languages.AddToCart;
        IsEnabled = true;
        Quantity = 1;
    }

    public DelegateCommand AddToCartCommand => _addToCartCommand ?? (_addToCartCommand = new DelegateCommand(AddToCartAsync));

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

    private async void AddToCartAsync()
    {
        bool isValid = await ValidateDataAsync();
        if (!isValid)
            {
            return;
        }

        List<OrderDetail> orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(Settings.OrderDetails);
        if (orderDetails == null)
        {
            orderDetails = new List<OrderDetail>();
        }

        foreach (var orderDetail in orderDetails)
        {
            if (orderDetail.Product.Id == Product.Id)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ProductExistInOrder, Languages.Accept);
                await _navigationService.GoBackAsync();
                return;
            }
        }


        orderDetails.Add(new OrderDetail
        {
            Product = Product,
            Quantity = Quantity,
            Remarks = Remarks
        });

        Settings.OrderDetails = JsonConvert.SerializeObject(orderDetails);
        await App.Current.MainPage.DisplayAlert(Languages.Ok, Languages.AddToCartMessage, Languages.Accept);
        await _navigationService.NavigateAsync($"/{nameof(OnSaleMasterDetailPage)}/NavigationPage/{nameof(ProductsPage)}");
    }

    private async Task<bool> ValidateDataAsync()
    {
        if (Quantity == 0)
        {
            await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.QuantityError, Languages.Accept);
            return false;
        }

        return true;
    }
}
}
