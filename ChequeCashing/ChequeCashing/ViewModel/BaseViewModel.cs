using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChequeCashing.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties

        public bool IsLoaded { get; set; }


        

        private string _icon;
        public string Icon
        {
            get => _icon;
            set { _icon = value; OnPropertyChanged(nameof(Icon)); }
        }


        

        #endregion

        #region Methods
        public void VibrateDevice(double time = 0.15)
        {
            Vibration.Vibrate(TimeSpan.FromSeconds(time));
        }

        public virtual string Validate()
        {
            return string.Empty;
        }

        

        public bool IsInternetConnected()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                return true;
            }
            return false;
        }

       
       

        
        #endregion

        #region Tasks
        public async virtual Task LoadData()
        {
        }

        public async virtual Task OnViewModelAppearing()
        {
        }

        public async Task PushToNextPage(Page page)
        {
            if (page != null)
            {
                var latestPage = App.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
                if (latestPage.GetType() != page.GetType())
                {
                    await App.Current.MainPage.Navigation.PushAsync(page);
                }
            }
        }

        public async Task PushModelNextPage(Page page)
        {
            if (page != null)
            {
                if (App.Current.MainPage.Navigation.ModalStack.Count > 0)
                {
                    var latestPage = App.Current.MainPage.Navigation.ModalStack.LastOrDefault();
                    if (latestPage?.GetType() != page.GetType())
                    {
                        await App.Current.MainPage.Navigation.PushModalAsync(page);
                    }
                }
                else
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(page);
                }

            }
        }

       

        public Page FindPageByType(Type type)
        {
            return App.Current.MainPage.Navigation.NavigationStack.FirstOrDefault(x => x.GetType() == type);
        }

        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
