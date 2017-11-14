using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using AsNum.XFControls;
using Newtonsoft.Json;
using Plugin.Media;
using Rg.Plugins.Popup.Extensions;
using Thinkdocotor;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class Consulting_Upload : ContentPage
	{
		RadioGroup r1FileType;
		StackLayout stkFileType;

		CustomFrame Fuploadframe,FDocumenttitleEntry1;

		StackLayout stkFuploadframe;

		Switch showpublic;

		StackLayout stkshowpublic;

		StackLayout stkuploadimgbtn,stkFDocumenttitleEntry1;

		Label chosefilename;

		MyEntry DocumenttitleEntry1;

		StackLayout stkperview,stkviewdelete;


			byte[] previewdata;

			Button btnupload;


		consulting_venues cv;
		con_uploaddetails uploaddata;
		public Consulting_Upload(consulting_venues consultingvenue)
		{
			NavigationPage.SetBackButtonTitle(this, " ");
			NavigationPage.SetHasBackButton(this, false);
			cv = consultingvenue;


			//ToolbarItems.Add(new ToolbarItem("Next", Device.OnPlatform("tick.png", "tick.png", null), saveupload));
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
			Title = "Documents Upload";

			#region FileType
			Label FileType = new Label
			{
				Text = "FileType:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			var radioList = new List<string>();
			radioList.Add("Document");
			radioList.Add("Images");
			radioList.Add("Videos");

			r1FileType = new RadioGroup()
			{
				ItemsSource = radioList,
				//TextColor = Color.White,
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.FillAndExpand,
				OnImg = "radioon.png",
				OffImg = "radiooff.png"
			};

			stkFileType = new StackLayout();
			stkFileType.Orientation = StackOrientation.Vertical;
			stkFileType.HorizontalOptions = LayoutOptions.Fill;
			stkFileType.Children.Add(FileType);
			stkFileType.Children.Add(r1FileType);
			stkFileType.Spacing = 10;
			#endregion parking

			Label Documenttitle = new Label
			{
				Text = "Title of Document/Logo/Video:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			DocumenttitleEntry1 = new MyEntry
			{
				Placeholder = "Enter Title",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				PlaceholderColor = Color.Gray,
				Keyboard = Keyboard.Text,

			};

			FDocumenttitleEntry1 = new CustomFrame
			{
				Content = DocumenttitleEntry1,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};

			stkFDocumenttitleEntry1 = new StackLayout();
			stkFDocumenttitleEntry1.Orientation = StackOrientation.Vertical;
			stkFDocumenttitleEntry1.HorizontalOptions = LayoutOptions.Fill;
			stkFDocumenttitleEntry1.Children.Add(Documenttitle);
			stkFDocumenttitleEntry1.Children.Add(FDocumenttitleEntry1);
			stkFDocumenttitleEntry1.Spacing = 2;

			Label uploadname = new Label
			{
				Text = "Upload Document/Logo/Video:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			IconView uploadimg = new IconView
			{
				Source = "Uploadfile.png",
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.Transparent,
				Foreground = Color.FromHex(Config.iconcolor)
			};
			Button uploadclick = new Button()
			{
				Text = "Browse",
				FontSize = 20,
				TextColor = Color.White,

			};
			chosefilename = new Label
			{
				Text = "----",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			IconView preview = new IconView
			{
				Source = "previewdata.png",
				HeightRequest = 25,
				WidthRequest = 25,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Transparent,
				Foreground = Color.FromHex(Config.iconcolor)
			};
			var tappreview = new TapGestureRecognizer();
			tappreview.Tapped += showdata;
			preview.GestureRecognizers.Add(tappreview);

			IconView previewdelete = new IconView
			{
				Source = "previewdelete.png",
				HeightRequest = 25,
				WidthRequest = 25,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Transparent,
				Foreground = Color.FromHex(Config.iconcolor)
			};
			var tappreviewdelete = new TapGestureRecognizer();
			tappreviewdelete.Tapped += deletedata;
			previewdelete.GestureRecognizers.Add(tappreviewdelete);

			stkviewdelete = new StackLayout();
			stkviewdelete.Orientation = StackOrientation.Horizontal;
			stkviewdelete.HorizontalOptions = LayoutOptions.CenterAndExpand;

			stkviewdelete.Children.Add(chosefilename);
			stkviewdelete.Children.Add(preview);
			stkviewdelete.Children.Add(previewdelete);
			stkviewdelete.IsVisible = false;


			uploadclick.Clicked += uploadpicker;
			stkuploadimgbtn = new StackLayout();
			stkuploadimgbtn.Orientation = StackOrientation.Vertical;
			stkuploadimgbtn.HorizontalOptions = LayoutOptions.Fill;
			stkuploadimgbtn.Children.Add(uploadimg);
			stkuploadimgbtn.Children.Add(uploadclick);
			stkuploadimgbtn.Children.Add(stkviewdelete);

			stkuploadimgbtn.Spacing = 5;

			Fuploadframe = new CustomFrame
			{
				Content = stkuploadimgbtn,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(20),
				OutlineColor = Color.White,
				BorderWidth = 1,
				BorderRadius = 5,
				BackgroundColor = Color.Transparent,

			};
			stkFuploadframe = new StackLayout();
			stkFuploadframe.Orientation = StackOrientation.Vertical;
			stkFuploadframe.HorizontalOptions = LayoutOptions.FillAndExpand;
			stkFuploadframe.Children.Add(uploadname);
			stkFuploadframe.Children.Add(Fuploadframe);
			stkFuploadframe.Spacing = 10;



			Label showpublicl = new Label
			{
				Text = "Show Public:",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			showpublic = new Switch
			{
				IsToggled = false,
				HorizontalOptions = LayoutOptions.StartAndExpand,

			};

			stkshowpublic = new StackLayout();
			stkshowpublic.Orientation = StackOrientation.Vertical;
			stkshowpublic.HorizontalOptions = LayoutOptions.Fill;
			stkshowpublic.Children.Add(showpublicl);
			stkshowpublic.Children.Add(showpublic);
			stkshowpublic.Spacing = 4;



			btnupload  = new Button
			{
				Text = "Upload",

				Style = (Style)Application.Current.Resources["CPButton"],
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End,
            };
			btnupload.Clicked += saveupload;
			Content = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Margin = 20,
				Spacing = 20,
				Children = {

						stkFDocumenttitleEntry1,
						stkFuploadframe,
					btnupload
						
						
				}
			};
		}

		void saveupload(object sender, EventArgs e)
		{
			uploadphotodoc(uploaddata);
		}

		void deletedata(object sender, EventArgs e)
		{
			chosefilename.Text = "";
			previewdata = null;
			stkviewdelete.IsVisible = false;
			chosefilename.IsEnabled = true;
		}

		void showdata(object sender, EventArgs e)
		{
			IDataViewer dataViewer = DependencyService.Get<IDataViewer>();
			dataViewer.showPhoto(chosefilename.Text, previewdata);
		}

		//void saveupload()
		//{
		//	 Navigation.PushAsync(new  uploadsucc());
		//}

		async void uploadpicker(object sender, EventArgs e)
		{

			if (string.IsNullOrEmpty(DocumenttitleEntry1.Text))
			{
				if (!FDocumenttitleEntry1.AnimationIsRunning("TranslateTo"))
				{

					await FDocumenttitleEntry1.TranslateTo(-10, 0, 100);
					await FDocumenttitleEntry1.TranslateTo(10, 0, 100);
					await FDocumenttitleEntry1.TranslateTo(0, 0, 100);
					return;
				}
			}
			chosefilename.IsEnabled = false;
			if (!string.IsNullOrEmpty(DocumenttitleEntry1.Text))
			{
				var action = await DisplayActionSheet("Choose?", "Cancel", null, "Take a Picture", "Image From Gallery", "Take a Video", "Video From Gallery", "Browse Document");

				if (action == "Take a Picture")
				{
					TakePicture_Clicked();
				}
				if (action == "Image From Gallery")
				{
					PickPicture_Clicked();
				}
				if (action == "Take a Video")
				{
					TakeVideo_Clicked();
				}
				if (action == "Video From Gallery")
				{
					PickVideo_Clicked();
				}
				if (action == "Browse Document")
				{
					browsfile();
				}
			}
		}

		async private void TakePicture_Clicked()
		{

			var file = await CrossMedia.Current.TakePhotoAsync(
			  new Plugin.Media.Abstractions.StoreCameraMediaOptions
			  {
				  Directory = "AutoCard",
				  Name = String.Format("{0}.jpg", Guid.NewGuid())
			  });

			if (file == null)
				return;
			using (var streamReader = new MemoryStream())

			{
				var stream = file.GetStream();
				stream.CopyTo(streamReader);
				previewdata = streamReader.ToArray();
			}

			//await Navigation.PushPopupAsync(new popup_pleasewait());
			var content = new MultipartFormDataContent();

			string s = file.Path.ToString();
			string filename = Path.GetFileName(s);
			string extension = Path.GetExtension(s);

			string[] words = extension.Split('.');
			string imgextenstion = words[1];

			var strContent = new StreamContent(file.GetStream());
			strContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/" + imgextenstion + "");
			//content.Add(strContent, "image", "test.jpg");

			chosefilename.Text = DocumenttitleEntry1.Text+extension;
			stkviewdelete.IsVisible = true;

			var uploaddetails = new con_uploaddetails
			{
				userid=Config.user_Id,
				consulting_id=cv.id,
				filetype="image",
				filename = chosefilename.Text ,
				data=previewdata,
				stream=strContent
								
			};
			uploaddata = uploaddetails;


		}
		async private void PickPicture_Clicked()
		{

			var file = await CrossMedia.Current.PickPhotoAsync();
			if (file == null)
			{
				return;
			}
			using (var streamReader = new MemoryStream())

			{
				var stream = file.GetStream();
				stream.CopyTo(streamReader);
				previewdata = streamReader.ToArray();
			}
			//await Navigation.PushPopupAsync(new popup_pleasewait());
			var content = new MultipartFormDataContent();

			string s = file.Path.ToString();
			string filename = Path.GetFileName(s);
			string extension = Path.GetExtension(s);
			string[] words = extension.Split('.');
			string imgextenstion = words[1];

			var strContent = new StreamContent(file.GetStream());
			strContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/" + imgextenstion + "");
			content.Add(strContent, "image", "test.jpg");


			chosefilename.Text = DocumenttitleEntry1.Text+extension;;
			stkviewdelete.IsVisible = true;
			var uploaddetails = new con_uploaddetails
			{
				userid = Config.user_Id,
				consulting_id = cv.id,
				filetype = "image",
				filename = chosefilename.Text ,
				data = previewdata,
				stream=strContent

			};
			uploaddata = uploaddetails;



		}
		async private void PickVideo_Clicked()
		{

			var file = await CrossMedia.Current.PickVideoAsync();
			if (file == null)
			{
				return;
			}
			using (var streamReader = new MemoryStream())

			{
				var stream = file.GetStream();
				stream.CopyTo(streamReader);
				previewdata = streamReader.ToArray();
			}
			//await Navigation.PushPopupAsync(new popup_pleasewait());
			var content = new MultipartFormDataContent();

			string s = file.Path.ToString();
			string filename = Path.GetFileName(s);
			string extension = Path.GetExtension(s);
			string[] words = extension.Split('.');
			string imgextenstion = words[1];

			var strContent = new StreamContent(file.GetStream());
			strContent.Headers.ContentType = MediaTypeHeaderValue.Parse("video/" + imgextenstion + "");



			chosefilename.Text = DocumenttitleEntry1.Text+extension;;
			stkviewdelete.IsVisible = true;
			var uploaddetails = new con_uploaddetails
			{
				userid = Config.user_Id,
				consulting_id = cv.id,
				filetype = "video",
				filename = chosefilename.Text ,
				data = previewdata,
				stream=strContent

			};
			uploaddata = uploaddetails;

		}
		async private void TakeVideo_Clicked()
		{

		if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
        {
          DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
          return;
        }

        var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
		{
			//Name = "video.mp4",
			//Directory = "DefaultVideos"
		});

			if (file == null)
			{
				return;
			}
			using (var streamReader = new MemoryStream())

			{
				var stream = file.GetStream();
				stream.CopyTo(streamReader);
				previewdata = streamReader.ToArray();
			}
			//await Navigation.PushPopupAsync(new popup_pleasewait());
			var content = new MultipartFormDataContent();
			string s = file.Path.ToString();
			string filename = Path.GetFileName(s);
			string extension = Path.GetExtension(s);
			string[] words = extension.Split('.');
			string imgextenstion = words[1];
			var strContent = new StreamContent(file.GetStream());
			strContent.Headers.ContentType = MediaTypeHeaderValue.Parse("video/" + imgextenstion + "");



			chosefilename.Text = DocumenttitleEntry1.Text+extension;
			stkviewdelete.IsVisible = true;
			var uploaddetails = new con_uploaddetails
			{
				userid = Config.user_Id,
				consulting_id = cv.id,
				filetype = "video",
				filename = chosefilename.Text ,
				data = previewdata,
				stream=strContent

			};
			uploaddata = uploaddetails;
		}

		async private void browsfile()
		{
				var _media = await DependencyService.Get<ICrossFilePicker>().Current().PickFile();
				string filename="", extension="";
				if (_media != null)
				{
					 filename = Path.GetFileName(_media.FilePath);
					 extension = Path.GetExtension(_media.FilePath);
					chosefilename.Text = DocumenttitleEntry1.Text+extension;;
					previewdata = _media.DataArray;
							stkviewdelete.IsVisible = true;

				}
			var uploaddetails = new con_uploaddetails
			{
				userid = Config.user_Id,
				consulting_id = cv.id,
				filetype = "Document",
				filename = chosefilename.Text ,
				data = previewdata,


			};
			uploaddata = uploaddetails;	
		}

		async private void uploadphotodoc(con_uploaddetails cu)
		{
			if (string.IsNullOrEmpty(DocumenttitleEntry1.Text))
			{
				if (!FDocumenttitleEntry1.AnimationIsRunning("TranslateTo"))
				{

					await FDocumenttitleEntry1.TranslateTo(-10, 0, 100);
					await FDocumenttitleEntry1.TranslateTo(10, 0, 100);
					await FDocumenttitleEntry1.TranslateTo(0, 0, 100);
					return;
				}
			}
			if (previewdata==null)
			{
				if (!Fuploadframe.AnimationIsRunning("TranslateTo"))
				{

					await Fuploadframe.TranslateTo(-10, 0, 100);
					await Fuploadframe.TranslateTo(10, 0, 100);
					await Fuploadframe.TranslateTo(0, 0, 100);
					return;
				}
			}
			
			try
			{	
				await Navigation.PushPopupAsync(new popup_pleasewait());
				string[] words = cu.filename.Split('.');
				string imgextenstion = words[1];
				var content = new MultipartFormDataContent();
			

				HttpContent bytesContent = new ByteArrayContent(cu.data);
				if (cu.filetype == "video")
				{
					content.Add(bytesContent, "file", cu.filename);
				}
				else
				{
					content.Add(bytesContent, "file", cu.filename);
				}
				var httpClient = new HttpClient();
				var uploadServiceBaseAddress = "http://178.238.139.243/ThinkdocotorApi/api/ConsultingRoom/Upload_Consulting?userid=" + cu.userid + "&consulting_id=" + cu.consulting_id + "&filetype=" + cu.filetype + " ";
				var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);
				var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
				var response = JsonConvert.DeserializeObject<string>(responseContent);
				if (response == "File already exits")
				{
					await Navigation.PopAllPopupAsync();
					await DisplayAlert("", "FileName already exits", "OK");
					return;
				}
				if (httpResponseMessage.IsSuccessStatusCode)
					{
					await Navigation.PopAllPopupAsync();
					uploadsucc consentPage = new uploadsucc();
					await Navigation.PushAsync(consentPage);
					var con_uploaddetails = new con_uploaddetails();
					chosefilename.Text = "";
					DocumenttitleEntry1.Text = "";
					previewdata = null;
					stkviewdelete.IsVisible = false;
						 
					}
					else
					{
						await  Navigation.PopAllPopupAsync();
						await DisplayAlert("error", "Not upload", "OK");
					}

			}
			catch (Exception ex)
			{
					await Navigation.PopAllPopupAsync();
				await DisplayAlert("Error!", ex.Message, "OK");
				
			}
					
		}


	
	}
}
