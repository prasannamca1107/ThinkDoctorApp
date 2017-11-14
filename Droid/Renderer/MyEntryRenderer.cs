using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

using ThinkDoctor;
using Android.Graphics.Drawables;
using Android.Graphics;

[assembly: ExportRenderer (typeof(MyEntry), typeof(MyEntryRenderer))]
namespace ThinkDoctor
{
	class MyEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				//Control.SetBackgroundColor (global::Android.Graphics.Color.Rgb(237, 243, 252));
               // Control.SetTextColor(global::Android.Graphics.Color.Black );
                Control.SetPadding(0, 10,0, 10);

                var nativeEditText = (global::Android.Widget.EditText)Control;
                var shape = new ShapeDrawable(new global::Android.Graphics.Drawables.Shapes.RectShape());
                shape.Paint.Color = Xamarin.Forms.Color.Transparent .ToAndroid();
                shape.Paint.SetStyle(Paint.Style.Stroke);
                nativeEditText.Background = shape;



            }
		}
	}
}

