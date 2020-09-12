﻿using OnSalePrep.Common.Responses;
using OnSalePrep.Prism.Views;
using Prism.Commands;
using Prism.Navigation;

namespace OnSalePrep.Prism.ItemViewModels
{
    public class OrderItemViewModel : OrderResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectOrderCommand;

        public OrderItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectOrderCommand => _selectOrderCommand ?? (_selectOrderCommand = new DelegateCommand(SelectOrderAsync));

        private async void SelectOrderAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "order", this }
            };

            await _navigationService.NavigateAsync(nameof(OrderPage), parameters);
        }
    }
}
