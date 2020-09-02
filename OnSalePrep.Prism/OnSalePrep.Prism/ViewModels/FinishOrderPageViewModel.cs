using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using OnSalePrep.Common.Helpers;
using OnSalePrep.Common.Models;
using OnSalePrep.Common.Responses;
using OnSalePrep.Prism.Helpers;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class FinishOrderPageViewModel : ViewModelBase
    {
        private bool _isRunning;
        private bool _isEnabled;
        private decimal _totalValue;
        private int _totalItems;
        private float _totalQuantity;
        private string _deliveryAddress;
        private ObservableCollection<PaymentMethod> _paymentMethods;
        private PaymentMethod _paymentMethod;

        public FinishOrderPageViewModel(INavigationService navigationService, ICombosHelper combosHelper)
            : base(navigationService)
        {
            Title = Languages.FinishOrder;
            IsEnabled = true;
            PaymentMethods = new ObservableCollection<PaymentMethod>(combosHelper.GetPaymentMethods());
        }

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
            List<OrderDetail> orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(Settings.OrderDetails);
            if (orderDetails == null)
            {
                orderDetails = new List<OrderDetail>();
            }

            TotalItems = orderDetails.Count;
            TotalValue = orderDetails.Sum(od => od.Value).Value;
            TotalQuantity = orderDetails.Sum(od => od.Quantity);
            DeliveryAddress = $"{token.User.Address}, {token.User.City.Name}";
        }
    }
}
