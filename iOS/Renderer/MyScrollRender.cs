using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using ThinkDoctor;
using System.ComponentModel;

[assembly: ExportRenderer (typeof(MyScroll ), typeof(MyScrollRender))]
namespace ThinkDoctor
{
	public class MyScrollRender : ScrollViewRenderer
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
		private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{

			this.ShowsHorizontalScrollIndicator = false;
		}
	}
}

