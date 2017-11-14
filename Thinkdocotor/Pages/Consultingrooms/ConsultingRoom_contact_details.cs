using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AsNum.XFControls;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Thinkdocotor;

using Thinkdoctor;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class ConsultingRoom_contact_details : ContentPage
	{
		MyEntry tel1Entry,tel2Entry,email1Entry,email2Entry;
		Editor parkdircEntry;

        CustomFrame Ftel1Entry,Ftel2Entry,Femail1Entry,Femail2Entry,FparkdircEntry,Faddroom;

        StackLayout stktel1Entry,stktel2Entry,stkemail1Entry,stkemail2Entry,stkyesno,stkparking,stkparkdircEntry,addroommain;

		RadioGroup r1;
		consulting_venues cv;
		Switch yesno;
        Image imgaddroom;
		private string uri = "http://178.238.139.243/ThinkdocotorApi/api/consulting_venuesApi";
		public ConsultingRoom_contact_details(consulting_venues consulting_venue)
		{
			cv = consulting_venue;
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
			Title = "Contact Details";
			ToolbarItems.Add(new ToolbarItem("Next", Device.OnPlatform("Docotor/Nextpage.png", "Nextpage.png", null),testclick));

			#region tel1
			Label Ltel1 = new Label
			{
				Text = "Tel 1:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			tel1Entry = new MyEntry
			{
				Placeholder = "+123 4567 890",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				PlaceholderColor = Color.Gray,
				Keyboard = Keyboard.Telephone,

			};

			Ftel1Entry = new CustomFrame
			{
				Content = tel1Entry,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};
			tel1Entry.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(tel1Entry.Text))
				{
					Ftel1Entry.OutlineColor = Color.White;
				}
			
			};
			stktel1Entry = new StackLayout();
			stktel1Entry.Orientation = StackOrientation.Vertical;
			stktel1Entry.HorizontalOptions = LayoutOptions.Fill;
			stktel1Entry.Children.Add(Ltel1);
			stktel1Entry.Children.Add(Ftel1Entry);
			stktel1Entry.Spacing = 2;

			#endregion Consulting Room name

			#region tel2
			Label Ltel2 = new Label
			{
				Text = "Tel 2:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			tel2Entry = new MyEntry
			{
				Placeholder = "+123 4567 890",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				PlaceholderColor = Color.Gray,
				Keyboard = Keyboard.Telephone,

			};

			Ftel2Entry = new CustomFrame
			{
				Content = tel2Entry,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};
			tel2Entry.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(tel2Entry.Text))
				{
					Ftel2Entry.OutlineColor = Color.White;
				}
			
			};
			stktel2Entry = new StackLayout();
			stktel2Entry.Orientation = StackOrientation.Vertical;
			stktel2Entry.HorizontalOptions = LayoutOptions.Fill;
			stktel2Entry.Children.Add(Ltel2);
			stktel2Entry.Children.Add(Ftel2Entry);
			stktel2Entry.Spacing = 2;

			#endregion Consulting Room name

			#region email1
			Label Lemail1 = new Label
			{
				Text = "Email 1:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			email1Entry = new MyEntry
			{
				Placeholder = "Email",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				PlaceholderColor = Color.Gray,
				Keyboard = Keyboard.Email,

			};

			Femail1Entry = new CustomFrame
			{
				Content = email1Entry,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};
			email1Entry.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(email1Entry.Text))
				{
					Femail1Entry.OutlineColor = Color.White;
				}
			
			};
			stkemail1Entry = new StackLayout();
			stkemail1Entry.Orientation = StackOrientation.Vertical;
			stkemail1Entry.HorizontalOptions = LayoutOptions.Fill;
			stkemail1Entry.Children.Add(Lemail1);
			stkemail1Entry.Children.Add(Femail1Entry);
			stkemail1Entry.Spacing = 2;

			#endregion Consulting Room name

			#region email2
			Label Lemail2 = new Label
			{
				Text = "Email 2:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			email2Entry = new MyEntry
			{
				Placeholder = "Email 2",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				PlaceholderColor = Color.Gray,
				Keyboard = Keyboard.Email,

			};

			Femail2Entry = new CustomFrame
			{
				Content = email2Entry,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};
			email2Entry.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(email2Entry.Text))
				{
					Femail2Entry.OutlineColor = Color.White;
				}
			
			};
			stkemail2Entry = new StackLayout();
			stkemail2Entry.Orientation = StackOrientation.Vertical;
			stkemail2Entry.HorizontalOptions = LayoutOptions.Fill;
			stkemail2Entry.Children.Add(Lemail2);
			stkemail2Entry.Children.Add(Femail2Entry);
			stkemail2Entry.Spacing = 2;

			#endregion Consulting Room name

			#region disable access

			Label disable = new Label
			{
				Text = "Disable Access(Yes/No):",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			 yesno = new Switch
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,

			};
			yesno.Toggled += switcher_Toggled;

			stkyesno = new StackLayout();
			stkyesno.Orientation = StackOrientation.Vertical;
			stkyesno.HorizontalOptions = LayoutOptions.Fill;
			stkyesno.Children.Add(disable);
			stkyesno.Children.Add(yesno);
			stkyesno.Spacing = 2;

			#endregion disable access

			#region parking
			Label parking = new Label
			{
				Text = "Parking:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			var radioList = new List<string>();
				radioList.Add("None");
				radioList.Add("On Site");
				radioList.Add("Off Road");

			 r1 = new RadioGroup()
			{
				ItemsSource = radioList,
				//TextColor=Color.White,
				Orientation = StackOrientation.Horizontal,
				OnImg = "radioon.png",
				OffImg = "radiooff.png"
			};

			stkparking = new StackLayout();
			stkparking.Orientation = StackOrientation.Vertical;
			stkparking.HorizontalOptions = LayoutOptions.Fill;
			stkparking.Children.Add(parking);
			stkparking.Children.Add(r1);
			stkparking.Spacing = 2;
			#endregion parking

			#region Praking/Direction
			Label Lparkdirc = new Label
			{
				Text = "Praking/Direction:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			parkdircEntry = new Editor
			{
				Text="Praking/Direction",
				TextColor = Color.White,
				BackgroundColor=Color.Transparent ,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Keyboard = Keyboard.Text,
				HeightRequest=75

			};
			parkdircEntry.Focused += editor_Focused;
			parkdircEntry.Unfocused += editor_Unfocused;
			FparkdircEntry = new CustomFrame
			{
				Content = parkdircEntry,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(0),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};
			parkdircEntry.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(parkdircEntry.Text))
				{
					FparkdircEntry.OutlineColor = Color.White;
				}
			
			};
			stkparkdircEntry = new StackLayout();
			stkparkdircEntry.Orientation = StackOrientation.Vertical;
			stkparkdircEntry.HorizontalOptions = LayoutOptions.Fill;
			stkparkdircEntry.Children.Add(Lparkdirc);
			stkparkdircEntry.Children.Add(FparkdircEntry);
			stkparkdircEntry.Spacing = 2;

			#endregion Consulting Room name

           
			StackLayout main = new StackLayout
			{
				Margin=10,
				Spacing=10,
                Padding=new Thickness (0,0,0,20),
				Children = {
					
                    stktel1Entry,stktel2Entry,stkemail1Entry,stkemail2Entry,stkyesno,stkparking,stkparkdircEntry
				}
			};
			var scroll = new ScrollView();
			scroll.Content = main;
			Content = scroll;
		}

       

        void switcher_Toggled(object sender, ToggledEventArgs e)
		{
			
		}
		async void testclick()
{

	if (string.IsNullOrEmpty(tel1Entry.Text))
	{
		Ftel1Entry.OutlineColor = Color.Yellow;
		if (!stktel1Entry.AnimationIsRunning("TranslateTo"))
		{
			await stktel1Entry.TranslateTo(-10, 0, 100);
			await stktel1Entry.TranslateTo(10, 0, 100);
			await stktel1Entry.TranslateTo(0, 0, 100);
					return;
		}
	}
	else if (string.IsNullOrEmpty(email1Entry.Text))
	{
		Femail1Entry.OutlineColor = Color.Yellow;
		if (!stkemail1Entry.AnimationIsRunning("TranslateTo"))
		{
			await stkemail1Entry.TranslateTo(-10, 0, 100);
			await stkemail1Entry.TranslateTo(10, 0, 100);
			await stkemail1Entry.TranslateTo(0, 0, 100);
					return;
		}

	}
			else if (r1.SelectedItem==null)
	{
		if (!stkparking.AnimationIsRunning("TranslateTo"))
		{
			await stkparking.TranslateTo(-10, 0, 100);
			await stkparking.TranslateTo(10, 0, 100);
			await stkparking.TranslateTo(0, 0, 100);
					return;
		}
	}
		var consulting_venues = new consulting_venues
		{
				consulting_name = cv.consulting_name,
				address1 = cv.address1,
				address2 = cv.address2,
				address3 = cv.address3,
				city_town = cv.city_town,
				county_state =cv.county_state,
				country = 1,
				postcode = cv.postcode,
				tel1=tel1Entry.Text,
				tel2=tel2Entry.Text,
				email1=email1Entry.Text,
				email2=email2Entry.Text,
				diable_access=yesno.IsToggled,
				parking=r1.SelectedItem.ToString(),
				parking_directions=parkdircEntry.Text,
				created_by=Config.user_Id,
				modify_by=Config.user_Id,
				created=DateTime.Now,
				modifyed=DateTime.Now
		};
				var httpclient = new HttpClient();
				await Navigation.PushPopupAsync(new popup_pleasewait());
				var json = JsonConvert.SerializeObject(consulting_venues);
				HttpContent httpcontent = new StringContent(json);
				httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
				var result = await httpclient.PostAsync(uri, httpcontent);
				var id=result.Headers.Location;
				string  consultingid = id.ToString().Split('/').Last();
				consulting_venues.id = Convert.ToInt32(consultingid);
				await Navigation.PopAllPopupAsync();

				await Navigation.PushAsync(new Servcies_Hours(consulting_venues));

		}
		void editor_Focused(object sender, FocusEventArgs e)
		{
			if (parkdircEntry.Text.Equals("Praking/Direction"))
			{
				parkdircEntry.Text = "";
			}
		}

		void editor_Unfocused(object sender, FocusEventArgs e)
		{
			if (parkdircEntry.Text.Equals(""))
			{
				parkdircEntry.Text = "Praking/Direction";
			}
		}
	}
}

