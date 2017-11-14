using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Thinkdocotor;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class ConsultingRoom_details : ContentPage
	{
		MyEntry ConsulEntry,PostcodeEntry,addEntry1,addEntry2,addEntry3,CitytownEntry,CountyStateEntry,CountryEntry;
		ObservableCollection<addressviewmodel> datecolpostal;
		StackLayout stkConsulEntry,stkadd1, stkpostal,stkPostcodeEntry,stkadd2,stkadd3,stkCitytown,stkCountyState,stkCountry;
		CustomFrame FConsulEntry,FPostcodeEntry,FaddEntry1,FaddEntry2,FaddEntry3,FCitytownEntry,FCountyStateEntry,FCountryEntry;
		public ConsultingRoom_details()
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
					BackgroundImage = "Bg.png";
			}
			Title = "Details/Address Info";
			ToolbarItems.Add(new ToolbarItem("Next", Device.OnPlatform("Docotor/Nextpage.png", "Nextpage.png", null), testclick));



			#region Consulting Room name
			Label Cname = new Label
			{
                Text = "Hospital/Clinic Name:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			ConsulEntry = new MyEntry
			{
                Placeholder = "Hospital/Clinic Name",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				PlaceholderColor = Color.Gray,
				Keyboard = Keyboard.Text,

			};

			 FConsulEntry = new CustomFrame
			{
				Content = ConsulEntry,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};
			ConsulEntry.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(ConsulEntry.Text))
				{
					FConsulEntry.OutlineColor = Color.White;
				}
			
			};
			stkConsulEntry = new StackLayout();
			stkConsulEntry.Orientation = StackOrientation.Vertical;
			stkConsulEntry.HorizontalOptions = LayoutOptions.Fill;
			stkConsulEntry.Children.Add(Cname);
			stkConsulEntry.Children.Add(FConsulEntry);
			stkConsulEntry.Spacing = 2;

			#endregion Consulting Room name

			#region postcode

			Label Cpostcode = new Label
			{
				Text = "Post Code:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			PostcodeEntry = new MyEntry
			{
				Placeholder = "Post Code",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				PlaceholderColor = Color.Gray,
				Keyboard = Keyboard.Text,

			};
				PostcodeEntry.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(PostcodeEntry.Text))
				{
					FaddEntry1.OutlineColor = Color.White;
				}
			
			};
			IconView imgpostalsearch = new IconView
			{
				Source = Device.OnPlatform("Docotor/search.png", "search.png", null),
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,
				Foreground = Color.FromHex(Config.iconcolor)
			};
			stkpostal = new StackLayout();
			stkpostal.Orientation = StackOrientation.Horizontal;
			stkpostal.HorizontalOptions = LayoutOptions.FillAndExpand;
			stkpostal.Children.Add(PostcodeEntry);
			stkpostal.Children.Add(imgpostalsearch);

			FPostcodeEntry = new CustomFrame
			{
				Content = stkpostal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};

			PostcodeEntry.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(PostcodeEntry.Text))
				{
					FPostcodeEntry.OutlineColor = Color.White;
				}
			
			};

			var tapimgpostalsearch = new TapGestureRecognizer();
			tapimgpostalsearch.Tapped += GetAddress;
			imgpostalsearch.GestureRecognizers.Add(tapimgpostalsearch);

			PostcodeEntry.Completed += (s, e) =>
			{
				GetAddress(s, e);
			};

			 stkPostcodeEntry = new StackLayout();
			stkPostcodeEntry.Orientation = StackOrientation.Vertical;
			stkPostcodeEntry.HorizontalOptions = LayoutOptions.Fill;
			stkPostcodeEntry.Children.Add(Cpostcode);
			stkPostcodeEntry.Children.Add(FPostcodeEntry);
			stkPostcodeEntry.Spacing = 2;

			#endregion postcode

			#region address1
			Label Cadd1 = new Label
			{
				Text = "Address1:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			addEntry1 = new MyEntry
			{
				Placeholder = "Address1",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				PlaceholderColor = Color.Gray,
				Keyboard = Keyboard.Text,

			};

			FaddEntry1 = new CustomFrame
			{
				Content = addEntry1,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};
			addEntry1.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(addEntry1.Text))
				{
					FaddEntry1.OutlineColor = Color.White;
				}
			
			};
			stkadd1 = new StackLayout();
			stkadd1.Orientation = StackOrientation.Vertical;
			stkadd1.HorizontalOptions = LayoutOptions.Fill;
			stkadd1.Children.Add(Cadd1);
			stkadd1.Children.Add(FaddEntry1);
			stkadd1.Spacing = 2;

			#endregion address1

			#region address2
			Label Cadd2 = new Label
			{
				Text = "Address2:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			addEntry2 = new MyEntry
			{
				Placeholder = "Address2",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				PlaceholderColor = Color.Gray,
				Keyboard = Keyboard.Text,

			};

			FaddEntry2 = new CustomFrame
			{
				Content = addEntry2,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};
				addEntry2.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(addEntry2.Text))
				{
					FaddEntry2.OutlineColor = Color.White;
				}
			
			};
			stkadd2 = new StackLayout();
			stkadd2.Orientation = StackOrientation.Vertical;
			stkadd2.HorizontalOptions = LayoutOptions.Fill;
			stkadd2.Children.Add(Cadd2);
			stkadd2.Children.Add(FaddEntry2);
			stkadd2.Spacing = 2;
			stkadd2.IsVisible = false;

			#endregion address2

			#region address3
		Label Cadd3 = new Label
		{
			Text = "Address3:",
			TextColor = Color.White,
			HorizontalOptions = LayoutOptions.StartAndExpand
		};

		addEntry3 = new MyEntry
			{
				Placeholder = "Address3",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				PlaceholderColor = Color.Gray,
				Keyboard = Keyboard.Text,

			};

			FaddEntry3 = new CustomFrame
			{
				Content = addEntry3,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};
				addEntry3.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(addEntry3.Text))
				{
					FaddEntry3.OutlineColor = Color.White;
				}
			
			};
			stkadd3 = new StackLayout();
			stkadd3.Orientation = StackOrientation.Vertical;
			stkadd3.HorizontalOptions = LayoutOptions.Fill;
			stkadd3.Children.Add(Cadd3);
			stkadd3.Children.Add(FaddEntry3);
			stkadd3.Spacing = 2;
			stkadd3.IsVisible = false;

			#endregion address3

			#region City/town
			Label Citytown = new Label
			{
				Text = "City/Town:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			CitytownEntry = new MyEntry
			{
				Placeholder = "City/Town",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				PlaceholderColor = Color.Gray,
				Keyboard = Keyboard.Text,


			};

			FCitytownEntry = new CustomFrame
			{
				Content = CitytownEntry,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};
				CitytownEntry.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(CitytownEntry.Text))
				{
					FCitytownEntry.OutlineColor = Color.White;
				}
			
			};
			stkCitytown = new StackLayout();
			stkCitytown.Orientation = StackOrientation.Vertical;
			stkCitytown.HorizontalOptions = LayoutOptions.Fill;
			stkCitytown.Children.Add(Citytown);
			stkCitytown.Children.Add(FCitytownEntry);
			stkCitytown.Spacing = 2;

			#endregion City/town

			#region County/State
			Label CountyState = new Label
			{
				Text = "County/State:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			CountyStateEntry = new MyEntry
			{
				Placeholder = "County/State",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				PlaceholderColor = Color.Gray,
				Keyboard = Keyboard.Text,

			};

			FCountyStateEntry = new CustomFrame
			{
				Content = CountyStateEntry,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};
				CountyStateEntry.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(CountyStateEntry.Text))
				{
					FCountyStateEntry.OutlineColor = Color.White;
				}
			
			};
			stkCountyState = new StackLayout();
			stkCountyState.Orientation = StackOrientation.Vertical;
			stkCountyState.HorizontalOptions = LayoutOptions.Fill;
			stkCountyState.Children.Add(CountyState);
			stkCountyState.Children.Add(FCountyStateEntry);
			stkCountyState.Spacing = 2;

			#endregion County/State

			#region Country
			Label Country = new Label
			{
				Text = "Country:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			CountryEntry = new MyEntry
			{
				Placeholder = "Country",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				PlaceholderColor = Color.Gray,
				Keyboard = Keyboard.Text,

			};

			FCountryEntry = new CustomFrame
			{
				Content = CountryEntry,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};
				CountryEntry.TextChanged += (object sender, TextChangedEventArgs e) => {
				if (!string.IsNullOrEmpty(CountryEntry.Text))
				{
					FCountryEntry.OutlineColor = Color.White;
				}
			
			};
			stkCountry = new StackLayout();
			stkCountry.Orientation = StackOrientation.Vertical;
			stkCountry.HorizontalOptions = LayoutOptions.Fill;
			stkCountry.Children.Add(Country);
			stkCountry.Children.Add(FCountryEntry);
			stkCountry.Spacing = 2;

			#endregion Country


			StackLayout main = new StackLayout
			{
				Margin = 10,
				Children = {
					stkConsulEntry,stkPostcodeEntry,stkadd1,stkadd2,stkadd3,stkCitytown,stkCountyState,stkCountry
				}
			};
			var scroll = new ScrollView();
			scroll.Content = main;
			Content = scroll;
		}

		async void  testclick()
		{
			
			if (string.IsNullOrEmpty(ConsulEntry.Text))
			{
				FConsulEntry.OutlineColor = Color.Yellow;
				if (!stkConsulEntry.AnimationIsRunning("TranslateTo"))
					{
					await stkConsulEntry.TranslateTo(-10, 0, 100);
					await stkConsulEntry.TranslateTo(10, 0, 100);
					await stkConsulEntry.TranslateTo(0, 0, 100);
					return;
					}
			}
			else if (string.IsNullOrEmpty(PostcodeEntry.Text))
			{
				FPostcodeEntry.OutlineColor = Color.Yellow;
				if (!stkPostcodeEntry.AnimationIsRunning("TranslateTo"))
				{
					await stkPostcodeEntry.TranslateTo(-10, 0, 100);
					await stkPostcodeEntry.TranslateTo(10, 0, 100);
					await stkPostcodeEntry.TranslateTo(0, 0, 100);
					return;
				}

			}
			else if (string.IsNullOrEmpty(addEntry1.Text))
			{
				FaddEntry1.OutlineColor = Color.Yellow;
				if (!stkadd1.AnimationIsRunning("TranslateTo"))
				{
					await stkadd1.TranslateTo(-10, 0, 100);
					await stkadd1.TranslateTo(10, 0, 100);
					await stkadd1.TranslateTo(0, 0, 100);
					return;
				}
			}
			else if (string.IsNullOrEmpty(CountryEntry.Text))
			{
				FCountryEntry.OutlineColor = Color.Yellow;
				if (!stkCountry.AnimationIsRunning("TranslateTo"))
				{
					await stkCountry.TranslateTo(-10, 0, 100);
					await stkCountry.TranslateTo(10, 0, 100);
					await stkCountry.TranslateTo(0, 0, 100);
					return;
				}

			}

			var consulting_venues = new consulting_venues
			{
				consulting_name=ConsulEntry.Text,
				address1=addEntry1.Text,
				address2=addEntry2.Text,
				address3=addEntry3.Text,
				city_town=CitytownEntry.Text,
				county_state=CountyStateEntry.Text,
				country=1,
				postcode=PostcodeEntry.Text,

			};
			await Navigation.PushAsync(new ConsultingRoom_contact_details(consulting_venues));



		
		}

		async void GetAddress(object sender, EventArgs e)
{
	if (string.IsNullOrEmpty(PostcodeEntry.Text))
	{
				FPostcodeEntry.OutlineColor = Color.Yellow;
				if (!stkPostcodeEntry.AnimationIsRunning("TranslateTo"))
				{
					await stkPostcodeEntry.TranslateTo(-10, 0, 100);
					await stkPostcodeEntry.TranslateTo(10, 0, 100);
					await stkPostcodeEntry.TranslateTo(0, 0, 100);
				}
				return;
	}
	await Navigation.PushPopupAsync(new popup_pleasewait());
	var httpclient = new HttpClient();
	datecolpostal = new ObservableCollection<addressviewmodel>();


	var encoded = Uri.EscapeUriString(PostcodeEntry.Text);

	string uriadd = "https://services.3xsoftware.co.uk/Search/ByPostcode/json?username=CoralTechnologiesHAMedical1365&key=IIZY-KT80-M507-6Z9W&postcode=" + encoded;
	var json = await httpclient.GetStringAsync(uriadd);
	Addressinfo response = JsonConvert.DeserializeObject<Addressinfo>(json);

	if (response.Summaries != null && response.Summaries.Length != 0)
	{
		foreach (Summaries v in response.Summaries)
		{
			datecolpostal.Add(new addressviewmodel(v));
		}

		await Navigation.PopPopupAsync();


		Adrsspop consentPage = new Adrsspop(datecolpostal);
		await Navigation.PushPopupAsync(consentPage);
		await consentPage.PageClosedTask;
		if (!string.IsNullOrEmpty(Config.addressdetails))
		{
			string uriaddid = "https://services.3xsoftware.co.uk/search/byid/json?username=CoralTechnologiesHAMedical1365&key=IIZY-KT80-M507-6Z9W&id=" + Config.addressdetails;
			var jsonid = await httpclient.GetStringAsync(uriaddid);
			Addressid address = JsonConvert.DeserializeObject<Addressid>(jsonid);
					addEntry1.Text = address.Address.StreetAddress1;
					if (string.IsNullOrEmpty(address.Address.StreetAddress2))
					{
						stkadd2.IsVisible = false;
					}
					else
					{
						stkadd2.IsVisible = true;
						addEntry2.Text = address.Address.StreetAddress2;
					}

					if (string.IsNullOrEmpty(address.Address.StreetAddress3))
					{
						stkadd3.IsVisible = false;
					}
					else
					{
						stkadd3.IsVisible = true;
						addEntry3.Text = address.Address.StreetAddress3;
					}
					address.Address.CountryName = "UK";
					CitytownEntry.Text = address.Address.PostTown;
					CountyStateEntry.Text = address.Address.County;
					CountryEntry.Text = address.Address.CountryName;
		}


	}
	else
	{
		await Navigation.PopAllPopupAsync();
		DisplayAlert("", "The postcode is invalid", "Ok");

	}
		}
	
	}
}

