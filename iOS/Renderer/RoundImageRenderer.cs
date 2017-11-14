using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ThinkDoctor;
using ThinkDoctor.iOS;

[assembly: ExportRenderer(typeof(RoundImage),typeof(RoundImageRenderer))]
namespace ThinkDoctor.iOS
{
	public class RoundImageRenderer : ImageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || Element == null)
				return;
			CreateCircle();
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == VisualElement.HeightProperty.PropertyName || e.PropertyName == VisualElement.WidthProperty.PropertyName)
			{
				
				CreateCircle();
			}
		}

		private void CreateCircle()
		{
			try
			{
				double min = Math.Min(Element.Width, Element.Height);
				Control.Layer.CornerRadius = (float)(min / 2.0);
				Control.Layer.MasksToBounds = false;
				Control.Layer.BorderColor = Color.Transparent.ToCGColor();
				//Control.Layer.BorderColor = ;
				Control.Layer.BorderWidth = 1;
				Control.ClipsToBounds = true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Unable to create circle image: " + ex);
		    }
		}
	}
}
