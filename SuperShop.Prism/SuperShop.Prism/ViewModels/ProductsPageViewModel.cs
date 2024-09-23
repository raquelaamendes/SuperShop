using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SuperShop.Prism.Models;
using SuperShop.Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperShop.Prism.ViewModels
{
    public class ProductsPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private List<ProductResponse> _products;

        public ProductsPageViewModel(INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _apiService = apiService;
            Title = "Products Page";
            LoadProductsAync();
        }

        public List<ProductResponse> Products 
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        private async void LoadProductsAync()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();

            Response response = await _apiService.GetListAsync<ProductResponse>(url, "/api", "/Products");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            Products = (List<ProductResponse>)response.Result;
            foreach (var item in Products)
            {
                if (item.ImageFullPath != null)
                {
                    item.ImageFullPath = item.ImageFullPath.Replace("localhost", "10.0.2.2");
                }
            }
        }
    }
}
