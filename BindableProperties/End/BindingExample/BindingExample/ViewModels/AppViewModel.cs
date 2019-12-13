using System;
using System.ComponentModel;
using System.Windows.Input;
using BindingExample.Views;
using Xamarin.Forms;

namespace BindingExample.ViewModels
{
    public class AppViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string ButtonTitle { get; set; }
        public ImageSource ImgSource { get; set; }
        public ICommand NavCommand { get; set; }

        public AppViewModel()
        {
            ButtonTitle = "Click Here";
            ImgSource = ImageSource.FromFile("music.png");
            NavCommand = new Command(async () => {
                ButtonTitle = "WOW!";
                var nav =(NavigationPage)App.Current.MainPage;
                await nav.PushAsync(new PageTwo());
            });
        }
    }
}
