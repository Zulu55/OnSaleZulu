using OnSalePrep.Prism.Helpers;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class ModifyUserPageViewModel : ViewModelBase
    {
        public ModifyUserPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.ModifyUser;
        }
    }
}
