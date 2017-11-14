using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thinkdocotor.ViewModels;
using Xamarin.Forms;
using Messier16.Forms.Controls;
using ThinkDoctor;

namespace Thinkdocotor.Pages
{
    public class SignupPage : CustomPageWithGradient
    {

        StackLayout st_main, stk_name, stk_mname, stk_lname, stk_HospitalName, stk_country, stk_email, stk_phone, stk_pass, stk_Repass, stk_terms;
        MyEntry uname, mname, lname, hospital_name, entry_email, entry_phone, entry_pass, entry_repass;
        Label lbl_name, lbl_mname, lbl_lname, lbl_hospital_name, lbl_country, lbl_email, lbl_phone, lbl_pass, lbl_repass;
        CustomFrame Funame, Fmname, Flname, FHospitalName, Fcountry, FEmail, FPhone, FPass, FRepass;
        Button btnRegister;
        Checkbox chk_terms;
        UnderlineLabel lbl_terms;
        DropDownMenuView picker_country;
        //AutoCompleteView acView;
        RelativeLayout rl_main;

        SignupViewModel regViewModel;

        public SignupPage()
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            regViewModel = new SignupViewModel();
            BindingContext = regViewModel;

            #region Content Design

            #region First Name 
            lbl_name = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Text = "First Name",
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
            };
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    lbl_name.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    break;
                case TargetIdiom.Tablet:
                    lbl_name.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    break;
            }

            uname = new MyEntry
            {
                Placeholder = "First Name",
                //FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                PlaceholderColor = Color.LightGray,
                TextColor = Color.White,
                Keyboard = Keyboard.Text,
            };
            switch(Device.Idiom)
            {
                case TargetIdiom.Phone:
                    uname.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry));
                    break;
                case TargetIdiom.Tablet:
                    uname.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry));
                    break;
            }
            uname.SetBinding(MyEntry.TextProperty, "Name");

            IconView lbluserimg = new IconView
            {
                Source = "usericon.png",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Transparent,
                Foreground = Color.FromHex(Config.iconcolor)
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

            stk_name = new StackLayout();
            stk_name.Orientation = StackOrientation.Vertical;
            stk_name.HorizontalOptions = LayoutOptions.FillAndExpand;
            stk_name.VerticalOptions = LayoutOptions.Center;
            stk_name.Padding = 0;
            stk_name.Spacing = 5;
            stk_name.Children.Add(lbl_name);
            stk_name.Children.Add(Funame);
            #endregion

            #region Middle Name 
            lbl_mname = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Text = "Middle Name",
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
            };
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    lbl_mname.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    break;
                case TargetIdiom.Tablet:
                    lbl_mname.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    break;
            }

            mname = new MyEntry
            {
                Placeholder = "Middle Name",
                //FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                PlaceholderColor = Color.LightGray,
                TextColor = Color.White,
                Keyboard = Keyboard.Text,
            };
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    mname.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry));
                    break;
                case TargetIdiom.Tablet:
                    mname.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry));
                    break;
            }
            mname.SetBinding(MyEntry.TextProperty, "MName");

            IconView lbluser1img = new IconView
            {
                Source = "usericon.png",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Transparent,
                Foreground = Color.FromHex(Config.iconcolor)
            };

            StackLayout stkFmname = new StackLayout();
            stkFmname.Orientation = StackOrientation.Horizontal;
            stkFmname.HorizontalOptions = LayoutOptions.FillAndExpand;
            stkFmname.Padding = 2;
            stkFmname.Children.Add(lbluser1img);
            stkFmname.Children.Add(mname);

            //var semiTransparentColor = new Color(0, 0, 0, 0.05);
            Fmname = new CustomFrame
            {
                Content = stkFmname,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,//---------------------------------------------/////
                Padding = new Thickness(10, 7, 0, 7),
                Margin = new Thickness(2, 0),
                OutlineColor = Color.White,
                BorderRadius = 5,
                BackgroundColor = semiTransparentColor,
            };

            stk_mname = new StackLayout();
            stk_mname.Orientation = StackOrientation.Vertical;
            stk_mname.HorizontalOptions = LayoutOptions.FillAndExpand;
            stk_mname.VerticalOptions = LayoutOptions.Center;
            stk_mname.Padding = 0;
            stk_mname.Spacing = 5;
            stk_mname.Children.Add(lbl_mname);
            stk_mname.Children.Add(Fmname);
            #endregion

            #region Last Name 
            lbl_lname = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Text = "Last Name",
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
            };
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    lbl_lname.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    break;
                case TargetIdiom.Tablet:
                    lbl_lname.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    break;
            }

            lname = new MyEntry
            {
                Placeholder = "First Name",
                //FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                PlaceholderColor = Color.LightGray,
                TextColor = Color.White,
                Keyboard = Keyboard.Text,
            };
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    lname.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry));
                    break;
                case TargetIdiom.Tablet:
                    lname.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry));
                    break;
            }
            lname.SetBinding(MyEntry.TextProperty, "LName");

            IconView lbluser2img = new IconView
            {
                Source = "usericon.png",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Transparent,
                Foreground = Color.FromHex(Config.iconcolor)
            };

            StackLayout stkFlname = new StackLayout();
            stkFlname.Orientation = StackOrientation.Horizontal;
            stkFlname.HorizontalOptions = LayoutOptions.FillAndExpand;
            stkFlname.Padding = 2;
            stkFlname.Children.Add(lbluser2img);
            stkFlname.Children.Add(lname);

            //var semiTransparentColor = new Color(0, 0, 0, 0.05);
            Flname = new CustomFrame
            {
                Content = stkFlname,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,//---------------------------------------------/////
                Padding = new Thickness(10, 7, 0, 7),
                Margin = new Thickness(2, 0),
                OutlineColor = Color.White,
                BorderRadius = 5,
                BackgroundColor = semiTransparentColor,
            };

            stk_lname = new StackLayout();
            stk_lname.Orientation = StackOrientation.Vertical;
            stk_lname.HorizontalOptions = LayoutOptions.FillAndExpand;
            stk_lname.VerticalOptions = LayoutOptions.Center;
            stk_lname.Padding = 0;
            stk_lname.Spacing = 5;
            stk_lname.Children.Add(lbl_lname);
            stk_lname.Children.Add(Flname);
            #endregion

            #region Practice/Hospital Name 
            lbl_hospital_name = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Text = "Practice / Hospital Name",
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White
            };
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    lbl_hospital_name.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    break;
                case TargetIdiom.Tablet:
                    lbl_hospital_name.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    break;
            }

            //hospital_name = new MyEntry
            //{
            //    Placeholder = "Practice / Hospital Name",
            //    //FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry)),
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.Center,
            //    PlaceholderColor = Color.LightGray,
            //    TextColor = Color.White,
            //    Keyboard = Keyboard.Text,
            //};
            //switch (Device.Idiom)
            //{
            //    case TargetIdiom.Phone:
            //        hospital_name.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry));
            //        break;
            //    case TargetIdiom.Tablet:
            //        hospital_name.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry));
            //        break;
            //}
            //hospital_name.SetBinding(MyEntry.TextProperty, "HospitalName");

            //IconView hospital_image = new IconView
            //{
            //    Source = "hospital.png",
            //    HorizontalOptions = LayoutOptions.Start,
            //    VerticalOptions = LayoutOptions.Center,
            //    BackgroundColor = Color.Transparent,
            //    Foreground = Color.FromHex(Config.iconcolor)
            //};

            //StackLayout stkhospital_name = new StackLayout();
            //stkhospital_name.Orientation = StackOrientation.Horizontal;
            //stkhospital_name.HorizontalOptions = LayoutOptions.FillAndExpand;
            //stkhospital_name.Padding = 2;
            //stkhospital_name.Children.Add(hospital_image);
            //stkhospital_name.Children.Add(hospital_name);

            //var semiTransparentColor = new Color(0, 0, 0, 0.05);
            //FHospitalName = new CustomFrame
            //{
            //    Content = stkhospital_name,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.Center,//---------------------------------------------/////
            //    Padding = new Thickness(10, 7, 0, 7),
            //    Margin = new Thickness(2, 0),
            //    OutlineColor = Color.White,
            //    BorderRadius = 5,
            //    BackgroundColor = semiTransparentColor,
            //};

            //stk_HospitalName = new StackLayout();
            //stk_HospitalName.Orientation = StackOrientation.Vertical;
            //stk_HospitalName.HorizontalOptions = LayoutOptions.FillAndExpand;
            //stk_HospitalName.VerticalOptions = LayoutOptions.Center;
            //stk_HospitalName.Padding = 0;
            //stk_HospitalName.Spacing = 5;
            //stk_HospitalName.Children.Add(lbl_hospital_name);
            //stk_HospitalName.Children.Add(FHospitalName);
            #endregion

            #region Country
            lbl_country = new Label
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
                    lbl_country.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    break;
                case TargetIdiom.Tablet:
                    lbl_country.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    break;
            }


            picker_country = new DropDownMenuView
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
            picker_country.ItemSelectedEvent = i =>
            {
                regViewModel.CountrySelectedIndex = i;
            };
            picker_country.SetBinding(DropDownMenuView.ItemsSourceProperty, "CountriesItemSource");
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

            #region Email 
            lbl_email = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Text = "Email",
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
            };
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    lbl_email.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    break;
                case TargetIdiom.Tablet:
                    lbl_email.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    break;
            }

            entry_email = new MyEntry
            {
                Placeholder = "Email",
                //FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                PlaceholderColor = Color.LightGray,
                TextColor = Color.White,
                Keyboard = Keyboard.Email,
            };
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    entry_email.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry));
                    break;
                case TargetIdiom.Tablet:
                    entry_email.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry));
                    break;
            }
            entry_email.SetBinding(MyEntry.TextProperty, "Email");

            IconView emailimg = new IconView
            {
                Source = "email.png",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Transparent,
                Foreground = Color.FromHex(Config.iconcolor)
            };

            StackLayout stkEmail = new StackLayout();
            stkEmail.Orientation = StackOrientation.Horizontal;
            stkEmail.HorizontalOptions = LayoutOptions.FillAndExpand;
            stkEmail.Padding = 2;
            stkEmail.Children.Add(emailimg);
            stkEmail.Children.Add(entry_email);

            //var semiTransparentColor = new Color(0, 0, 0, 0.05);
            FEmail = new CustomFrame
            {
                Content = stkEmail,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,//---------------------------------------------/////
                Padding = new Thickness(10, 7, 0, 7),
                Margin = new Thickness(2, 0),
                OutlineColor = Color.White,
                BorderRadius = 5,
                BackgroundColor = semiTransparentColor,
            };

            stk_email = new StackLayout();
            stk_email.Orientation = StackOrientation.Vertical;
            stk_email.HorizontalOptions = LayoutOptions.FillAndExpand;
            stk_email.VerticalOptions = LayoutOptions.Center;
            stk_email.Padding = 0;
            stk_email.Spacing = 5;
            stk_email.Children.Add(lbl_email);
            stk_email.Children.Add(FEmail);
            #endregion

            #region Phone 
            lbl_phone = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Text = "Phone",
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
            };
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    lbl_phone.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    break;
                case TargetIdiom.Tablet:
                    lbl_phone.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    break;
            }

            entry_phone = new MyEntry
            {
                Placeholder = "+44 000 000",
                //FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                PlaceholderColor = Color.LightGray,
                TextColor = Color.White,
                Keyboard = Keyboard.Telephone,
            };
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    entry_phone.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry));
                    break;
                case TargetIdiom.Tablet:
                    entry_phone.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry));
                    break;
            }
            entry_phone.SetBinding(MyEntry.TextProperty, "PhoneNo");

            IconView phoneimg = new IconView
            {
                Source = "mobile.png",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Transparent,
                Foreground = Color.FromHex(Config.iconcolor)
            };

            StackLayout stkPhone = new StackLayout();
            stkPhone.Orientation = StackOrientation.Horizontal;
            stkPhone.HorizontalOptions = LayoutOptions.FillAndExpand;
            stkPhone.Padding = 2;
            stkPhone.Children.Add(phoneimg);
            stkPhone.Children.Add(entry_phone);

            //var semiTransparentColor = new Color(0, 0, 0, 0.05);
            FPhone = new CustomFrame
            {
                Content = stkPhone,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,//---------------------------------------------/////
                Padding = new Thickness(10, 7, 0, 7),
                Margin = new Thickness(2, 0),
                OutlineColor = Color.White,
                BorderRadius = 5,
                BackgroundColor = semiTransparentColor,
            };

            stk_phone = new StackLayout();
            stk_phone.Orientation = StackOrientation.Vertical;
            stk_phone.HorizontalOptions = LayoutOptions.FillAndExpand;
            stk_phone.VerticalOptions = LayoutOptions.Center;
            stk_phone.Padding = 0;
            stk_phone.Spacing = 5;
            stk_phone.Children.Add(lbl_phone);
            stk_phone.Children.Add(FPhone);
            #endregion

            #region Password 
            //lbl_pass = new Label
            //{
            //    HorizontalOptions = LayoutOptions.Start,
            //    VerticalOptions = LayoutOptions.Center,
            //    Text = "Password",
            //    TextColor = Color.White,
            //    FontAttributes = FontAttributes.Bold,
            //};
            //switch (Device.Idiom)
            //{
            //    case TargetIdiom.Phone:
            //        lbl_pass.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            //        break;
            //    case TargetIdiom.Tablet:
            //        lbl_pass.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            //        break;
            //}

            //entry_pass = new MyEntry
            //{
            //    Placeholder = "Password",
            //    //FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry)),
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.Center,
            //    PlaceholderColor = Color.LightGray,
            //    TextColor = Color.White,
            //    Keyboard = Keyboard.Text,
            //    IsPassword = true
            //};
            //switch (Device.Idiom)
            //{
            //    case TargetIdiom.Phone:
            //        entry_pass.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry));
            //        break;
            //    case TargetIdiom.Tablet:
            //        entry_pass.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry));
            //        break;
            //}
            //entry_pass.SetBinding(MyEntry.TextProperty, "Pass");

            //Image passimg = new Image
            //{
            //    Source = "usericon.png",
            //    HorizontalOptions = LayoutOptions.Start,
            //    VerticalOptions = LayoutOptions.Center
            //};

            //StackLayout stkPass = new StackLayout();
            //stkPass.Orientation = StackOrientation.Horizontal;
            //stkPass.HorizontalOptions = LayoutOptions.FillAndExpand;
            //stkPass.Padding = 2;
            //stkPass.Children.Add(passimg);
            //stkPass.Children.Add(entry_pass);

            ////var semiTransparentColor = new Color(0, 0, 0, 0.05);
            //FPass = new CustomFrame
            //{
            //    Content = stkPass,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.Center,//---------------------------------------------/////
            //    Padding = new Thickness(10, 7, 0, 7),
            //    Margin = new Thickness(2, 0),
            //    OutlineColor = Color.White,
            //    BorderRadius = 5,
            //    BackgroundColor = semiTransparentColor,
            //};

            //stk_pass = new StackLayout();
            //stk_pass.Orientation = StackOrientation.Vertical;
            //stk_pass.HorizontalOptions = LayoutOptions.FillAndExpand;
            //stk_pass.VerticalOptions = LayoutOptions.Center;
            //stk_pass.Padding = 0;
            //stk_pass.Spacing = 5;
            //stk_pass.Children.Add(lbl_pass);
            //stk_pass.Children.Add(FPass);
            #endregion

            #region Confirm Password 
            //lbl_repass = new Label
            //{
            //    HorizontalOptions = LayoutOptions.Start,
            //    VerticalOptions = LayoutOptions.Center,
            //    Text = "Confirm Password",
            //    TextColor = Color.White,
            //    FontAttributes = FontAttributes.Bold,
            //};
            //switch (Device.Idiom)
            //{
            //    case TargetIdiom.Phone:
            //        lbl_repass.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            //        break;
            //    case TargetIdiom.Tablet:
            //        lbl_repass.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            //        break;
            //}

            //entry_repass = new MyEntry
            //{
            //    Placeholder = "Confirm Password",
            //    //FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry)),
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.Center,
            //    PlaceholderColor = Color.LightGray,
            //    TextColor = Color.White,
            //    Keyboard = Keyboard.Text,
            //    IsPassword = true
            //};
            //switch (Device.Idiom)
            //{
            //    case TargetIdiom.Phone:
            //        entry_repass.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry));
            //        break;
            //    case TargetIdiom.Tablet:
            //        entry_repass.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry));
            //        break;
            //}
            //entry_repass.SetBinding(MyEntry.TextProperty, "PassC");

            //Image repassimg = new Image
            //{
            //    Source = "usericon.png",
            //    HorizontalOptions = LayoutOptions.Start,
            //    VerticalOptions = LayoutOptions.Center
            //};

            //StackLayout stkRePass = new StackLayout();
            //stkRePass.Orientation = StackOrientation.Horizontal;
            //stkRePass.HorizontalOptions = LayoutOptions.FillAndExpand;
            //stkRePass.Padding = 2;
            //stkRePass.Children.Add(repassimg);
            //stkRePass.Children.Add(entry_repass);

            ////var semiTransparentColor = new Color(0, 0, 0, 0.05);
            //FRepass = new CustomFrame
            //{
            //    Content = stkRePass,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.Center,//---------------------------------------------/////
            //    Padding = new Thickness(10, 7, 0, 7),
            //    Margin = new Thickness(2, 0),
            //    OutlineColor = Color.White,
            //    BorderRadius = 5,
            //    BackgroundColor = semiTransparentColor,
            //};

            //stk_Repass = new StackLayout();
            //stk_Repass.Orientation = StackOrientation.Vertical;
            //stk_Repass.HorizontalOptions = LayoutOptions.FillAndExpand;
            //stk_Repass.VerticalOptions = LayoutOptions.Center;
            //stk_Repass.Padding = 0;
            //stk_Repass.Spacing = 5;
            //stk_Repass.Children.Add(lbl_repass);
            //stk_Repass.Children.Add(FRepass);
            #endregion

            #region Register Button
            btnRegister = new Button
            {
                Text = "Register",
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
                IsEnabled = false
                //WidthRequest = 100
            };
            btnRegister.SetBinding(Button.CommandProperty, "doRegister");
            //btnRegister.SetBinding(Button.IsEnabledProperty, "IsAllDetailsValid");
            #endregion

            #region Terms & Conditions
            chk_terms = new Checkbox()
            {
                
                CheckboxBackgroundColor = Color.White,
                TickColor = AppStyles.btnColor,
                Checked = false,
                WidthRequest = Device.OnPlatform(25, 25, 0)
            };
            chk_terms.SetBinding(Checkbox.CheckedProperty, "AccepTerms");
            //chk_terms.CheckedChanged += showloginbtn;

            Label lbl_accept = new Label
            {
                Text = "I accept the",
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
            };

            lbl_terms = new UnderlineLabel
            {
                Text = "terms & conditions",
                TextColor = AppStyles.btnColor,
                VerticalOptions = LayoutOptions.Center,
            };
            TapGestureRecognizer tap_terms = new TapGestureRecognizer();
            tap_terms.SetBinding(TapGestureRecognizer.CommandProperty, "showTerms");
            lbl_terms.GestureRecognizers.Add(tap_terms);

            StackLayout stklabels = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Start,
                Spacing = 5,
                Children =
                {
                    lbl_accept,
                    lbl_terms
                }
            };

            stk_terms = new StackLayout();
            stk_terms.Orientation = StackOrientation.Horizontal;
            stk_terms.HorizontalOptions = LayoutOptions.Start;
            stk_terms.Spacing = 6;
            stk_terms.Children.Add(chk_terms);
            stk_terms.Children.Add(stklabels);
            #endregion

            st_main = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            switch(Device.Idiom)
            {
                case TargetIdiom.Phone:
                    st_main.Padding = new Thickness(10, 5, 10, 10);
                    st_main.Spacing = 15;
                    break;
                case TargetIdiom.Tablet:
                    st_main.Padding = new Thickness(75, 25, 75, 20);
                    st_main.Spacing = 15;
                    break;
                default:
                    st_main.Padding = new Thickness(10, 5, 10, 10);
                    st_main.Spacing = 15;
                    break;
            }
            st_main.Children.Add(stk_name);
            st_main.Children.Add(stk_mname);
            st_main.Children.Add(stk_lname);
           // st_main.Children.Add(stk_HospitalName);
            st_main.Children.Add(stk_email);
            st_main.Children.Add(stk_phone);
            st_main.Children.Add(stk_country);
            //st_main.Children.Add(stk_pass);
            //st_main.Children.Add(stk_Repass);
            st_main.Children.Add(stk_terms);
            st_main.Children.Add(btnRegister);
            #endregion

            #region Page attributes
            StartColor = Color.FromHex("#3a527d");
            EndColor = Color.FromHex("#24334e");

            Title = "Registration";

            double topPadding = 0;
            switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    topPadding = 15;
                    break;
                default:
                    topPadding = 5;
                    break;
            }
            Padding = new Thickness(0, topPadding, 0 , 15);

            ScrollView sv_main = new ScrollView();
            sv_main.Content = st_main;

            Content = sv_main;
            #endregion
        }

        protected async override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            await regViewModel.getCountriesList();
        }
    }
}