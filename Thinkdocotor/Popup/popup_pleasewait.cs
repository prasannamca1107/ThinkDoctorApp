using System;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class popup_pleasewait : PopupPage
	{
		public popup_pleasewait()
		{
			NavigationPage.SetHasBackButton(this, false);
			ActivityIndicator ac = new ActivityIndicator();
			ac.Color = Color.White;

			ac.IsRunning = true;


			Label pl = new Label()
			{
				Text = "Loading...",
				TextColor = Color.White,
				VerticalOptions=LayoutOptions.Center,
				//FontFamily = Device.OnPlatform(Configuration.fontfamliyios, Configuration.fontfamliyandroid, null)


			};
StackLayout stkmain = new StackLayout
{
	Orientation = StackOrientation.Vertical,
	HorizontalOptions = LayoutOptions.Fill,
	Spacing = 10,
	Children =
				{
			ac,pl
				}
};
			var semiTransparentColor1 = new Color(0, 0, 0, 0.5);
			Frame Fmain = new Frame
{
	Content = stkmain,
	OutlineColor = Color.White,
	HorizontalOptions = LayoutOptions.CenterAndExpand,
	Padding = new Thickness(20),
	BackgroundColor = semiTransparentColor1,
	HasShadow = true
};
StackLayout	main = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.Center,
				Spacing = 10,
				Children =
				{
			Fmain
				}
			};

			var semiTransparentColor = new Color(0, 0, 0, 0.5);
			BackgroundColor = semiTransparentColor;
			Content = new StackLayout
			{
				
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					main
				}
			};
		}
protected override bool OnBackButtonPressed()
{
			// Prevent hide popup
			//return base.OnBackButtonPressed();
			return false;
}

// Invoced when background is clicked
protected override bool OnBackgroundClicked()
{
			// Return default value - CloseWhenBackgroundIsClicked
			//return base.OnBackgroundClicked();  
			return false;
		}
	}
}

