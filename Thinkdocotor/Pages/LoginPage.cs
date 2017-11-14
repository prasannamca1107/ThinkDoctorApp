using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using Thinkdocotor;
using Thinkdocotor.Models;
using Xamarin.Forms;


namespace ThinkDoctor
{
    public class LoginPage : ContentPage
    {
        Label cap,Lor, Lforget;
      
        Entry uname, pasw,Uniquecode,Gmcno;
        Button loginbtn, regbtn;
		int left, right, top, bottom;

		double widthAlloc,heightAlloc;
		StackLayout main;
		private string uri = "http://178.238.139.243/ThinkdocotorApi/api/DoctorRegsApi";

		UnderlineLabel singuplabel;

		Grid gridMain, gridSplash;
		Image imgSplash, imgSplash1;

		//AutoCompleteView test;
        public LoginPage()
        {


            
            NavigationPage.SetHasNavigationBar(this, false);
        	 
            var logoImage = new Image { WidthRequest = 100, HeightRequest = 100 };
			logoImage.Source = "ThinkdoctorLogo.png";
            // logoImage.Source = ImageSource.FromFile("logo.jpg");
            logoImage.Aspect = Aspect.AspectFit;
			logoImage.Margin = new Thickness(50, 30, 50, 0);
			//logoImage.HorizontalOptions = LayoutOptions.Fill;
			//logoImage.VerticalOptions = LayoutOptions.Center;


			cap = new Label
			{
				Text = "Think Doctor",
				//Style = (Style)Application.Current.Resources["labelColor"],
				TextColor = Color.FromHex("#E8641A"),
				FontSize=40,
				 
				FontAttributes=FontAttributes.Bold,
                HorizontalOptions=LayoutOptions.Center,
                VerticalOptions=LayoutOptions.CenterAndExpand ,
               

            };





			Uniquecode = new MyEntry
			{
				Placeholder = "User Id",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				PlaceholderColor = Color.WhiteSmoke,
				TextColor=Color.White,
				Keyboard = Keyboard.Text,

			};

			Image  lbluserimg = new Image
			{

				Source="usericon.png",
				HorizontalOptions = LayoutOptions.Start,


			};


			StackLayout stkFuname = new StackLayout();
			stkFuname.Orientation = StackOrientation.Horizontal;
			stkFuname.HorizontalOptions = LayoutOptions.FillAndExpand;
			stkFuname.Children.Add(lbluserimg);
			stkFuname.Children.Add(Uniquecode);

			var semiTransparentColor = new Color(0, 0, 0, 0.05);
			CustomFrame Funame = new CustomFrame
			{
				Content = stkFuname,

				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(10, 13, 0, 13),
				OutlineColor = Color.White,
				BorderRadius=20,

				BackgroundColor = semiTransparentColor,
				//Margin = new Thickness(17, 1, 17, 1),
				// VerticalOptions = LayoutOptions.CenterAndExpand,
				//HorizontalOptions = LayoutOptions.Center
			};








			pasw = new MyEntry
			{
				Placeholder = "Password",
			//	Text = Setting.UsernameSettings,
				//TextColor=Color.FromHex(Configuration.maincolor),
				//FontFamily = Device.OnPlatform(Configuration.fontfamliyios, Configuration.fontfamliyandroid, "Droid Sans Mono"),
				//FontSize = Configuration.mainFont,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				TextColor=Color.White,
				 IsPassword=true ,
				PlaceholderColor = Color.WhiteSmoke,
				Keyboard = Keyboard.Text,

			};
			Image lblpasimg = new Image
			{

				Source="iconpasw.png",
				HorizontalOptions = LayoutOptions.Start,


			};


		StackLayout stkFpasw = new StackLayout();
		stkFpasw.Orientation = StackOrientation.Horizontal;
		stkFpasw.HorizontalOptions = LayoutOptions.FillAndExpand;
		stkFpasw.Children.Add(lblpasimg);
		stkFpasw.Children.Add(pasw);


		CustomFrame Fpasw = new CustomFrame
		{
			Content = stkFpasw,
			HorizontalOptions = LayoutOptions.FillAndExpand,
			Padding = new Thickness(10, 13, 0, 13),
			OutlineColor = Color.White,
			BorderRadius = 20,
			BackgroundColor = semiTransparentColor,
		};



			Lforget = new Label
			{
				Text = "Cannot access your account?",
				Margin = new Thickness(0, 0, 20, 0),
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.Start

               

            };
			  var tapLforget = new TapGestureRecognizer();
			tapLforget.Tapped += TapLforget_Tapped;
			Lforget.GestureRecognizers.Add(tapLforget);
            loginbtn = new Button
			{
				Text = "Signin",
				Style = (Style)Application.Current.Resources["CPButton"],
				//Margin = new Thickness(40, 0, 40, 0),

				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
               
            };
			Lor = new Label
			{
				Text = "Don't have account yet? ",
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,

            };
			singuplabel = new UnderlineLabel
			{
				Text = "SignUp",

				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				TextColor = Color.FromRgb(31, 210, 155),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				    

            };
		var tapreg = new TapGestureRecognizer();
		tapreg.Tapped += Regbtn_Clicked;
		singuplabel.GestureRecognizers.Add(tapreg);
		
            regbtn  = new Button
            {
                Text = "SignUp",
				Margin = new Thickness(20, 0, 20, 0),
                  Style = (Style)Application.Current.Resources["CPButton"],
                FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };




		regbtn.Clicked += Regbtn_Clicked;
		loginbtn.Clicked += loginbtn_Clicked;
		StackLayout stkbtnforgot = new StackLayout();
		stkbtnforgot.Orientation = StackOrientation.Vertical;
		stkbtnforgot.HorizontalOptions = LayoutOptions.FillAndExpand;
		stkbtnforgot.Spacing = 7;
		stkbtnforgot.Children.Add(loginbtn);
		stkbtnforgot.Children.Add(Lforget);




		StackLayout stkbtnreg = new StackLayout();
		stkbtnreg.Orientation = StackOrientation.Horizontal;
		stkbtnreg.HorizontalOptions = LayoutOptions.CenterAndExpand;
		stkbtnreg.Children.Add(Lor);
		stkbtnreg.Children.Add(singuplabel);





		Image drwline = new Image
		{

			Source = "line.png",
			HorizontalOptions = LayoutOptions.CenterAndExpand
		};


			StackLayout stkarrangereg = new StackLayout();
			stkarrangereg.Orientation = StackOrientation.Vertical;
			stkarrangereg.HorizontalOptions = LayoutOptions.FillAndExpand;
			stkarrangereg.VerticalOptions = LayoutOptions.EndAndExpand;
			stkarrangereg.Spacing = 2;
			stkarrangereg.Children.Add(drwline);
			stkarrangereg.Children.Add(stkbtnreg);
            Title = "Back";

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
	
			main = new StackLayout
			{
				Spacing = 0,
				Padding = 0,

                Children = {
                    logoImage,Funame,Fpasw,stkbtnforgot,stkarrangereg

                }
            };

		


			var scroll=new ScrollView ();
			scroll.Content = main;
			Content = scroll;
        }






		protected override void OnSizeAllocated(double widht, double height)
		{
			base.OnSizeAllocated(widht, height);

			widthAlloc = widht;
			heightAlloc = height;
			OnAppearing();

		}

		protected override async void OnAppearing()
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

		async void loginbtn_Clicked(object sender, EventArgs e)
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
				 if (string.IsNullOrEmpty(Uniquecode.Text))
				{
					DisplayAlert("", "Enter User Id", "Ok");
					//uname.Focus();
					return;
				}
				else if (string.IsNullOrEmpty(pasw.Text))
				{
					DisplayAlert("", "Enter the Password", "Ok");
					//pasw.Focus();
					return;
				}

            Application.Current.MainPage = (new ThinkDoctor.Menu.UserMasterDetailPage());

		 
			//var uid_obj = Uniquecode.Text;
			//var passw_obj = pasw.Text;


			//await Navigation.PushPopupAsync(new popup_pleasewait());
			//var httpclient = new HttpClient();
			//var json = await httpclient.GetStringAsync("http://178.238.139.243/ThinkdocotorApi/api/DoctorRegsApi/"+ uid_obj +"/"+ passw_obj);
			//loginResponse response = JsonConvert.DeserializeObject<loginResponse>(json);
		
				//if (response.Status.ToString() == "success")
				//{
				//	await Navigation.PopAllPopupAsync();
				//	Config.user_Id =Convert.ToInt32(response.Userid);
				//	Application.Current.MainPage = (new ThinkDoctor.Menu.UserMasterDetailPage());
				//	return;
				//}
				//else if (response.Status == "Fail")
				//{
				//	Responseerror reson = JsonConvert.DeserializeObject<Responseerror>(json);
				//	if (reson.Message == "user_not_exits")
				//	{
				//	await Navigation.PopAllPopupAsync();
				//	await DisplayAlert("", "User Not Exits", "Ok");
				//		return;
				//	}
				//	if (reson.Message == "worng_password")
				//	{
				//	await Navigation.PopAllPopupAsync();
				//	await DisplayAlert("", "Password Worng", "Ok");
				//		return;
				//	}
				//	if (reson.Message == "email_not_confirm")
				//	{
				//	await Navigation.PopAllPopupAsync();
				//	await DisplayAlert("", "Account not activate", "Ok");
				//		return;
				//	}
				//}
			
				
			
		}

	

		 async void  TapLforget_Tapped(object sender, EventArgs e)
		{
			Navigation.PushAsync(new forgetpasw());
		}



		private void Regbtn_Clicked(object sender, EventArgs e)
        {
          //Navigation.PushAsync(new  Reg());
        }

    }
}
