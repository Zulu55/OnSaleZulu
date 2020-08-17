using OnSalePrep.Prism.Helpers;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class ShowHistoryPageViewModel : ViewModelBase
    {
        public ShowHistoryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.ShowPurchaseHistory;
        }
    }
}
