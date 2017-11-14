using System;
using ThinkDoctor.Menu;
using Xamarin.Forms;

namespace ThinkDoctor.Menu
{
    public class UserDetailPage : ContentPage
    {
        StackLayout st_mainStack, st_content, st_tabhome, st_tabdiary, st_tabhistory;
        Grid grid_tabs;
        Label lblDiary, lblHome, lblHistory;

        const int animateLength = 500;

        //private const double tabimgwidth = 32;
        //private const double tabimgheight = 32;
        //private static Color tabselcolor = Color.FromRgb(165, 255, 135);
        //private static Color tabdefcolor = Color.FromRgb(212, 212, 212);
        //private const double tabstackspacing = 1;

        //UserOptions.Home.Home homeClass;
        //UserOptions.Diary.Diary diaryClass;

        //public StackLayout TabHome { get { return st_tabhome; } }
        //public StackLayout TabDiary { get { return st_tabdiary; } }
        //public StackLayout TabHistory { get { return st_tabhistory; } }

        public StackLayout ContentStack { get { return st_content; } }

        //public Color TabSelColor { get { return tabselcolor; } }
        //public Color TabDefColor { get { return tabdefcolor; } }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        public UserDetailPage()
        {
            Title = "Home";
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            //NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = MPConsts.PagesBGColor;

            MPConsts.IsHome = true;
            MPConsts.IsDiary = false;
            MPConsts.IsHistory = false;
            CreateTabs();
            updateTabs();

            st_content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Fill,
                //BackgroundColor = Color.Green,
                Margin = new Thickness(0),
            };
            st_content.Children.Add(MPConsts.myHomeContent);

            st_mainStack = new StackLayout();
            st_mainStack.VerticalOptions = LayoutOptions.Fill;
            st_mainStack.HorizontalOptions = LayoutOptions.Fill;
            st_mainStack.BackgroundColor = Color.Transparent;
            st_mainStack.Padding = new Thickness(0);
            st_mainStack.Spacing = 2;
            st_mainStack.Margin = new Thickness(0);
            st_mainStack.Children.Add(st_content);
            st_mainStack.Children.Add(grid_tabs);

            Content = st_mainStack;
        }

        #region TABS

        private void CreateTabs()
        {
            //-------------------------TABS-------------------------
            grid_tabs = new Grid();
            grid_tabs.ColumnSpacing = 0;
            grid_tabs.HeightRequest = 50;
            grid_tabs.BackgroundColor = Color.Transparent;
            grid_tabs.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid_tabs.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid_tabs.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid_tabs.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            grid_tabs.VerticalOptions = LayoutOptions.End;
            grid_tabs.HorizontalOptions = LayoutOptions.Fill;
            grid_tabs.Padding = new Thickness(0);

            //-------------------------Home-------------------------
            Image imgHome = new Image();
            imgHome.WidthRequest = MPConsts.tabimgwidth;
            imgHome.HeightRequest = MPConsts.tabimgheight;
            imgHome.VerticalOptions = LayoutOptions.Center;
            imgHome.HorizontalOptions = LayoutOptions.Center;
            imgHome.Source = "hometab.png";

            lblHome = new Label();
            lblHome.Text = "Home";
            lblHome.TextColor = Color.Black;
            lblHome.HorizontalOptions = LayoutOptions.Center;
            lblHome.VerticalOptions = LayoutOptions.Center;
            lblHome.VerticalTextAlignment = TextAlignment.Center;
            lblHome.HorizontalTextAlignment = TextAlignment.Center;
            //lblHome.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            lblHome.FontSize = 13;

            st_tabhome = new StackLayout();
            st_tabhome.BackgroundColor = MPConsts.tabselcolor;
            st_tabhome.Padding = new Thickness(5, 5, 5, 0);
            st_tabhome.Spacing = MPConsts.tabstackspacing;
            st_tabhome.Children.Add(imgHome);
            st_tabhome.Children.Add(lblHome);
            //st_tabhome.Children.Add(boxHome);

            TapGestureRecognizer tap_home = new TapGestureRecognizer();
            tap_home.Tapped += Tap_home_Tapped;
            st_tabhome.GestureRecognizers.Add(tap_home);

            //-------------------------Diary-------------------------
            Image imgDiary = new Image();
            imgDiary.WidthRequest = MPConsts.tabimgwidth;
            imgDiary.HeightRequest = MPConsts.tabimgheight;
            imgDiary.VerticalOptions = LayoutOptions.Center;
            imgDiary.HorizontalOptions = LayoutOptions.Center;
            imgDiary.Source = "diarytab.png";

            lblDiary = new Label();
            lblDiary.Text = "Diary";
            lblDiary.TextColor = Color.Black;
            lblDiary.HorizontalOptions = LayoutOptions.Center;
            lblDiary.VerticalOptions = LayoutOptions.Center;
            lblDiary.VerticalTextAlignment = TextAlignment.Center;
            lblDiary.HorizontalTextAlignment = TextAlignment.Center;
            //lblDiary.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            lblDiary.FontSize = 13;

            st_tabdiary = new StackLayout();
            st_tabdiary.BackgroundColor = MPConsts.tabdefcolor;
            st_tabdiary.Padding = new Thickness(5, 5, 5, 0);
            st_tabdiary.Spacing = MPConsts.tabstackspacing;
            st_tabdiary.Children.Add(imgDiary);
            st_tabdiary.Children.Add(lblDiary);
            //st_tabdiary.Children.Add(boxDiary);

            TapGestureRecognizer tap_diary = new TapGestureRecognizer();
            tap_diary.Tapped += Tap_diary_Tapped; ;
            st_tabdiary.GestureRecognizers.Add(tap_diary);

            //-------------------------History-------------------------
            Image imgHistory = new Image();
            imgHistory.WidthRequest = MPConsts.tabimgwidth;
            imgHistory.HeightRequest = MPConsts.tabimgheight;
            imgHistory.VerticalOptions = LayoutOptions.Center;
            imgHistory.HorizontalOptions = LayoutOptions.Center;
            imgHistory.Source = "historytab.png";

            lblHistory = new Label();
            lblHistory.Text = "History";
            lblHistory.TextColor = Color.Black;
            lblHistory.HorizontalOptions = LayoutOptions.Center;
            lblHistory.VerticalOptions = LayoutOptions.Center;
            lblHistory.VerticalTextAlignment = TextAlignment.Center;
            lblHistory.HorizontalTextAlignment = TextAlignment.Center;
            //lblHistory.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            lblHistory.FontSize = 13;

            st_tabhistory = new StackLayout();
            st_tabhistory.BackgroundColor = MPConsts.tabdefcolor;
            st_tabhistory.Padding = new Thickness(5, 5, 5, 0);
            st_tabhistory.Spacing = MPConsts.tabstackspacing;
            st_tabhistory.Children.Add(imgHistory);
            st_tabhistory.Children.Add(lblHistory);
            //st_tabhistory.Children.Add(boxHistory);

            TapGestureRecognizer tap_history = new TapGestureRecognizer();
            tap_history.Tapped += Tap_history_Tapped; ; ;
            st_tabhistory.GestureRecognizers.Add(tap_history);
            //--------------------------------------------------

            grid_tabs.Children.Add(st_tabhome, 0, 0);
            grid_tabs.Children.Add(st_tabdiary, 1, 0);
            grid_tabs.Children.Add(st_tabhistory, 2, 0);
        }

        private void Tap_history_Tapped(object sender, EventArgs e)
        {
            showHistory();
        }

        private void Tap_diary_Tapped(object sender, EventArgs e)
        {
            showDiary();
        }

        private void Tap_home_Tapped(object sender, EventArgs e)
        {
            showHome();
        }

        #endregion

        #region Display Fucntions
        private void updateTabs()
        {
            if(MPConsts.IsHome)
            {
                lblDiary.ScaleTo(1, animateLength, Easing.CubicInOut);
                lblHistory.ScaleTo(1, animateLength, Easing.CubicInOut);
                lblHome.ScaleTo(1.1, animateLength, Easing.CubicInOut);
            }
            else if(MPConsts.IsDiary)
            {
                lblHome.ScaleTo(1, animateLength, Easing.CubicInOut);
                lblHistory.ScaleTo(1, animateLength, Easing.CubicInOut);
                lblDiary.ScaleTo(1.1, animateLength, Easing.CubicInOut);
            }
            else if (MPConsts.IsHistory)
            {
                lblHome.ScaleTo(1, animateLength, Easing.CubicInOut);
                lblDiary.ScaleTo(1, animateLength, Easing.CubicInOut);
                lblHistory.ScaleTo(1.1, animateLength, Easing.CubicInOut);
            }
        }
        public void showHome()
        {
            if (!MPConsts.IsHome)
            {
                st_tabhome.BackgroundColor = MPConsts.tabselcolor;
                st_tabdiary.BackgroundColor = MPConsts.tabdefcolor;
                st_tabhistory.BackgroundColor = MPConsts.tabdefcolor;
                Title = "Home";
                MPConsts.IsDiary = false;
                MPConsts.IsHistory = false;
                MPConsts.IsHome = true;
                updateTabs();

                st_content.Children.Clear();
                st_content.Children.Add(MPConsts.myHomeContent);
            }
        }

        public void showDiary()
        {
            if (!MPConsts.IsDiary)
            {
                st_tabhome.BackgroundColor = MPConsts.tabdefcolor;
                st_tabdiary.BackgroundColor = MPConsts.tabselcolor;
                st_tabhistory.BackgroundColor = MPConsts.tabdefcolor;
                Title = "Diary - Select Doctor";
                MPConsts.IsHome = false;
                MPConsts.IsHistory = false;
                MPConsts.IsDiary = true;
                updateTabs();

                st_content.Children.Clear();
                st_content.Children.Add(MPConsts.myDiaryContent);
            }
        }

        public void showHistory()
        {
            if (!MPConsts.IsHistory)
            {
                st_tabhome.BackgroundColor = MPConsts.tabdefcolor;
                st_tabdiary.BackgroundColor = MPConsts.tabdefcolor;
                st_tabhistory.BackgroundColor = MPConsts.tabselcolor;
                Title = "History";
                MPConsts.IsHome = false;
                MPConsts.IsDiary = false;
                MPConsts.IsHistory = true;

                st_content.Children.Clear();
                st_content.Children.Add(MPConsts.myHistoryContent);

                updateTabs();
            }
        }
        #endregion
    }
}

