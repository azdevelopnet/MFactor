using System;
using RendererExample.CustomControls;
using Xamarin.Forms;

namespace RendererExample
{
    public class PageOne: ContentPage
    {
        public PageOne()
        {
            Content = new StackLayout()
            {
                Children =
                {
                    new CoreButton()
                    {
                        Margin=new Thickness(40,100,40,100),
                        CornerRadius=5,
                        StartColor = Color.LightGreen,
                        EndColor = Color.DarkGreen,
                        TextColor = Color.White,
                        Text = "Perform Action"
                    }
                }
            };
        }
    }
}
