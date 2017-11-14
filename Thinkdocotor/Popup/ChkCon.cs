using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;

using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class ChkCon : PopupPage
	{
		
		Button btncontinue;
        StackLayout main;
		public Task PageClosedTask { get { return tcs.Task; } 


			}

		private TaskCompletionSource<bool> tcs { get; set; }

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			tcs.SetResult(true);

		}

		// Or provide your own PopAsync function so that when you decide to leave the page explicitly the TaskCompletion is triggered
		public async Task PopAwaitableAsync()
		{
			await Navigation.PopAsync();

		
			tcs.SetResult(true);
		}

		public ChkCon()
		{
			tcs = new System.Threading.Tasks.TaskCompletionSource<bool>();



			Label heading = new Label();
			heading.Text = "Network Error";

			heading.FontSize = 20;
			heading.TextColor = Color.Black;
			heading.HorizontalOptions = LayoutOptions.CenterAndExpand;


			Label des = new Label();
			des.Text = "Error communicating with the server,\nplease check your internet connection.";
			des.FontSize = 10;
			des.TextColor = Color.Gray;
			des.HorizontalTextAlignment = TextAlignment.Center;
			des.HorizontalOptions = LayoutOptions.CenterAndExpand;

			btncontinue = new Button
			{
				Text = "Ok",
				// Style = (Style)Application.Current.Resources["CPButton"],
				TextColor = Color.White,
				//BackgroundColor =Color.FromHex( Config.concolor),

				//	FontFamily = Device.OnPlatform(Configuration.fontfamliyios,Configuration.fontfamliyandroid,null),
                FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
			btncontinue.Clicked += btncontinue_Clicked;


			StackLayout stkmain = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Spacing = 10,
				Children =
				{
			 heading,des,btncontinue
				}
			};
			Frame Fmain = new Frame
			{
				Content = stkmain,
				OutlineColor = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(20),
				BackgroundColor = Color.White,
				HasShadow = true
			};
			main = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Children =
				{
			Fmain
				}
			};
			BackgroundColor = Color.Transparent;
			Content = new StackLayout
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions=LayoutOptions.Center,
				Children = {
					main
				}
			};
		}

		async void btncontinue_Clicked(object sender, EventArgs e)
		{
await Navigation.PopAllPopupAsync();
//			//await Navigation.PopAllPopupAsync();
//			var isConnected = CrossConnectivity.Current.IsConnected;
//			if (isConnected == true)
//			{
//				await Navigation.PopAllPopupAsync();

//			}
//			else
//			{
//await Navigation.PopPopupAsync();

//ChkCon consentPage = new ChkCon();
//await Navigation.PushPopupAsync(consentPage);
//await consentPage.PageClosedTask;
//			}
		}


		protected override bool OnBackButtonPressed()
		{
	// Prevent hide popup
	//return base.OnBackButtonPressed();
			return false;
		}
		protected override bool OnBackgroundClicked()
{
	// Return default value - CloseWhenBackgroundIsClicked
	//return base.OnBackgroundClicked();  
	return false;
}
	}


}

