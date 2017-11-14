using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using ThinkDoctor;
using Android.Graphics.Drawables;
using Android.Graphics;

[assembly: ExportRenderer (typeof(MyScroll), typeof(MySrollRenderer))]
namespace ThinkDoctor
{
	class MySrollRenderer : ScrollViewRenderer
	{
		 protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || this.Element == null)
				return;

			if (e.OldElement != null)
				
				e.OldElement.PropertyChanged -= OnElementPropertyChanged;


				e.NewElement.PropertyChanged += OnElementPropertyChanged;



		}

		protected void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{


			this.HorizontalScrollBarEnabled = false;
			this.VerticalScrollBarEnabled = false;



		}
		}
	}

