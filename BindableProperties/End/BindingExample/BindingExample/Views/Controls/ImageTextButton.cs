using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace BindingExample.Views.Controls
{
    public class ImageTextButton: ContentView
    {
        #region Private Variables
        private Image _image;
        private Label _Label;
        private StackLayout _stackLayout;
        private TapGestureRecognizer _tapGestureRecognizer;
        #endregion

        #region Bindable Properties
        public static readonly BindableProperty ClickCommandProperty = BindableProperty.Create(nameof(ClickCommand), typeof(ICommand), typeof(ImageTextButton), default(ICommand));
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ImageTextButton), default(string), propertyChanged: OnTextChanged);
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image), typeof(ImageSource), typeof(ImageTextButton), default(ImageSource), propertyChanged: OnImageChanged);
        #endregion

        #region Properties
        public ICommand ClickCommand
        {
            get
            {
                return (ICommand)GetValue(ClickCommandProperty);
            }

            set
            {
                SetValue(ClickCommandProperty, value);
            }
        }
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }

            set
            {
                SetValue(TextProperty, value);
            }
        }
        public ImageSource Image
        {
            get
            {
                return (ImageSource)GetValue(ImageProperty);
            }

            set
            {
                SetValue(ImageProperty, value);
            }
        }
        #endregion

        #region Properties Changed Methods

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var control = (ImageTextButton)bindable;

                var value = (string)newValue;

                control.ApplyText(value);
            }
            catch (Exception ex)
            {
                // TODO: Handle exception.
            }
        }
        private static void OnImageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var control = (ImageTextButton)bindable;

                var value = (ImageSource)newValue;

                control.ApplyImage(value);
            }
            catch (Exception ex)
            {
                // TODO: Handle exception.
            }
        }
        #endregion

        #region Private Methods
        private void ApplyText(string value)
        {
            _Label.Text = value;
        }
        private void ApplyImage(ImageSource value)
        {
            _image.Source = value;
        }
        #endregion


        public ImageTextButton()
        {
            _tapGestureRecognizer = new TapGestureRecognizer()
            {
                Command = new Command(async() =>
                {
                    var percent = ((Width-10) / this.Width);
                    await this.ScaleTo(percent, 75);
                    await this.ScaleTo(1, 75);
                    ClickCommand?.Execute(null);
                })
            };
            _Label = new Label()
            {
                Margin = new Thickness(0, 5, 10, 5),
                Text = this.Text,
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
            };
            _image = new Image()
            {
                Margin = new Thickness(10, 5, 0, 5),
                Source = this.Image,
                HeightRequest = 22,
            };


            _stackLayout = new StackLayout()
            {
                BackgroundColor = this.BackgroundColor,
                HeightRequest = this.HeightRequest,
                Margin = this.Margin,
                Children =
                        {
                            new StackLayout()
                            {
                                Margin = 8,
                                HorizontalOptions = LayoutOptions.Center,
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    _image,
                                    _Label,
                                    
                                }
                            }
                        }
            };
            _stackLayout.GestureRecognizers.Add(_tapGestureRecognizer);

            Content = _stackLayout;
        }
    }
}
