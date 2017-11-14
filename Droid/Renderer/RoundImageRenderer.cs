using System;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ThinkDoctor;
using ThinkDoctor.Droid;

[assembly: ExportRenderer(typeof(RoundImage), typeof(RoundImageRenderer))]

namespace ThinkDoctor.Droid
{
	public class RoundImageRenderer : ImageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement == null)
			{

				if ((int)global::Android.OS.Build.VERSION.SdkInt < 18)
					SetLayerType(global::Android.Views.LayerType.Software, null);
			}
		}

		protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
		{
			try
			{
				var radius = Math.Min(Width, Height) / 2;
				//var myWidth = (float)Element.Width;
				//var myHeight = (float)Element.Height;
				//var radius = Math.Min(myWidth, myHeight) / 2;
				var strokeWidth = 10;
				radius -= strokeWidth / 2;

				//Create path to clip
				var path = new Path();
				path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
				canvas.Save();
				canvas.ClipPath(path);

				var result = base.DrawChild(canvas, child, drawingTime);

				canvas.Restore();

				// Create path for circle border
				path = new Path();
				path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);

				var paint = new Paint();
				paint.AntiAlias = true;
				paint.StrokeWidth = 1;
				paint.SetStyle(Paint.Style.Stroke);
				paint.Color = global::Android.Graphics.Color.Transparent;

				canvas.DrawPath(path, paint);

				//Properly dispose
				paint.Dispose();
				path.Dispose();
				return result;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("Unable to create circle image: " + ex);
			}

			return base.DrawChild(canvas, child, drawingTime);
		}
	}
}
