using OnSalePrep.Prism.Helpers;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.Login;
        }
    }
}
