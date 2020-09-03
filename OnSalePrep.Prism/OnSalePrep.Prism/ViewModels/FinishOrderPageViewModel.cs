using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnSalePrep.Common.Helpers;
using OnSalePrep.Common.Models;
using OnSalePrep.Common.Responses;
using OnSalePrep.Common.Services;
using OnSalePrep.Prism.Helpers;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Essentials;

namespace OnSalePrep.Prism.ViewModels
{
    public class FinishOrderPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        private decimal _totalValue;
        private int _totalItems;
        private float _totalQuantity;
        private string _deliveryAddress;
        private ObservableCollection<PaymentMethod> _paymentMethods;
        private PaymentMethod _paymentMethod;
        private DelegateCommand _finishOrderCommand;

        public FinishOrderPageViewModel(INavigationService navigationService, ICombosHelper combosHelper, IApiService apiService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.FinishOrder;
            IsEnabled = true;
            PaymentMethods = new ObservableCollection<PaymentMethod>(combosHelper.GetPaymentMethods());
        }

        public DelegateCommand FinishOrderCommand => _finishOrderCommand ?? (_finishOrderCommand = new DelegateCommand(FinishOrderAsync));

        public ObservableCollection<PaymentMethod> PaymentMethods
        {
            get => _paymentMethods;
            set => SetProperty(ref _paymentMethods, value);
        }

        public PaymentMethod PaymentMethod
        {
            get => _paymentMethod;
            set => SetProperty(ref _paymentMethod, value);
        }

        public string DeliveryAddress
        {
            get => _deliveryAddress;
            set => SetProperty(ref _deliveryAddress, value);
        }

        public decimal TotalValue
        {
            get => _totalValue;
            set => SetProperty(ref _totalValue, value);
        }

        public int TotalItems
        {
            get => _totalItems;
            set => SetProperty(ref _totalItems, value);
        }

        public float TotalQuantity
        {
            get => _totalQuantity;
            set => SetProperty(ref _totalQuantity, value);
        }

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

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            LoadOrderTotals();
        }

        private void LoadOrderTotals()
        {
            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            List<OrderDetailResponse> orderDetails = JsonConvert.DeserializeObject<List<OrderDetailResponse>>(Settings.OrderDetails);
            if (orderDetails == null)
            {
                orderDetails = new List<OrderDetailResponse>();
            }

            TotalItems = orderDetails.Count;
            TotalValue = orderDetails.Sum(od => od.Value).Value;
            TotalQuantity = orderDetails.Sum(od => od.Quantity);
            DeliveryAddress = $"{token.User.Address}, {token.User.City.Name}";
        }

        private async void FinishOrderAsync()
        {
            bool isValid = await ValidateDataAsync();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                return;
            }

            string url = App.Current.Resources["UrlAPI"].ToString();
            TokenRequest request = new TokenRequest
            {
                Password = Password,
                Username = Email
            };

            Response response = await _apiService.GetTokenAsync(url, "api", "/Account/CreateToken", request);
            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.LoginError, Languages.Accept);
                Password = string.Empty;
                return;
            }

            TokenResponse token = (TokenResponse)response.Result;
            Settings.Token = JsonConvert.SerializeObject(token);
            Settings.IsLogin = true;

            IsRunning = false;
            IsEnabled = true;

            if (string.IsNullOrEmpty(_pageReturn))
            {
                await _navigationService.NavigateAsync($"/{nameof(OnSaleMasterDetailPage)}/NavigationPage/{nameof(ProductsPage)}");
            }
            else
            {
                await _navigationService.NavigateAsync($"/{nameof(OnSaleMasterDetailPage)}/NavigationPage/{_pageReturn}");
            }

            Password = string.Empty;
        }

        private async Task<bool> ValidateDataAsync()
        {
            if (PaymentMethod == null)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.PaymentMethodError, Languages.Accept);
                return false;
            }

            if (string.IsNullOrEmpty(DeliveryAddress))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.DeliveryAddressError, Languages.Accept);
                return false;
            }

            return true;
        }
    }
}
