using System;
using Android.Graphics;
using ThinkDoctor;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(UnderlineLabel), typeof(UnderlineRenderer))]
namespace ThinkDoctor

{
public class UnderlineRenderer : LabelRenderer
{
	protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
	{
		base.OnElementChanged(e);
		if (this.Control != null)
		{
			Control.PaintFlags = PaintFlags.UnderlineText;
			//Control.SetTextColor(Android.Graphics.Color.Black);
		}

	}
}
}
