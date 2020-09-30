using Newtonsoft.Json;
using OnSalePrep.Common.Helpers;
using OnSalePrep.Common.Models;
using OnSalePrep.Common.Responses;
using OnSalePrep.Prism.Helpers;
using OnSalePrep.Prism.ItemViewModels;
using OnSalePrep.Prism.Views;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OnSalePrep.Prism.ViewModels
{
    public class OnSaleMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private UserResponse _user;
        private static OnSaleMasterDetailPageViewModel _instance;
        
        public OnSaleMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _instance = this;
            _navigationService = navigationService;
            LoadMenus();
            LoadUser();
        }

        public UserResponse User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        public static OnSaleMasterDetailPageViewModel GetInstance()
        {
            return _instance;
        }

        public void LoadUser()
        {
            if (Settings.IsLogin)
            {
                TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
                User = token.User;
            }
        }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_card_giftcard",
                    PageName = $"{nameof(ProductsPage)}",
                    Title = Languages.Products
                },
                new Menu
                {
                    Icon = "ic_shopping_cart",
                    PageName = $"{nameof(ShowCarPage)}",
                    Title = Languages.ShowShoppingCar
                },
                new Menu
                {
                    Icon = "ic_history",
                    PageName = $"{nameof(ShowHistoryPage)}",
                    Title = Languages.ShowPurchaseHistory,
                    IsLoginRequired = true
                },
                new Menu
                {
                    Icon = "ic_person",
                    PageName = $"{nameof(ModifyUserPage)}",
                    Title = Languages.ModifyUser,
                    IsLoginRequired = true
                },
                new Menu
                {
                    Icon = "ic_location_on",
                    PageName = $"{nameof(MapPage)}",
                    Title = Languages.Buyers
                },
                new Menu
                {
                    Icon = "ic_exit_to_app",
                    PageName = $"{nameof(LoginPage)}",
                    Title = Settings.IsLogin ? Languages.Logout : Languages.Login
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title,
                    IsLoginRequired = m.IsLoginRequired
                }).ToList());
        }
    }
}
