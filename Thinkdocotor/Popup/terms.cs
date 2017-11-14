using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using ThinkDoctor;
using Xamarin.Forms;

namespace Thinkdocotor
{
	public class terms : PopupPage
	{
		
		Button btncontinue,btnno;
        StackLayout main;
        WebView webView;
        Label labelLoading;
		ProgressBar loadingpage;

		public Task PageClosedTask
        {
            get
            {
                return tcs.Task;
            }
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

		public terms()
		{
			tcs = new System.Threading.Tasks.TaskCompletionSource<bool>();

			Label heading = new Label();
			heading.Text = "Terms & Conditions";
			heading.FontSize = 20;
			heading.TextColor = Color.Black;
			heading.HorizontalOptions = LayoutOptions.CenterAndExpand;

			BoxView bxh1 = new BoxView();
			bxh1.Color = Color.Gray;
			bxh1.WidthRequest = 10;
			bxh1.HeightRequest = 1;
		    

			//Loading label should not render by default.
			labelLoading = new Label() { Text = "Loading...", IsVisible = true, TextColor = Color.Green };
			loadingpage = new ProgressBar
			{
				Progress=0.3,
				HorizontalOptions=LayoutOptions.FillAndExpand,
				IsVisible=true,
			};


	        webView = new WebView() { HeightRequest = 1000, WidthRequest = 1000, Source = "https://coraltechnologies.co.uk/apk/terms/index.html" };
	        webView.Navigated += webviewNavigated;
	        webView.Navigating += webviewNavigating;

            var layout = new StackLayout();
            layout.Children.Add(loadingpage);
	        layout.Children.Add(webView);

			Label des = new Label();
			des.Text = "test";
			des.FontSize = 12;
			des.TextColor = Color.Black;
			des.HorizontalTextAlignment = TextAlignment.Start;
			des.HorizontalOptions = LayoutOptions.Start;






		

			StackLayout mainfeature = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 5,
				Children =
				{
					layout
				}
			};

			BoxView bxh2 = new BoxView();
			bxh2.Color = Color.Gray;
            bxh2.WidthRequest = Config.mainFont;
			bxh2.HeightRequest = 1;


			btnno = new Button
			{
				Text = "Ok",
				TextColor = Color.White,
				BackgroundColor = Color.FromHex(Config.concolor),
                FontFamily = Device.OnPlatform(Config.fontfamliyios, Config.fontfamliyandroid, null),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
			btnno.Clicked += btnno_Clicked;

			btncontinue = new Button
			{
				Text = "Accept",
				// Style = (Style)Application.Current.Resources["CPButton"],
				TextColor = Color.White,
                BackgroundColor =Color.FromHex( Config.concolor),

                FontFamily = Device.OnPlatform(Config.fontfamliyios,Config.fontfamliyandroid,null),
                FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
			btncontinue.Clicked += btncontinue_Clicked;

			StackLayout stkhr = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Children =
				{
			        btnno
				}
			};

			StackLayout stkmain = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.Fill,
				Spacing = 10,
				Children =
				{
			        heading,bxh1,mainfeature,bxh2,stkhr
				}
			};

			Frame Fmain = new Frame
			{
				Content = stkmain,
				OutlineColor = Color.White,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Padding = new Thickness(20),
				BackgroundColor = Color.White,
				HasShadow = true
			};

			main = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.Center,
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
				Margin=20,
				Children = {
					main
				}
			};
		}

		protected async  override void OnAppearing()
		{
			base.OnAppearing();
			await loadingpage.ProgressTo(0.9, 900, Easing.CubicIn);
		}

        async void btnno_Clicked(object sender, EventArgs e)
		{
            await Navigation.PopAllPopupAsync();
		}

		async void btncontinue_Clicked(object sender, EventArgs e)
		{
			Setting.termsSetting = "true";
			await Navigation.PopAllPopupAsync();
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

        void webviewNavigating(object sender, WebNavigatingEventArgs e)
        {
			loadingpage.IsVisible = true;
        }

        /// <summary>
        /// Called when the webview finished navigating. Hides the loading label.
        /// </summary>
        void webviewNavigated(object sender, WebNavigatedEventArgs e)
        {
	        loadingpage.IsVisible =  false;
        }
	}
}

