﻿using ChequeCashing.Abstractions;
using ChequeCashing.Model;
using ChequeCashing.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace ChequeCashing.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerifyPage : BaseContentPage
    {
        public VerifyPage()
        {
            InitializeComponent();
            BindingContext = new VerifyViewModel();
            CustomDatePicker.MinimumDate = DateTime.Now;
        }

        private void CustomDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var date = ((DatePicker)sender).Date;
            ((VerifyViewModel)this.BindingContext).SelectedDate = date;
        }
    }
}