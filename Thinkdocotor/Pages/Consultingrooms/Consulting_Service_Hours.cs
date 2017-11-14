using System;
using System.Net.Http;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using Thinkdocotor;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class Consulting_Service_Hours : ContentPage
	{
		StackLayout mainweeks;

		ScrollView mainweeksscroll;

		consulting_venues cv;
		public Consulting_Service_Hours(consulting_venues consultingvenue)
		{
			cv = consultingvenue;
			//loadjson();
			NavigationPage.SetBackButtonTitle(this, " ");
			NavigationPage.SetHasBackButton(this, false);
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
			Title = "Consulting Hours";
			ToolbarItems.Add(new ToolbarItem("Done", null,backclick));
			NavigationPage.SetHasBackButton(this, false);

			mainweeks = new StackLayout();
			//mainweeks.Spacing = 0;
			//Label l1 = new Label();
			//l1.Text = "Test";
			//mainweeks.Children.Add(l1);
			//this.BackgroundColor = Color.White;
			mainweeksscroll = new ScrollView
			{
				Content = mainweeks
			};

			Content = new StackLayout
			{
				Margin=10,
				Children = {
						mainweeksscroll
				}
			};
		}

		void backclick()
		{
			Navigation.PopAsync(); 
		}


		async public void loadjson()
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
		mainweeks.Children.Clear();
		
		string uri = "http://178.238.139.243/ThinkdocotorApi/api/consulting_hoursApi?userid=1&consulting_id="+cv.id+"";
		var json = await httpclient.GetStringAsync(uri);
		consulting_hours_info responsemain = JsonConvert.DeserializeObject<consulting_hours_info>(json);

		foreach (consulting_hours_details c in responsemain.consulting_hours_details)
		{
			mainweeks.Children.Add(createstk(new consulting_hours_viewmodel(c)));
                    Config.consultinghours = true;
						
		}
		await Navigation.PopAllPopupAsync();
		
	}
	catch (Exception ex)
	{
		DisplayAlert("", "SomthSomething to worng\n" + ex.Message, "Ok");
		await Navigation.PopAllPopupAsync();
		return;
	}
	}
		protected override async void OnAppearing()
		{
			base.OnAppearing();
			loadjson();

		}
		private StackLayout createstk(consulting_hours_viewmodel c)
		{
				
				StackLayout mainlist = new StackLayout();
				mainlist.Spacing = 0;
				mainlist.Orientation = StackOrientation.Vertical;
				mainlist.HorizontalOptions = LayoutOptions.FillAndExpand;
				mainlist.VerticalOptions = LayoutOptions.FillAndExpand;



				StackLayout main = new StackLayout();
				main.BackgroundColor = Color.Transparent;
				main.Orientation = StackOrientation.Horizontal;
				main.HorizontalOptions = LayoutOptions.FillAndExpand;
				main.VerticalOptions = LayoutOptions.FillAndExpand;
				main.Spacing = 0;
				//main.Padding = new Thickness(5);

				StackLayout s1 = new StackLayout();
				s1.Orientation = StackOrientation.Vertical;
				s1.HorizontalOptions = LayoutOptions.FillAndExpand;
				s1.VerticalOptions = LayoutOptions.Center;
				s1.Padding = new Thickness(5,0,0,0);

				Image img = new Image();
				img.HorizontalOptions = LayoutOptions.Center;
				img.VerticalOptions = LayoutOptions.Center;
				img.HeightRequest = 50;
				img.WidthRequest = 50;
				img.BackgroundColor = Color.Transparent;
				img.Aspect = Aspect.AspectFill;
				//img.Source = c.Day_img;
				img.SetBinding(Image.SourceProperty, "Day_img");



				Label l1 = new Label();
				//l1.Text = c.Heading;
				l1.SetBinding(Label.TextProperty, new Binding("Heading"));
				l1.FontSize = 17;
				l1.SetBinding(Label.TextColorProperty, new Binding("Headingcolor"));
					
				
				
				Label l2 = new Label();
				l2.SetBinding(Label.TextProperty, new Binding("Openinghours"));
				l2.FontSize = 12;
				l2.TextColor = Color.White;
				
				

				s1.Children.Add(l1);
				s1.Children.Add(l2);

				Image imgedit = new Image();
				imgedit.HorizontalOptions = LayoutOptions.End;
				imgedit.VerticalOptions = LayoutOptions.Center;
				imgedit.BackgroundColor = Color.Transparent;
				imgedit.Aspect = Aspect.AspectFill;
				imgedit.Source = "editdate.png";

				

				BoxView border = new BoxView();
				border.HeightRequest = 1;
				border.Color=Color.FromHex("#f16725");
				main.Children.Add(img);
				main.Children.Add(s1);
				main.Children.Add(imgedit);

				mainlist.Children.Add(main);
			    mainlist.BindingContext = c;

				var tapbtnedit = new TapGestureRecognizer();
				tapbtnedit.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("editdetails"));
				tapbtnedit.Tapped += Btnedit_Clicked;
				main.GestureRecognizers.Add(tapbtnedit);

				return mainlist;

			
		}

		async void Btnedit_Clicked(object sender, EventArgs e)
		{
			var item = (StackLayout)sender;
			TapGestureRecognizer t = (TapGestureRecognizer)item.GestureRecognizers[0];
			consulting_hours_details consultingtime = (consulting_hours_details)t.CommandParameter;
			Consulting_Service_Hours_edit consentPage = new Consulting_Service_Hours_edit(consultingtime);
			await Navigation.PushAsync(consentPage);
			return;
		}
	}
}

