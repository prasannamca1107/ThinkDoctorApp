using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Thinkdocotor;
using Thinkdocotor.Droid.Renderer;

[assembly: ExportRenderer(typeof(CustomPageWithGradient), typeof(GradientPageRenderer))]
namespace Thinkdocotor.Droid.Renderer
{
    public class GradientPageRenderer : PageRenderer
    {
        private Xamarin.Forms.Color StartColor { get; set; }
        private Xamarin.Forms.Color EndColor { get; set; }

        protected override void DispatchDraw(
            global::Android.Graphics.Canvas canvas)
        {
            //var gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0,
            //    this.StartColor.ToAndroid(),
            //    this.EndColor.ToAndroid(),
            //    Android.Graphics.Shader.TileMode.Mirror);
            var gradient = new Android.Graphics.LinearGradient(0, 0, 0, Height,
                this.StartColor.ToAndroid(),
                this.EndColor.ToAndroid(),
                Android.Graphics.Shader.TileMode.Mirror);
            var paint = new Android.Graphics.Paint()
            {
                Dither = true,
            };
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                var page = e.NewElement as CustomPageWithGradient;
                this.StartColor = page.StartColor;
                this.EndColor = page.EndColor;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR: ", ex.Message);
            }
        }

    }
}