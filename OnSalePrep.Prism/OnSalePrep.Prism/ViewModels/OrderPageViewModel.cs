using OnSalePrep.Prism.Helpers;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class OrderPageViewModel : ViewModelBase
    {
        public OrderPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.Order;
        }
    }
}
