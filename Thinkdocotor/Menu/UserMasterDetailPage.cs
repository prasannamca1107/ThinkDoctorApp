using System;
using ThinkDoctor;
using Xamarin.Forms;
using System.Threading.Tasks;
using Thinkdocotor.Test;

namespace ThinkDoctor.Menu
{
	public class UserMasterDetailPage : MasterDetailPage
	{
		UserMenu masterPage;
        public NavigationPage myNavPage;

        //UserOptions.Home.Home _homePage;
        //UserOptions.Diary.Diary _diaryPage;
        //UserOptions.History.History _historyPage;
        //UserOptions.Search.SearchPage _searchPage;
        //UserOptions.Settings.SettingsPage _settingsPage;
        //UserOptions.Home.AccountsPage _accountsPage;
        //BottomBar.BottomBarPage myTabBar;

        MainPage _detailPage;
        ThinkDoctor.Menu.Home1 _homeContent;
        // ThinkDoctor.Menu.Diary1 _diaryContent;
        // ThinkDoctor.Menu.History1 _historyContent;

        public UserMasterDetailPage()
		{
            //MPConsts.CreateTabs();

            //_homePage = new UserOptions.Home.Home();
            //_diaryPage = new UserOptions.Diary.Diary();
            //_historyPage = new UserOptions.History.History();
            //_searchPage = new UserOptions.Search.SearchPage();
            //_settingsPage = new UserOptions.Settings.SettingsPage();
            //_accountsPage = new UserOptions.Home.AccountsPage();

            //myTabBar = new BottomTabs().getInstance;

            //MPConsts.myMasterPage = this;
            //MPConsts.HomePage = _homePage;
            //MPConsts.DiaryPage = _diaryPage;
            //MPConsts.HistoryPage = _historyPage;
            //MPConsts.mySearchPage = _searchPage;
            //MPConsts.mySettingsPage = _settingsPage;
            //MPConsts.myAccountsPage = _accountsPage;
            //MPConsts.myBottomBarPage = myTabBar;

            //masterPage = new UserMenu();
            //myNavPage = new NavigationPage(MPConsts.myBottomBarPage);
            //MPConsts.myNavigationPage = myNavPage;

            _homeContent = new ThinkDoctor.Menu.Home1();
          //  _diaryContent = new ThinkDoctor.Menu.Diary1();
           // _historyContent = new UserOptions.History.History1();

            _detailPage = new MainPage();
            //MPConsts.myUserDetailPage = _detailPage;

            masterPage = new UserMenu();
            myNavPage = new NavigationPage(_detailPage);
            MPConsts.myNavigationPage = myNavPage;

            Master = masterPage;
            Detail = myNavPage;

			TapGestureRecognizer tap_home = new TapGestureRecognizer();
			tap_home.Tapped += Tap_Home_Tapped;
			TapGestureRecognizer tap_Accounts = new TapGestureRecognizer();
            tap_Accounts.Tapped += Tap_Accounts_Tapped; ; ;
			TapGestureRecognizer tap_Search = new TapGestureRecognizer();
            tap_Search.Tapped += Tap_Search_Tapped; ; ;
			TapGestureRecognizer tap_diary = new TapGestureRecognizer();
            tap_diary.Tapped += Tap_diary_Tapped; ;
			TapGestureRecognizer tap_settings = new TapGestureRecognizer();
			tap_settings.Tapped += Tap_Settings_Tapped;
			TapGestureRecognizer tap_logout = new TapGestureRecognizer();
			tap_logout.Tapped += Tap_Logout_Tapped;

			masterPage.optHome.GestureRecognizers.Add(tap_home);
			masterPage.optAccounts.GestureRecognizers.Add(tap_Accounts);
			masterPage.optSearch.GestureRecognizers.Add(tap_Search);
			masterPage.optDiary.GestureRecognizers.Add(tap_diary);
			masterPage.optSettings.GestureRecognizers.Add(tap_settings);
			masterPage.optLogout.GestureRecognizers.Add(tap_logout);

		}

        private void Tap_Search_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;

			//Detail =  new NavigationPage(new Create_slots());
            //MPConsts.myBottomBarPage.CurrentPage = MPConsts.myBottomBarPage.Children[0];
            //myTabBar.CurrentPage = myTabBar.Children[0];
        }

        private void Tap_Accounts_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
			Detail =  new NavigationPage(new ConsultingRoom_details());
        }

        void Tap_Home_Tapped(object sender, EventArgs e)
		{
			IsPresented = false;
            //myNavPage = new NavigationPage(_homePage);
            //Detail = myNavPage;
            MPConsts.myUserDetailPage.showHome();
        }

        private void Tap_diary_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            //myNavPage.Navigation.InsertPageBefore(DiaryPage, myNavPage.Navigation.NavigationStack[0]);
            //myNavPage.Navigation.PopAsync();
            //Detail = myNavPage;
            //myNavPage = new NavigationPage(_diaryPage);
            //Detail = myNavPage;
            MPConsts.myUserDetailPage.showDiary();
        }

        void Tap_Settings_Tapped(object sender, EventArgs e)
		{
			IsPresented = false;
			//Detail =  new NavigationPage(new setting());
		}

		async void Tap_Logout_Tapped(object sender, EventArgs e)
		{
			IsPresented = false;
			var x = await DisplayAlert("Logout", "Are you sure?", "Yes", "No");
            if (x)
            {
               	Application.Current.MainPage = (new NavigationPage(new LoginPage()));
            }
		}

        protected override bool OnBackButtonPressed()
        {
            if (myNavPage.Navigation.NavigationStack.Count == 1)
            {
                Device.BeginInvokeOnMainThread(async () => {
                    var result = await this.DisplayAlert("Logout!", "Do you really want to exit?", "Yes", "No");
                    if (result)
                    {
                     //   App.Current.MainPage = new Login.LoginPage();
                    }
                });

                return true;
            }

            return base.OnBackButtonPressed();
        }

    }
}

