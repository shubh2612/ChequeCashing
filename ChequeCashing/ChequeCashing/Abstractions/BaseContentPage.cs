using ChequeCashing.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChequeCashing.Abstractions
{
    public class BaseContentPage : ContentPage
    {
        public bool _isLoaded { get; set; }

        public BaseContentPage()
        {
            BindingContext = new BaseViewModel();        
        }

        protected async override void OnAppearing()
        {
            if (!_isLoaded)
            {
                _isLoaded = true;
                var viewModel = (BaseViewModel)BindingContext;
                await viewModel.LoadData();
            }
        }
    }
}
