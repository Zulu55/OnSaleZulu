using System.Collections.ObjectModel;
using System.Linq;
using OnSalePrep.Common.Responses;
using OnSalePrep.Prism.Helpers;
using OnSalePrep.Prism.ItemViewModels;
using OnSalePrep.Prism.Views;
using Prism.Commands;
using Prism.Navigation;

namespace OnSalePrep.Prism.ViewModels
{
    public class QualificationsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ProductResponse _product;
        private bool _isRunning;
        private ObservableCollection<QualificationItemViewModel> _qualifications;
        private DelegateCommand _addQualificationCommand;

        public QualificationsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = Languages.Qualifications;
        }

        public DelegateCommand AddQualificationCommand => _addQualificationCommand ?? (_addQualificationCommand = new DelegateCommand(AddQualificationAsync));

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public ObservableCollection<QualificationItemViewModel> Qualifications
        {
            get => _qualifications;
            set => SetProperty(ref _qualifications, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("product"))
            {
                IsRunning = true;
                _product = parameters.GetValue<ProductResponse>("product");
                if (_product.Qualifications != null)
                {
                    Qualifications = new ObservableCollection<QualificationItemViewModel>(
                        _product.Qualifications.Select(q => new QualificationItemViewModel(_navigationService)
                    {
                        Date = q.Date,
                        Id = q.Id,
                        Remarks = q.Remarks,
                        Score = q.Score
                    }).ToList());
                }

                IsRunning = false;
            }
        }

        private async void AddQualificationAsync()
        {
            await _navigationService.NavigateAsync(nameof(AddQualificationPage));
        }
    }
}
