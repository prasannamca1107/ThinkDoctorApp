using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using DLToolkit.Forms.Controls;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using Syncfusion.SfAutoComplete.XForms;
using Thinkdocotor;
using ThinkDoctor;
using Xamarin.Forms;
using Xfx;

namespace Thinkdoctor
{
    class services
    {

        public string servicesName
        {
            get;
            set;
        }
    }

    class Clinicians
    {

        public string CliniciansName
        {
            get;
            set;
        }
    }

    public partial class Servcies_Hours : ContentPage
    {
        public Func<string, ICollection<string>, ICollection<string>> SortingAlgorithm { get; } = (text, values) => values
        .Where(x => x.ToLower().StartsWith(text.ToLower()))
        .OrderBy(x => x)
        .ToList();

        public Func<string, ICollection<string>, ICollection<string>> SortingAlgorithm1 { get; } = (text, values) => values
        .Where(x => x.ToLower().StartsWith(text.ToLower()))
        .OrderBy(x => x)
        .ToList();

        List<string> ls;
        List<string> servicelist;
        List<services> serviceslistview;
      
        SfAutoComplete xfserv;
        SfAutoComplete xfclin;

        List<string> clinicianslist;

        StackLayout stkmoredetEntry;

        Editor moredetEntry;

        CustomFrame FmoredetEntry;

        CustomFrame Fconshour;

        Dictionary<string, int> formFields = new Dictionary<string, int>()
        {

        };

        Dictionary<string, int> formFieldsclinic = new Dictionary<string, int>()
        {

        };
        Image imgconshour;

        private string uriservices = "http://178.238.139.243/ThinkdocotorApi/api/servies";
        consulting_venues cv;
        private string uri = "http://178.238.139.243/ThinkdocotorApi/api/Consulting_services_clinic/post/";
         Image imgaddroom;
         CustomFrame Faddroom;

        public Servcies_Hours(consulting_venues consulting_venues)
        {
            InitializeComponent();
            cv = consulting_venues;
            loadjson();
            NavigationPage.SetBackButtonTitle(this, " ");
            NavigationPage.SetHasBackButton(this, false);
            ToolbarItems.Add(new ToolbarItem("Next", Device.OnPlatform("Docotor/Nextpage.png", "Nextpage.png", null), testclick));

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
            Title = "Services & Hours";


            serviceslistview = new List<services>();
            myListserv.FlowItemsSource = serviceslistview;

          
            myListserv.FlowUseAbsoluteLayoutInternally = true;
            myListserv.FlowColumnExpand = FlowColumnExpand.Proportional;
            myListserv.IsVisible = false;


          

            Label servicel = new Label();
            servicel.Text = "Services";
            servicel.TextColor = Color.White;


            // xfserv = new XfxComboBox
            //{
            //  Placeholder = "Type",
            //  FloatingHintEnabled = false,
            //  TextColor = Color.White,
            //  PlaceholderColor = Color.WhiteSmoke,
            //  HorizontalOptions = LayoutOptions.FillAndExpand



            //};

            servicelist = new List<string>();
            servicelist.Add("Diabetics");


            //  xfserv.ItemsSource = servicelist;
            //  xfserv.SortingAlgorithm = SortingAlgorithm;

            xfserv = new SfAutoComplete();
            xfserv.BorderColor = Color.White;
            xfserv.HeightRequest = 40;
            xfserv.DataSource = servicelist;
            xfserv.AutoCompleteMode = Syncfusion.SfAutoComplete.XForms.AutoCompleteMode.Suggest;
            xfserv.SuggestionMode = SuggestionMode.Contains;
            xfserv.TextColor = Color.White;
            xfserv.SelectionChanged += tapLimgaddserv_Tapped;

            Image imgaddserv = new Image();
            imgaddserv.HorizontalOptions = LayoutOptions.End;
            imgaddserv.VerticalOptions = LayoutOptions.Center;
            imgaddserv.BackgroundColor = Color.Transparent;
            imgaddserv.Aspect = Aspect.AspectFill;
            imgaddserv.Source = "addclinic.png";

            var tapLimgaddserv = new TapGestureRecognizer();
            tapLimgaddserv.Tapped += tapLimgaddserv_Tapped;
            imgaddserv.GestureRecognizers.Add(tapLimgaddserv);

            StackLayout stkimgserv = new StackLayout();
            stkimgserv.Orientation = StackOrientation.Horizontal;
            stkimgserv.HorizontalOptions = LayoutOptions.FillAndExpand;
            stkimgserv.Children.Add(servicel);
            //stkimgserv.Children.Add(imgaddserv);

            StackLayout stkservices = new StackLayout();
            stkservices.Orientation = StackOrientation.Vertical;
            stkservices.HorizontalOptions = LayoutOptions.FillAndExpand;
            stkservices.Children.Add(stkimgserv);
            stkservices.Children.Add(xfserv);

            servicesstk.Children.Add(stkservices);




            Label Lparkdirc = new Label
            {
                Text = "Further Details:",
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            moredetEntry = new Editor
            {
                Text = "Further Details",
                TextColor = Color.White,
                BackgroundColor = Color.Transparent,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Keyboard = Keyboard.Text,
                HeightRequest = 75

            };
            moredetEntry.Focused += editor_Focused;
            moredetEntry.Unfocused += editor_Unfocused;
            FmoredetEntry = new CustomFrame
            {
                Content = moredetEntry,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0),
                OutlineColor = Color.White,
                BorderWidth = 1,
                BorderRadius = 5,
                BackgroundColor = Color.Transparent,

            };
            moredetEntry.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                if (!string.IsNullOrEmpty(moredetEntry.Text))
                {
                    FmoredetEntry.OutlineColor = Color.White;
                }

            };
            stkmoredetEntry = new StackLayout();
            stkmoredetEntry.Orientation = StackOrientation.Vertical;
            stkmoredetEntry.HorizontalOptions = LayoutOptions.Fill;
            stkmoredetEntry.Children.Add(Lparkdirc);
            stkmoredetEntry.Children.Add(FmoredetEntry);
            stkmoredetEntry.Spacing = 2;

            stkmoredetails.Children.Add(stkmoredetEntry);


            Label conshour = new Label
            {
                Text = "Consulting Hours",
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            imgconshour = new Image();
            imgconshour.HorizontalOptions = LayoutOptions.End;
            imgconshour.VerticalOptions = LayoutOptions.Center;
            imgconshour.BackgroundColor = Color.Transparent;
            imgconshour.Aspect = Aspect.AspectFill;
            imgconshour.Source = "Nextpage.png";
            imgconshour.WidthRequest = 25;
            imgconshour.HeightRequest = 25;


            StackLayout stkconshour = new StackLayout();
            stkconshour.Orientation = StackOrientation.Horizontal;
            stkconshour.HorizontalOptions = LayoutOptions.FillAndExpand;
            stkconshour.Children.Add(conshour);
            stkconshour.Children.Add(imgconshour);


            Fconshour = new CustomFrame
            {
                Content = stkconshour,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(10),
                OutlineColor = Color.White,

                BorderWidth = 1,
                BorderRadius = 5,
                BackgroundColor = Color.WhiteSmoke,

            };
            var tapFconshour = new TapGestureRecognizer();
            tapFconshour.Tapped += tapFconshour_Tapped;
            Fconshour.GestureRecognizers.Add(tapFconshour);

            consultinghours.Children.Add(Fconshour);

            Label addroom = new Label
            {
                Text = "Add Room",
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            imgaddroom = new Image();
            imgaddroom.HorizontalOptions = LayoutOptions.End;
            imgaddroom.VerticalOptions = LayoutOptions.Center;
            imgaddroom.BackgroundColor = Color.Transparent;
            imgaddroom.Aspect = Aspect.AspectFill;
            imgaddroom.Source = "Nextpage.png";
            imgaddroom.WidthRequest = 25;
            imgaddroom.HeightRequest = 25;


            StackLayout stkaddroom = new StackLayout();
            stkaddroom.Orientation = StackOrientation.Horizontal;
            stkaddroom.HorizontalOptions = LayoutOptions.FillAndExpand;
            stkaddroom.Children.Add(addroom);
            stkaddroom.Children.Add(imgaddroom);


            Faddroom = new CustomFrame
            {
                Content = stkaddroom,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(10),
                OutlineColor = Color.White,

                BorderWidth = 1,
                BorderRadius = 5,
                BackgroundColor = Color.WhiteSmoke,

            };
            var tapFaddroom = new TapGestureRecognizer();
            tapFaddroom.Tapped += tapFaddroom_TappedAsync;
            Faddroom.GestureRecognizers.Add(tapFaddroom);


           
            addroommain.Children.Add(Faddroom);

            main.HorizontalOptions = LayoutOptions.FillAndExpand;
            main.VerticalOptions = LayoutOptions.StartAndExpand;
            main.Margin = 20;
            main.Spacing = 20;
        }
        async void tapFaddroom_TappedAsync(object sender, EventArgs e)
        {
            Faddroom.BackgroundColor = Color.Gray;
            await Navigation.PushAsync(new consultingRoom_create(cv));
            Faddroom.BackgroundColor = Color.White;
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
                //await Navigation.PushPopupAsync(new popup_pleasewait());

                var httpclient = new HttpClient();
                var json = await httpclient.GetStringAsync(uriservices);
                serviesinfo responsemain = JsonConvert.DeserializeObject<serviesinfo>(json);
                var count = responsemain.servies.Count();
                if (count >= 1)
                {
                    foreach (servies v in responsemain.servies)
                    {
                        formFields.Add(v.service_name, v.Id);



                    }
                    servicelist = new List<string>(formFields.Keys);
                    xfserv.DataSource = servicelist;

                    //await Navigation.PopAllPopupAsync();
                }
                else
                {
                    //await Navigation.PopAllPopupAsync();
                    //  Tapadd_Tapped();

                }


            }
            catch (Exception ex)
            {
                DisplayAlert("", "SomthSomething to worng\n" + ex.Message, "Ok");
                await Navigation.PopAllPopupAsync();
                return;
            }
        }
        async void tapFconshour_Tapped(object sender, EventArgs e)
        {
            Fconshour.BackgroundColor = Color.Gray;
            await Navigation.PushAsync(new Consulting_Service_Hours(cv));
            Fconshour.BackgroundColor = Color.White;

        }

        async void testclick()
        {
            //if (serviceslistview.Count == 0)
            //{
            //    if (!servicesstk.AnimationIsRunning("TranslateTo"))
            //    {
            //        await servicesstk.TranslateTo(-10, 0, 100);
            //        await servicesstk.TranslateTo(10, 0, 100);
            //        await servicesstk.TranslateTo(0, 0, 100);
            //        return;
            //    }
            //}
             if (!Config.consultinghours)
            {
                if (!consultinghours.AnimationIsRunning("TranslateTo"))
                {
                    await consultinghours.TranslateTo(-10, 0, 100);
                    await consultinghours.TranslateTo(10, 0, 100);
                    await consultinghours.TranslateTo(0, 0, 100);
                    return;
                }
                
            }
            
            var serv_clinic_details = new consulting_services_clinicians_detailsinfo();
            var servarray = new consulting_services_details[serviceslistview.Count];
           
            int i = 0;
            int j = 0;
            foreach (var obj in serviceslistview)
            {
                var servdetailsmain = new consulting_services_details
                {
                    userid = Config.user_Id,
                    consulting_id = cv.id,
                    service_id = formFields[obj.servicesName],
                    created_by = Config.user_Id,
                    modified_by = Config.user_Id,
                    created = DateTime.Now,
                    modified = DateTime.Now
                };

                servarray[i] = servdetailsmain;
                i++;
            }
           
            serv_clinic_details.consulting_services_details = servarray;
            serv_clinic_details.futherdetails = moredetEntry.Text;
            serv_clinic_details.consulting_id = cv.id;
            try
            {

                var httpclient = new HttpClient();
                await Navigation.PushPopupAsync(new popup_pleasewait());
                var json = JsonConvert.SerializeObject(serv_clinic_details);
                HttpContent httpcontent = new StringContent(json);
                httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var result = await httpclient.PostAsync(uri, httpcontent);


                if (result.IsSuccessStatusCode)
                {
                    Config.consultinghours = false;
                    await Navigation.PopAllPopupAsync();
                    maintabbedpage consentPage = new maintabbedpage(cv);
                    await Navigation.PushAsync(consentPage);
                    return;

                }
                else
                {
                    await Navigation.PopPopupAsync();
                    await DisplayAlert("", "error try again", "Ok");
                    return;
                }



            }
            catch (Exception ex)
            {
                await Navigation.PopPopupAsync();
                await DisplayAlert("", "error try again" + ex.Message, "Ok");
                return;

            }
        }

        void tapLimgaddserv_Tapped(object sender, EventArgs e)
        {
            myListserv.IsVisible = true;
            serviceslistview.Add(new services { servicesName = xfserv.SelectedItem.ToString() });
            //var itemToRemove = servicelist.Single(r => r == xfserv.SelectedItem.ToString());
            //if (itemToRemove != null)
            //          servicelist.Remove(itemToRemove);
            //xfserv.DataSource = servicelist;
            myListserv.ForceReload();
            xfserv.Text = "";
            xfserv.SelectedItem = "";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Config.consultinghours)
            {
                imgconshour.Source = "complete.png";
            }
            else
            {
                imgconshour.Source = "Nextpage.png";
            }
        }
        private void myListserv_OnFlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var grourp = e.Group;
            myListserv.FlowTappedBackgroundColor = Color.Gray;
            var xyz = e.Item;
            var itemToRemove = serviceslistview.Single(r => r == e.Item);
            if (itemToRemove != null)
                serviceslistview.Remove(itemToRemove);
            //var itemToAdd = servicelist.Single(r => r == e.Item );
            //if (itemToRemove == null)
            //servicelist.Add(itemToAdd);
            myListserv.FlowItemsSource = null;
            myListserv.FlowItemsSource = serviceslistview;
            myListserv.ForceReload();
            if (myListserv.FlowItemsSource.Count == 0)
            {
                myListserv.IsVisible = false;
            }



        }
        void editor_Focused(object sender, FocusEventArgs e)
        {
            if (moredetEntry.Text.Equals("Further Details"))
            {
                moredetEntry.Text = "";
            }
        }

        void editor_Unfocused(object sender, FocusEventArgs e)
        {
            if (moredetEntry.Text.Equals(""))
            {
                moredetEntry.Text = "Further Details";
            }
        }
       

    }
}