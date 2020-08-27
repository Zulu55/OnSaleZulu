using OnSalePrep.Common.Helpers;
using OnSalePrep.Common.Models;
using OnSalePrep.Prism.Views;
using Prism.Commands;
using Prism.Navigation;

namespace OnSalePrep.Prism.ItemViewModels
{
    public class MenuItemViewModel : Menu
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectMenuCommand;

        public MenuItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectMenuCommand => _selectMenuCommand ?? (_selectMenuCommand = new DelegateCommand(SelectMenuAsync));

        private async void SelectMenuAsync()
        {
            if (PageName == "LoginPage" && Settings.IsLogin)
            {
                Settings.IsLogin = false;
                Settings.Token = null;
            }

            if (IsLoginRequired && !Settings.IsLogin)
            {
                NavigationParameters parameters = new NavigationParameters
                {
                    { "pageReturn", PageName }
                };

                await _navigationService.NavigateAsync($"/{nameof(OnSaleMasterDetailPage)}/NavigationPage/{nameof(LoginPage)}", parameters);
            }
            else
            {
                await _navigationService.NavigateAsync($"/{nameof(OnSaleMasterDetailPage)}/NavigationPage/{PageName}");
            }
        }
    }
}
