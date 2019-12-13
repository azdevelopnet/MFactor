using System;
using Xamarin.Forms;

namespace BindingExample.Views
{
    public class PageOne: ContentPage
    {
        public PageOne()
        {
            this.Title = "PageOne";

            var tapGesture = new TapGestureRecognizer()
            {
                Command = new Command(async() =>
                {
                    await Navigation.PushAsync(new PageTwo());
                })
            };

            var compositeControl = new StackLayout()
            {
                BackgroundColor = Color.LightGray,
                HeightRequest = 45,
                Margin = new Thickness(150, 100, 150, 100),
                Children =
                        {
                            new StackLayout()
                            {
                                Margin = 8,
                                HorizontalOptions = LayoutOptions.Center,
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    new Image()
                                    {
                                        Margin=new Thickness(10,5,0,5),
                                        Source = ImageSource.FromFile("music.png"),
                                        HeightRequest = 22,

                                    },
                                    new Label()
                                    {
                                        Margin=new Thickness(0,5,10,5),
                                        Text = "Click Here",
                                        TextColor = Color.Black,
                                        VerticalTextAlignment = TextAlignment.Center,
                                    }
                                }
                            }
                        }
            };

            compositeControl.GestureRecognizers.Add(tapGesture);

            Content = new StackLayout()
            {
                Children =
                {
                    compositeControl
                }
            };
        }
    }
}
