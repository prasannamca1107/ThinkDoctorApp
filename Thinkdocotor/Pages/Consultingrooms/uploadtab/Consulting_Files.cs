using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Messier16.Forms.Controls;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using Thinkdocotor;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class Consulting_Files : ContentPage
	{
		StackLayout _stacker;
		consulting_venues cv;
		ListView lview;
		private string uri = "http://178.238.139.243/ThinkdocotorApi/api/consulting_documents?";	

		StackLayout maniclone;



		Label nofile;



		public Consulting_Files(consulting_venues consultingvenue)
		{
			cv = consultingvenue;
			loadjson();
			ToolbarItems.Add(new ToolbarItem("Done", null,gotohome));



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


			_stacker = new StackLayout();
			_stacker.VerticalOptions = LayoutOptions.FillAndExpand;
			_stacker.HorizontalOptions = LayoutOptions.FillAndExpand;

			maniclone = new StackLayout();



			nofile = new Label()
			{
				Text = "Nofile",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions=LayoutOptions.CenterAndExpand,
				TextColor = Color.White
			};

			maniclone.Children.Add(nofile);

			StackLayout mainContent = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Margin=5,
				Children = {
					maniclone
				}
			};

			var scroll = new ScrollView();
			scroll.Content = mainContent;
			Content = scroll;
		}

		void gotohome()
		{
			Application.Current.MainPage = (new ThinkDoctor.Menu.UserMasterDetailPage());
		}

		public async Task loadjson()
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

		var json = await httpclient.GetStringAsync(uri+"consulting_id="+cv.id);

		Consulting_Detailsinfo responsemain = JsonConvert.DeserializeObject<Consulting_Detailsinfo>(json);
		var count = responsemain.consulting_documents.Count();
		if (count != 0)
		{
					if(maniclone.Children.Count!=0)
					maniclone.Children.Clear();
			foreach (consulting_documents v in responsemain.consulting_documents)
			{

				maniclone.Children.Add(createstk(new consulting_documentsStackviewmodel(v)));


			}


			await Navigation.PopAllPopupAsync();
		}
		else
		{
				if(maniclone.Children.Count!=0)
					maniclone.Children.Clear();
					maniclone.Children.Add(nofile);
			await Navigation.PopAllPopupAsync();
			

		}


	}

	catch (Exception ex)
	{
		DisplayAlert("", "SomthSomething to worng\n" + ex.Message, "Ok");

		await Navigation.PopAllPopupAsync();
		return;
	}
		}

		private StackLayout createstk(consulting_documentsStackviewmodel c)
		{
			
				StackLayout mainlist = new StackLayout();
				mainlist.Spacing = 0;
				mainlist.Orientation = StackOrientation.Vertical;
				mainlist.HorizontalOptions = LayoutOptions.FillAndExpand;
				mainlist.VerticalOptions = LayoutOptions.FillAndExpand;
				var tapmainlist = new TapGestureRecognizer();
				int i = 0;
				tapmainlist.Tapped += (s, e) => {
					if (i == 0)
					{
						var entity = ((StackLayout)s);
						entity.BackgroundColor = Color.Gray;
            			
						i++;
					}
					else
					{
						mainlist.BackgroundColor = Color.White;
						i = 0;
					}
					
				};
				mainlist.GestureRecognizers.Add(tapmainlist);
				StackLayout main = new StackLayout();
				main.BackgroundColor = Color.White;
				main.Orientation = StackOrientation.Horizontal;
				main.HorizontalOptions = LayoutOptions.FillAndExpand;
				main.VerticalOptions = LayoutOptions.FillAndExpand;
				main.Spacing = 5;
				main.Padding = new Thickness(5);

				StackLayout s1 = new StackLayout();
				s1.Orientation = StackOrientation.Vertical;
				s1.HorizontalOptions = LayoutOptions.FillAndExpand;
				s1.VerticalOptions = LayoutOptions.FillAndExpand;
				s1.Spacing = 5;

				Image img = new Image();
				img.HorizontalOptions = LayoutOptions.Center;
				img.VerticalOptions = LayoutOptions.Center;
				img.HeightRequest = 75;
				img.WidthRequest = 75;
				//	img.Foreground = Color.Gray;
				var tapimg = new TapGestureRecognizer();
				tapimg.SetBinding(TapGestureRecognizer.CommandParameterProperty, "filepath");
				tapimg.Tapped += showfile;
				img.GestureRecognizers.Add(tapimg);
				string extension = Path.GetExtension(c.filepath);

			if (extension == ".jpeg" || extension == ".png" || extension == ".jpg" || extension == ".gif")
			{
				img.Source = "img_file.png";
			}
			else if (extension == ".pdf")
			{
				img.Source = "pdf_file.png";
			}
			else if (extension == ".ppt")
			{
				img.Source = "ppt_file.png";
			}
			else if (extension == ".doc" || extension == ".dot" || extension == ".wbk" || extension == ".docx" || extension == ".docm" || extension == ".dotx" || extension == ".dotm" || extension == "docb")
			{
				img.Source = "doc_file.png";
			}
			else if (extension == ".xls" || extension == ".xlt" || extension == ".xlm" || extension == ".xlsx" || extension == ".xlsm" || extension == ".xltx" || extension == ".xltm" || extension == ".xlam")
			{
				img.Source = "excel_file.png";
			}

			else if (extension == ".txt")
			{
				img.Source = "text_file.png";
			}
			else if (extension == ".mp3")
			{
				img.Source = "audio_file.png";
			}
			else
			{
				img.Source = "video_file.png";
			}
				
				
				

				Label l1 = new Label();
				l1.Text = c.filename;
				l1.FontSize = 18;
				l1.TextColor = Color.FromHex("#3A527C");

				Label filesizetime = new Label();
				filesizetime.Text = c.Filesizedate;
				filesizetime.FontSize = 14;
				filesizetime.TextColor = Color.FromHex("#6d6d6d");

			Checkbox chkshowpublic = new Checkbox()
			{
					AutomationId = c.ID.ToString(),
					CheckboxBackgroundColor = Color.Green,
					TickColor = Color.White,
					Checked = c.Allowpublic,
					WidthRequest = Device.OnPlatform(18, 25, 0)
				};

			chkshowpublic.CheckedChanged += updatestatus;

				Label showpublic = new Label
				{
					Text = "Show Public",
					TextColor = Color.FromHex("#AA3F37"),
					VerticalOptions=LayoutOptions.Center
				};       

            
			StackLayout showpublicstk = new StackLayout();
			showpublicstk.Orientation = StackOrientation.Horizontal;
			showpublicstk.HorizontalOptions = LayoutOptions.Start;
			showpublicstk.Spacing =6;
			showpublicstk.Children.Add(chkshowpublic);
			showpublicstk.Children.Add(showpublic);

		

				s1.Children.Add(l1);
				s1.Children.Add(filesizetime);
				s1.Children.Add(showpublicstk);

				//BoxView border = new BoxView();
				//border.HeightRequest = 5;
				//border.Color = Color.Black;
				Image deletefile = new Image();
				deletefile.HorizontalOptions = LayoutOptions.Center;
				deletefile.VerticalOptions = LayoutOptions.Center;
				deletefile.Source = "deletefile.png";

				var tapdeletefile = new TapGestureRecognizer();
				tapdeletefile.SetBinding(TapGestureRecognizer.CommandParameterProperty, "ID");
				tapdeletefile.Tapped += clickdeletefile;
				deletefile.GestureRecognizers.Add(tapdeletefile);

				main.Children.Add(img);
				main.Children.Add(s1);
				main.Children.Add(deletefile);


				mainlist.Children.Add(main);
				//mainlist.Children.Add(border);
				mainlist.BindingContext = c;

				return mainlist;
		}

		async void updatestatus(object sender, EventArgs e)
		{
			
				//if (Device.OS == TargetPlatform.Android)
				//{

				//	await Navigation.PushPopupAsync(new popup_pleasewait());

				//}
				//if (Device.OS == TargetPlatform.iOS)
				//{

				//	await Navigation.PushPopupAsync(new popup_pleasewait());
				//	await Navigation.PushPopupAsync(new popup_pleasewait());

				//}
				var chk = (Checkbox)sender;
			if (chk.Checked)
			{
				chk.Checked = true;
			}
			else
			{
				chk.Checked = false;
			}
				var id=chk.AutomationId;
				var showpublic = chk.Checked;
				HttpResponseMessage responsePutMethod = consultingPutRequest("http://178.238.139.243/ThinkdocotorApi/api/ConsultingRoom/Upload_Consulting/Update?id=" + id + "&userid=" + Config.user_Id+"&showpublic="+showpublic);

				if (responsePutMethod.IsSuccessStatusCode)
				{
					
					await Navigation.PopAllPopupAsync();
					loadjson();

				}
				else
				{
					await Navigation.PopPopupAsync();
					await DisplayAlert("", "Update error try again" , "Ok");
					return;
				}


		}
		private static HttpResponseMessage consultingPutRequest(string RequestURI)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://178.238.139.243/ThinkdocotorApi/api/ConsultingRoom/Upload_Consulting/Update/");
			HttpResponseMessage response = client.PutAsync(RequestURI, null).Result;
			return response;
		
		}  

		async void clickdeletefile(object sender, EventArgs e)
		{
			var answer = await DisplayAlert("", "Sure you want to delete", "Yes", "No");
			if (answer == true)
			{
				//if (Device.OS == TargetPlatform.Android)
				//{

				//	await Navigation.PushPopupAsync(new popup_pleasewait());

				//}
				//if (Device.OS == TargetPlatform.iOS)
				//{

				//	await Navigation.PushPopupAsync(new popup_pleasewait());
				//	await Navigation.PushPopupAsync(new popup_pleasewait());

				//}
				var item = (Image)sender;
				TapGestureRecognizer t = (TapGestureRecognizer)item.GestureRecognizers[0];
				var id = t.CommandParameter;

				HttpResponseMessage responsePutMethod = documentDeleteRequest("http://178.238.139.243/ThinkdocotorApi/api/ConsultingRoom/Upload_Consulting/delete?id=" + id);
				if (responsePutMethod.IsSuccessStatusCode)
				{
						await Navigation.PopAllPopupAsync();
						//await DisplayAlert("", "Deleted ", "Ok");
						maniclone.Children.Clear();
						loadjson();

				}
					else
				{
					await Navigation.PopAllPopupAsync();
					DisplayAlert("", "Erorr deleting try again", "Ok");
					return;
				}

			}
		}
		private static HttpResponseMessage documentDeleteRequest(string RequestURI)
		{
			HttpClient client = new HttpClient();	
			client.DefaultRequestHeaders.Accept.Clear();
			HttpResponseMessage response = client.DeleteAsync(RequestURI).Result;
			return response;	
		}  

			async void showfile(object sender, EventArgs e)


			{
				var item = (Image)sender;
				TapGestureRecognizer t = (TapGestureRecognizer)item.GestureRecognizers[0];
				var filepath = t.CommandParameter.ToString();
				string filename = Path.GetFileName(filepath);
				Device.OpenUri(new Uri(filepath));
				//LoadingLabelCode consentPage = new LoadingLabelCode(filename,filepath);
				//await Navigation.PushAsync(consentPage);

			}

		void showdata(string filename, byte[] previewdata)
		{
			IDataViewer dataViewer = DependencyService.Get<IDataViewer>();
			dataViewer.showPhoto(filename, previewdata);
		}
		public async Task<byte[]> Download(string path)
		{
			using (HttpClient client = new HttpClient())
			{
				byte[] fileArray = await client.GetByteArrayAsync(path);
				return fileArray;
			}
		}
        protected  override async void OnAppearing()
            {
	        base.OnAppearing();
			//maniclone.Children.Clear();
			await  loadjson();
	}
	}

}

