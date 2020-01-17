#if __ANDROID__
using System.ComponentModel;
using Android.Content;
using RendererExample.CustomControls;
using RendererExample.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics.Drawables;
using Util = Android.Util;

[assembly: ExportRenderer (typeof(CoreButton), typeof(CoreButtonRenderer))]

namespace RendererExample.Droid.Renderers
{
    public class CoreButtonRenderer : ButtonRenderer
    {
        private Context _context;

        public CoreButtonRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var caller = e.NewElement as CoreButton;

                var gradient = new GradientDrawable(GradientDrawable.Orientation.TopBottom, new[] {
                    caller.StartColor.ToAndroid().ToArgb(),
                    caller.EndColor.ToAndroid().ToArgb()
                });


                gradient.SetCornerRadius(caller.CornerRadius.ToDevicePixels(_context));
                Control.SetBackground(gradient);

                var num = caller.IsEnabled ? 105f : 100f;

                Control.Elevation = num;
                Control.TranslationZ = num;

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }

    public static class HelerExtension
    {
        public static float ToDevicePixels(this int number, Context ctx)
        {
            var displayMetrics = ctx.Resources.DisplayMetrics;

            return (float)System.Math.Round(number * (displayMetrics.Xdpi / (float)Util.DisplayMetricsDensity.Default));
        }
    }

}
#endif
