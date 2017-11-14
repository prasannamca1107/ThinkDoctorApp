using System;
using ThinkDoctor;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

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
			if (e.NewElement != null)
			{
				var label = (UnderlineLabel)this.Element;
				this.Control.AttributedText = new NSAttributedString(label.Text, underlineStyle: NSUnderlineStyle.Single);
				//Control.TextColor = UIColor.Black;
			}
		}

	}
}
}
