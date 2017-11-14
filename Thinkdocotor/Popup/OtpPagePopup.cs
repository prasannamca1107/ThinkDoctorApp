using System;
using System.Net.Http;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class OtpPagePopup : PopupPage
	{
		MyEntry Otp;

		Button verfiy,Resendotp,Cancel;
		double widthAlloc, heightAlloc;
		private string uri = "";

		StackLayout main;

		public OtpPagePopup()
		{

			BackgroundColor = Color.Transparent;
			Label heading = new Label();
			heading.Text = "OTP Verification";
			heading.TextColor = Color.Black;
			heading.FontSize = 20;
			heading.HorizontalOptions = LayoutOptions.CenterAndExpand;
			Otp = new MyEntry
			{
				Placeholder = "Enter OTP",
				//TextColor=Color.FromHex(Configuration.maincolor),
			//	FontFamily = Device.OnPlatform(Configuration.fontfamliyios,Configuration.fontfamliyandroid,null),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
			//	PlaceholderColor = Color.FromHex(Configuration.maincolor),
				Keyboard = Keyboard.Numeric,

			};
			CustomFrame FOtp = new CustomFrame
			{
				Content = Otp,
				OutlineColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(5, 15, 0, 15),
				BackgroundColor = Color.White,

			};
			verfiy = new Button
            {
                Text = "Verfiy",
                 Style = (Style)Application.Current.Resources["CPButton"],

					//FontFamily = Device.OnPlatform(Configuration.fontfamliyios,Configuration.fontfamliyandroid,null),
                FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
			verfiy.Clicked += validateotp;

			Resendotp = new Button
            {
                Text = "Resend OTP",
                 Style = (Style)Application.Current.Resources["CPButton"],

				//	FontFamily = Device.OnPlatform(Configuration.fontfamliyios,Configuration.fontfamliyandroid,null),
                FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
			Resendotp.Clicked += resendotp;
			Cancel = new Button
            {
                Text = "Cancel",
                 Style = (Style)Application.Current.Resources["CPButton"],

				//	FontFamily = Device.OnPlatform(Configuration.fontfamliyios,Configuration.fontfamliyandroid,null),
                FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

			StackLayout stkv = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Children =
				{
			  heading,FOtp,verfiy,
				}
			};


			StackLayout stkh = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 5,
				Children =
				{
			 Resendotp,Cancel
				}
			};
			Cancel.Clicked += closepop;
			StackLayout stkf = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Children =
				{
			 stkv,stkh
				}
			};
		StackLayout stkmain = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Children =
				{
			 stkv,stkh
				}
			};
		CustomFrame Fmain = new CustomFrame
		{
	Content = stkmain,
	OutlineColor = Color.White,
	HorizontalOptions = LayoutOptions.FillAndExpand,
	Padding = new Thickness(20),
	BackgroundColor = Color.White
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

			Content = new StackLayout
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions=LayoutOptions.CenterAndExpand,


				Children = {
					main
				}
			};
		}

		async void resendotp(object sender, EventArgs e)
		{
			try
			{
var isConnected = CrossConnectivity.Current.IsConnected;
	if (isConnected == false)
	{
		
		ChkCon consentPage = new ChkCon();
await Navigation.PushPopupAsync(consentPage);
await consentPage.PageClosedTask;
		return;
	}
	
				await Navigation.PushPopupAsync(new popup_pleasewait());
				var httpclient = new HttpClient();
				String urlParameters = "?email=" + Config.email  + "&forgot=forgot";
				uri = Config.Api + urlParameters;
				var json = await httpclient.GetStringAsync(uri);
				Forgetpasswordresponse response = JsonConvert.DeserializeObject<Forgetpasswordresponse>(json);
				if (response.Status.ToString() == "success")
				{
					await Navigation.PopAllPopupAsync();

					Config.otp = response.otp;
					Config.user_Id  = response.userid;
					Config.exptime = response.exptime;
					await Navigation.PushPopupAsync(new OtpPagePopup());
					await DisplayAlert("", "OTP sent to registered mail", "Ok");

				}
				else if (response.Status == "fail")
			{
				Forgetpassworderror reson = JsonConvert.DeserializeObject<Forgetpassworderror>(json);
				if (reson.Message == "user_not_exits")
				{
					await Navigation.PopAllPopupAsync();
					await DisplayAlert("", "Email not exits", "Ok");
					return;
				}
				else if (reson.Message == "error")
				{
					await Navigation.PopAllPopupAsync();
					await DisplayAlert("", "Otp not generating", "Ok");
					return;
				}
			}
			}
			catch (Exception ex)
			{
				DisplayAlert("", "Something went to worng\n" + ex.Message , "Ok");
				await Navigation.PopAllPopupAsync();
				return;
			}		}

			async void validateotp(object sender, EventArgs e)
	
			{
			try
			{
				var isConnected = CrossConnectivity.Current.IsConnected;
				if (isConnected == false)
				{

					this.Opacity = 0.3;
					ChkCon consentPage = new ChkCon();
					await Navigation.PushPopupAsync(consentPage);
					await consentPage.PageClosedTask;
					this.Opacity = 1;
					return;
				}
				await Navigation.PushPopupAsync(new popup_pleasewait());
				var httpclient = new HttpClient();
				var encoded = Uri.EscapeUriString(Config.exptime.ToString());
				String urlParameters = "?otpval=" + Otp.Text + "&userid=" + Config.user_Id+"&exptime="+encoded ;
				uri = Config.Api  + urlParameters;
				var json = await httpclient.GetStringAsync(uri);
				otpvalidresponse response = JsonConvert.DeserializeObject<otpvalidresponse>(json);

				if (response.Status.ToString() == "success")
				{
					
					await Navigation.PopAllPopupAsync();
					Application.Current.MainPage = (new NavigationPage(new NewPassword()));

				}
				else if (response.Status == "fail")
				{
					otpvaliderror reson = JsonConvert.DeserializeObject<otpvaliderror>(json);
					if (reson.Message == "invalid")
					{
						await Navigation.PopAllPopupAsync();
						await Navigation.PushPopupAsync(new OtpPagePopup());
						await DisplayAlert("", "Invalid OTP", "Ok");
						return;
					}
					else if (reson.Message == "expired")
					{
						await Navigation.PopAllPopupAsync();
						await Navigation.PushPopupAsync(new OtpPagePopup());
						await DisplayAlert("", "OTP expired", "Ok");
						return;
					}

				}
			}
			catch (Exception ex)
			{
				DisplayAlert("", "Something went to worng\n" + ex.Message , "Ok");
				await Navigation.PopAllPopupAsync();
				await Navigation.PushPopupAsync(new OtpPagePopup());
				return;
			}
			}



			async void closepop(object sender, EventArgs e)
		{
			var answer = await DisplayAlert("", "Confirm to Exit", "Yes", "No");
			if (answer)
			{
				await Navigation.PopAllPopupAsync();
			}
			}

		protected override bool OnBackButtonPressed()
{
	
	return false;
}

// Invoced when background is clicked
protected override bool OnBackgroundClicked()
{
	// Return default value - CloseWhenBackgroundIsClicked
	//return base.OnBackgroundClicked();  
	return false;
}
protected override void OnSizeAllocated(double widht, double height)
{
base.OnSizeAllocated(widht, height);

widthAlloc = widht;
heightAlloc = height;
OnAppearing();

}

protected override void OnAppearing()
{
	base.OnAppearing();
	if (Device.OS == TargetPlatform.iOS)
	{
		int[] margin = ScreenSize.MarginSizeIOS(widthAlloc, heightAlloc);
		main.Margin = new Thickness(margin[0], margin[1], margin[2], margin[3]);
		int spacing = ScreenSize.SpacingSizeIOS(widthAlloc, heightAlloc);
		main.Spacing = spacing;
	}
	else if (Device.OS == TargetPlatform.Android)
	{
		int[] margin = ScreenSize.MarginSizeANDROID(widthAlloc, heightAlloc);
		main.Margin = new Thickness(margin[0], margin[1], margin[2], margin[3]);
		int spacing = ScreenSize.SpacingSizeANDOID(widthAlloc, heightAlloc);
		main.Spacing = spacing;

	}
	}
	}


	}
