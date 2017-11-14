using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;

using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class Adrsspop : PopupPage
	{
		
		Button btncontinue;
		StackLayout main;
		public Task PageClosedTask { get { return tcs.Task; } 


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
	ObservableCollection<ListViewModel> ListItems { get; set; } 

		ListView ListView { get; set;}
		public Adrsspop(ObservableCollection<addressviewmodel> datalist)
		{
			ListItems = new ObservableCollection<ListViewModel>();
			foreach (var txt in datalist)
			{
				ListItems.Add(new ListViewModel() {Text=txt.Places,Id=txt.Id});
			}

			tcs = new System.Threading.Tasks.TaskCompletionSource<bool>();
			Label heading = new Label();
			heading.Text = "Select Address";

			heading.FontSize = 20;
			heading.TextColor = Color.Black;
			heading.HorizontalOptions = LayoutOptions.CenterAndExpand;

			ListView = new ListView();
			ListView.ItemsSource = ListItems;
			ListView.ItemTemplate =  new DataTemplate(typeof(CustomCell));
			ListView.ItemTapped += MenuListView_ItemTapped;
			ListView.HeightRequest = 200;
			//ListView.SeparatorVisibility = SeparatorVisibility.None;



					
			btncontinue = new Button
			{
				Text = "Cancel",
				// Style = (Style)Application.Current.Resources["CPButton"],
				TextColor = Color.White,
				BackgroundColor =Color.FromHex( "#63C3DA"),
				//	FontFamily = Device.OnPlatform(Configuration.fontfamliyios,Configuration.fontfamliyandroid,null),
                FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
			btncontinue.Clicked += btncontinue_Clicked;


			StackLayout stkmain = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Spacing = 10,
				Children =
				{
			 heading,ListView,btncontinue
				}
			};
			Frame Fmain = new Frame
			{
				Content = stkmain,
				OutlineColor = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(20),
				BackgroundColor = Color.White,
				HasShadow = true
			};
			main = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				Margin = new Thickness(12),
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
				Children = {
					main
				}
			};
		}

		async void MenuListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			if ((sender as ListView).SelectedItem == null)
				return;
			(sender as ListView).SelectedItem = null;

			var item = e.Item as ListViewModel;


			if (item.IsSelected)
				item.IsSelected = false;
			else
				item.IsSelected = true;

			Config.addressdetails = item.Id.ToString();
			await Navigation.PopPopupAsync();
		}
		async void btncontinue_Clicked(object sender, EventArgs e)
		{
await Navigation.PopPopupAsync();
//			//await Navigation.PopAllPopupAsync();
//			var isConnected = CrossConnectivity.Current.IsConnected;
//			if (isConnected == true)
//			{
//				await Navigation.PopAllPopupAsync();

//			}
//			else
//			{
//await Navigation.PopPopupAsync();

//ChkCon consentPage = new ChkCon();
//await Navigation.PushPopupAsync(consentPage);
//await consentPage.PageClosedTask;
//			}
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
	}


}

