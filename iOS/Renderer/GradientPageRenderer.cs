using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using Thinkdocotor;
using Thinkdocotor.iOS.Renderer;
using CoreAnimation;
using CoreGraphics;

[assembly: ExportRenderer(typeof(CustomPageWithGradient), typeof(GradientPageRenderer))]
namespace Thinkdocotor.iOS.Renderer
{
    public class GradientPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null) // perform initial setup
            {
                var page = e.NewElement as CustomPageWithGradient;
                var gradientLayer = new CAGradientLayer();
                gradientLayer.Frame = View.Bounds;
                gradientLayer.Colors = new CGColor[] { page.StartColor.ToCGColor(), page.EndColor.ToCGColor() };
                View.Layer.InsertSublayer(gradientLayer, 0);
            }
        }
    }
}
