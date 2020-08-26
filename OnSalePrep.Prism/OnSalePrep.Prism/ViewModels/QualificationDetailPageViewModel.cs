using OnSalePrep.Prism.Helpers;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class QualificationDetailPageViewModel :ViewModelBase
    {
        public QualificationDetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.Qualification;
        }
    }
}
