#if __IOS__
using System.ComponentModel;
using RendererExample.CustomControls;
using RendererExample.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using CoreAnimation;
using CoreGraphics;
using System.Linq;

[assembly: ExportRenderer (typeof(CoreButton), typeof(CoreButtonRenderer))]

namespace RendererExample.iOS.Renderers
{
    public class CoreButtonRenderer : ButtonRenderer
    {
        private CAGradientLayer gradient;
        public CoreButton caller;
       
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null && Control!=null)
            {
                caller = e.NewElement as CoreButton;
                gradient = new CAGradientLayer();
                gradient.Frame = Control.Bounds;
                gradient.CornerRadius = Control.Layer.CornerRadius = caller.CornerRadius;

                gradient.Colors = new CGColor[]
                {
                    caller.StartColor.ToCGColor(),
                    caller.EndColor.ToCGColor(),
                };

                Control?.Layer.InsertSublayer(gradient, 0);
            }

         
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }



        public override void LayoutSubviews()
        {
            if (Control != null)
            {
                foreach (var layer in Control.Layer.Sublayers.Where(layer => layer is CAGradientLayer))
                {
                    layer.Frame = new CGRect(0, 0, caller.Bounds.Width, caller.Bounds.Height);
                }
            }
            base.LayoutSubviews();
        }
    }
}
#endif