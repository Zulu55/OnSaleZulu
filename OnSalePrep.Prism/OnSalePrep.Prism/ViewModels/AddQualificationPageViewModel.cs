using OnSalePrep.Prism.Helpers;
using Prism.Commands;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class AddQualificationPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _saveCommand;

        public AddQualificationPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = Languages.NewQualification;
            IsEnabled = true;
        }

        public DelegateCommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(SaveAsync));

        public float Qualification { get; set; }

        public string Remarks { get; set; }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void SaveAsync()
        {
            if (Qualification == 0)
            {
                await App.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.QualificationError,
                    Languages.Accept);
                return;
            }

            await _navigationService.GoBackAsync();
        }
    }
}
