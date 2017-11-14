using System;
using Thinkdocotor;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class uploadsucc: ContentPage
	{
		Button btncontinue;

		IconView succ;


		public uploadsucc()
		{
				NavigationPage.SetHasNavigationBar(this, false);
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
				BackgroundImage = "Bg.png";
			}

			succ = new IconView
			{
				Source = "succ.png",
				HeightRequest = 100,
				WidthRequest = 100,
				BackgroundColor = Color.Transparent,
				Foreground = Color.FromHex(Config.iconcolor)
			};
			Label succl = new Label
			{
				Text = "Uploaded Successfully",
				TextColor = Color.White,

			};
				StackLayout stksucc = new StackLayout();
				stksucc.Orientation = StackOrientation.Vertical;
				stksucc.HorizontalOptions = LayoutOptions.CenterAndExpand;
				stksucc.VerticalOptions = LayoutOptions.CenterAndExpand;
				stksucc.Children.Add(succ);
				stksucc.Children.Add(succl);
				stksucc.Spacing = 5;
				

			btncontinue  = new Button
			{
				Text = "Continue",
				Margin = new Thickness(20, 0, 20, 0),
				Style = (Style)Application.Current.Resources["CPButton"],
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End,
            };
			btncontinue.Clicked += backprs;
			Content = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Margin=20,
				Spacing=10,
				Children = {

						
						stksucc,btncontinue 
						
						
				}
			};
		}

		void backprs(object sender, EventArgs e)
		{
			Navigation.PopAsync(); 
		}
		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await succ.ScaleTo(1.2, 300);
			await succ.ScaleTo(1, 300);


		}
}
}
