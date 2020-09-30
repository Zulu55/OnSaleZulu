using OnSalePrep.Prism.Helpers;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {
        public MapPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.Buyers;
        }
    }
}
