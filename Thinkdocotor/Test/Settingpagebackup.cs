using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using AsNum.XFControls;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Media;
using Rg.Plugins.Popup.Extensions;
using Thinkdocotor;
using Xamarin.Forms;


namespace ThinkDoctor   
{
    public class SettingPagetest : CustomPageWithGradient
	{
		RoundImage img_person,img_edit;
		Label lblName,clinic,gmcupload,gmcname,Indemnityupload,Indemnityname,Appraisalupload,Appraisalname,logoname,logoupload,Singname,Singupload;
		int h, w;
		Color outline, plccolor;
		MyEntry name,dob,postalcode,address1,address2,city,country,mobile,Hmobile,email,Wmobile;
		Image imgname, nameedit, imgdob, dobedit, postalcodeedit, imgpostalcode, imgaddress1, address1edit, imgaddress2, address2edit, imgcity, imgcountry, imgmobile, imgHmobile, imgemail, cityedit, countryedit,imgclinic, clinicedit, mobileedit, Hmobileedit, emailedit,imgfile,uploaddeleteimg,uploadaddimg,imgfileIndemnity;
		Grid gridname,griddob,gridpostalcode,gridaddress1,gridaddress2,gridcity, gridcountry, gridmobile, gridHmobile, gridemail,gridclinic,gridclinic1,gridclinic2,griduploadgmc,griduploadIndemnity;
		Button btnupdate;
		Picker imagpick;
		int flagper_qly = 0,flagexpq=0,flagdocupl=0,flaglogo=0,flagsing=0;
		StackLayout stkclinics;
		Editor  editor;
		byte[] selectedFileBytes;
		private string localfilepath;
		Frame fgmc;
		ProgressBar progressBar;
        DropDownMenuView picker_gender;
		Dictionary<string, string> nameToColor = new Dictionary<string, string>
		{
			{
			  "Take a Picture ","_takePic"
			},
			 {
			  "Image From Gallery","_galleryPic"
			 }

		};
		double widthAlloc;
		double heightAlloc;
		StackLayout arrangeupload;
		Image uploadaddimgtapIndemnity;

		Image uploaddeleteimgIndemnity;

		ProgressBar progressBarIndemnity;

		Frame fIndemnity;

		Image imgfileAppraisal;

		Image uploadaddimgtapAppraisal;

		Image uploaddeleteimgAppraisal;

		ProgressBar progressBarAppraisal;

		Grid griduploadAppraisal;

		Frame fAppraisal;

		Frame flogo;

		Grid griduploadlogo;

		ProgressBar progressBarlogo;

		Image uploaddeleteimglogo;

		Image uploadaddimgtaplogo;

		Image imgfilelogo;

		Frame fSing;

		Grid griduploadSing;

		ProgressBar progressBarSing;

		Image uploaddeleteimgSing;

		Image uploadaddimgtapSing;

		Image imgfileSing;

		Grid gridWmobile;

		Image imgWmobile;

		Grid griddocuplexp;

		Image imgdocuplexpen;

		Grid gridsingupldexp;

		Image imglogouploadexpen;
		Grid gridlogouploadexp;

		Image imgsinguplexpen;
		Label lblAppoint, lblDetails, lblPhotos, lbllogoupload;
		StackLayout st_appoint, st_details, st_photos, st_logo;
		ObservableCollection<addressviewmodel> datecol;
		BoxView boxAppoint, boxDetails, boxPhotos, boxlogo;
		StackLayout st_tabContent;
		Label lblcontent;
		Grid grid_tabs;
		ScrollView scroll;
		Grid gridprfqexp;
		Image imgprfqexpen;
		MyScroll gridscroll;


		Label lbllogoSing;

		BoxView boxsing;

		StackLayout st_sing;

		StackLayout stkprofile;

		StackLayout stklogo;

		StackLayout stkClinic;

		StackLayout stkdoc;

		StackLayout stksing;

        StackLayout stkgender;

        RadioGroup gender_radio;

		CustomFrame Fname,Fdob,Fpostalcode,Faddress1,Faddress2,Fcountry,FHmobile,FWmobile,Fmobile,Femail,Fcity;

		bool pickerflag = false;








        public SettingPagetest()
		{
			loadjson();
			
            StartColor = Color.FromHex("#3a527d");
            EndColor = Color.FromHex("#24334e");
				
			h = 20;
			w = 20;

			outline = Color.Black;
			plccolor = Color.FromRgb(123, 124, 124);


			Title = "Setting";
			//BackgroundImage = "bkgd131.jpg";

			//BackgroundColor = Color.FromRgb(237, 243, 252) ;
			img_person = new RoundImage();

			img_person.Source = "defalutdoctor.png";
			img_person.HorizontalOptions = LayoutOptions.Center;
			img_person.VerticalOptions = LayoutOptions.Center;
			img_person.HeightRequest = 110;
			img_person.WidthRequest = 110;
			img_person.Aspect = Aspect.AspectFill;


			img_edit = new RoundImage();
			img_edit.Source = "editphoto.png";
			img_edit.HorizontalOptions = LayoutOptions.Center;
			img_edit.VerticalOptions = LayoutOptions.Center;
			img_edit.HeightRequest = 30;
			img_edit.WidthRequest = 30;
			img_edit.Aspect = Aspect.AspectFill;

			imagpick = new Picker
			{
				Title = "Choose",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				IsVisible = false,
				IsEnabled=false


			};
			foreach (string colorName in nameToColor.Keys)
			{
				imagpick.Items.Add(colorName);
			}
			imagpick.SelectedIndexChanged += imagpick_SelectedIndexChanged;
			imagpick.SelectedIndex = -1;


			var tapImgedit = new TapGestureRecognizer();
			tapImgedit.Tapped += Loadimage;
			img_edit.GestureRecognizers.Add(tapImgedit);


			

			lblName = new Label();
			lblName.Text = "....";
			lblName.TextColor = Color.Black;
			lblName.HorizontalOptions = LayoutOptions.Center;
			lblName.VerticalOptions = LayoutOptions.Center;
			lblName.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
			BoxView boxView = new BoxView
			{
				Color = Color.FromHex("#CEE8FA"),
				WidthRequest = 700,
				HeightRequest = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};



			RelativeLayout layout = new RelativeLayout();
			layout.WidthRequest = 150;
			layout.HeightRequest = 150;
			layout.HorizontalOptions = LayoutOptions.Center;
			layout.VerticalOptions  = LayoutOptions.Center;
			//layout.BackgroundColor = Color.White ;
			layout.Children.Add(img_person,
				Constraint.Constant(25),
				Constraint.Constant(25),
				//Constraint.RelativeToParent((parent) => { return parent.Width; }),
				//Constraint.RelativeToParent((parent) => { return parent.Height; })
			                   Constraint.Constant(110),Constraint.Constant(110));

			layout.Children.Add(img_edit,
				Constraint.Constant(105),
				Constraint.Constant(105),
				//Constraint.RelativeToParent((parent) => { return parent.Width; }),
				//Constraint.RelativeToParent((parent) => { return parent.Height; }));
			                    Constraint.Constant(30), Constraint.Constant(30));


            var tapImgtest = new TapGestureRecognizer();
            tapImgtest.Tapped += TapImgtest_Tapped;
            layout.GestureRecognizers.Add(tapImgtest);

			StackLayout stack_user = new StackLayout();
			stack_user.BackgroundColor = Color.FromHex("#CEE8FA");
			//stack_user.BackgroundColor = Color.Transparent;
			stack_user.HorizontalOptions = LayoutOptions.Fill;
			stack_user.VerticalOptions = LayoutOptions.Start;
			stack_user.Orientation = StackOrientation.Vertical;
			stack_user.Padding = new Thickness(0);

			stack_user.Children.Add(layout);
			stack_user.Children.Add(lblName);
			stack_user.Children.Add(boxView);


			Label prf = new Label
			{


				TextColor = Color.Gray ,
				FontSize = Device.OnPlatform(20, 20, 20),
				FontAttributes=FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,

			};
			#region gridscroll

			grid_tabs = new Grid();
			grid_tabs.ColumnSpacing = 0;
			BackgroundColor = Color.Transparent;
			grid_tabs.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid_tabs.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid_tabs.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid_tabs.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60) });

			//-------------------------Appointment-------------------------
			lblAppoint = new Label();
			lblAppoint.Text = "Personal Details";
			lblAppoint.TextColor = Color.White;
			lblAppoint.HorizontalOptions = LayoutOptions.Center;
			lblAppoint.VerticalOptions = LayoutOptions.CenterAndExpand;
			lblAppoint.VerticalTextAlignment = TextAlignment.Center;
			lblAppoint.HorizontalTextAlignment = TextAlignment.Center;
			lblAppoint.FontSize = 10;


			Image iprf = new Image();
			iprf.Source = Device.OnPlatform( "Docotor/prfl.png","prfl.png",null);
			iprf.VerticalOptions = LayoutOptions.Center;
			iprf.HorizontalOptions = LayoutOptions.Center;



			boxAppoint = new BoxView();
			boxAppoint.Color = Color.FromRgb(250, 105, 31);
			//boxAppoint.HorizontalOptions = LayoutOptions.Center;
			boxAppoint.VerticalOptions = LayoutOptions.End;
			boxAppoint.HeightRequest = 2;
			boxAppoint.WidthRequest = lblAppoint.Width;
			boxAppoint.IsVisible = true;


			st_appoint = new StackLayout();
			st_appoint.BackgroundColor = Color.Transparent;
			st_appoint.Spacing = 1;
			//st_appoint.WidthRequest = 25;
			st_appoint.Children.Add(iprf);
			st_appoint.Children.Add(lblAppoint);
			st_appoint.Children.Add(boxAppoint);

			TapGestureRecognizer tap_appoint = new TapGestureRecognizer();
			tap_appoint.Tapped += Tap_Appoint_Tapped;
			st_appoint.GestureRecognizers.Add(tap_appoint);

			//-------------------------Details-------------------------
			lblDetails = new Label();
			lblDetails.Text = "Professional Details";
			lblDetails.TextColor = Color.White;
			lblDetails.HorizontalOptions = LayoutOptions.Center;
			lblDetails.VerticalOptions = LayoutOptions.CenterAndExpand;
			lblDetails.VerticalTextAlignment = TextAlignment.Center;
			lblDetails.HorizontalTextAlignment = TextAlignment.Center;
			lblDetails.FontSize = 10;

			Image icln = new Image();
			icln.Source =Device.OnPlatform("Docotor/clicnicbl.png", "clicnicbl.png", null);
			icln.VerticalOptions = LayoutOptions.Center;
			icln.HorizontalOptions = LayoutOptions.Center;


			boxDetails = new BoxView();
			boxDetails.Color = Color.FromRgb(250, 105, 31);
			//boxDetails.HorizontalOptions = LayoutOptions.Center;
			boxDetails.VerticalOptions = LayoutOptions.End;
			boxDetails.HeightRequest = 2;
			boxDetails.WidthRequest = lblDetails.Width;
			boxDetails.IsVisible = false;

			st_details = new StackLayout();
			//st_details.BackgroundColor = Color.FromHex("#CEE8FA");


			st_details.Opacity = 0.3;
			st_details.Spacing = 0;
			st_details.WidthRequest = 25;
			st_details.Children.Add(icln);
			st_details.Children.Add(lblDetails);
			st_details.Children.Add(boxDetails);

			TapGestureRecognizer tap_details = new TapGestureRecognizer();
			tap_details.Tapped += Tap_Appoint_Tapped;
			st_details.GestureRecognizers.Add(tap_details);

			//-------------------------Photos-------------------------
			lblPhotos = new Label();
			lblPhotos.Text = "Professional Registration";
			lblPhotos.TextColor = Color.White;
			lblPhotos.HorizontalOptions = LayoutOptions.Center;
			lblPhotos.VerticalOptions = LayoutOptions.CenterAndExpand;
			lblPhotos.VerticalTextAlignment = TextAlignment.Center;
			lblPhotos.HorizontalTextAlignment = TextAlignment.Center;
			lblPhotos.FontSize = 10;

			Image idoc = new Image();
			idoc.Source = Device.OnPlatform("Docotor/uploadfile.png", "uploadfile.png", null); 
			idoc.VerticalOptions = LayoutOptions.Center;
			idoc.HorizontalOptions = LayoutOptions.Center;


			boxPhotos = new BoxView();
			boxPhotos.Color = Color.FromRgb(250, 105, 31);
			//boxPhotos.HorizontalOptions = LayoutOptions.Center;
			boxPhotos.VerticalOptions = LayoutOptions.End;
			boxPhotos.HeightRequest = 2;
			boxPhotos.WidthRequest = lblPhotos.Width;
			boxPhotos.IsVisible = false;

			st_photos = new StackLayout();
			st_photos.Spacing = 0;
			st_photos.Opacity = 0.3;
			st_photos.BackgroundColor = Color.Transparent;
			st_photos.Children.Add(idoc);
			st_photos.Children.Add(lblPhotos);
			st_photos.Children.Add(boxPhotos);

			TapGestureRecognizer tap_photos = new TapGestureRecognizer();
			tap_photos.Tapped += Tap_Appoint_Tapped;
			st_photos.GestureRecognizers.Add(tap_photos);

			//----LOGO UPLOAD

			lbllogoupload = new Label();
			lbllogoupload.Text = "Document";
			lbllogoupload.TextColor = Color.White;
			lbllogoupload.HorizontalOptions = LayoutOptions.Center;
			lbllogoupload.VerticalOptions = LayoutOptions.CenterAndExpand;
			lbllogoupload.VerticalTextAlignment = TextAlignment.Center;
			lbllogoupload.HorizontalTextAlignment = TextAlignment.Center;
			lbllogoupload.FontSize = 10;



			Image ilog = new Image();
			ilog.Source = Device.OnPlatform("Docotor/imglogoupload.png", "imglogoupload.png", null);
			ilog.VerticalOptions = LayoutOptions.Center;
			ilog.HorizontalOptions = LayoutOptions.Center;


			boxlogo = new BoxView();
			boxlogo.Color = Color.FromRgb(250, 105, 31);
			//boxPhotos.HorizontalOptions = LayoutOptions.Center;
			boxlogo.VerticalOptions = LayoutOptions.End;
			boxlogo.HeightRequest = 2;
			boxlogo.WidthRequest = lbllogoupload.Width;
			boxlogo.IsVisible = false;

			st_logo = new StackLayout();
			st_logo.Spacing = 0;
			st_logo.Opacity = 0.3;
			st_logo.BackgroundColor = Color.Transparent;
			st_logo.Children.Add(ilog);
			st_logo.Children.Add(lbllogoupload);
			st_logo.Children.Add(boxlogo);

			TapGestureRecognizer tap_logo = new TapGestureRecognizer();
			tap_logo.Tapped += Tap_Appoint_Tapped;
			st_logo.GestureRecognizers.Add(tap_logo);

			//----Sing UPLOAD

			lbllogoSing = new Label();
			lbllogoSing.Text = "UPLOAD SING";
			lbllogoSing.TextColor = Color.White;
			lbllogoSing.HorizontalOptions = LayoutOptions.Center;
			lbllogoSing.VerticalOptions = LayoutOptions.CenterAndExpand;
			lbllogoSing.VerticalTextAlignment = TextAlignment.Center;
			lbllogoSing.HorizontalTextAlignment = TextAlignment.Center;
			lbllogoSing.FontSize = 10;



			Image ising = new Image();
			ising.Source = Device.OnPlatform("Docotor/singupload.png", "singupload.png", null);
			ising.VerticalOptions = LayoutOptions.Center;
			ising.HorizontalOptions = LayoutOptions.Center;


			boxsing = new BoxView();
			boxsing.Color = Color.FromRgb(250, 105, 31);
			//boxPhotos.HorizontalOptions = LayoutOptions.Center;
			boxsing.VerticalOptions = LayoutOptions.End;
			boxsing.HeightRequest = 2;
			boxsing.WidthRequest = lbllogoSing.Width;
			boxsing.IsVisible = false;

			st_sing = new StackLayout();
			st_sing.Spacing = 0;
			st_sing.Opacity = 0.3;
			st_sing.BackgroundColor = Color.Transparent;
			st_sing.Children.Add(ising);
			st_sing.Children.Add(lbllogoSing);
			st_sing.Children.Add(boxsing);

			TapGestureRecognizer tap_sing = new TapGestureRecognizer();
			tap_sing.Tapped += Tap_Appoint_Tapped;
			st_sing.GestureRecognizers.Add(tap_sing);


			grid_tabs.Children.Add(st_appoint, 0, 0);
			grid_tabs.Children.Add(st_details, 1, 0);
			grid_tabs.Children.Add(st_photos, 2, 0);
			grid_tabs.Children.Add(st_logo, 3, 0);
			grid_tabs.Children.Add(st_sing, 4, 0);

			grid_tabs.ColumnSpacing = 4;
			grid_tabs.HorizontalOptions = LayoutOptions.FillAndExpand;
			grid_tabs.VerticalOptions = LayoutOptions.Fill;
			gridscroll = new MyScroll();
			gridscroll.Content = grid_tabs;
			//	scroll.BackgroundColor = Color.White  ;
			gridscroll.Orientation = ScrollOrientation.Horizontal;
			#endregion

            #region Country
            Label  lbl_gender = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Text = "Country",
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
            };
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    lbl_gender.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    break;
                case TargetIdiom.Tablet:
                    lbl_gender.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    break;
            }


            picker_gender = new DropDownMenuView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Margin = 0,
                HeightRequest = 30,
                imageWidth = 15,
                imageHeight = 15
                //Margin = new Thickness(5, 0, 5, 0)
            };
            //picker_country.SetBinding(DropDownMenuView.ItemSelectedEventProperty, "CountrySelectedIndex");
            picker_gender.ItemSelectedEvent = i =>
            {
                regViewModel.CountrySelectedIndex = i;
            };
            picker_gender.SetBinding(DropDownMenuView.ItemsSourceProperty, "CountriesItemSource");
            //picker_country.SetBinding(Picker.SelectedItemProperty, "CountriesSelectedItem");

            //acView = new AutoCompleteView
            //{
            //    Placeholder = "Country",
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.Center,
            //    //SearchBackgroundColor = Color.Blue,
            //    //SearchBorderColor = Color.Yellow,
            //    //SearchTextColor = Color.Yellow,
            //    ShowSearchButton = false,
            //    SuggestionBackgroundColor = Color.White,
            //    //SearchCommand = "{Binding SearchCommand}"
            //    //                   SelectedCommand = "{Binding CellSelectedCommand}"
            //    //                   SelectedItem = "{Binding SelectedItem}"
            //    //                   SuggestionItemDataTemplate = "{StaticResource SugestionItemTemplate}"
            //    //                   Suggestions = "{Binding Items, Mode = TwoWay }"
            //};
            //acView.SetBinding(AutoCompleteView.SuggestionsProperty, "CountriesItemSource");

            IconView imgCountry = new IconView
            {
                Source = "country.png",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Transparent,
                Foreground = Color.FromHex(Config.iconcolor)
            };

            StackLayout stkFcountry = new StackLayout();
            stkFcountry.Orientation = StackOrientation.Horizontal;
            stkFcountry.HorizontalOptions = LayoutOptions.FillAndExpand;
            stkFcountry.Padding = 2;
            stkFcountry.Children.Add(imgCountry);
            stkFcountry.Children.Add(picker_country);
            //stkFcountry.Children.Add(acView);

            //var semiTransparentColor = new Color(0, 0, 0, 0.05);
            Fcountry = new CustomFrame
            {
                Content = stkFcountry,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,//---------------------------------------------/////
                Padding = new Thickness(10, 7, 0, 7),
                Margin = new Thickness(2, 0),
                OutlineColor = Color.White,
                BorderRadius = 5,
                BackgroundColor = semiTransparentColor,
            };

            stk_country = new StackLayout();
            stk_country.Orientation = StackOrientation.Vertical;
            stk_country.HorizontalOptions = LayoutOptions.FillAndExpand;
            stk_country.VerticalOptions = LayoutOptions.Center;
            stk_country.Padding = 0;
            stk_country.Spacing = 5;
            stk_country.Children.Add(lbl_country);
            stk_country.Children.Add(Fcountry);
            //stk_country.Children.Add(acView);
            #endregion

			name = new MyEntry
			{
				Placeholder = "Firstname",
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions=LayoutOptions.Center,
				PlaceholderColor = Color.WhiteSmoke,
				TextColor=Color.White ,
				Keyboard = Keyboard.Text,
			};
			imgname = new Image
			{
				Source = Device.OnPlatform ( "Docotor/user.png","user.png",null),
				HorizontalOptions = LayoutOptions.Start ,
				BackgroundColor = Color.Transparent,

			};

			StackLayout namestk = new StackLayout();
			namestk.BackgroundColor = Color.Transparent;
			namestk.Orientation = StackOrientation.Horizontal;
			namestk.Children.Add(imgname);
			namestk.Children.Add(name);


			Fname = new CustomFrame
			{
				Content = namestk,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderRadius=10,
				BackgroundColor = Color.Transparent,
			};

			//gridname = new Grid()
			//{
			//	ColumnDefinitions =
			//  {
		 // new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		 // new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			//new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			//  },
			//	HeightRequest=35,
			//	  BackgroundColor = Color.White,
			//	Padding = new Thickness(10, 1, 10, 1)
			//};

			//gridname.Children.Add(imgname, 0, 0);
			//gridname.Children.Add(name, 1, 0);
			//gridname.Children.Add(nameedit, 3, 0);



		//date of brith


			dob= new MyEntry
			{
				Placeholder = "DOB",
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions=LayoutOptions.Center,
				PlaceholderColor = Color.WhiteSmoke,
				TextColor=Color.White ,
				Keyboard = Keyboard.Default,
			};
			imgdob = new Image
			{
				
				Source = Device.OnPlatform("Docotor/dob.png", "dob.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};


			StackLayout dobstk = new StackLayout();
			dobstk.Orientation = StackOrientation.Horizontal;
			dobstk.BackgroundColor = Color.Transparent;
			dobstk.Children.Add(imgdob);
			dobstk.Children.Add(dob);
		


				Fdob = new CustomFrame
			{
				Content = dobstk,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderRadius=10,
				BackgroundColor = Color.Transparent,
			};

			//griddob = new Grid()
			//{
			//	ColumnDefinitions =
			//  {
		 // new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		 // new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			//new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			//  },
			//	HeightRequest = 35,
			//	BackgroundColor = Color.White,
			//	Padding = new Thickness(10, 1, 10, 1)
			//};

			//griddob.Children.Add(imgdob , 0, 0);
			//griddob.Children.Add(dob, 1, 0);
			//griddob.Children.Add(dobedit, 3, 0);



			//postalcode

			postalcode = new MyEntry
			{
				Placeholder = "Postalcode",
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions=LayoutOptions.Center,
				PlaceholderColor = Color.WhiteSmoke,
				TextColor=Color.White ,
				Keyboard = Keyboard.Default,
			};
			imgpostalcode = new Image
			{
				
				Source = Device.OnPlatform("Docotor/postalcode.png", "postalcode.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};
			IconView imgpostalsearch = new IconView
			{

			Source = Device.OnPlatform("Docotor/search.png", "search.png", null),
			HorizontalOptions = LayoutOptions.End,
			BackgroundColor = Color.Transparent,
			Foreground = Color.FromHex(Config.iconcolor)

			};
			var tapimgpostalsearch = new TapGestureRecognizer();
			tapimgpostalsearch.Tapped += GetAddress;
			imgpostalsearch.GestureRecognizers.Add(tapimgpostalsearch);

			postalcode.Completed += (s, e) =>
			{
				GetAddress(s, e);
			};


			StackLayout postalcodestk = new StackLayout();
			postalcodestk.Orientation = StackOrientation.Horizontal;
			postalcodestk.BackgroundColor = Color.Transparent;
			postalcodestk.Children.Add(imgpostalcode);
			postalcodestk.Children.Add(postalcode);
			postalcodestk.Children.Add(imgpostalsearch);


				Fpostalcode = new CustomFrame
			{
				Content = postalcodestk,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderRadius=10,
				BackgroundColor = Color.Transparent,
			};

			//gridpostalcode = new Grid()
			//{
			//	ColumnDefinitions =
			//  {
		 // new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		 // new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			//new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			//  },
			//	HeightRequest = 35,
			//	BackgroundColor = Color.White,
			//	Padding = new Thickness(10, 1, 10, 1)
			//};

			//gridpostalcode.Children.Add(imgpostalcode, 0, 0);
			//gridpostalcode.Children.Add(postalcode, 1, 0);
			//gridpostalcode.Children.Add(postalcodeedit, 3, 0);


			//address1

			address1 = new MyEntry
			{
				Placeholder = "Address1",
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions=LayoutOptions.Center,
				PlaceholderColor = Color.WhiteSmoke,
				TextColor=Color.White ,
				Keyboard = Keyboard.Default,
			};
			imgaddress1 = new Image
			{
				Source =Device.OnPlatform("Docotor/address.png", "address.png", null) ,
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};


			StackLayout address1stk = new StackLayout();
			address1stk.Orientation = StackOrientation.Horizontal;
			address1stk.BackgroundColor = Color.Transparent;
			address1stk.Children.Add(imgaddress1);
			address1stk.Children.Add(address1);

				Faddress1 = new CustomFrame
				{
				Content = address1stk,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderRadius=10,
				BackgroundColor = Color.Transparent,
				};



			//gridaddress1 = new Grid()
			//{
			//	ColumnDefinitions =
			//  {
		 // new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		 // new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			//new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			//  },
			//	HeightRequest = 35,
			//	BackgroundColor = Color.White,
			//	Padding = new Thickness(10, 1, 10, 1)
			//};

			//gridaddress1.Children.Add(imgaddress1, 0, 0);
			//gridaddress1.Children.Add(address1, 1, 0);
			//gridaddress1.Children.Add(address1edit, 3, 0);



			//address2
			address2 = new MyEntry
			{
				Placeholder = "Address2",
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions=LayoutOptions.Center,
				PlaceholderColor = Color.WhiteSmoke,
				TextColor=Color.White ,
				Keyboard = Keyboard.Default,
			};
			imgaddress2 = new Image
			{
				Source = Device.OnPlatform("Docotor/address.png", "address.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};


			StackLayout address2stk = new StackLayout();
			address2stk.Orientation = StackOrientation.Horizontal;
			address2stk.BackgroundColor = Color.Transparent;
			address2stk.Children.Add(imgaddress2);
			address2stk.Children.Add(address2);

			Faddress2 = new CustomFrame
			{
				Content = address2stk,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderRadius=10,
				BackgroundColor = Color.Transparent,
			};

			//gridaddress2 = new Grid()
			//{
			//	ColumnDefinitions =
			//  {
		 // new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		 // new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			//new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			//  },
			//	HeightRequest = 35,
			//	BackgroundColor = Color.White,
			//	Padding = new Thickness(10, 1, 10, 1)
			//};

			//gridaddress2.Children.Add(imgaddress2, 0, 0);
			//gridaddress2.Children.Add(address2, 1, 0);
			//gridaddress2.Children.Add(address2edit, 3, 0);








			//city
			city = new MyEntry
			{
				Placeholder = "City",
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions=LayoutOptions.Center,
				PlaceholderColor = Color.WhiteSmoke,
				TextColor=Color.White ,
				Keyboard = Keyboard.Default,
			};
			imgcity = new Image
			{
				Source = Device.OnPlatform("Docotor/city.png", "city.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};


			StackLayout citystk = new StackLayout();
			citystk.Orientation = StackOrientation.Horizontal;
			citystk.BackgroundColor = Color.Transparent;
			citystk.Children.Add(imgcity);
			citystk.Children.Add(city);
		

			Fcity = new CustomFrame
			{
				Content = citystk,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderRadius=10,
				BackgroundColor = Color.Transparent,
			};

			//gridcity = new Grid()
			//{
			//	ColumnDefinitions =
			//  {
		 // new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		 // new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			//new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			//  },
			//	HeightRequest = 35,
			//	BackgroundColor = Color.White,
			//	Padding = new Thickness(10, 1, 10, 1)
			//};

			//gridcity.Children.Add(imgcity, 0, 0);
			//gridcity.Children.Add(city, 1, 0);
			//gridcity.Children.Add(cityedit, 3, 0);


			//country
			country = new MyEntry
			{
				Placeholder = "Country",
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions=LayoutOptions.Center,
				PlaceholderColor = Color.WhiteSmoke,
				TextColor=Color.White ,
				Keyboard = Keyboard.Default,
			};
			imgcountry = new Image
			{
				
				Source = Device.OnPlatform("Docotor/country.png", "country.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};


			StackLayout countrystk = new StackLayout();
			countrystk.Orientation = StackOrientation.Horizontal;
			countrystk.BackgroundColor = Color.Transparent;
			countrystk.Children.Add(imgcountry);
			countrystk.Children.Add(country);



			Fcountry = new CustomFrame
			{
				Content = countrystk,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderRadius=10,
				BackgroundColor = Color.Transparent,
			};
			//gridcountry = new Grid()
			//{
			//	ColumnDefinitions =
			//  {
		 // new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		 // new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			//new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			//  },
			//	HeightRequest = 35,
			//	BackgroundColor = Color.White,
			//	Padding = new Thickness(10, 1, 10, 1)
			//};

			//gridcountry.Children.Add(imgcountry, 0, 0);
			//gridcountry.Children.Add(country, 1, 0);
			//gridcountry.Children.Add(countryedit, 3, 0);

			//home
			Hmobile = new MyEntry
			{
				Placeholder = "Home Mobile",
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions=LayoutOptions.Center,
				PlaceholderColor = Color.WhiteSmoke,
				TextColor=Color.White ,
				Keyboard = Keyboard.Telephone,
			};
			imgHmobile = new Image
			{
				
				Source = Device.OnPlatform("Docotor/Hmobile.png", "Hmobile.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};


			StackLayout Hmobilestk = new StackLayout();
			Hmobilestk.Orientation = StackOrientation.Horizontal;
			Hmobilestk.BackgroundColor = Color.Transparent;
			Hmobilestk.Children.Add(imgHmobile);
			Hmobilestk.Children.Add(Hmobile);

			FHmobile = new CustomFrame
			{
				Content = Hmobilestk,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderRadius=10,
				BackgroundColor = Color.Transparent,
			};

			//gridHmobile = new Grid()
			//{
			//	ColumnDefinitions =
			//  {
		 // new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		 // new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			//new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			//  },
			//	HeightRequest = 35,
			//	BackgroundColor = Color.White,
			//	Padding = new Thickness(10, 1, 10, 1)
			//};

			//gridHmobile.Children.Add(imgHmobile, 0, 0);
			//gridHmobile.Children.Add(Hmobile, 1, 0);
			//gridHmobile.Children.Add(Hmobileedit, 3, 0);

			//Work mobile

			Wmobile = new MyEntry
			{
				Placeholder = "Work Mobile",
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions=LayoutOptions.Center,
				PlaceholderColor = Color.WhiteSmoke,
				TextColor=Color.White ,
				Keyboard = Keyboard.Telephone,
			};
			imgWmobile = new Image
			{

				Source = Device.OnPlatform("Docotor/landline.png", "landline.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};


			StackLayout Wmobilestk = new StackLayout();
			Wmobilestk.Orientation = StackOrientation.Horizontal;
			Wmobilestk.BackgroundColor = Color.Transparent;
			Wmobilestk.Children.Add(imgWmobile);
			Wmobilestk.Children.Add(Wmobile);

			FWmobile = new CustomFrame
			{
				Content = Wmobilestk,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderRadius=10,
				BackgroundColor = Color.Transparent,
			};

			//gridWmobile = new Grid()
			//{
			//	ColumnDefinitions =
			//  {
		 // new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		 // new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			//new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			//  },
			//	HeightRequest = 35,
			//	BackgroundColor = Color.White,
			//	Padding = new Thickness(10, 1, 10, 1)
			//};

			//gridWmobile.Children.Add(imgWmobile, 0, 0);
			//gridWmobile.Children.Add(Wmobile, 1, 0);
			//gridWmobile.Children.Add(Wmobileedit, 3, 0);



			//mobile
			mobile = new MyEntry
			{
				Placeholder = "Mobile",
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions=LayoutOptions.Center,
				PlaceholderColor = Color.WhiteSmoke,
				TextColor=Color.White ,
				Keyboard = Keyboard.Telephone,
			};
			imgmobile = new Image
			{
				
				Source = Device.OnPlatform("Docotor/mobile.png", "mobile.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};


			StackLayout mobilestk = new StackLayout();
			mobilestk.Orientation = StackOrientation.Horizontal;
			mobilestk.BackgroundColor = Color.Transparent;
			mobilestk.Children.Add(imgmobile);
			mobilestk.Children.Add(mobile);

			Fmobile = new CustomFrame
			{
				Content = mobilestk,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderRadius=10,
				BackgroundColor = Color.Transparent,
			};
			//gridmobile = new Grid()
			//{
			//	ColumnDefinitions =
			//  {
		 // new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		 // new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			//new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			//  },
			//	HeightRequest = 35,
			//	BackgroundColor = Color.White,
			//	Padding = new Thickness(10, 1, 10, 1)
			//};

			//gridmobile.Children.Add(imgmobile, 0, 0);
			//gridmobile.Children.Add(mobile, 1, 0);
			//gridmobile.Children.Add(mobileedit, 3, 0);






			//email
			email = new MyEntry
			{
				Placeholder = "Email",
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions=LayoutOptions.Center,
				PlaceholderColor = Color.WhiteSmoke,
				TextColor=Color.White ,
				Keyboard = Keyboard.Email,
			};
			imgemail = new Image
			{
				Source = Device.OnPlatform("Docotor/email.png", "email.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};


			StackLayout emailstk = new StackLayout();
			emailstk.Orientation = StackOrientation.Horizontal;
			emailstk.BackgroundColor = Color.Transparent;
			emailstk.Children.Add(imgemail);
			emailstk.Children.Add(email);

			Femail = new CustomFrame
			{
				Content = emailstk,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(7),
				OutlineColor = Color.White,
				BorderRadius=10,
				BackgroundColor = Color.Transparent,
			};

			//gridemail = new Grid()
			//{
			//	ColumnDefinitions =
			//  {
		 // new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		 // new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			//new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			//  },
			//	HeightRequest = 35,
			//	BackgroundColor = Color.White,
			//	Padding = new Thickness(10, 1, 10, 1)
			//};

			//gridemail.Children.Add(imgemail, 0, 0);
			//gridemail.Children.Add(email, 1, 0);
			//gridemail.Children.Add(emailedit, 3, 0);

			//clinic
			clinic = new Label 
			{
				

				TextColor = Color.White ,
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,

			};
			imgclinic = new Image
			{
				Source = "expen1.png",
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};



			clinicedit = new Image
			{
				Source = "downarow1.png",
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};



			gridclinic = new Grid()
			{
				ColumnDefinitions =
			  {
		  new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		  new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			  },
				HeightRequest = 35,
				BackgroundColor = Color.Gray,
				Padding = new Thickness(10, 1, 10, 1)
			};

			gridclinic.Children.Add(imgclinic, 3, 0);
			gridclinic.Children.Add(clinic, 0, 0);
			//gridclinic.Children.Add(clinicedit, 3, 0);

			var tapclicnic = new TapGestureRecognizer();
			tapclicnic.Tapped += Tapclinic_Tapped;
			gridclinic.GestureRecognizers.Add(tapclicnic);




			Label nameLabel = new Label
			{
				Text="Clinic1",
				TextColor = Color.FromRgb(30, 30, 30),
			
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.Center
			};

			Button btndeletedoc = new Button
			{


			};
			btndeletedoc.Image = Device.OnPlatform("Docotor/remove.png", "remove.png", "delete2.png");



			stkclinics = new StackLayout();
			stkclinics.Orientation = StackOrientation.Vertical ;
			stkclinics.BackgroundColor = Color.White ;








			//btndeletedoc.Clicked += Btndeletedoc_Clicked;
			imgprfqexpen = new Image
			{
				Source = "expen1.png",
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};



	Label prfq = new Label
	{

		Text = "Professional Details",
		TextColor = Color.White ,
		FontSize = Device.OnPlatform(20, 20, 20),
		
		HorizontalOptions = LayoutOptions.Start,
		VerticalOptions = LayoutOptions.Center,

	};
			gridprfqexp = new Grid()
			{
				ColumnDefinitions =
			  {
		  new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		  new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			

			  },
				HeightRequest = 35,
				BackgroundColor = Color.Gray ,
				Padding = new Thickness(10, 1, 10, 1)
			};

			gridprfqexp.Children.Add(imgprfqexpen, 3, 0);
			gridprfqexp.Children.Add(prfq, 0, 0);

			var tapimgprfqexpen = new TapGestureRecognizer();
			tapimgprfqexpen.Tapped += Tapimgprfqexpen_Tapped;
			gridprfqexp.GestureRecognizers.Add(tapimgprfqexpen);

		 editor = new Editor 
			{ 
				Text = "Enter The Professional Details",
				BackgroundColor = Color.White ,
				HeightRequest=75,
				TextColor = Color.Gray,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
			//	IsVisible=false 

			};
			editor.Focused += editor_Focused;
			editor.Unfocused += editor_Unfocused;


			imgdocuplexpen = new Image
			{
				Source = "expen1.png",
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};

			Label docupl = new Label
			{

				Text = "Upload Documents ",
				TextColor = Color.White  ,
				FontSize = Device.OnPlatform(20, 20, 20),

				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,

			};
			griddocuplexp = new Grid()
			{
				ColumnDefinitions =
			  {
		  new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		  new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},


			  },
				HeightRequest = 35,
				BackgroundColor = Color.Gray,
				Padding = new Thickness(10, 1, 10, 1)
			};

			griddocuplexp.Children.Add(imgdocuplexpen, 3, 0);
			griddocuplexp.Children.Add(docupl, 0, 0);

			var tapgriddocuplexp = new TapGestureRecognizer();
			tapgriddocuplexp.Tapped += Taptapgriddocuplexp_Tapped;
			griddocuplexp.GestureRecognizers.Add(tapgriddocuplexp);

			//GMC
			gmcupload = new Label
			{

				Text = "Choose File",
				TextColor = Color.Gray,
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize =15,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,

			};
			 gmcname = new Label
			{

				Text = "GMC",
				TextColor = Color.Red ,
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = 6,
				 HorizontalOptions = LayoutOptions.Start,



			};
			imgfile = new Image
			{
				
				Source = Device.OnPlatform("Docotor/uploadfile.png", "uploadfile.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};

			StackLayout stkgmcfile = new StackLayout();

			stkgmcfile.Orientation = StackOrientation.Vertical ;
			stkgmcfile.Children.Add(gmcname);
			stkgmcfile.Children.Add(imgfile);
			stkgmcfile.HorizontalOptions = LayoutOptions.Start ;
			stkgmcfile.Spacing = 0;
			stkgmcfile.WidthRequest = 32;
			uploadaddimg = new Image
			{
				
				Source = Device.OnPlatform("Docotor/addfile.png", "addfile.png", null),
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};
			//upload event
			var tapuploadaddimg = new TapGestureRecognizer();
			tapuploadaddimg.Tapped += Taptapuploadaddimg_Tapped;
			uploadaddimg.GestureRecognizers.Add(tapuploadaddimg);

			uploaddeleteimg = new Image
			{
				
				Source = Device.OnPlatform("Docotor/Deletefile.png", "Deletefile.png", null),
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};
			//deleteuplod
			deletefile d = new deletefile();
			d.gmc=Config.user_Id.ToString() + "_" + "gmc";
			var tapuploaddeleteimg = new TapGestureRecognizer();
          	tapuploaddeleteimg.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("gmc", 0 ,null,null,null,d));
			tapuploaddeleteimg.Tapped += Taptaptapuploaddeleteimg_Tapped;
			uploaddeleteimg.GestureRecognizers.Add(tapuploaddeleteimg);


			StackLayout stkuploadbtn = new StackLayout();

			stkuploadbtn.Orientation = StackOrientation.Horizontal;
			stkuploadbtn.Children.Add(uploadaddimg);
			stkuploadbtn.Children.Add(uploaddeleteimg);
			stkuploadbtn.HorizontalOptions = LayoutOptions.End;
			stkuploadbtn.Spacing = 15;
			//var tapclicnic = new TapGestureRecognizer();
			//tapclicnic.Tapped += Tapclinic_Tapped;
			//clinicedit.GestureRecognizers.Add(tapclicnic);

			progressBar = new ProgressBar
			{
				Progress = .0,
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = 22,
				Margin = new Thickness(0,2,0,0),
				IsVisible =false 

					
					
				                                 
			};
			griduploadgmc = new Grid()
			{
				ColumnDefinitions =
			  {
		  new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		  new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			  },
				HeightRequest = 35,
				BackgroundColor = Color.Transparent ,
				Padding = new Thickness(10, 1, 10, 1)
					
			};

			griduploadgmc.Children.Add(stkgmcfile, 0, 0);
			griduploadgmc.Children.Add(gmcupload, 1, 0);
			griduploadgmc.Children.Add(stkuploadbtn, 3, 0);
			griduploadgmc.Children.Add(progressBar, 0, 2,0,1);

			 fgmc = new Frame
			{
				Content = griduploadgmc,
				OutlineColor = Color.Red  ,
				Padding = new Thickness(0, 5, 0, 0),
				Margin = new Thickness(17, 1, 17, 1),
				HasShadow=Device.OnPlatform(false,true,true) 
				// VerticalOptions = LayoutOptions.CenterAndExpand,
				//HorizontalOptions = LayoutOptions.Center
			};
			//End GMC


			//Indemnity
			Indemnityupload = new Label
			{

				Text = "Choose File",
				TextColor = Color.Gray,
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = 15,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,

			};
			Indemnityname = new Label
			{

				Text = "Indemnity",
				TextColor = Color.Red,
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = 6,
				HorizontalOptions = LayoutOptions.Start,


			};
			imgfileIndemnity = new Image
			{

				Source = Device.OnPlatform("Docotor/uploadfile.png", "uploadfile.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};

			StackLayout stkIndemnityfile = new StackLayout();

			stkIndemnityfile.Orientation = StackOrientation.Vertical;
			stkIndemnityfile.Children.Add(Indemnityname);
			stkIndemnityfile.Children.Add(imgfileIndemnity);
			stkIndemnityfile.HorizontalOptions = LayoutOptions.Start;
			stkIndemnityfile.Spacing = 0;
			stkIndemnityfile.WidthRequest = 32;

			uploadaddimgtapIndemnity = new Image
			{
				
				Source = Device.OnPlatform("Docotor/addfile.png", "addfile.png", null),
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};
			//upload event
			var tapIndemnity = new TapGestureRecognizer();
			tapIndemnity.Tapped += tapuploadimgIndemnity_Tapped;
			uploadaddimgtapIndemnity.GestureRecognizers.Add(tapIndemnity);

			uploaddeleteimgIndemnity = new Image
			{
				
				Source = Device.OnPlatform("Docotor/Deletefile.png", "Deletefile.png", null),
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};
			//deleteuplod

			d.indemnity=Config.user_Id.ToString() + "_" + "indemnity";
			var tapuploaddeleteimgIndemnity = new TapGestureRecognizer();
			tapuploaddeleteimgIndemnity.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("indemnity", 0 ,null,null,null,d));
			tapuploaddeleteimgIndemnity.Tapped += tapuplodeleteimgIndemnity_Tapped;
			uploaddeleteimgIndemnity.GestureRecognizers.Add(tapuploaddeleteimgIndemnity);


			StackLayout stkuploadbtntIndemnity = new StackLayout();

			stkuploadbtntIndemnity.Orientation = StackOrientation.Horizontal;
			stkuploadbtntIndemnity.Children.Add(uploadaddimgtapIndemnity);
			stkuploadbtntIndemnity.Children.Add(uploaddeleteimgIndemnity);
			stkuploadbtntIndemnity.HorizontalOptions = LayoutOptions.End;
			stkuploadbtntIndemnity.Spacing = 15;
			//var tapclicnic = new TapGestureRecognizer();
			//tapclicnic.Tapped += Tapclinic_Tapped;
			//clinicedit.GestureRecognizers.Add(tapclicnic);

			progressBarIndemnity = new ProgressBar
			{
				Progress = .0,
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = 22,
				Margin = new Thickness(0, 2, 0, 0),
				IsVisible = false




			};
			griduploadIndemnity = new Grid()
			{
				ColumnDefinitions =
			  {
		  new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		  new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			  },
				HeightRequest = 35,
				BackgroundColor = Color.Transparent,
				Padding = new Thickness(10, 1, 10, 1)

			};

			griduploadIndemnity.Children.Add(stkIndemnityfile, 0, 0);
			griduploadIndemnity.Children.Add(Indemnityupload, 1, 0);
			griduploadIndemnity.Children.Add(stkuploadbtntIndemnity, 3, 0);
			griduploadIndemnity.Children.Add(progressBarIndemnity, 0, 2, 0, 1);

			fIndemnity = new Frame
			{
				Content = griduploadIndemnity,
				OutlineColor = Color.Red,
				Padding = new Thickness(0, 5, 0, 0),
				Margin = new Thickness(17, 1, 17, 1),
				HasShadow = Device.OnPlatform(false, true, true)
					
				// VerticalOptions = LayoutOptions.CenterAndExpand,
				//HorizontalOptions = LayoutOptions.Center
			};
			//End Indemnity

			//Appraisal

			Appraisalupload = new Label
			{

				Text = "Choose File",
				TextColor = Color.Gray,
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = 15,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,

			};
			Appraisalname = new Label
			{

				Text = "Appraisal",
				TextColor = Color.Red,
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = 6,
				HorizontalOptions = LayoutOptions.Start ,


			};
			imgfileAppraisal = new Image
			{
				
				Source = Device.OnPlatform("Docotor/uploadfile.png", "uploadfile.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};

			StackLayout stkAppraisalfile = new StackLayout();

			stkAppraisalfile.Orientation = StackOrientation.Vertical;
			stkAppraisalfile.Children.Add(Appraisalname);
			stkAppraisalfile.Children.Add(imgfileAppraisal);
			stkAppraisalfile.HorizontalOptions = LayoutOptions.Start;
			stkAppraisalfile.Spacing = 0;
			stkAppraisalfile.WidthRequest = 32;
			uploadaddimgtapAppraisal = new Image
			{
				Source = Device.OnPlatform("Docotor/addfile.png", "addfile.png", null),
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};
			//upload event
			var tapAppraisal = new TapGestureRecognizer();
			tapAppraisal.Tapped += tapuploadimgAppraisal_Tapped;
			uploadaddimgtapAppraisal.GestureRecognizers.Add(tapAppraisal);

			uploaddeleteimgAppraisal = new Image
			{
				Source = Device.OnPlatform("Docotor/Deletefile.png", "Deletefile.png", null),
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};
			//deleteuplod
			d.appraisal=Config.user_Id.ToString() + "_" + "appraisal";
			var tapuploaddeleteimgAppraisal = new TapGestureRecognizer();
			tapuploaddeleteimgAppraisal.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("appraisal", 0 ,null,null,null,d));
			tapuploaddeleteimgAppraisal.Tapped += tapuplodeleteimgAppraisal_Tapped;
			uploaddeleteimgAppraisal.GestureRecognizers.Add(tapuploaddeleteimgAppraisal);


			StackLayout stkuploadbtntAppraisal = new StackLayout();

			stkuploadbtntAppraisal.Orientation = StackOrientation.Horizontal;
			stkuploadbtntAppraisal.Children.Add(uploadaddimgtapAppraisal);
			stkuploadbtntAppraisal.Children.Add(uploaddeleteimgAppraisal);
			stkuploadbtntAppraisal.HorizontalOptions = LayoutOptions.End;
			stkuploadbtntAppraisal.Spacing = 15;
			//var tapclicnic = new TapGestureRecognizer();
			//tapclicnic.Tapped += Tapclinic_Tapped;
			//clinicedit.GestureRecognizers.Add(tapclicnic);

			progressBarAppraisal = new ProgressBar
			{
				Progress = .0,
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = 22,
				Margin = new Thickness(0, 2, 0, 0),
				IsVisible = false




			};
			griduploadAppraisal = new Grid()
			{
				ColumnDefinitions =
			  {
		  new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		  new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			  },
				HeightRequest = 35,
				BackgroundColor = Color.Transparent,
				Padding = new Thickness(10, 1, 10, 1)

			};

			griduploadAppraisal.Children.Add(stkAppraisalfile, 0, 0);
			griduploadAppraisal.Children.Add(Appraisalupload, 1, 0);
			griduploadAppraisal.Children.Add(stkuploadbtntAppraisal, 3, 0);
			griduploadAppraisal.Children.Add(progressBarAppraisal, 0, 2, 0, 1);

			fAppraisal = new Frame
			{
				Content = griduploadAppraisal,
				OutlineColor = Color.Red,
				Padding = new Thickness(0, 5, 0, 0),
				Margin = new Thickness(17, 1, 17, 1),
				HasShadow = Device.OnPlatform(false, true, true)
				// VerticalOptions = LayoutOptions.CenterAndExpand,
				//HorizontalOptions = LayoutOptions.Center
			};

			//End Appraisal

			 arrangeupload = new StackLayout();
			arrangeupload.Orientation = StackOrientation.Vertical ;
			arrangeupload.Children.Add(fgmc );
			arrangeupload.Children.Add(fIndemnity);
			arrangeupload.Children.Add(fAppraisal);
			//arrangeupload.IsVisible = false;




			Label logoupl = new Label
			{

				Text = "Upload Logos  ",
				TextColor = Color.White ,
				FontSize = Device.OnPlatform(20, 20, 20),
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,

			};


			//upload logo
			imglogouploadexpen = new Image
			{
				Source = "expen1.png",
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};


			logoupload = new Label
			{

				Text = "Choose File",
				TextColor = Color.Gray,
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = 15,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,

			};

			gridlogouploadexp = new Grid()
			{
				ColumnDefinitions =
			  {
		  new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		  new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},


			  },
				HeightRequest = 35,
				BackgroundColor = Color.Gray,
				Padding = new Thickness(10, 1, 10, 1),

			};

			gridlogouploadexp.Children.Add(imglogouploadexpen,3, 0 );
			gridlogouploadexp.Children.Add(logoupl, 0, 0);

			var tapgridlogouploadexp = new TapGestureRecognizer();
			tapgridlogouploadexp.Tapped += Tapgridlogouploadexp_Tapped;
			gridlogouploadexp.GestureRecognizers.Add(tapgridlogouploadexp);

			logoname = new Label
			{

				Text = "logo",
				TextColor = Color.Red,
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = 6,
				HorizontalOptions = LayoutOptions.Start,


			};
			imgfilelogo = new Image
			{
				
				Source = Device.OnPlatform("Docotor/imglogoupload.png", "imglogoupload.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};

			StackLayout stklogofile = new StackLayout();

			stklogofile.Orientation = StackOrientation.Vertical;
			stklogofile.Children.Add(logoname);
			stklogofile.Children.Add(imgfilelogo);
			stklogofile.HorizontalOptions = LayoutOptions.Start;
			stklogofile.Spacing = 0;
			stklogofile.WidthRequest = 32;

			uploadaddimgtaplogo = new Image
			{
				Source = Device.OnPlatform("Docotor/addfile.png", "addfile.png", null),
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};
			//upload event
			var taplogo = new TapGestureRecognizer();
			taplogo.Tapped += tapuploadimglogo_Tapped;
			uploadaddimgtaplogo.GestureRecognizers.Add(taplogo);

			uploaddeleteimglogo = new Image
			{
				Source = Device.OnPlatform("Docotor/Deletefile.png", "Deletefile.png", null),
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};
			//deleteuplod
			d.logo=Config.user_Id.ToString() + "_" + "logo";
			var tapuploaddeleteimglogo = new TapGestureRecognizer();
			tapuploaddeleteimglogo.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("logo", 0 ,null,null,null,d));
			tapuploaddeleteimglogo.Tapped += tapuplodeleteimglogo_Tapped;
			uploaddeleteimglogo.GestureRecognizers.Add(tapuploaddeleteimglogo);


			StackLayout stkuploadbtntlogo = new StackLayout();

			stkuploadbtntlogo.Orientation = StackOrientation.Horizontal;
			stkuploadbtntlogo.Children.Add(uploadaddimgtaplogo);
			stkuploadbtntlogo.Children.Add(uploaddeleteimglogo);
			stkuploadbtntlogo.HorizontalOptions = LayoutOptions.End;
			stkuploadbtntlogo.Spacing = 15;
			//var tapclicnic = new TapGestureRecognizer();
			//tapclicnic.Tapped += Tapclinic_Tapped;
			//clinicedit.GestureRecognizers.Add(tapclicnic);

			progressBarlogo = new ProgressBar
			{
				Progress = .0,
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = 22,
				Margin = new Thickness(0, 2, 0, 0),
				IsVisible = false




			};
			griduploadlogo = new Grid()
			{
				ColumnDefinitions =
			  {
		  new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		  new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			  },
				HeightRequest = 35,
				BackgroundColor = Color.Transparent,
				Padding = new Thickness(10, 1, 10, 1)

			};

			griduploadlogo.Children.Add(stklogofile, 0, 0);
			griduploadlogo.Children.Add(logoupload, 1, 0);
			griduploadlogo.Children.Add(stkuploadbtntlogo, 3, 0);
			griduploadlogo.Children.Add(progressBarlogo, 0, 2, 0, 1);

			flogo = new Frame
			{
				Content = griduploadlogo,
				OutlineColor = Color.Red,
				Padding = new Thickness(0, 5, 0, 0),
				Margin = new Thickness(17, 1, 17, 1),
				HasShadow = Device.OnPlatform(false, true, true)
				//IsVisible=false 
				// VerticalOptions = LayoutOptions.CenterAndExpand,
				//HorizontalOptions = LayoutOptions.Center
			};



			//end uploadlogo


			//Sing
			imgsinguplexpen = new Image
			{
				Source = "expen1.png",
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};
			Label singupl = new Label
			{

				Text = "Upload Signature ",
				TextColor = Color.White ,
				FontSize = Device.OnPlatform(20, 20, 20),
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,

			};

			gridsingupldexp = new Grid()
			{
				ColumnDefinitions =
			  {
		  new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		  new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},


			  },
				HeightRequest = 35,
				BackgroundColor = Color.Gray,
				Padding = new Thickness(10, 1, 10, 1)
			};

			gridsingupldexp.Children.Add(imgsinguplexpen, 3, 0);
			gridsingupldexp.Children.Add(singupl, 0, 0);

			var tapgridsingupldexp = new TapGestureRecognizer();
			tapgridsingupldexp.Tapped += Tapgridsingupldexp_Tapped;
			gridsingupldexp.GestureRecognizers.Add(tapgridsingupldexp);


			Singupload = new Label
			{

				Text = "Choose File",
				TextColor = Color.Gray,
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = 15,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,

			};
			Singname = new Label
			{

				Text = "Sing",
				TextColor = Color.Red,
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize = 6,
				HorizontalOptions = LayoutOptions.Start,


			};
			imgfileSing = new Image
			{
				
				Source = Device.OnPlatform("Docotor/singupload.png", "singupload.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};

			StackLayout stkSingfile = new StackLayout();

			stkSingfile.Orientation = StackOrientation.Vertical;
			stkSingfile.Children.Add(Singname);
			stkSingfile.Children.Add(imgfileSing);
			stkSingfile.HorizontalOptions = LayoutOptions.Start;
			stkSingfile.Spacing = 0;
			stkSingfile.WidthRequest = 32;

			uploadaddimgtapSing = new Image
			{
				Source = Device.OnPlatform("Docotor/addfile.png", "addfile.png", null),
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};
			//upload event
			var tapSing = new TapGestureRecognizer();
			tapSing.Tapped += tapuploadimgSing_Tapped;
			uploadaddimgtapSing.GestureRecognizers.Add(tapSing);

			uploaddeleteimgSing = new Image
			{
				Source = Device.OnPlatform("Docotor/Deletefile.png", "Deletefile.png", null),
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};
			//deleteuplod
			d.signature=Config.user_Id.ToString() + "_" + "signature";
			var tapuploaddeleteimgSing = new TapGestureRecognizer();
			tapuploaddeleteimgSing.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("signature", 0 ,null,null,null,d));
			tapuploaddeleteimgSing.Tapped += tapuplodeleteimgSing_Tapped;
			uploaddeleteimgSing.GestureRecognizers.Add(tapuploaddeleteimgSing);


			StackLayout stkuploadbtntSing = new StackLayout();

			stkuploadbtntSing.Orientation = StackOrientation.Horizontal;
			stkuploadbtntSing.Children.Add(uploadaddimgtapSing);
			stkuploadbtntSing.Children.Add(uploaddeleteimgSing);
			stkuploadbtntSing.HorizontalOptions = LayoutOptions.End;
			stkuploadbtntSing.Spacing = 15;
			//var tapclicnic = new TapGestureRecognizer();
			//tapclicnic.Tapped += Tapclinic_Tapped;
			//clinicedit.GestureRecognizers.Add(tapclicnic);

			progressBarSing = new ProgressBar
			{
				Progress = .0,
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = 22,
				Margin = new Thickness(0, 2, 0, 0),
				IsVisible = false




			};
			griduploadSing = new Grid()
			{
				ColumnDefinitions =
			  {
		  new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto)},
		  new ColumnDefinition{Width = new GridLength(2, GridUnitType.Auto)},
			new ColumnDefinition{Width = new GridLength(3, GridUnitType.Auto)},

			  },
				HeightRequest = 35,
				BackgroundColor = Color.Transparent,
				Padding = new Thickness(10, 1, 10, 1),


			};

			griduploadSing.Children.Add(stkSingfile, 0, 0);
			griduploadSing.Children.Add(Singupload, 1, 0);
			griduploadSing.Children.Add(stkuploadbtntSing, 3, 0);
			griduploadSing.Children.Add(progressBarSing, 0, 2, 0, 1);

			fSing = new Frame
			{
				Content = griduploadSing,
				OutlineColor = Color.Red,
				Padding = new Thickness(0, 5, 0, 0),
				Margin = new Thickness(17, 1, 17, 1),
				HasShadow = Device.OnPlatform(false, true, true)
				//IsVisible=false 
				// VerticalOptions = LayoutOptions.CenterAndExpand,
				//HorizontalOptions = LayoutOptions.Center
			};


			//end sing


			//update button
			btnupdate = new Button
			{
				Text = "Update",
				Style = (Style)Application.Current.Resources["CPButton"],
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Margin = new Thickness(20,2,20,2)
				                               
			};
			btnupdate.Clicked += updatedetails;
			stkprofile = new StackLayout();
			stkprofile.Margin = new Thickness(17,0,17,0);
			stkprofile.HorizontalOptions = LayoutOptions.Fill;
			stkprofile.VerticalOptions = LayoutOptions.Start;
			stkprofile.Orientation = StackOrientation.Vertical;
            stkprofile.Children.Add(stkgender);
			stkprofile.Children.Add(Fname);
			stkprofile.Children.Add(Fdob);
			stkprofile.Children.Add(Fpostalcode);
			stkprofile.Children.Add(Faddress1);
			stkprofile.Children.Add(Faddress2);
			stkprofile.Children.Add(Fcity);
			stkprofile.Children.Add(Fcountry);
			stkprofile.Children.Add(FHmobile);
			stkprofile.Children.Add(FWmobile);
			stkprofile.Children.Add(Fmobile);
			stkprofile.Children.Add(Femail);
			stkprofile.Children.Add(editor);

			stkClinic = new StackLayout();
			stkClinic.HorizontalOptions = LayoutOptions.Fill;
			stkClinic.VerticalOptions = LayoutOptions.Start;
			stkClinic.Orientation = StackOrientation.Vertical;
			//stkClinic.Children.Add(gridclinic);
			//stkClinic.Children.Add(stkclinics);

			stkdoc = new StackLayout();
			stkdoc.HorizontalOptions = LayoutOptions.Fill;
			stkdoc.VerticalOptions = LayoutOptions.Start;
			stkdoc.Orientation = StackOrientation.Vertical;
			//stkdoc.Children.Add(griddocuplexp);
			stkdoc.Children.Add(arrangeupload);

			stklogo = new StackLayout();
			stklogo.HorizontalOptions = LayoutOptions.Fill;
			stklogo.VerticalOptions = LayoutOptions.Start;
			stklogo.Orientation = StackOrientation.Vertical;
			//stklogo.Children.Add(gridlogouploadexp);
			stklogo.Children.Add(flogo);

			stksing = new StackLayout();
			stksing.HorizontalOptions = LayoutOptions.Fill;
			stksing.VerticalOptions = LayoutOptions.Start;
			stksing.Orientation = StackOrientation.Vertical;
			//stksing.Children.Add(gridsingupldexp);
			stksing.Children.Add(fSing);


			st_tabContent = new StackLayout();
			st_tabContent.BackgroundColor = Color.Transparent;
			st_tabContent.HorizontalOptions = LayoutOptions.Fill;
			st_tabContent.VerticalOptions = LayoutOptions.FillAndExpand;
			st_tabContent.Padding = new Thickness(0, 10, 0, 10);
			st_tabContent.Children.Add(stkprofile);


			StackLayout stkdetail = new StackLayout();
			stkdetail.HorizontalOptions = LayoutOptions.Fill;
			stkdetail.VerticalOptions = LayoutOptions.Start;
			stkdetail.Orientation = StackOrientation.Vertical;

			stkdetail.Children.Add(gridscroll);
			stkdetail.Children.Add(st_tabContent);

			stkdetail.Children.Add(btnupdate);
			stkdetail.Children.Add(imagpick);




		StackLayout	Content1 = new StackLayout
			{
				Children = {
					stack_user,stkdetail
				}
			};
			var scroll = new ScrollView();
			scroll.Content = Content1;
			Content = scroll;

		}

		void imagpick_SelectedIndexChanged(object sender, EventArgs e)
		{
				if (imagpick.SelectedIndex == 0)
			{
                takepic();
			}
			if (imagpick.SelectedIndex == 1)
			{
				gallerypic();
			}
				imagpick.IsEnabled = false;
	  		 	imagpick.Unfocus();
		
		}
		void Loadimage(object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(() =>
   			{
	 		  	imagpick.IsEnabled = true;
	  		 	imagpick.Focus();
   			});

		}
		async void updatedetails(object sender, EventArgs e)
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
			if (string.IsNullOrEmpty(name.Text))
			{
				DisplayAlert("Info", "Enter Name", "ok");
				return;
			}


			if (string.IsNullOrEmpty(dob.Text))
			{
				DisplayAlert("Info", "Enter Dob", "ok");
				return;
			}

			if (string.IsNullOrEmpty(postalcode.Text))
			{
				DisplayAlert("Info", "Enter postcode", "ok");
				return;
			}

			if (string.IsNullOrEmpty(address1.Text))
			{
				DisplayAlert("Info", "Enter address1", "ok");
				return;
			}

			if (string.IsNullOrEmpty(address2.Text))
			{
				DisplayAlert("Info", "Enter address2", "ok");
				return;
			}

			if (string.IsNullOrEmpty(city.Text))
			{
				DisplayAlert("Info", "Enter city", "ok");
				return;
			}
			if (string.IsNullOrEmpty(country .Text))
			{
				DisplayAlert("Info", "Enter country", "ok");
				return;
			}
			if (string.IsNullOrEmpty(Hmobile .Text))
			{
				DisplayAlert("Info", "Enter home mobile", "ok");
				return;
			}
			if (string.IsNullOrEmpty(Wmobile.Text))
			{
				DisplayAlert("Info", "Enter work mobile", "ok");
				return;
			}
			if (string.IsNullOrEmpty(mobile.Text))
			{
				DisplayAlert("Info", "Enter mobile", "ok");
				return;
			}
			if (string.IsNullOrEmpty(email.Text))
			{
				DisplayAlert("Info", "Enter email", "ok");
				return;
			}
			if (string.IsNullOrEmpty(editor.Text))
			{
				DisplayAlert("Info", "Enter professional details", "ok");
				return;
			}

		var doctors = new DoctorReg
		{
			Title = "",
			FirstName = name.Text,
			MiddleName = "",
			LastName = "",
			Dob = Convert.ToDateTime(dob.Text),
			Gender = "",
			NHSNo = "",
			PostCode = postalcode.Text,
			AddressLine1 = address1.Text,
			AddressLine2 = address2.Text,
			AddressLine3 = "",
			City = city.Text,
			State = "",
			Country = country.Text,
			HomeNo = "",
			WorkNo = Wmobile.Text,
			MobileNo = Hmobile.Text,
			EmailID1 = email.Text,
			Email2 = "",
			Age = "",
			ParentName = "",
			Relation = "",
			ParentAddress = "",
			ParentContactNo = "",
			NxKintName = "",
			NxtKinAddress = "",
			NxtKinContactNo = "",
			FileName = "",
			FilePath = "",
			Deviceid = ""
		};
			try
			{
				//await Navigation.PushPopupAsync(new popup_pleasewait());
				HttpResponseMessage responsePutMethod = ClinicPutRequest("http://178.238.139.243/ThinkdocotorApi/api/DoctorRegsApi?id=" + Config.user_Id, doctors);

				if (responsePutMethod.IsSuccessStatusCode)
				{
					
					//await Navigation.PopAllPopupAsync();
					await DisplayAlert("", "Updated" , "Ok");
					return;
				}
				else
				{
					//await Navigation.PopPopupAsync();
					await DisplayAlert("", "Update error try again" , "Ok");
					return;
				}


			

			}
			catch (Exception ex)
			{
				await Navigation.PopPopupAsync();
				await DisplayAlert("", "update error try again" + ex.Message, "Ok");
				return;

			}

		}
		private static HttpResponseMessage ClinicPutRequest(string RequestURI, DoctorReg docedit)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://178.238.139.243/ThinkdocotorApi/api/DoctorRegsApi/");
			client.DefaultRequestHeaders.Accept.Clear();
			var json = JsonConvert.SerializeObject(docedit);
			HttpContent httpcontent = new StringContent(json);
			httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
			HttpResponseMessage response = client.PutAsync(RequestURI, httpcontent).Result;
			return response;	
		}  
		private StackLayout createstk(CliniclsettingStackviewmodel c)
		{
			Label clinicname = new Label
			{
				Text = c.Clinic_name,
				TextColor = Color.Gray,
				FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
				FontSize =15,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,

			};

			Image imgfileclinic = new Image
			{
				
				Source = Device.OnPlatform("Docotor/clicnicbl.png", "clicnicbl.png", null),
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent,

			};

			Image deleteclinic = new Image
			{
				
				Source = Device.OnPlatform("Docotor/Deletefile.png", "Deletefile.png", null),
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,

			};


			var tapdeleteimg = new TapGestureRecognizer();
			tapdeleteimg.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("Id", 0 ,null,null,null, c));
			tapdeleteimg.Tapped += Taptapdeleteimg_Tapped;
			deleteclinic.GestureRecognizers.Add(tapdeleteimg);





			Grid gridclinicname = new Grid()
			{
				ColumnDefinitions =
			  {
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
		 		    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Auto) },
				    new ColumnDefinition { Width = new GridLength(3, GridUnitType.Auto) },

			  },
				HeightRequest = 35,
				BackgroundColor = Color.Transparent ,
				Padding = new Thickness(10, 1, 10, 1)


			};
			gridclinicname.Children.Add(imgfileclinic, 0, 0);
			gridclinicname.Children.Add(clinicname, 1, 0);
			gridclinicname.Children.Add(deleteclinic, 3, 0);
		

			Frame clinicframe = new Frame
			{
				Content = gridclinicname,
				OutlineColor = Color.Black,
				Padding = new Thickness(0, 5, 0, 0),
				Margin = new Thickness(17, 1, 17, 1),
				HasShadow=Device.OnPlatform(false,true,true) 
			};



			StackLayout mainstk = new StackLayout();
			mainstk.HorizontalOptions = LayoutOptions.FillAndExpand;
			mainstk.Spacing = 10;
			mainstk.VerticalOptions = LayoutOptions.FillAndExpand;
			mainstk.Children.Add(clinicframe);
			mainstk.BindingContext = c;

			return mainstk;
		}

		async void Taptapdeleteimg_Tapped(object sender, EventArgs e)
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
				var answer = await DisplayAlert("", "Sure you want to delete", "Yes", "No");
				if (answer == true)
				{
					if (Device.OS == TargetPlatform.Android)
					{

						await Navigation.PushPopupAsync(new popup_pleasewait());

					}
					if (Device.OS == TargetPlatform.iOS)
					{

						await Navigation.PushPopupAsync(new popup_pleasewait());
						await Navigation.PushPopupAsync(new popup_pleasewait());

					}
					var item = (Image)sender;
					TapGestureRecognizer t = (TapGestureRecognizer)item.GestureRecognizers[0];
					int clinicid = Convert.ToInt32(t.CommandParameter.ToString());
					HttpResponseMessage responsePutMethod = clinicDeleteRequest("http://178.238.139.243/ThinkdocotorApi/api/Clinic_DetailsApi?id=" + clinicid);
					if (responsePutMethod.IsSuccessStatusCode)
					{
						await Navigation.PopAllPopupAsync();
						await DisplayAlert("", "Deleted ", "Ok");
						stkClinic.Children.Clear();
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
			catch (Exception ex)
			{
				await Navigation.PopAllPopupAsync();
				DisplayAlert("", "Something went to worng\n" + ex.Message, "Ok");
				return;
			}
		}
async void GetAddress(object sender, EventArgs e)
{
	if (string.IsNullOrEmpty(postalcode.Text))
	{
		await DisplayAlert("", "Enter Postalcode", "Ok");
		return;
	}
	await Navigation.PushPopupAsync(new popup_pleasewait());
	var httpclient = new HttpClient();
	datecol = new ObservableCollection<addressviewmodel>();


	var encoded = Uri.EscapeUriString(postalcode.Text);

	string uriadd = "https://services.3xsoftware.co.uk/Search/ByPostcode/json?username=CoralTechnologiesHAMedical1365&key=IIZY-KT80-M507-6Z9W&postcode=" + encoded;
	var json = await httpclient.GetStringAsync(uriadd);
	Addressinfo response = JsonConvert.DeserializeObject<Addressinfo>(json);

	if (response.Summaries != null && response.Summaries.Length != 0)
	{
		foreach (Summaries v in response.Summaries)
		{
			datecol.Add(new addressviewmodel(v));
		}

		await Navigation.PopAllPopupAsync();


		Adrsspop consentPage = new Adrsspop(datecol);
		await Navigation.PushPopupAsync(consentPage);
		await consentPage.PageClosedTask;
		if (!string.IsNullOrEmpty(Config.addressdetails))
		{
			string[] word = Config.addressdetails.Split(',');
			address1.Text = word[0];
			address2.Text = word[1];
		}


	}
	else
	{
		await Navigation.PopAllPopupAsync();
		DisplayAlert("", "The postcode is invalid", "Ok");
	}
		}
		private static HttpResponseMessage clinicDeleteRequest(string RequestURI)
	{
		HttpClient client = new HttpClient();
		client.BaseAddress = new Uri("http://178.238.139.243/ThinkdocotorApi/api/Clinic_DetailsApi/");
		client.DefaultRequestHeaders.Accept.Clear();
		HttpResponseMessage response = client.DeleteAsync(RequestURI).Result;
		return response; ;
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
				var json = await httpclient.GetStringAsync("http://178.238.139.243/ThinkdocotorApi/api/Settingpagedetails?userid=" + Config.user_Id);
				Userdetails R = JsonConvert.DeserializeObject<Userdetails>(json);
				if (R != null)
				{
					if (pickerflag)
					{
						if (R.Imgpath != null)
						{
							//img_person.Source =  ImageSource.FromUri(new Uri(R.imageUrl));
							img_person.Source = new UriImageSource
							{
								Uri = new Uri(R.imageUrl),
								CachingEnabled = false
							};
						}
					}

					lblName.Text = R.FirstName;
					name.Text = R.FirstName;
					dob.Text = R.Dob.Date.ToString("D");
					postalcode.Text = R.PostCode;
					address1.Text = R.AddressLine1;
					address2.Text = R.AddressLine2;
					city.Text = R.City;
					country.Text = R.State;
					Hmobile.Text = R.HomeNo;
					Wmobile.Text = R.WorkNo;
					mobile.Text = R.MobileNo;
					email.Text = R.EmailID1;

					foreach (clinicdetails v in R.clinicdetails)
					{

						stkClinic.Children.Add(createstk(new CliniclsettingStackviewmodel(v)));


					}
					if (string.IsNullOrEmpty(R.document.gmc_path))
					{
						gmcupload.Text = "Choose File";
						fgmc.OutlineColor = Color.Red;
						gmcname.TextColor = Color.Red;
						uploadaddimg.Opacity =1;
						uploadaddimg.IsEnabled = true;
						uploaddeleteimg.Opacity = 0.3;
						uploaddeleteimg.IsEnabled = false;
					}
					else
					{
						var extension = Path.GetExtension(R.document.gmc_path);
						gmcupload .Text = "Gmcfile"+extension;
						fgmc.OutlineColor = Color.Green;
						gmcname.TextColor = Color.Green;
						uploadaddimg.Opacity = 0.3;
						uploadaddimg.IsEnabled = false;
						uploaddeleteimg.Opacity = 1;
						uploaddeleteimg.IsEnabled = true;
					}
					if (string.IsNullOrEmpty(R.document.indemnity_path))
					{
						Indemnityupload.Text = "Choose File";
						fIndemnity.OutlineColor = Color.Red;
						Indemnityname.TextColor = Color.Red;
						uploadaddimgtapIndemnity.Opacity = 1;
						uploadaddimgtapIndemnity.IsEnabled = true;
						uploaddeleteimgIndemnity.Opacity = 0.3;
						uploaddeleteimgIndemnity.IsEnabled = false;
					}
					else
					{
						var extension = Path.GetExtension(R.document.indemnity_path);
						Indemnityupload.Text ="Indemnity"+ extension;
						fIndemnity.OutlineColor = Color.Green;
						Indemnityname.TextColor = Color.Green;
						uploadaddimgtapIndemnity.Opacity = 0.3;
						uploadaddimgtapIndemnity.IsEnabled = false;
						uploaddeleteimgIndemnity.Opacity = 1;
						uploaddeleteimgIndemnity.IsEnabled = true;

					}
					if (string.IsNullOrEmpty(R.document.appraisal_path))
					{
						Appraisalupload.Text = "Choose File";
						fAppraisal.OutlineColor = Color.Red;
						Appraisalname.TextColor = Color.Red;
						uploadaddimgtapAppraisal.Opacity = 1;
						uploadaddimgtapAppraisal.IsEnabled = true;
						uploaddeleteimgAppraisal.Opacity = 0.3;
						uploaddeleteimgAppraisal.IsEnabled = false;
					}
					else
					{
						var extension = Path.GetExtension(R.document.appraisal_path);
						Appraisalupload.Text ="appraisal"+ extension;
						fAppraisal.OutlineColor = Color.Green;
						Appraisalname.TextColor = Color.Green;
						uploadaddimgtapAppraisal.Opacity = 0.3;
						uploadaddimgtapAppraisal.IsEnabled = false;
						uploaddeleteimgAppraisal.Opacity = 1;
						uploaddeleteimgAppraisal.IsEnabled = true;
					}
					if (string.IsNullOrEmpty(R.document.logo_path))
					{
						logoupload.Text = "Choose File";
						flogo.OutlineColor = Color.Red;
						logoname.TextColor = Color.Red;
						uploadaddimgtaplogo.Opacity = 1;
						uploadaddimgtaplogo.IsEnabled = true;
						uploaddeleteimglogo.Opacity = 0.3;
						uploaddeleteimglogo.IsEnabled = false;
					}
					else
					{
						var extension = Path.GetExtension(R.document.logo_path);
						logoupload.Text ="logo"+ extension;
						flogo.OutlineColor = Color.Green;
						logoname.TextColor = Color.Green;
						uploadaddimgtaplogo.Opacity = 0.3;
						uploadaddimgtaplogo.IsEnabled = false;
						uploaddeleteimglogo.Opacity = 1;
						uploaddeleteimglogo.IsEnabled = true;
					}
					if (string.IsNullOrEmpty(R.document.signature))
					{
						Singupload.Text = "Choose File";
						fSing.OutlineColor = Color.Red;
						Singname.TextColor = Color.Red;
						uploadaddimgtapSing.Opacity = 1;
						uploadaddimgtapSing.IsEnabled = true;
						uploaddeleteimgSing.Opacity = 0.3;
						uploaddeleteimgSing.IsEnabled = false;
					}
					else
					{
						var extension = Path.GetExtension(R.document.signature);
						Singupload.Text ="Signature"+ extension;
						fSing .OutlineColor = Color.Green;
						Singname.TextColor = Color.Green;
						uploadaddimgtapSing.Opacity = 0.3;
						uploadaddimgtapSing.IsEnabled = false;
						uploaddeleteimgSing.Opacity = 1;
						uploaddeleteimgSing.IsEnabled = true;
					}

					
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
		protected override void OnSizeAllocated(double widht, double height)
		{
			base.OnSizeAllocated(widht, height);

			widthAlloc = widht;
			heightAlloc = height;
			OnAppearing();

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();


		}

		void Tap_Appoint_Tapped(object sender, EventArgs e)
		{
			StackLayout tap_s = (StackLayout)sender;
			//DisplayAlert("!!!", tap_s.Id.ToString(), "OK");
			if (tap_s.Id == st_appoint.Id)
			{
				boxDetails.IsVisible = false;
				boxPhotos.IsVisible = false;
				boxAppoint.IsVisible = true;
				boxlogo.IsVisible = false;
				boxsing.IsVisible = false;
				btnupdate.IsVisible = true;
				st_details.Opacity = 0.3;
				st_photos.Opacity = 0.3;
				st_appoint.Opacity=10;
				st_logo.Opacity = 0.3;
				st_sing.Opacity = 0.3;
				if (heightAlloc < 600)
				{
					gridscroll.ScrollToAsync(st_appoint, ScrollToPosition.Start, true);

				}
			
				st_tabContent.Children.Clear();
				st_tabContent.Children.Add(stkprofile);

			}
			else if (tap_s.Id == st_details.Id)
			{
				boxAppoint.IsVisible = false;
				boxPhotos.IsVisible = false;
				boxDetails.IsVisible = true;
				boxlogo.IsVisible = false;
				boxsing.IsVisible = false;
				btnupdate.IsVisible = false;

				st_details.Opacity = 10;
				st_photos.Opacity = 0.3;
				st_appoint.Opacity = 0.3;
				st_sing.Opacity = 0.3;
				st_logo.Opacity = 0.3;
				if (heightAlloc < 600)
				{
					gridscroll.ScrollToAsync(st_details, ScrollToPosition.Start , true);
				}
				st_tabContent.Children.Clear();
				st_tabContent.Children.Add(stkClinic);
			}
			else if (tap_s.Id == st_photos.Id)
			{
				boxDetails.IsVisible = false;
				boxAppoint.IsVisible = false;
				boxlogo.IsVisible = false;
				boxPhotos.IsVisible = true;
				boxsing.IsVisible = false;
				btnupdate.IsVisible = false;
				st_details.Opacity = 0.3;
				st_photos.Opacity = 10;
				st_appoint.Opacity = 0.3;
				st_sing.Opacity = 0.3;
				st_logo.Opacity = 0.3;
				if (heightAlloc < 600)
				{
					gridscroll.ScrollToAsync(st_photos, ScrollToPosition.Center, true);
				}
				st_tabContent.Children.Clear();
				st_tabContent.Children.Add(stkdoc);

			}
			else if (tap_s.Id == st_logo.Id)
			{
				boxDetails.IsVisible = false;
				boxAppoint.IsVisible = false;
				boxPhotos.IsVisible = false;
				boxsing.IsVisible = false;
				boxlogo.IsVisible = true;
				btnupdate.IsVisible = false;
				st_details.Opacity = 0.3;
				st_photos.Opacity = 0.3;
				st_appoint.Opacity = 0.3;
				st_sing.Opacity = 0.3;
				st_logo.Opacity = 10;
				if (heightAlloc < 600)
				{
					gridscroll.ScrollToAsync(st_logo, ScrollToPosition.Center, true);
				}
				st_tabContent.Children.Clear();
				st_tabContent.Children.Add(stklogo);
			}
			else if (tap_s.Id == st_sing .Id)
			{
				boxDetails.IsVisible = false;
				boxAppoint.IsVisible = false;
				boxPhotos.IsVisible = false;
				boxlogo.IsVisible = false;
				boxsing.IsVisible = true;
				btnupdate.IsVisible = false;
				st_details.Opacity = 0.3;
				st_photos.Opacity = 0.3;
				st_appoint.Opacity = 0.3;
				st_logo.Opacity = 0.3;
				st_sing.Opacity = 10;
				if (heightAlloc < 600)
				{
					gridscroll.ScrollToAsync(st_sing, ScrollToPosition.End, true);
				}
				st_tabContent.Children.Clear();
				st_tabContent.Children.Add(stksing);
			}


		}
		async void Taptapuploadaddimg_Tapped(object sender, EventArgs e)
		{
			try
			{
				var _media = await DependencyService.Get<ICrossFilePicker>().Current().PickFile();

				if (_media != null)
				{
					//var filename = Path.GetFileName(_media.FilePath);
					var extension = Path.GetExtension(_media.FilePath);
					localfilepath = "Gmcfile"+extension;
					gmcupload.Text = localfilepath;
					progressBar.IsVisible = true;
					selectedFileBytes = _media.DataArray;

				}

			try
			{	
				await progressBar.ProgressTo(1, 3500, Easing.Linear);
				var content = new MultipartFormDataContent();
				var extension = Path.GetExtension(localfilepath);
				HttpContent bytesContent = new ByteArrayContent(selectedFileBytes);
				content.Add(bytesContent, "file","Gmcfile" + "_"+DateTime.Now.ToString("MM-dd-yyyy")+ extension);
				var httpClient = new HttpClient();

				var uploadServiceBaseAddress = "http://178.238.139.243/ThinkdocotorApi/api/Files/uploads?userid=" + Config.user_Id + "&filetype=gmc";
				var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);

					if (httpResponseMessage.IsSuccessStatusCode)
					{
						progressBar.IsVisible = false;
						fgmc.OutlineColor = Color.Green;
						gmcname.TextColor = Color.Green;
                       	loadjson();
					}
					else
					{
						progressBar.IsVisible = false;
						await DisplayAlert("error", "Not upload", "OK");
					}
				
			
			
				

			}
			catch (Exception ex)
			{
				await DisplayAlert("Error!", ex.Message, "OK");
				
			}
					

				}

			catch (Exception ex)
			{
				await DisplayAlert("Error!", ex.Message, "OK");

			}
		}

		async void Taptaptapuploaddeleteimg_Tapped(object sender, EventArgs e)
		{
			var answer = await DisplayAlert("", "Sure you want to delete", "Yes", "No");
			if (answer == true)
			{
				if (Device.OS == TargetPlatform.Android)
					{

						await Navigation.PushPopupAsync(new popup_pleasewait());

					}
					if (Device.OS == TargetPlatform.iOS)
					{

						await Navigation.PushPopupAsync(new popup_pleasewait());
						await Navigation.PushPopupAsync(new popup_pleasewait());

					}
				var item = (Image)sender;
				TapGestureRecognizer t = (TapGestureRecognizer)item.GestureRecognizers[0];
				string[] deletedetails = t.CommandParameter.ToString().Split('_');

				HttpResponseMessage responsePutMethod = documentDeleteRequest("http://178.238.139.243/ThinkdocotorApi/api/Files/delete?userid=" + deletedetails[0] +"&filetype="+deletedetails[1]);
				if (responsePutMethod.IsSuccessStatusCode)
				{
						await Navigation.PopAllPopupAsync();
						await DisplayAlert("", "Deleted ", "Ok");
						progressBar.Progress = .0;
						gmcupload.Text = "Choose File";
						fgmc.OutlineColor = Color.Red ;
						gmcname.TextColor = Color.Red ;
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
			//client.BaseAddress = new Uri("http://178.238.139.243/ThinkdocotorApi/api/Files/delete");
			client.DefaultRequestHeaders.Accept.Clear();
			HttpResponseMessage response = client.DeleteAsync(RequestURI).Result;
			return response; 
		}  

		async void tapuploadimgIndemnity_Tapped(object sender, EventArgs e)
		{
			
				var _media = await DependencyService.Get<ICrossFilePicker>().Current().PickFile();

				if (_media != null)
				{
				
					var extension = Path.GetExtension(_media.FilePath);
					localfilepath = "Indemnityfile"+extension;
					Indemnityupload.Text = localfilepath;
					progressBarIndemnity.IsVisible = true;
					selectedFileBytes = _media.DataArray;


				}
			try
			{	
					await  progressBarIndemnity.ProgressTo(1, 3500, Easing.Linear);
					var content = new MultipartFormDataContent();
					var extension = Path.GetExtension(localfilepath);
					HttpContent bytesContent = new ByteArrayContent(selectedFileBytes);
					content.Add(bytesContent, "file","Indemnityfile" + "_"+DateTime.Now.ToString("MM-dd-yyyy")+ extension);
					var httpClient = new HttpClient();
					var uploadServiceBaseAddress = "http://178.238.139.243/ThinkdocotorApi/api/Files/uploads?userid=" + Config.user_Id + "&filetype=indemnity";
					var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);

					if (httpResponseMessage.IsSuccessStatusCode)
					{
							progressBarIndemnity.IsVisible = false;
							fIndemnity.OutlineColor = Color.Green;
							Indemnityname.TextColor = Color.Green;
							loadjson();
					}
					else
					{
						progressBarIndemnity.IsVisible = false;
						await DisplayAlert("error", "Not upload", "OK");
					}
				

			}
			catch (Exception ex)
			{
				await DisplayAlert("Error!", ex.Message, "OK");
				
			}
		}

		async void tapuplodeleteimgIndemnity_Tapped(object sender, EventArgs e)
		{
			var answer = await DisplayAlert(" ", "Sure you want to delete", "Yes", "No");
			if (answer == true)
			{
				if (Device.OS == TargetPlatform.Android)
					{

						await Navigation.PushPopupAsync(new popup_pleasewait());

					}
					if (Device.OS == TargetPlatform.iOS)
					{

						await Navigation.PushPopupAsync(new popup_pleasewait());
						await Navigation.PushPopupAsync(new popup_pleasewait());

					}
				var item = (Image)sender;
				TapGestureRecognizer t = (TapGestureRecognizer)item.GestureRecognizers[0];
				string[] deletedetails = t.CommandParameter.ToString().Split('_');
				HttpResponseMessage responsePutMethod = documentDeleteRequest("http://178.238.139.243/ThinkdocotorApi/api/Files/delete?userid=" + deletedetails[0] + "&filetype=" + deletedetails[1]);
				if (responsePutMethod.IsSuccessStatusCode)
				{
						await Navigation.PopAllPopupAsync();
						await DisplayAlert("", "Deleted ", "Ok");
						progressBarIndemnity.Progress = .0;
						Indemnityupload.Text = "Choose File";
						fIndemnity.OutlineColor = Color.Red;
						Indemnityname.TextColor = Color.Red;
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

		async void tapuploadimgAppraisal_Tapped(object sender, EventArgs e)
		{
				var _media = await DependencyService.Get<ICrossFilePicker>().Current().PickFile();

				if (_media != null)
				{
					var extension = Path.GetExtension(_media.FilePath);
					localfilepath = "Appraisalfile"+extension;
					Appraisalupload.Text = localfilepath;
					progressBarAppraisal.IsVisible = true;
					selectedFileBytes = _media.DataArray;
					

				}
			try
			{	
				await progressBarAppraisal.ProgressTo(1, 3500, Easing.Linear);
				var content = new MultipartFormDataContent();
				var extension = Path.GetExtension(localfilepath);
				HttpContent bytesContent = new ByteArrayContent(selectedFileBytes);
				content.Add(bytesContent, "file","Appraisalfile" + "_"+DateTime.Now.ToString("MM-dd-yyyy")+ extension);
				var httpClient = new HttpClient();
				var uploadServiceBaseAddress = "http://178.238.139.243/ThinkdocotorApi/api/Files/uploads?userid=" + Config.user_Id + "&filetype=appraisal";
				var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);

					if (httpResponseMessage.IsSuccessStatusCode)
					{
						progressBarAppraisal.IsVisible = false;
						fAppraisal.OutlineColor = Color.Green;
						Appraisalname.TextColor = Color.Green;
                   		loadjson();
					}
					else
					{
						progressBarAppraisal.IsVisible = false;
						await DisplayAlert("error", "Not upload", "OK");
					}
				

			}
			catch (Exception ex)
			{
				await DisplayAlert("Error!", ex.Message, "OK");
				
			}
		}

		async void tapuplodeleteimgAppraisal_Tapped(object sender, EventArgs e)
		{
			var answer = await DisplayAlert("", "Sure you want to delete", "Yes", "No");
			if (answer == true)
			{
				if (Device.OS == TargetPlatform.Android)
					{

						await Navigation.PushPopupAsync(new popup_pleasewait());

					}
					if (Device.OS == TargetPlatform.iOS)
					{

						await Navigation.PushPopupAsync(new popup_pleasewait());
						await Navigation.PushPopupAsync(new popup_pleasewait());

					}
				var item = (Image)sender;
				TapGestureRecognizer t = (TapGestureRecognizer)item.GestureRecognizers[0];
				string[] deletedetails = t.CommandParameter.ToString().Split('_');
				HttpResponseMessage responsePutMethod = documentDeleteRequest("http://178.238.139.243/ThinkdocotorApi/api/Files/delete?userid=" + deletedetails[0] + "&filetype=" + deletedetails[1]);
				if (responsePutMethod.IsSuccessStatusCode)
				{
						await Navigation.PopAllPopupAsync();
						await DisplayAlert("", "Deleted ", "Ok");
						progressBarAppraisal.Progress = .0;
						Appraisalupload.Text = "Choose File";
						fAppraisal.OutlineColor = Color.Red;
						Appraisalname.TextColor = Color.Red;
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

		async void tapuploadimglogo_Tapped(object sender, EventArgs e)
		{
			
				var _media = await DependencyService.Get<ICrossFilePicker>().Current().PickFile();

				if (_media != null)
				{
					var extension = Path.GetExtension(_media.FilePath);
					localfilepath = "Logofile"+extension;
					logoupload.Text = localfilepath;
					progressBarlogo.IsVisible = true;
					selectedFileBytes = _media.DataArray;


				}
			try
			{	
				await progressBarlogo.ProgressTo(1, 3500, Easing.Linear);
				var content = new MultipartFormDataContent();
				var extension = Path.GetExtension(localfilepath);
				HttpContent bytesContent = new ByteArrayContent(selectedFileBytes);
				content.Add(bytesContent, "file","Logofile" + "_"+DateTime.Now.ToString("MM-dd-yyyy")+ extension);
				var httpClient = new HttpClient();
				var uploadServiceBaseAddress = "http://178.238.139.243/ThinkdocotorApi/api/Files/uploads?userid=" + Config.user_Id + "&filetype=logo";
				var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);

					if (httpResponseMessage.IsSuccessStatusCode)
					{
						progressBarlogo.IsVisible = false;
						flogo.OutlineColor = Color.Green;
						logoname.TextColor = Color.Green;
                   		 loadjson();
					}
					else
					{
						progressBarlogo.IsVisible = false;
						await DisplayAlert("error", "Not upload", "OK");
					}
				

			}
			catch (Exception ex)
			{
				await DisplayAlert("Error!", ex.Message, "OK");
				
			}
		}

		async void tapuplodeleteimglogo_Tapped(object sender, EventArgs e)
		{
			var answer = await DisplayAlert(" ", "Sure you want to delete", "Yes", "No");
			if (answer == true)
			{
				if (Device.OS == TargetPlatform.Android)
					{

						await Navigation.PushPopupAsync(new popup_pleasewait());

					}
					if (Device.OS == TargetPlatform.iOS)
					{

						await Navigation.PushPopupAsync(new popup_pleasewait());
						await Navigation.PushPopupAsync(new popup_pleasewait());

					}
				var item = (Image)sender;
				TapGestureRecognizer t = (TapGestureRecognizer)item.GestureRecognizers[0];
				string[] deletedetails = t.CommandParameter.ToString().Split('_');
				HttpResponseMessage responsePutMethod = documentDeleteRequest("http://178.238.139.243/ThinkdocotorApi/api/Files/delete?userid=" + deletedetails[0] + "&filetype=" + deletedetails[1]);
				if (responsePutMethod.IsSuccessStatusCode)
				{
						await Navigation.PopAllPopupAsync();
						await DisplayAlert("", "Deleted ", "Ok");
						progressBarlogo.Progress = .0;
						logoupload.Text = "Choose File";
						flogo.OutlineColor = Color.Red;
						logoname.TextColor = Color.Red;
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

		async void tapuploadimgSing_Tapped(object sender, EventArgs e)
		{
			
				var _media = await DependencyService.Get<ICrossFilePicker>().Current().PickFile();

				if (_media != null)
				{
					var extension = Path.GetExtension(_media.FilePath);
					localfilepath = "Signaturefile"+extension;
					Singupload.Text = localfilepath;
					progressBarSing.IsVisible = true;
					selectedFileBytes = _media.DataArray;
					

				}
			try
			{	
					await progressBarSing.ProgressTo(1, 3500, Easing.Linear);
					var content = new MultipartFormDataContent();
					var extension = Path.GetExtension(localfilepath);
					HttpContent bytesContent = new ByteArrayContent(selectedFileBytes);
					content.Add(bytesContent, "file","signaturefile"+ "_"+DateTime.Now.ToString("MM-dd-yyyy")+ extension);
					var httpClient = new HttpClient();
					var uploadServiceBaseAddress = "http://178.238.139.243/ThinkdocotorApi/api/Files/uploads?userid=" + Config.user_Id + "&filetype=signature";
					var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);

					if (httpResponseMessage.IsSuccessStatusCode)
					{
						progressBarSing.IsVisible = false;
						flogo.OutlineColor = Color.Green;
						logoname.TextColor = Color.Green;
                    	loadjson();
					}
					else
					{
						progressBarSing.IsVisible = false;
						await DisplayAlert("error", "Not upload", "OK");
					}
				

			}
			catch (Exception ex)
			{
				await DisplayAlert("Error!", ex.Message, "OK");
				
			}
		}

		async void tapuplodeleteimgSing_Tapped(object sender, EventArgs e)
		{
			var answer = await DisplayAlert(" ", "Sure you want to delete", "Yes", "No");
			if (answer == true)
			{
				if (Device.OS == TargetPlatform.Android)
					{

						await Navigation.PushPopupAsync(new popup_pleasewait());

					}
					if (Device.OS == TargetPlatform.iOS)
					{

						await Navigation.PushPopupAsync(new popup_pleasewait());
						await Navigation.PushPopupAsync(new popup_pleasewait());

					}
				var item = (Image)sender;
				TapGestureRecognizer t = (TapGestureRecognizer)item.GestureRecognizers[0];
				string[] deletedetails = t.CommandParameter.ToString().Split('_');
				HttpResponseMessage responsePutMethod = documentDeleteRequest("http://178.238.139.243/ThinkdocotorApi/api/Files/delete?userid=" + deletedetails[0] + "&filetype=" + deletedetails[1]);
				if (responsePutMethod.IsSuccessStatusCode)
				{
						await Navigation.PopAllPopupAsync();
						await DisplayAlert("", "Deleted ", "Ok");
						progressBarSing.Progress = .0;
						Singupload.Text = "Choose File";
						fSing.OutlineColor = Color.Red;
						Singname.TextColor = Color.Red;
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

		void editor_Focused(object sender, FocusEventArgs e)
		{
			if (editor.Text.Equals("Enter The Professional Details"))
			{
				editor.Text = "";
				// FreeText.TextColor = Color.FromRgb(30, 30, 30);
			}


		}

		void editor_Unfocused(object sender, FocusEventArgs e)
		{
			if (editor.Text.Equals(""))
			{
				editor.Text = "Enter The Professional Details";
				// FreeText.TextColor = Color.FromRgb(30, 30, 30);
			}
		}

		void Tapimgprfqexpen_Tapped(object sender, EventArgs e)
		{
			if (flagexpq == 0)
			{
				imgprfqexpen.Source = "expen.png";
				editor .IsVisible = true;

				flagexpq = 1;
			}
			else
			{
				imgprfqexpen.Source = "expen1.png";
				editor .IsVisible = false;

				flagexpq = 0;
			}
		}

		void Taptapgriddocuplexp_Tapped(object sender, EventArgs e)
		{
			if (flagdocupl == 0)
			{
				imgdocuplexpen.Source = "expen.png";
				 arrangeupload .IsVisible = true;

				flagdocupl = 1;
			}
			else
			{
				imgdocuplexpen.Source = "expen1.png";
				arrangeupload.IsVisible = false;

				flagdocupl = 0;
			}
		}

		void Tapgridlogouploadexp_Tapped(object sender, EventArgs e)
		{
			if (flaglogo == 0)
			{
				imglogouploadexpen .Source = "expen.png";
				flogo .IsVisible = true;

				flaglogo = 1;
			}
			else
			{
				imglogouploadexpen.Source = "expen1.png";
				flogo.IsVisible = false;

				flaglogo = 0;
			}
		}

		void Tapgridsingupldexp_Tapped(object sender, EventArgs e)
		{
			if (flagsing == 0)
			{
				imgsinguplexpen.Source = "expen.png";
				fSing .IsVisible = true;

				flagsing = 1;
			}
			else
			{
				imgsinguplexpen .Source = "expen1.png";
				fSing.IsVisible = false;

				flagsing = 0;
			}
		}

		void Tapclinic_Tapped(object sender, EventArgs e)
		{
			if (flagper_qly == 0)
			{
				imgclinic .Source = "expen.png";
				stkclinics.IsVisible = true;
				btnupdate.IsVisible = false;
				flagper_qly = 1;
			}
			else
			{
				imgclinic.Source = "expen1.png";
				stkclinics.IsVisible = false;
				btnupdate.IsVisible = false;
				flagper_qly = 0;
			}
		}



		

		private async void gallerypic()
		{
			if (!CrossMedia.Current.IsPickPhotoSupported)
			{
				DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
				return;
			}
			var file = await CrossMedia.Current.PickPhotoAsync();


			if (file == null)
				return;
			
			byte[] result;
			var imgpath = file.Path;
			using (var streamReader = new MemoryStream())

				{
					var stream = file.GetStream();
					stream.CopyTo(streamReader);
					result = streamReader.ToArray();

				}


			img_person.Source = ImageSource.FromStream(() =>
			{
				var stream = file.GetStream();
				//file.Dispose();
				return stream;
			});

			string filename = Path.GetFileNameWithoutExtension(imgpath);
			pickerflag = true;
			var imgdata = new profilepic
			{
				filename = filename,
				filepath = file.Path,
				data = result
			};
			file.Dispose();
            uploadprofileimage(imgdata);
		}

		private async void takepic()
		{
			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
				return;
			}

			var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
			{

				Directory = "Sample",
				Name = "test.jpg"
			});

			if (file == null)
				return;
			byte[] result;
			var imgpath = file.Path;
			using (var streamReader = new MemoryStream())

				{
					var stream = file.GetStream();
					stream.CopyTo(streamReader);
					result = streamReader.ToArray();

				}


			img_person.Source = ImageSource.FromStream(() =>
			{
				
				var stream = file.GetStream();
				//file.Dispose();
				return stream;
			});
			string filename = Path.GetFileNameWithoutExtension(imgpath);
			pickerflag = true;
			var imgdata = new profilepic
			{
				filename=filename,
				filepath=file.Path,
				data = result
			};
			file.Dispose();
			uploadprofileimage(imgdata);

		}

		async void uploadprofileimage(profilepic pic)
		{
			try
			{
				await Navigation.PushPopupAsync(new popup_pleasewait());
				var content = new MultipartFormDataContent();
				var extension = Path.GetExtension(pic.filepath);
				HttpContent bytesContent = new ByteArrayContent(pic.data);
				content.Add(bytesContent, "file", lblName.Text + "_" + Config.user_Id.ToString() + extension);
				var httpClient = new HttpClient();
				var uploadServiceBaseAddress = "http://178.238.139.243/ThinkdocotorApi/api/Files/profile?userid=" + Config.user_Id ;
				var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);

				if (httpResponseMessage.IsSuccessStatusCode)
				{
					await Navigation.PopAllPopupAsync();

					loadjson();
				}
				else
				{
					await Navigation.PopAllPopupAsync();
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

