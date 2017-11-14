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
using Thinkdocotor.Models;
using ThinkDoctor;
using Xamarin.Forms;


namespace Thinkdocotor
{
    public class LoginPage : CustomPageWithGradient
    {
        Label Lor;
        Entry uname, pasw;
        Button loginbtn;
		StackLayout main;
		UnderlineLabel singuplabel, forgotPasswordlbl;
        Image logoImage;
        CustomFrame Funame, Fpasw;
        StackLayout stkbtnforgot, stkarrangereg;

        //Grid gridMain, gridSplash;
        //Image imgSplash, imgSplash1;

        double widthAlloc, heightAlloc;
        public LoginPage()
        {
            //StartColor = Color.FromHex("#ffffff");
            //EndColor = Color.FromHex("#146068");

            StartColor = Color.FromHex("#3a527d");
            EndColor = Color.FromHex("#24334e");

            //BackgroundColor = Color.White;

            //gridMain = new Grid();
            //gridMain.HorizontalOptions = LayoutOptions.Fill;
            //gridMain.VerticalOptions = LayoutOptions.Fill;

            //gridSplash = new Grid();
            //gridSplash.HorizontalOptions = LayoutOptions.Fill;
            //gridSplash.VerticalOptions = LayoutOptions.Fill;
            //gridSplash.BackgroundColor = Color.White;
            //gridSplash.RowDefinitions.Add (new RowDefinition { Height = GridLength.Star });
            //gridSplash.RowDefinitions.Add (new RowDefinition { Height = GridLength.Star });

            //imgSplash = new Image();
            //imgSplash.Source = "logo1.png";
            //imgSplash.VerticalOptions = LayoutOptions.End;
            //gridSplash.Children.Add(imgSplash,0,0);

            //imgSplash1 = new Image();
            //imgSplash1.Source = "ThinkdoctorLogo.png";
            //imgSplash1.VerticalOptions = LayoutOptions.Start;
            //gridSplash.Children.Add(imgSplash1,0,1);

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new LoginViewModel();

            #region Phone Design
            if (Device.Idiom == TargetIdiom.Phone)
            {
                #region logo
                logoImage = new Image();
                logoImage.HorizontalOptions = LayoutOptions.Fill;
                logoImage.VerticalOptions = LayoutOptions.Fill;
                //logoImage.WidthRequest = 120;
                //logoImage.HeightRequest = 120;
                logoImage.Source = "ThinkdoctorLogo.png";
                logoImage.Aspect = Aspect.AspectFit;
                logoImage.Margin = Device.OnPlatform(new Thickness(0, 20, 0, 0), new Thickness(0, 10, 0, 0), new Thickness(0, 10, 0, 0));
                #endregion

                #region Username 
                uname = new MyEntry
                {
                    Placeholder = "Username",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry)),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,
                    PlaceholderColor = Color.WhiteSmoke,
                    TextColor = Color.White,
                    Keyboard = Keyboard.Text,
                };
                uname.SetBinding(MyEntry.TextProperty, "Username");

                IconView lbluserimg = new IconView
                {
                    Source = "usericon.png",
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                    BackgroundColor = Color.Transparent,
                    Foreground = Color.White
                };

                StackLayout stkFuname = new StackLayout();
                stkFuname.Orientation = StackOrientation.Horizontal;
                stkFuname.HorizontalOptions = LayoutOptions.FillAndExpand;
                stkFuname.Padding = 2;
                stkFuname.Children.Add(lbluserimg);
                stkFuname.Children.Add(uname);

                var semiTransparentColor = new Color(0, 0, 0, 0.05);
                Funame = new CustomFrame
                {
                    Content = stkFuname,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,//---------------------------------------------/////
                    Padding = new Thickness(10, 7, 0, 7),
                    Margin = new Thickness(2, 0),
                    OutlineColor = Color.White,
                    BorderRadius = 5,
                    BackgroundColor = semiTransparentColor,
                };
                #endregion

                #region Password 
                pasw = new MyEntry
                {
                    Placeholder = "Password",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry)),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Color.White,
                    IsPassword = true,
                    PlaceholderColor = Color.WhiteSmoke,
                    Keyboard = Keyboard.Text,
                };
                pasw.SetBinding(MyEntry.TextProperty, "Password");

                Image lblpasimg = new Image
                {
                    Source = "iconpasw.png",
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center
                };

                StackLayout stkFpasw = new StackLayout();
                stkFpasw.Orientation = StackOrientation.Horizontal;
                stkFpasw.HorizontalOptions = LayoutOptions.FillAndExpand;
                stkFpasw.Padding = 2;
                stkFpasw.Children.Add(lblpasimg);
                stkFpasw.Children.Add(pasw);


                Fpasw = new CustomFrame
                {
                    Content = stkFpasw,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,//---------------------------------------------/////
                    Padding = new Thickness(10, 7, 0, 7),
                    Margin = new Thickness(2, 0),
                    OutlineColor = Color.White,
                    BorderRadius = 5,
                    BackgroundColor = semiTransparentColor,
                };
                #endregion

                #region Forgot Password
                forgotPasswordlbl = new UnderlineLabel
                {
                    Text = "Forgot Password?",
                    Margin = new Thickness(5, 0, 0, 0),
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    TextColor = Color.FromRgb(31, 210, 155),
                    HorizontalOptions = LayoutOptions.Start
                };

                var tapLforget = new TapGestureRecognizer();
                tapLforget.SetBinding(TapGestureRecognizer.CommandProperty, "DoForgotPassword");
                //tapLforget.Tapped += TapLforget_Tapped;
                forgotPasswordlbl.GestureRecognizers.Add(tapLforget);
                #endregion

                #region Login Button
                loginbtn = new Button
                {
                    Text = "Login",
                    BackgroundColor = AppStyles.btnColor,
                    TextColor = Color.White,
                    BorderWidth = 1,
                    BorderRadius = 5,
                    BorderColor = AppStyles.btnColor,
                    //Style = (Style)Application.Current.Resources["CPButton"],
                    //FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,
                    Margin = Device.OnPlatform(new Thickness(2, 0), 0, 0),
                };
                loginbtn.SetBinding(Button.CommandProperty, "DoLogin");
                //loginbtn.Clicked += loginbtn_Clicked;
                #endregion

                #region Signup
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
                    Text = "Signup",

                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    TextColor = AppStyles.btnColor,
                    //HorizontalOptions = LayoutOptions.StartAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,

                };
                var tapreg = new TapGestureRecognizer();
                tapreg.SetBinding(TapGestureRecognizer.CommandProperty, "DoRegister");
                //tapreg.Tapped += Regbtn_Clicked;
                singuplabel.GestureRecognizers.Add(tapreg);
                #endregion


                stkbtnforgot = new StackLayout();
                stkbtnforgot.Orientation = StackOrientation.Vertical;
                stkbtnforgot.HorizontalOptions = LayoutOptions.FillAndExpand;
                stkbtnforgot.VerticalOptions = LayoutOptions.Center;//---------------------------------------------/////
                stkbtnforgot.Spacing = 7;
                stkbtnforgot.Children.Add(loginbtn);
                stkbtnforgot.Children.Add(forgotPasswordlbl);

                StackLayout stkbtnreg = new StackLayout();
                stkbtnreg.Orientation = StackOrientation.Horizontal;
                stkbtnreg.HorizontalOptions = LayoutOptions.CenterAndExpand;
                stkbtnreg.VerticalOptions = LayoutOptions.Start;
                stkbtnreg.Children.Add(Lor);
                stkbtnreg.Children.Add(singuplabel);

                Image drwline = new Image
                {
                    Source = "line.png",
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };

                stkarrangereg = new StackLayout();
                stkarrangereg.Orientation = StackOrientation.Vertical;
                stkarrangereg.HorizontalOptions = LayoutOptions.FillAndExpand;
                stkarrangereg.VerticalOptions = LayoutOptions.EndAndExpand;
                stkarrangereg.Spacing = 2;
                stkarrangereg.Children.Add(drwline);
                stkarrangereg.Children.Add(stkbtnreg);
            }
            #endregion
            #region Tablet Design
            else
            {
                #region logo
                logoImage = new Image();
                logoImage.HorizontalOptions = LayoutOptions.Center;
                logoImage.VerticalOptions = LayoutOptions.Center;
                //logoImage.WidthRequest = 150;
                //logoImage.HeightRequest = 150;
                logoImage.Source = "ThinkdoctorLogo.png";
                logoImage.Aspect = Aspect.AspectFit;
                logoImage.Margin = Device.OnPlatform(new Thickness(0, 20, 0, 0), new Thickness(0, 10, 0, 0), new Thickness(0, 10, 0, 0));
                #endregion

                #region Username 
                uname = new MyEntry
                {
                    Placeholder = "Username",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,
                    PlaceholderColor = Color.WhiteSmoke,
                    TextColor = Color.White,
                    Keyboard = Keyboard.Text,
                };
                uname.SetBinding(MyEntry.TextProperty, "Username");

                Image lbluserimg = new Image
                {
                    Source = "usericon.png",
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center
                };

                StackLayout stkFuname = new StackLayout();
                stkFuname.Orientation = StackOrientation.Horizontal;
                stkFuname.HorizontalOptions = LayoutOptions.FillAndExpand;
                stkFuname.Padding = 2;
                stkFuname.Children.Add(lbluserimg);
                stkFuname.Children.Add(uname);

                var semiTransparentColor = new Color(0, 0, 0, 0.05);
                Funame = new CustomFrame
                {
                    Content = stkFuname,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,//---------------------------------------------/////
                    Padding = new Thickness(10, 7, 0, 7),
                    Margin = new Thickness(2, 0),
                    OutlineColor = Color.White,
                    BorderRadius = 5,
                    BackgroundColor = semiTransparentColor,
                    //WidthRequest = 100
                };
                #endregion

                #region Password 
                pasw = new MyEntry
                {
                    Placeholder = "Password",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Color.White,
                    IsPassword = true,
                    PlaceholderColor = Color.WhiteSmoke,
                    Keyboard = Keyboard.Text,
                };
                pasw.SetBinding(MyEntry.TextProperty, "Password");

                Image lblpasimg = new Image
                {
                    Source = "iconpasw.png",
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center
                };

                StackLayout stkFpasw = new StackLayout();
                stkFpasw.Orientation = StackOrientation.Horizontal;
                stkFpasw.HorizontalOptions = LayoutOptions.FillAndExpand;
                stkFpasw.Padding = 2;
                stkFpasw.Children.Add(lblpasimg);
                stkFpasw.Children.Add(pasw);


                Fpasw = new CustomFrame
                {
                    Content = stkFpasw,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,//---------------------------------------------/////
                    Padding = new Thickness(10, 7, 0, 7),
                    Margin = new Thickness(2, 0),
                    OutlineColor = Color.White,
                    BorderRadius = 5,
                    BackgroundColor = semiTransparentColor,
                    //WidthRequest = 100
                };
                #endregion

                #region Forgot Password
                forgotPasswordlbl = new UnderlineLabel
                {
                    Text = "Forgot Password?",
                    Margin = new Thickness(5, 0, 0, 0),
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    TextColor = Color.FromRgb(31, 210, 155),
                    HorizontalOptions = LayoutOptions.Start
                };

                var tapLforget = new TapGestureRecognizer();
                tapLforget.SetBinding(TapGestureRecognizer.CommandProperty, "DoForgotPassword");
                //tapLforget.Tapped += TapLforget_Tapped;
                forgotPasswordlbl.GestureRecognizers.Add(tapLforget);
                #endregion

                #region Login Button
                loginbtn = new Button
                {
                    Text = "Login",
                    BackgroundColor = AppStyles.btnColor,
                    TextColor = Color.White,
                    BorderWidth = 1,
                    BorderRadius = 5,
                    BorderColor = AppStyles.btnColor,
                    //Style = (Style)Application.Current.Resources["CPButton"],
                    //FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,
                    Margin = Device.OnPlatform(new Thickness(2, 0), 0, 0),
                    //WidthRequest = 100
                };
                loginbtn.SetBinding(Button.CommandProperty, "DoLogin");
                //loginbtn.Clicked += loginbtn_Clicked;
                #endregion

                #region Signup
                Lor = new Label
                {
                    Text = "Don't have account yet? ",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    TextColor = Color.White,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.CenterAndExpand,

                };
                singuplabel = new UnderlineLabel
                {
                    Text = "Signup",

                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    TextColor = AppStyles.btnColor,
                    //HorizontalOptions = LayoutOptions.StartAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,

                };
                var tapreg = new TapGestureRecognizer();
                tapreg.SetBinding(TapGestureRecognizer.CommandProperty, "DoRegister");
                //tapreg.Tapped += Regbtn_Clicked;
                singuplabel.GestureRecognizers.Add(tapreg);
                #endregion


                stkbtnforgot = new StackLayout();
                stkbtnforgot.Orientation = StackOrientation.Vertical;
                stkbtnforgot.HorizontalOptions = LayoutOptions.FillAndExpand;
                stkbtnforgot.VerticalOptions = LayoutOptions.Center;//---------------------------------------------/////
                stkbtnforgot.Spacing = 7;
                stkbtnforgot.Children.Add(loginbtn);
                stkbtnforgot.Children.Add(forgotPasswordlbl);

                StackLayout stkbtnreg = new StackLayout();
                stkbtnreg.Orientation = StackOrientation.Horizontal;
                stkbtnreg.HorizontalOptions = LayoutOptions.CenterAndExpand;
                stkbtnreg.VerticalOptions = LayoutOptions.Start;
                stkbtnreg.Children.Add(Lor);
                stkbtnreg.Children.Add(singuplabel);

                Image drwline = new Image
                {
                    Source = "line.png",
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };

                stkarrangereg = new StackLayout();
                stkarrangereg.Orientation = StackOrientation.Vertical;
                stkarrangereg.HorizontalOptions = LayoutOptions.FillAndExpand;
                stkarrangereg.VerticalOptions = LayoutOptions.EndAndExpand;
                stkarrangereg.Spacing = 2;
                stkarrangereg.Children.Add(drwline);
                stkarrangereg.Children.Add(stkbtnreg);
            }
            #endregion


            main = new StackLayout
			{
				Padding = new Thickness(10,10,10,10),

                Children = {
                    //logoImage,
                    Funame,
                    Fpasw,
                    stkbtnforgot,
                    stkarrangereg
                }
            };
            if(Device.Idiom == TargetIdiom.Phone)
            {
                main.Spacing = 15;
            }
            else
            {
                main.Spacing = 20;
            }

            //gridMain.Children.Add(main);
            //gridMain.Children.Add(gridSplash);

            //var logoHeight = Math.Ceiling((double)heightAlloc / 3);
            //var remainingHeight = heightAlloc - logoHeight;

            Grid grid_main = new Grid();
            grid_main.HorizontalOptions = LayoutOptions.Fill;
            grid_main.VerticalOptions = LayoutOptions.Fill;
            grid_main.Padding = new Thickness(10, 10);
            if(Device.Idiom == TargetIdiom.Phone)
            {
                grid_main.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.3, GridUnitType.Star) });
                grid_main.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.7, GridUnitType.Star) });
            }
            else
            {
                grid_main.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.4, GridUnitType.Star) });
                grid_main.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.6, GridUnitType.Star) });
                grid_main.Padding = new Thickness(75, 20, 75, 20);
            }

            grid_main.Children.Add(logoImage, 0, 0);
            grid_main.Children.Add(main, 0, 1);

            //var scroll = new ScrollView();
			//scroll.Content = grid_main;
			Content = grid_main;
        }

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);

			widthAlloc = width;
			heightAlloc = height;
		}

		protected override async void OnAppearing()
		{
            SubscribeToMessages();
			base.OnAppearing();

            var isConnected = CrossConnectivity.Current.IsConnected;
            if (isConnected == false)
            {
                ChkCon check_connection = new ChkCon();
                await App.Current.MainPage.Navigation.PushPopupAsync(check_connection);
                await check_connection.PageClosedTask;

                return;
            }
            await AppStyles.countries_list();

            //if (Device.RuntimePlatform == Device.iOS)
            //{
            //    //int[] margin = ScreenSize.MarginSizeIOS(widthAlloc, heightAlloc);
            //    //main.Margin = new Thickness(margin[0], margin[1], margin[2], margin[3]);
            //    //int spacing = ScreenSize.SpacingSizeIOS(widthAlloc, heightAlloc);
            //    //main.Spacing = spacing;

            //    //if (logoImage.Height > 200)
            //    //{
            //    //    //logoImage.HeightRequest = 200;
            //    //    //logoImage.WidthRequest = 200;
            //    //    uname.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Entry));
            //    //    pasw.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Entry));
            //    //}
            //}
            //else if (Device.RuntimePlatform == Device.Android)
            //{
            //    //int[] margin = ScreenSize.MarginSizeANDROID(widthAlloc, heightAlloc);
            //    //main.Margin = new Thickness(margin[0], margin[1], margin[2], margin[3]);
            //    //int spacing = ScreenSize.SpacingSizeANDOID(widthAlloc, heightAlloc);
            //    //main.Spacing = spacing;
            //}

            ////await Task.Delay(2000);
            ////await Task.WhenAll(
            ////	gridSplash.FadeTo(0,2000),
            ////	imgSplash1.FadeTo(0,500),
            ////	imgSplash.ScaleTo(10,2000)
            ////);
        }
        private void  SubscribeToMessages()

        {

            MessagingCenter.Subscribe<NavigationMessage>(this, eNavigationMessage.ShowTargetView.ToString(), async (navigationMessage) =>

            {
                if(navigationMessage.ViewName=="Username")
                {
                    if (string.IsNullOrEmpty(navigationMessage.Parameter))

                    {
                       
                        if (!Funame.AnimationIsRunning("TranslateTo"))
                        {
                            await Funame.TranslateTo(-10, 0, 100);
                            await Funame.TranslateTo(10, 0, 100);
                            await Funame.TranslateTo(0, 0, 100);
                            return;
                        }



                    }

                }
                else if (navigationMessage.ViewName == "Password")
                {
                    if (string.IsNullOrEmpty(navigationMessage.Parameter))

                    {

                        if (!Fpasw.AnimationIsRunning("TranslateTo"))
                        {
                            await Fpasw.TranslateTo(-10, 0, 100);
                            await Fpasw.TranslateTo(10, 0, 100);
                            await Fpasw.TranslateTo(0, 0, 100);
                            return;
                        }


                    }

                }


                    
               

            });

        }
     
        private void UnsubscribeFromMessages()

        {

            MessagingCenter.Unsubscribe<NavigationMessage>(this, eNavigationMessage.ShowTargetView.ToString());

        }
        protected override void OnDisappearing()

        {

            UnsubscribeFromMessages();

            base.OnDisappearing();

        }
       
    }
}
