using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using ThinkDoctor.Menu.SubPage;
using Xamarin.Forms;

namespace ThinkDoctor.Menu.SubPage
{
    public class gridpage : ContentPage
    {
        Grid griddoct, gridnurse, gridadmin, gridsecretion;
        Image imgdoct, imgnurse, imgadmin, imgsecretion;
        Label Ldoct, Lnurse, Ladmin, Lsecretion;
        StackLayout stkdoct, stknurse, stkadmin, stksecretion;

        public gridpage()
        {
            Padding = new Thickness (0, Device.OnPlatform (10, 0, 0), 0, 0);
            
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.FromRgb(212, 212, 212) ;
            createdocgrid();
            createnursegrid();
            creategridsecretion();
            createadmingrid();

            var grid = new Grid ();
            grid.ColumnSpacing = 2;
            grid.RowSpacing  = 2;
            grid.Children.Add(griddoct, 0, 0);
            grid.Children.Add(gridnurse, 1, 0);
            grid.Children.Add(gridadmin , 0, 1);
            grid.Children.Add(gridsecretion, 1, 1);
         


            var grid1 = new Grid();
            grid1.ColumnSpacing = 2;
            grid1.RowSpacing = 2;
            grid1.Children.Add(gridItemNew("Therapist.png", 40, 40, "Therapist", LayoutOptions.Center, LayoutOptions.Center, 1, 1, Color.White), 0, 0);
            grid1.Children.Add(gridItemNew("Emailg.png", 40, 40, "Email", LayoutOptions.Center, LayoutOptions.Center, 1, 1, Color.White), 1, 0);
            grid1.Children.Add(gridItemNew("Letter.png", 40, 40, "Letter", LayoutOptions.Center, LayoutOptions.Center, 1, 1, Color.White), 2, 0);
            grid1.Children.Add(gridItemNew("test1.png", 40, 40, "Test", LayoutOptions.Center, LayoutOptions.Center, 1, 1, Color.White), 0, 1);
            grid1.Children.Add(gridItemNew("sms.png", 40, 40, "SMS", LayoutOptions.Center, LayoutOptions.Center, 1, 1, Color.White), 1, 1);
            grid1.Children.Add(gridItemNew("emailga.png", 40, 40, "Email", LayoutOptions.Center, LayoutOptions.Center, 1, 1, Color.White), 2, 1);

            StackLayout arrgrid = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor =Color.FromRgb(212, 212, 212),
                Margin = new Thickness(10, 15, 10, 0),
                Spacing =2
            };
            arrgrid.Children.Add (grid);
            arrgrid.Children.Add(grid1);
            Content = arrgrid;
        }

        public void createdocgrid()
        {
            griddoct = new Grid
            {
                BackgroundColor = Color.White,
                Padding = new Thickness(20, 20, 20, 20)
            };


            imgdoct = new Image
            {
                Source = "doctor.png",
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 50,
                WidthRequest = 50
            };

           
            Ldoct = new Label
            {
                Text = "Doctor",
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
           };
           

            stkdoct  = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                   imgdoct,Ldoct
                }
            };

            griddoct.Children.Add(stkdoct, 0, 0);
            var tapdoct = new TapGestureRecognizer();
            tapdoct.Tapped += Tapdoct_Tapped;
            griddoct.GestureRecognizers.Add(tapdoct);
        }

      

        public void createnursegrid()
        {
            gridnurse = new Grid
            {
                BackgroundColor = Color.White,
                Padding = new Thickness(20, 20, 20, 20)
            };


            imgnurse = new Image
            {
                Source = "nurse.png",
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 50,
                WidthRequest = 50
            };


            Lnurse = new Label
            {
                Text = "Nurse",
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };


            stknurse = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                   imgnurse,Lnurse
                }
            };

            gridnurse.Children.Add(stknurse, 0, 0);
         
            var tapnurse = new TapGestureRecognizer();
            tapnurse.Tapped += Tapnurse_Tapped;
            gridnurse.GestureRecognizers.Add(tapnurse);
        }

      

        public void createadmingrid()
        {
            gridadmin = new Grid
            {
                BackgroundColor = Color.White,
                Padding = new Thickness(20, 20, 20, 20)
            };


            imgadmin = new Image
            {
                Source = "admin.png",
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 50,
                WidthRequest = 50
            };


            Ladmin = new Label
            {
                Text = "Admin",
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };


            stkadmin = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                   imgadmin,Ladmin
                }
            };

            gridadmin.Children.Add(stkadmin, 0, 0);

            var tapadmin = new TapGestureRecognizer();
            tapadmin.Tapped += Tapadmin_Tapped;
            gridadmin.GestureRecognizers.Add(tapadmin);
        }

      

        public void creategridsecretion()
        {
            gridsecretion = new Grid
            {
                BackgroundColor = Color.White,
                Padding = new Thickness(20, 20, 20, 20)
            };


            imgsecretion = new Image
            {
                Source = "Documents.png",
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 50,
                WidthRequest = 50
            };


            Lsecretion = new Label
            {
                Text = "Secretion",
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };


            stksecretion = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                   imgsecretion,Lsecretion
                }
            };

            gridsecretion.Children.Add(stksecretion, 0, 0);

            var tapsecretion = new TapGestureRecognizer();
            tapsecretion.Tapped += Tapsecretion_Tapped;
            gridsecretion.GestureRecognizers.Add(tapsecretion);
        }

        

        private Grid gridItemNew(string imgSrc, double h, double w, string text1, LayoutOptions imghOptions, LayoutOptions lblhOptions, double fw, double sw, Color cl)
        {
            Grid grid_details_info = new Grid
            {

                BackgroundColor = cl,
                Padding = new Thickness(20, 20, 20, 20)
            };



            Image i = new Image();
            i.Source = imgSrc;
            i.VerticalOptions = LayoutOptions.Center;
            i.HorizontalOptions = imghOptions;
            i.HeightRequest = h;
            i.WidthRequest = w;

            Label l1 = new Label();
            l1.Text = text1;
            l1.TextColor = Color.Black;
            l1.VerticalTextAlignment = TextAlignment.Center;
            l1.HorizontalTextAlignment = TextAlignment.Center;
            l1.VerticalOptions = LayoutOptions.Center;
            l1.HorizontalOptions = lblhOptions;
            l1.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));

            StackLayout arr = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                   i,l1
                }
            };

            grid_details_info.Children.Add(arr, 0, 0);
            // grid_details_info.Children.Add(l1, 1, 0);

            return grid_details_info;
        }
        private void Tapdoct_Tapped(object sender, EventArgs e)
        {
            //active
            imgdoct.Source = "doctor1.png";
            griddoct.BackgroundColor = Color.FromHex("#D56928");
            Ldoct.TextColor = Color.White;

            //deactive
            imgnurse.Source = "nurse.png";
            gridnurse.BackgroundColor = Color.White;
            Lnurse.TextColor = Color.Black ;

            imgadmin.Source = "admin.png";
            gridadmin.BackgroundColor = Color.White;
            Ladmin.TextColor = Color.Black;

            imgsecretion.Source = "Documents.png";
            gridsecretion.BackgroundColor = Color.White;
            Lsecretion.TextColor = Color.Black;

        }
        private void Tapnurse_Tapped(object sender, EventArgs e)
        {
            //active
            imgnurse.Source = "nurse1.png";
            gridnurse.BackgroundColor = Color.FromHex("#D56928");
            Lnurse.TextColor = Color.White;

            //deactive
            imgdoct.Source = "doctor.png";
            griddoct.BackgroundColor = Color.White;
            Ldoct.TextColor = Color.Black;

            imgadmin.Source = "admin.png";
            gridadmin.BackgroundColor = Color.White;
            Ladmin.TextColor = Color.Black;

            imgsecretion.Source = "Documents.png";
            gridsecretion.BackgroundColor = Color.White;
            Lsecretion.TextColor = Color.Black;

            Navigation.PushAsync(new NurseRegv1());
        }
        private void Tapadmin_Tapped(object sender, EventArgs e)
        {
            //active
            imgadmin.Source = "admin1.png";
            gridadmin.BackgroundColor = Color.FromHex("#D56928");
            Ladmin.TextColor = Color.White;

            //deactive
            imgnurse.Source = "nurse.png";
            gridnurse.BackgroundColor = Color.White;
            Lnurse.TextColor = Color.Black;

            imgdoct.Source = "doctor.png";
            griddoct.BackgroundColor = Color.White;
            Ldoct.TextColor = Color.Black;

            imgsecretion.Source = "Documents.png";
            gridsecretion.BackgroundColor = Color.White;
            Lsecretion.TextColor = Color.Black;


        }

        private void Tapsecretion_Tapped(object sender, EventArgs e)
        {
            //active
            imgsecretion.Source = "Documents1.png";
            gridsecretion.BackgroundColor = Color.FromHex("#D56928");
            Lsecretion.TextColor = Color.White;


            //deactive
            imgnurse.Source = "nurse.png";
            gridnurse.BackgroundColor = Color.White;
            Lnurse.TextColor = Color.Black;

            imgadmin.Source = "admin.png";
            gridadmin.BackgroundColor = Color.White;
            Ladmin.TextColor = Color.Black;

            imgdoct.Source = "doctor.png";
            griddoct.BackgroundColor = Color.White;
            Ldoct.TextColor = Color.Black;
        }
    }
}
