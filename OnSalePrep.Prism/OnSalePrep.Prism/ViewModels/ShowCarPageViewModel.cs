using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using OnSalePrep.Common.Helpers;
using OnSalePrep.Common.Models;
using OnSalePrep.Prism.Helpers;
using OnSalePrep.Prism.ItemViewModels;
using Prism.Commands;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class ShowCarPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<ProductItemViewModel> _products;
        private bool _isRunning;
        private bool _isEnabled;
        private decimal _totalValue;
        private int _totalItems;
        private float _totalQuantity;
        private DelegateCommand _clearAllCommand;
        private DelegateCommand _finishOrderCommand;

        public ShowCarPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = Languages.ShowShoppingCar;
            IsEnabled = true;
            LoadOrderDetails();
        }

        public DelegateCommand ClearAllCommand => _clearAllCommand ?? (_clearAllCommand = new DelegateCommand(ClearAllAsync));

        public DelegateCommand FinishOrderCommand => _finishOrderCommand ?? (_finishOrderCommand = new DelegateCommand(FinishOrderAsync));

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

        public ObservableCollection<ProductItemViewModel> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        private void LoadOrderDetails()
        {
            List<OrderDetail> orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(Settings.OrderDetails);
            if (orderDetails == null)
            {
                orderDetails = new List<OrderDetail>();
            }

            TotalItems = orderDetails.Count;
            TotalValue = orderDetails.Sum(od => od.Value).Value;
            TotalQuantity = orderDetails.Sum(od => od.Quantity);

            Products = new ObservableCollection<ProductItemViewModel>(orderDetails.Select(od => new ProductItemViewModel(_navigationService)
            {
                Category = od.Product.Category,
                Description = od.Product.Description,
                Id = od.Id,
                IsActive = od.Product.IsActive,
                IsStarred = od.Product.IsStarred,
                Name = od.Product.Name,
                Price = od.Product.Price,
                ProductImages = od.Product.ProductImages,
                Qualifications = od.Product.Qualifications,
                Quantity = od.Quantity,
                Remarks = od.Remarks
            }).ToList());
        }

        private void FinishOrderAsync()
        {
        }

        private void ClearAllAsync()
        {
        }
    }
}
