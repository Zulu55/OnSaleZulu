using OnSalePrep.Prism.Helpers;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class ShowCarPageViewModel : ViewModelBase
    {
        public ShowCarPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.ShowShoppingCar;
        }
    }
}
