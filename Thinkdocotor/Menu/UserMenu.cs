using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ThinkDoctor.Menu
{
	public class UserMenu : ContentPage
	{
		public StackLayout optHome { get { return stack_Home; } }
		public StackLayout optAccounts { get { return stack_Accounts; } }
		public StackLayout optSearch { get { return stack_Search; } }
		public StackLayout optDiary { get { return stack_Diary; } }
		public StackLayout optSettings { get { return stack_Settings; } }
        //public StackLayout optLogout { get { return stack_Logout; } }
        public StackLayout optLogout { get { return stlog; } }

        StackLayout stlog, stack_userInfo, stack_options, stack_Home, stack_Accounts, stack_Search, stack_Diary, stack_Settings, stack_Logout;

		Label lblName, lblMPname;
		RoundImage img_person;

		public UserMenu()
		{
			#region Person Info
			img_person = new RoundImage();
			img_person.Source = "userdefault.png";
			img_person.HorizontalOptions = LayoutOptions.Center;
			img_person.VerticalOptions = LayoutOptions.Center;
			img_person.HeightRequest = 100;
			img_person.WidthRequest = 100;
			img_person.Aspect = Aspect.AspectFill;

			lblName = new Label();
			lblName.Text = "Dr. Rakesh Mehta";
			lblName.TextColor = MPConsts.menuForecolor;
			lblName.HorizontalOptions = LayoutOptions.Center;
			lblName.VerticalOptions = LayoutOptions.Center;
			lblName.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));

            lblMPname = new Label();
            lblMPname.Text = "(Medical Practice Name)";
            lblMPname.TextColor = MPConsts.menuForecolor;
            lblMPname.HorizontalOptions = LayoutOptions.Center;
            lblMPname.VerticalOptions = LayoutOptions.Center;
            lblMPname.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            lblMPname.FontAttributes = FontAttributes.Italic;

            stack_userInfo = new StackLayout();
            stack_userInfo.BackgroundColor = Color.FromRgb(44, 45, 47);
            stack_userInfo.HorizontalOptions = LayoutOptions.Fill;
            stack_userInfo.VerticalOptions = LayoutOptions.Start;
            stack_userInfo.Orientation = StackOrientation.Vertical;
            stack_userInfo.Padding = new Thickness(5);

            stack_userInfo.Children.Add(img_person);
            stack_userInfo.Children.Add(lblName);
          //  stack_userInfo.Children.Add(lblMPname);
            #endregion

            #region Main Options

            stack_Home = stackOptions("arrowNxt.png", "Home");
            stack_Diary = stackOptions("arrowNxt.png", "Diary");
            stack_Search = stackOptions("arrowNxt.png", "Create Slots");
            stack_Settings = stackOptions("arrowNxt.png", "Settings");
            stack_Accounts = stackOptions("arrowNxt.png", "Add Hospital/Clinic");
            stack_Logout = stackLogout("logout_menu.png");
            //stack_Logout = stackOptions("logout.png", "Logout");

            stack_options = new StackLayout();
			stack_options.VerticalOptions = LayoutOptions.Fill;
			stack_options.HorizontalOptions = LayoutOptions.Fill;
			stack_options.Padding = new Thickness(0);
			stack_options.Spacing = 1;
			stack_options.Children.Add(stack_Home);
			stack_options.Children.Add(stack_Diary);
			stack_options.Children.Add(stack_Search);
			stack_options.Children.Add(stack_Accounts);
            stack_options.Children.Add(stack_Settings);
           
			
			#endregion

			#region Menu Container

			StackLayout stack_main = new StackLayout();
            
			stack_main.VerticalOptions = LayoutOptions.Fill;
			stack_main.HorizontalOptions = LayoutOptions.Fill;
            stack_main.BackgroundColor = Color.White;
			stack_main.Spacing = 1;
			stack_main.Children.Add(stack_userInfo);
			stack_main.Children.Add(stack_options);
            stack_main.Children.Add(stack_Logout);

            #endregion

            Padding = new Thickness(0,40,0,0);
			Icon = "hamburger.png";
			Title = "Menu";
            //BackgroundColor = MPConsts.AppBGColor;
            BackgroundColor = Color.FromHex("3A527C");
			Content = new ScrollView
			{
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.Fill,
				Content = stack_main
			};
		}

		private StackLayout stackOptions(string imgsrc, string lblt)
		{
			StackLayout stoptions = new StackLayout();
			stoptions.StyleId = lblt;
			stoptions.BackgroundColor = MPConsts.menuBGcolor;
			stoptions.HorizontalOptions = LayoutOptions.Fill;
			stoptions.VerticalOptions = LayoutOptions.Start;
			stoptions.Orientation = StackOrientation.Horizontal;
			stoptions.Padding = new Thickness(15,6,6,6);
            stoptions.Spacing = 4;

			Image imgOptions = new Image();
			imgOptions.Source = imgsrc;
			imgOptions.HorizontalOptions = LayoutOptions.Center;
			imgOptions.VerticalOptions = LayoutOptions.Center;
			imgOptions.HeightRequest = 25;
			imgOptions.WidthRequest = 25;

			Label lblOptions = new Label();
			lblOptions.Text = lblt;
			lblOptions.TextColor = MPConsts.menuForecolor;
			lblOptions.HorizontalOptions = LayoutOptions.Center;
			lblOptions.VerticalOptions = LayoutOptions.Center;
			lblOptions.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));

			stoptions.Children.Add(imgOptions);
			stoptions.Children.Add(lblOptions);

			return stoptions;
		}

        private StackLayout stackLogout(string imgsrc)
        {
            StackLayout stoptions = new StackLayout();
            stoptions.StyleId = "Logout";
            stoptions.BackgroundColor = MPConsts.menuBGcolor;
            stoptions.HorizontalOptions = LayoutOptions.Fill;
            stoptions.VerticalOptions = LayoutOptions.FillAndExpand;
            stoptions.Orientation = StackOrientation.Horizontal;
            stoptions.Padding = new Thickness(5);
            stoptions.Spacing = 0;
            //stoptions.Margin = new Thickness(0,10,0,0);

            stlog = new StackLayout();
            stlog.BackgroundColor = Color.Transparent;
            stlog.HorizontalOptions = LayoutOptions.CenterAndExpand;
            stlog.VerticalOptions = LayoutOptions.End;
            stlog.Orientation = StackOrientation.Vertical;
            stlog.Padding = new Thickness(0);
            stlog.Spacing = 0;

            RoundImage imgOptions = new RoundImage();
            imgOptions.Source = imgsrc;
            imgOptions.HorizontalOptions = LayoutOptions.Center;
            imgOptions.VerticalOptions = LayoutOptions.Center;
            imgOptions.HeightRequest = 32;
            imgOptions.WidthRequest = 32;

            Label lblOptions = new Label();
            lblOptions.Text = "Logout";
            lblOptions.TextColor = MPConsts.menuForecolor;
            lblOptions.HorizontalOptions = LayoutOptions.Center;
            lblOptions.VerticalOptions = LayoutOptions.Center;
            lblOptions.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));


            stlog.Children.Add(imgOptions);
            stlog.Children.Add(lblOptions);
            stoptions.Children.Add(stlog);

            return stoptions;
        }

        //void Tap_Home_Tapped(object sender, EventArgs e)
        //{
        //	DisplayAlert("Selected", "Home", "OK");
        //}

        //void Tap_Calendar_Tapped(object sender, EventArgs e)
        //{
        //	DisplayAlert("Selected", "Calendar", "OK");
        //}

        //void Tap_Dashboard_Tapped(object sender, EventArgs e)
        //{
        //	DisplayAlert("Selected", "Dashboard", "OK");
        //}

        //void Tap_Patients_Tapped(object sender, EventArgs e)
        //{
        //	DisplayAlert("Selected", "Patients", "OK");
        //}

        //void Tap_Recommendations_Tapped(object sender, EventArgs e)
        //{
        //	DisplayAlert("Selected", "Recommendations", "OK");
        //}

        //void Tap_Website_Tapped(object sender, EventArgs e)
        //{
        //	DisplayAlert("Selected", "Website", "OK");
        //}

        //void Tap_Settings_Tapped(object sender, EventArgs e)
        //{
        //	DisplayAlert("Selected", "Settings", "OK");
        //}

        //void Tap_Logout_Tapped(object sender, EventArgs e)
        //{
        //	DisplayAlert("Selected", "Logout", "OK");
        //}
    }
}

