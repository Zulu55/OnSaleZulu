using OnSalePrep.Common.Responses;
using OnSalePrep.Prism.Helpers;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class QualificationDetailPageViewModel :ViewModelBase
    {
        private QualificationResponse _qualification;

        public QualificationDetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.Qualification;
        }

        public QualificationResponse Qualification
        {
            get => _qualification;
            set => SetProperty(ref _qualification, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("qualification"))
            {
                Qualification = parameters.GetValue<QualificationResponse>("qualification");
            }
        }
    }
}
