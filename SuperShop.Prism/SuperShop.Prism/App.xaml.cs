using Prism;
using Prism.Ioc;
using Prism.Navigation;
using SuperShop.Prism.Services;
using SuperShop.Prism.ViewModels;
using SuperShop.Prism.Views;
using Syncfusion.Licensing;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace SuperShop.Prism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzQ5MzAyM0AzMTM5MmUzMjJlMzBkVlJZUDNFRjYzSmVIN0NzaVliWFFkejhXRFBqeFA0S3dlenZvSlRBeFN3PQ==");

            InitializeComponent();

            await NavigationService.NavigateAsync
                ($"/{nameof(SuperShopMasterDetailPage)}/NavigationPage/{nameof(ProductsPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductsPage, ProductsPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductDetailPage, ProductDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<SuperShopMasterDetailPage, SuperShopMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<ShowHistoryPage, ShowHistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<ShowCartPage, ShowCartPageViewModel>();
        }
    }
}
