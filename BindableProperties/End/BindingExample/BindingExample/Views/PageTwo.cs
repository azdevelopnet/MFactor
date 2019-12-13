using System;
using Xamarin.Forms;

namespace BindingExample.Views
{
    public class PageTwo: ContentPage
    {
        public PageTwo()
        {
            this.Title = "PageTwo";

            Content = new StackLayout()
            {
                Children =
                {
                    new Label()
                    {
                        Text="Another Page",
                       Margin = 50,

                    }
                }
            };
        }
    }
}
