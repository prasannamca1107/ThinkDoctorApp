using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ThinkDoctor.Menu
{
    public static class MPConsts
    {
        public const double imgWidth = 64;
        public const double imgHeight = 64;
        public const double tabimgwidth = 24;
        public const double tabimgheight = 24;
        public const double tabstackspacing = 1;
        public static List<string> registrationType = new List<string> { "Doctor", "Nurse", "Specialist", "Therapist", "Health Care Assistant", "Nurse Practitioner", "Admin"};
        public static List<string> registrationTypeAndroid = new List<string> { "Select", "Doctor", "Nurse", "Specialist", "Therapist", "Health Care Assistant", "Nurse Practitioner", "Admin" };

        #region Tab Colors
        public static Color tabselcolor = Color.FromHex("#FBA02D");
        //public static Color tabselcolor = Color.FromRgb(165, 255, 135);
        //public static Color tabselcolor = Color.FromRgb(255, 204, 102);
        public static Color tabdefcolor = Color.FromRgb(212, 212, 212);
        #endregion

        #region App Common Colors
        public static Color CoralColor = Color.FromRgb(255, 204, 102);
        public static Color lblColor = Color.Black;
        public static Color AppBGColor = Color.Black;
        public static Color PagesBGColor = Color.Gray;
        //public static Color PagesBGColor = Color.FromRgb(212, 212, 212);
        public static Color PagesSelColor = Color.FromHex("#FBA02D");
        #endregion

        #region Menu Colors
        public static Color menuBGcolor = Color.FromRgb(44, 45, 47);
        public static Color menuForecolor = Color.White;
        #endregion

        #region booleans
        private static bool isHome;
        public static bool IsHome
        {
            get
            {
                return isHome;
            }
            set
            {
                isHome = value;
            }
        }
        private static bool isDiary;
        public static bool IsDiary
        {
            get
            {
                return isDiary;
            }
            set
            {
                isDiary = value;
            }
        }
        private static bool isHistory;
        public static bool IsHistory
        {
            get
            {
                return isHistory;
            }
            set
            {
                isHistory = value;
            }
        }
        #endregion

        #region Content Instances

        private static ThinkDoctor.Menu.UserDetailPage userDetailPage;
        public static ThinkDoctor.Menu.UserDetailPage myUserDetailPage
        {
            get
            {
                return userDetailPage;
            }
            set
            {
                userDetailPage = value;
            }
        }
        private static StackLayout gpContent;
        public static StackLayout myGPContent
        {
            get
            {
                return gpContent;
            }
            set
            {
                gpContent = value;
            }
        }
        //private static ScrollView homeContent;
        //public static ScrollView myHomeContent
        //{
        //    get
        //    {
        //        return homeContent;
        //    }
        //    set
        //    {
        //        homeContent = value;
        //    }
        //}
        private static StackLayout homeContent;
        public static StackLayout myHomeContent
        {
            get
            {
                return homeContent;
            }
            set
            {
                homeContent = value;
            }
        }

        private static ListView diaryContent;
        public static ListView myDiaryContent
        {
            get
            {
                return diaryContent;
            }
            set
            {
                diaryContent = value;
            }
        }

        private static ScrollView historyContent;
        public static ScrollView myHistoryContent
        {
            get
            {
                return historyContent;
            }
            set
            {
                historyContent = value;
            }
        }
        #endregion

        #region Page Instances
        private static NavigationPage navigationPage;
        public static NavigationPage myNavigationPage
        {
            get
            {
                return navigationPage;
            }
            set
            {
                navigationPage = value;
            }
        }

        //private static BottomBar.BottomBarPage bottomBarPage;
        //public static BottomBar.BottomBarPage myBottomBarPage
        //{
        //    get
        //    {
        //        return bottomBarPage;
        //    }
        //    set
        //    {
        //        bottomBarPage = value;
        //    }
        //}

        //private static MainPage.UserMasterDetailPage masterPage;
        //public static MainPage.UserMasterDetailPage myMasterPage
        //{
        //    get
        //    {
        //        return masterPage;
        //    }
        //    set
        //    {
        //        masterPage = value;
        //    }
        //}

        //private static UserOptions.Home.Home homePage;
        //public static UserOptions.Home.Home HomePage
        //{
        //    get
        //    {
        //        return homePage;
        //    }
        //    set
        //    {
        //        homePage = value;
        //    }
        //}

        //private static UserOptions.Diary.Diary diaryPage;
        //public static UserOptions.Diary.Diary DiaryPage
        //{
        //    get
        //    {
        //        if( diaryPage != null)
        //        {
        //            return new UserOptions.Diary.Diary();
        //        }
        //        else
        //        {
        //            return diaryPage;
        //        }
        //    }
        //    set
        //    {
        //        diaryPage = value;
        //    }
        //}

        //private static UserOptions.History.History historyPage;
        //public static UserOptions.History.History HistoryPage
        //{
        //    get
        //    {
        //        return historyPage;
        //    }
        //    set
        //    {
        //        historyPage = value;
        //    }
        //}

        //private static UserOptions.Search.SearchPage searchPage;
        //public static UserOptions.Search.SearchPage mySearchPage
        //{
        //    get
        //    {
        //        return searchPage;
        //    }
        //    set
        //    {
        //        searchPage = value;
        //    }
        //}

        //private static UserOptions.Settings.SettingsPage settingsPage;
        //public static UserOptions.Settings.SettingsPage mySettingsPage
        //{
        //    get
        //    {
        //        return settingsPage;
        //    }
        //    set
        //    {
        //        settingsPage = value;
        //    }
        //}

        //private static UserOptions.Home.AccountsPage accountsPage;
        //public static UserOptions.Home.AccountsPage myAccountsPage
        //{
        //    get
        //    {
        //        return accountsPage;
        //    }
        //    set
        //    {
        //        accountsPage = value;
        //    }
        //}
        #endregion

        //#region TABS
        //private static Grid grid_tabs;
        //private static StackLayout st_tabhome, st_tabdiary, st_tabhistory;
        //public static StackLayout TabHome
        //{
        //    get { return st_tabhome; }
        //}
        //public static StackLayout TabDiary
        //{
        //    get { return st_tabdiary; }
        //}
        //public static StackLayout TabHistory
        //{
        //    get { return st_tabhistory; }
        //}
        //public static Grid myTabs { get { return grid_tabs; } }
        //public static void CreateTabs()
        //{
        //    //-------------------------TABS-------------------------
        //    grid_tabs = new Grid();
        //    grid_tabs.ColumnSpacing = 0;
        //    grid_tabs.BackgroundColor = Color.Transparent;
        //    grid_tabs.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        //    grid_tabs.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        //    grid_tabs.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        //    grid_tabs.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60) });
        //    grid_tabs.VerticalOptions = LayoutOptions.End;
        //    grid_tabs.HorizontalOptions = LayoutOptions.Fill;
        //    grid_tabs.Padding = new Thickness(0);

        //    //-------------------------Home-------------------------
        //    Image imgHome = new Image();
        //    imgHome.WidthRequest =  tabimgwidth;
        //    imgHome.HeightRequest =  tabimgheight;
        //    imgHome.VerticalOptions = LayoutOptions.Center;
        //    imgHome.HorizontalOptions = LayoutOptions.Center;
        //    imgHome.Source = "hometab.png";

        //    Label lblHome = new Label();
        //    lblHome.Text = "Home";
        //    lblHome.TextColor = Color.Black;
        //    lblHome.HorizontalOptions = LayoutOptions.Center;
        //    lblHome.VerticalOptions = LayoutOptions.Center;
        //    lblHome.VerticalTextAlignment = TextAlignment.Center;
        //    lblHome.HorizontalTextAlignment = TextAlignment.Center;
        //    lblHome.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));

        //    st_tabhome = new StackLayout();
        //    st_tabhome.BackgroundColor =  tabselcolor;
        //    st_tabhome.Padding = new Thickness(5, 5, 5, 0);
        //    st_tabhome.Spacing =  tabstackspacing;
        //    st_tabhome.Children.Add(imgHome);
        //    st_tabhome.Children.Add(lblHome);

        //    TapGestureRecognizer tap_home = new TapGestureRecognizer();
        //    tap_home.Tapped += Tap_home_Tapped;
        //    st_tabhome.GestureRecognizers.Add(tap_home);

        //    //-------------------------Diary-------------------------
        //    Image imgDiary = new Image();
        //    imgDiary.WidthRequest =  tabimgwidth;
        //    imgDiary.HeightRequest =  tabimgheight;
        //    imgDiary.VerticalOptions = LayoutOptions.Center;
        //    imgDiary.HorizontalOptions = LayoutOptions.Center;
        //    imgDiary.Source = "diarytab.png";

        //    Label lblDiary = new Label();
        //    lblDiary.Text = "Diary";
        //    lblDiary.TextColor = Color.Black;
        //    lblDiary.HorizontalOptions = LayoutOptions.Center;
        //    lblDiary.VerticalOptions = LayoutOptions.Center;
        //    lblDiary.VerticalTextAlignment = TextAlignment.Center;
        //    lblDiary.HorizontalTextAlignment = TextAlignment.Center;
        //    lblDiary.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));

        //    st_tabdiary = new StackLayout();
        //    st_tabdiary.BackgroundColor =  tabdefcolor;
        //    st_tabdiary.Padding = new Thickness(5, 5, 5, 0);
        //    st_tabdiary.Spacing =  tabstackspacing;
        //    st_tabdiary.Children.Add(imgDiary);
        //    st_tabdiary.Children.Add(lblDiary);

        //    TapGestureRecognizer tap_diary = new TapGestureRecognizer();
        //    tap_diary.Tapped += Tap_diary_Tapped; ;
        //    st_tabdiary.GestureRecognizers.Add(tap_diary);

        //    //-------------------------History-------------------------
        //    Image imgHistory = new Image();
        //    imgHistory.WidthRequest =  tabimgwidth;
        //    imgHistory.HeightRequest =  tabimgheight;
        //    imgHistory.VerticalOptions = LayoutOptions.Center;
        //    imgHistory.HorizontalOptions = LayoutOptions.Center;
        //    imgHistory.Source = "historytab.png";

        //    Label lblHistory = new Label();
        //    lblHistory.Text = "History";
        //    lblHistory.TextColor = Color.Black;
        //    lblHistory.HorizontalOptions = LayoutOptions.Center;
        //    lblHistory.VerticalOptions = LayoutOptions.Center;
        //    lblHistory.VerticalTextAlignment = TextAlignment.Center;
        //    lblHistory.HorizontalTextAlignment = TextAlignment.Center;
        //    lblHistory.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));

        //    st_tabhistory = new StackLayout();
        //    st_tabhistory.BackgroundColor =  tabdefcolor;
        //    st_tabhistory.Padding = new Thickness(5, 5, 5, 0);
        //    st_tabhistory.Spacing =  tabstackspacing;
        //    st_tabhistory.Children.Add(imgHistory);
        //    st_tabhistory.Children.Add(lblHistory);

        //    TapGestureRecognizer tap_history = new TapGestureRecognizer();
        //    tap_history.Tapped += Tap_history_Tapped; ; ;
        //    st_tabhistory.GestureRecognizers.Add(tap_history);
        //    //--------------------------------------------------

        //    grid_tabs.Children.Add(st_tabhome, 0, 0);
        //    grid_tabs.Children.Add(st_tabdiary, 1, 0);
        //    grid_tabs.Children.Add(st_tabhistory, 2, 0);
        //}

        //private static void Tap_history_Tapped(object sender, EventArgs e)
        //{
        //    TabHome.BackgroundColor =  tabdefcolor;
        //    TabDiary.BackgroundColor =  tabdefcolor;
        //    TabHistory.BackgroundColor =  tabselcolor;
        //    myMasterPage.Detail = new NavigationPage(HistoryPage);
        //}

        //private static void Tap_diary_Tapped(object sender, EventArgs e)
        //{
        //    TabHome.BackgroundColor =  tabdefcolor;
        //    TabDiary.BackgroundColor =  tabselcolor;
        //    TabHistory.BackgroundColor =  tabdefcolor;
        //    myMasterPage.Detail = new NavigationPage(DiaryPage);
        //}

        //private static void Tap_home_Tapped(object sender, EventArgs e)
        //{
        //    TabHome.BackgroundColor =  tabselcolor;
        //    TabDiary.BackgroundColor =  tabdefcolor;
        //    TabHistory.BackgroundColor =  tabdefcolor;
        //    myMasterPage.Detail = new NavigationPage(HomePage);
        //}

        //#endregion
    }
}
