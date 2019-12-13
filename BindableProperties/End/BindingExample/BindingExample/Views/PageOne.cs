using System;
using BindingExample.ViewModels;
using BindingExample.Views.Controls;
using Xamarin.Forms;

namespace BindingExample.Views
{
    public class PageOne: ContentPage
    {
        private ImageTextButton _imageTextButton;
        public PageOne()
        {
            this.Title = "PageOne";
            this.BindingContext = new AppViewModel();

            _imageTextButton = new ImageTextButton()
            {
                BackgroundColor = Color.LightGray,
                HeightRequest = 45,
                Margin = 150
            };
            _imageTextButton.SetBinding(ImageTextButton.TextProperty, nameof(AppViewModel.ButtonTitle));
            _imageTextButton.SetBinding(ImageTextButton.ImageProperty, nameof(AppViewModel.ImgSource));
            _imageTextButton.SetBinding(ImageTextButton.ClickCommandProperty, nameof(AppViewModel.NavCommand));

            Content = new StackLayout()
            {
                Children =
                {
                    _imageTextButton
                }
            };
        }
    }
}
