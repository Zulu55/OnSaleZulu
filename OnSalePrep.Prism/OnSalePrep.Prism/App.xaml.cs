using Prism;
using Prism.Ioc;
using OnSalePrep.Prism.ViewModels;
using OnSalePrep.Prism.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OnSalePrep.Common.Services;
using Syncfusion.Licensing;
using OnSalePrep.Common.Helpers;
using OnSalePrep.Prism.Helpers;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace OnSalePrep.Prism
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzAxMjQ2QDMxMzgyZTMyMmUzMEEwd1VtbUdCVDlHdm1HYjhKNDBUNVk2WE4zdU1DMjFkY3BmNDZ6SXJXM2s9");
            InitializeComponent();
            await NavigationService.NavigateAsync($"{nameof(OnSaleMasterDetailPage)}/NavigationPage/{nameof(ProductsPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<IRegexHelper, RegexHelper>();
            containerRegistry.Register<IFilesHelper, FilesHelper>();
            containerRegistry.Register<ICombosHelper, CombosHelper>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ProductsPage, ProductsPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductDetailPage, ProductDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<OnSaleMasterDetailPage, OnSaleMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ShowCarPage, ShowCarPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<ShowHistoryPage, ShowHistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<QualificationsPage, QualificationsPageViewModel>();
            containerRegistry.RegisterForNavigation<QualificationDetailPage, QualificationDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductTabbedPage, ProductTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<AddQualificationPage, AddQualificationPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<RecoverPasswordPage, RecoverPasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<ChangePasswordPage, ChangePasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<AddToCartPage, AddToCartPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifiyOrderPage, ModifiyOrderPageViewModel>();
            containerRegistry.RegisterForNavigation<FinishOrderPage, FinishOrderPageViewModel>();
            containerRegistry.RegisterForNavigation<OrderPage, OrderPageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
        }
    }
}
