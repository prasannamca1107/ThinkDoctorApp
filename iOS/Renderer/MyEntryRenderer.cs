using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using ThinkDoctor;

[assembly: ExportRenderer (typeof(MyEntry), typeof(MyEntryRenderer))]
namespace ThinkDoctor
{
	public class MyEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				// do whatever you want to the UITextField here!
				//Control.BackgroundColor = UIColor.FromRGB (237, 243, 252);
				Control.BorderStyle = UITextBorderStyle.Line;
              // Control.TextColor = UIColor.Black;
                Control.BorderStyle = UITextBorderStyle.None;
				//Control.TextAlignment = UITextAlignment.Center;
            }
		}
		private void SetMaxLength(MyEntry view)
		{
			Control.ShouldChangeCharacters = (textField, range, replacementString) =>
			{
				var newLength = textField.Text.Length + replacementString.Length - range.Length;
				return newLength <= view.MaxLength;
			};
		}
	}
}

