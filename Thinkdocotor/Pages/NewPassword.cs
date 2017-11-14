using System;
using System.Net.Http;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using Thinkdocotor;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class NewPassword : ContentPage
	{
		MyEntry newpasw, repasw;
		Button setnewpasw;
		int left, right, top, bottom;
		double widthAlloc, heightAlloc;
		StackLayout main;
		private string uri = "";
		Label cap;
		public NewPassword()
		{
			 if (Device.OS == TargetPlatform.iOS)
			{


				if (App.ScreenWidth == 320 && App.ScreenHight == 568)
				{
					BackgroundImage = "BG/Bg320x568.png";
				}
				else if (App.ScreenWidth == 375 && App.ScreenHight == 667)
				{
					BackgroundImage = "BG/Bg375x667.png";
				}
				else if (App.ScreenWidth == 414 && App.ScreenHight == 736)
				{
					BackgroundImage = "BG/Bg414x736.png";
				}
				else if (App.ScreenWidth == 768 && App.ScreenHight == 1024)
				{
					BackgroundImage = "BG/Bg768x1024.png";
				}
				else if (App.ScreenWidth == 1536 && App.ScreenHight == 2048)
				{
					BackgroundImage = "BG/Bg1536x2048.png";
				}
				else
				{
					BackgroundImage = "Bg.png";
				}
			}
			else
			{
			//	BackgroundColor = Color.White;
				BackgroundImage = "Bg.png";
			}



			cap = new Label
			{
				Text = "Create New Password",
				//Style = (Style)Application.Current.Resources["labelColor"],
				//TextColor = Color.FromHex(Configuration.maincolor),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.Center,
				//FontFamily = Device.OnPlatform(Configuration.fontfamliyios, Configuration.fontfamliyandroid, null),


			};
			newpasw = new MyEntry
			{
				Placeholder = "New Password",
				//TextColor = Color.FromHex(Configuration.maincolor),
				//	FontFamily = Device.OnPlatform(Configuration.fontfamliyios,Configuration.fontfamliyandroid,null),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				//PlaceholderColor = Color.FromHex(Configuration.maincolor),
				Keyboard = Keyboard.Text,
				IsPassword = true

			};
			CustomFrame Fnewpasw = new CustomFrame
			{
				Content = newpasw,
				//OutlineColor = Color.FromHex(Configuration.maincolor),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(5, 15, 0, 15),
				BackgroundColor = Color.White,

			};
			repasw = new MyEntry
			{
				Placeholder = "Re enter New Password  ",
				//TextColor = Color.FromHex(Configuration.maincolor),
				//	FontFamily = Device.OnPlatform(Configuration.fontfamliyios,Configuration.fontfamliyandroid,null),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				//PlaceholderColor = Color.FromHex(Configuration.maincolor),
				Keyboard = Keyboard.Text,
				IsPassword = true

			};
			CustomFrame Frepasw = new CustomFrame
			{
				Content = repasw,
				//OutlineColor = Color.FromHex(Configuration.maincolor),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(5, 15, 0, 15),
				BackgroundColor = Color.White,

			};

			setnewpasw = new Button
			{
				Text = "Set New Paswword",
				Style = (Style)Application.Current.Resources["CPButton"],
				Margin = new Thickness(40, 0, 40, 0),
				//	FontFamily = Device.OnPlatform(Configuration.fontfamliyios,Configuration.fontfamliyandroid,null),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};
			setnewpasw.Clicked += setnewpasw_clicked;

			main = new StackLayout
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Spacing = 25,
				Padding = 0,
				Children = {
					cap, Fnewpasw, Frepasw, setnewpasw

				}
			};

			var scroll = new ScrollView();
			scroll.Content = main;
			Content = scroll;
		}

		async void setnewpasw_clicked(object sender, EventArgs e)
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

				if (string.IsNullOrEmpty(newpasw.Text))
				{
					await DisplayAlert("", "Enter New Password", "Ok");
					newpasw.Focus();
					await Navigation.PopAllPopupAsync();
					return;
				}
				else if (string.IsNullOrEmpty(repasw.Text))
				{
					await DisplayAlert("", "Re-enter New Password", "Ok");
					repasw.Focus();
					await Navigation.PopAllPopupAsync();
					return;
				}
				else if (newpasw.Text != repasw.Text)
				{
					await DisplayAlert("", "New password does not match", "Ok");
					repasw.Focus();
					await Navigation.PopAllPopupAsync();
					return;
				}
				await Navigation.PushPopupAsync(new popup_pleasewait());
				var httpclient = new HttpClient();
				String urlParameters = "?email=" + Config.email + "&password=" + repasw.Text;
				uri = Config.Api  + urlParameters;
				var json = await httpclient.GetStringAsync(uri);
				Changedpasswordresponse response = JsonConvert.DeserializeObject<Changedpasswordresponse>(json);

				if (response.Status.ToString() == "success")
				{
					await Navigation.PopAllPopupAsync();
					await DisplayAlert("", "Password Changed", "Ok");
					Application.Current.MainPage = (new NavigationPage(new LoginPage()));
					return;
				}
				else if (response.Status == "fail")
				{
					Changedpassworderror reson = JsonConvert.DeserializeObject<Changedpassworderror>(json);
					if (reson.Message == "error")
					{
						await Navigation.PopAllPopupAsync();
						await DisplayAlert("", "Password has not been changed ", "Ok");
						return;
					}
					if (reson.Message == "user_not_exits")
					{
						await Navigation.PopAllPopupAsync();
						await DisplayAlert("", "Invalid User ID", "Ok");
						return;
					}

				}
			}
			catch (Exception ex)
			{
				DisplayAlert("", "Something went to worng\n" + ex.Message , "Ok");
				await Navigation.PopAllPopupAsync();
				return;
			}
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