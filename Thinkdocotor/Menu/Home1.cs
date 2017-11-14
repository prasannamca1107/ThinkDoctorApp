using System;
using Xamarin.Forms;

namespace ThinkDoctor.Menu
{
    public class Home1
    {
        Image imgAccounts, imgPatients, imgDiary, imgDocuments, imgInvoices, imgReports, imgTeam, imgMngDocs, imgMngPats;
        Label lblAccounts, lblPatients, lblDiary, lblDocuments, lblInvoices, lblReports, lblTeam, lblMngDocs, lblMngPats;
        StackLayout st_home, st_team, st_accounts, st_patients, st_diary, st_documents, st_reports;
        Frame frame_diary, frame_patients, frame_documents, frame_reports, frame_accounts, frame_team;
        ScrollView homeScroll;
        Grid homeGrid, grid_tabs;
        RelativeLayout rl_home;

        public Home1()
        {
            createHomeContent();
            //MPConsts.myHomeContent = homeScroll;
            MPConsts.myHomeContent = st_home;
        }

        #region Home Content
        private void createHomeContent()
        {
            createAccountsStack();
            createPatientsStack();
            createDiaryStack();
            createDocumentsStack();
            //createInvoicesStack();
            createReportsStack();
            createTeamStack();

            homeGrid = new Grid();
            homeGrid.VerticalOptions = LayoutOptions.Center;
            homeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            homeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            homeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            homeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            homeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //homeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            homeGrid.BackgroundColor = Color.Transparent;
            homeGrid.ColumnSpacing = 5;
            homeGrid.RowSpacing = 5;

            //homeGrid.Children.Add(st_diary, 0, 0);
            //homeGrid.Children.Add(st_patients, 1, 0);
            //homeGrid.Children.Add(st_documents, 0, 1);
            //homeGrid.Children.Add(st_reports, 1, 1);
            //homeGrid.Children.Add(st_accounts, 0, 2);
            //homeGrid.Children.Add(st_team, 1, 2);

            homeGrid.Children.Add(frame_diary, 0, 0);
            homeGrid.Children.Add(frame_patients, 1, 0);
            homeGrid.Children.Add(frame_documents, 0, 1);
            homeGrid.Children.Add(frame_reports, 1, 1);
            homeGrid.Children.Add(frame_accounts, 0, 2);
            homeGrid.Children.Add(frame_team, 1, 2);

            homeScroll = new ScrollView();
            homeScroll.BackgroundColor = Color.Transparent;
            homeScroll.HorizontalOptions = LayoutOptions.Fill;
            homeScroll.VerticalOptions = LayoutOptions.Center;
            homeScroll.Padding = new Thickness(10);
            homeScroll.Content = homeGrid;

            st_home = new StackLayout();
            st_home.BackgroundColor = Color.Transparent;
            st_home.HorizontalOptions = LayoutOptions.Fill;
            st_home.VerticalOptions = LayoutOptions.CenterAndExpand;
            st_home.Padding = new Thickness(0);
            st_home.Margin = new Thickness(0);
            st_home.Spacing = 0;
            st_home.Children.Add(homeScroll);
            
        }

        public void createAccountsStack()
        {
            imgAccounts = new Image
            {
                Source = "accounts.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = MPConsts.imgHeight,
                WidthRequest = MPConsts.imgWidth
            };


            lblAccounts = new Label
            {
                Text = "Accounts",
                TextColor = MPConsts.lblColor,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.OnPlatform(15, Device.GetNamedSize(NamedSize.Medium, typeof(Label)), Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
            };


            st_accounts = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.White,
                Padding = new Thickness(10),
                Children =
                {
                   imgAccounts, lblAccounts
                }
            };

            frame_accounts = new Frame
            {
                Padding = new Thickness(1),
                HasShadow = true,
                Content = st_accounts
            };
            
            var tapAcc = new TapGestureRecognizer();
            tapAcc.Tapped += TapAcc_Tapped;
            st_accounts.GestureRecognizers.Add(tapAcc);
            //frame_accounts.GestureRecognizers.Add(tapAcc);
        }

        private async void TapAcc_Tapped(object sender, EventArgs e)
        {
            //await MPConsts.myNavigationPage.Navigation.PushAsync(new AccountsPage());
           // await MPConsts.myNavigationPage.Navigation.PushAsync(new Accounts.Accounts());
        }

        public void createPatientsStack()
        {
            imgPatients = new Image
            {
                Source = "manage_patients.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = MPConsts.imgHeight,
                WidthRequest = MPConsts.imgWidth
            };


            lblPatients = new Label
            {
                Text = "Patients",
                TextColor = MPConsts.lblColor,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.OnPlatform(15, Device.GetNamedSize(NamedSize.Medium, typeof(Label)), Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
            };


            st_patients = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(10),
                VerticalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.White,
                Children =
                {
                   imgPatients, lblPatients
                }
            };

            frame_patients = new Frame
            {
                Padding = new Thickness(1),
                HasShadow = true,
                Content = st_patients
            };

            var tapPats = new TapGestureRecognizer();
            tapPats.Tapped += TapPats_Tapped;
            st_patients.GestureRecognizers.Add(tapPats);
            //frame_patients.GestureRecognizers.Add(tapPats);
        }

        private async void TapPats_Tapped(object sender, EventArgs e)
        {
          //  await MPConsts.myNavigationPage.Navigation.PushAsync(new PatientsPage());
        }

        public void createDiaryStack()
        {
            imgDiary = new Image
            {
                Source = "diarynew.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = MPConsts.imgHeight,
                WidthRequest = MPConsts.imgWidth
            };


            lblDiary = new Label
            {
                Text = "Diary",
                TextColor = MPConsts.lblColor,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.OnPlatform(15, Device.GetNamedSize(NamedSize.Medium, typeof(Label)), Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
            };


            st_diary = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(10),
                VerticalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.White,
                Children =
                {
                   imgDiary, lblDiary
                }
            };

            frame_diary = new Frame
            {
                Padding = new Thickness(1),
                HasShadow = true,
                Content = st_diary
            };

            var tapDiary = new TapGestureRecognizer();
            tapDiary.Tapped += TapDiary_Tapped;
            st_diary.GestureRecognizers.Add(tapDiary);
            //frame_diary.GestureRecognizers.Add(tapDiary);
        }

        private async void TapDiary_Tapped(object sender, EventArgs e)
        {
            //await MPConsts.myNavigationPage.Navigation.PushAsync(new Diary.DairyPage());
           // await MPConsts.myNavigationPage.Navigation.PushAsync(new Diary.WeekPage());
        }

        public void createDocumentsStack()
        {
            imgDocuments = new Image
            {
                Source = "Doc.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = MPConsts.imgHeight,
                WidthRequest = MPConsts.imgWidth
            };


            lblDocuments = new Label
            {
                Text = "Documents",
                TextColor = MPConsts.lblColor,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.OnPlatform(15, Device.GetNamedSize(NamedSize.Medium, typeof(Label)), Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
            };


            st_documents = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(10),
                VerticalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.White,
                Children =
                {
                   imgDocuments, lblDocuments
                }
            };

            frame_documents = new Frame
            {
                Padding = new Thickness(1),
                HasShadow = true,
                Content = st_documents
            };

            var tapDocs = new TapGestureRecognizer();
            tapDocs.Tapped += TapDocs_Tapped;
            st_documents.GestureRecognizers.Add(tapDocs);
            //frame_documents.GestureRecognizers.Add(tapDocs);
        }

        private async void TapDocs_Tapped(object sender, EventArgs e)
        {

        }

        //public void createInvoicesStack()
        //{
        //    imgInvoices = new Image
        //    {
        //        Source = "invoices.png",
        //        HorizontalOptions = LayoutOptions.Center,
        //        VerticalOptions = LayoutOptions.Center,
        //        HeightRequest = MPConsts.imgHeight,
        //        WidthRequest = MPConsts.imgWidth
        //    };


        //    lblInvoices = new Label
        //    {
        //        Text = "Invoices",
        //        TextColor = MPConsts.lblColor,
        //        VerticalTextAlignment = TextAlignment.Center,
        //        HorizontalTextAlignment = TextAlignment.Center,
        //        VerticalOptions = LayoutOptions.Center,
        //        HorizontalOptions = LayoutOptions.Center,
        //        FontSize = Device.OnPlatform(15, Device.GetNamedSize(NamedSize.Medium, typeof(Label)), Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
        //    };


        //    st_invoices = new StackLayout
        //    {
        //        Orientation = StackOrientation.Vertical,
        //        Padding = new Thickness(10),
        //        VerticalOptions = LayoutOptions.Fill,
        //        BackgroundColor = Color.White,
        //        Children =
        //        {
        //           imgInvoices, lblInvoices
        //        }
        //    };

        //    var tapInv = new TapGestureRecognizer();
        //    tapInv.Tapped += TapInv_Tapped;
        //    st_invoices.GestureRecognizers.Add(tapInv);
        //}

        //private async void TapInv_Tapped(object sender, EventArgs e)
        //{

        //}

        public void createReportsStack()
        {
            imgReports = new Image
            {
                Source = "reports.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = MPConsts.imgHeight,
                WidthRequest = MPConsts.imgWidth
            };


            lblReports = new Label
            {
                Text = "Reports",
                TextColor = MPConsts.lblColor,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.OnPlatform(15, Device.GetNamedSize(NamedSize.Medium, typeof(Label)), Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
            };


            st_reports = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(10),
                VerticalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.White,
                Children =
                {
                   imgReports, lblReports
                }
            };

            frame_reports = new Frame
            {
                Padding = new Thickness(1),
                HasShadow = true,
                Content = st_reports
            };

            var tapRep = new TapGestureRecognizer();
            tapRep.Tapped += TapRep_Tapped;
            st_reports.GestureRecognizers.Add(tapRep);
            //frame_reports.GestureRecognizers.Add(tapRep);
        }

        private async void TapRep_Tapped(object sender, EventArgs e)
        {

        }

        public void createTeamStack()
        {
            imgTeam = new Image
            {
                Source = "patients.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = MPConsts.imgHeight,
                WidthRequest = MPConsts.imgWidth
            };


            lblTeam = new Label
            {
                Text = "Team",
                TextColor = MPConsts.lblColor,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.OnPlatform(15, Device.GetNamedSize(NamedSize.Medium, typeof(Label)), Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
            };


            st_team = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(10),
                VerticalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.White,
                Children =
                {
                   imgTeam, lblTeam
                }
            };

            frame_team = new Frame
            {
                Padding = new Thickness(1),
                HasShadow = true,
                Content = st_team
            };

            var tapTeam = new TapGestureRecognizer();
            tapTeam.Tapped += TapTeam_Tapped; ;
            st_team.GestureRecognizers.Add(tapTeam);
            //frame_team.GestureRecognizers.Add(tapTeam);
        }

        private async void TapTeam_Tapped(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
