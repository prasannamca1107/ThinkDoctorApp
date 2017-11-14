using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Thinkdocotor.Pages;
using Thinkdocotor.Pages.Users;
using ThinkDoctor;
using ThinkDoctor.Menu;

namespace Thinkdocotor
{
	public class NavigationService : INavigationService
	{
		public NavigationService()
		{
		}

        public async Task PopCurrentPage()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        #region Popup
        public async Task PopAllPopupAsync()
		{
			await App.Current.MainPage.Navigation.PopAllPopupAsync();
		}

        public async Task PushPopupCheckConnection()
        {
            ChkCon check_connection = new ChkCon();
            await App.Current.MainPage.Navigation.PushPopupAsync(check_connection);
            await check_connection.PageClosedTask;
        }

        public async Task PushPopupPleaseWait()
		{
			await App.Current.MainPage.Navigation.PushPopupAsync(new popup_pleasewait());
		}
        #endregion

        #region Login
        public async Task PushRegisterPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SignupPage());
        }

        public void PushRootPage(bool rc)
        {
            if(rc)
            {
                App.Current.MainPage = new UserMasterDetailPage();
            }
            else
            {
                App.Current.MainPage = new SettingPage();
            }
        }
        #endregion

        #region Signup
        public async Task PushTermsConditionsPage()
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new terms());
        }
        #endregion

        #region Register
        public async Task PushPersonalDetailsPage()
        {
           // await App.Current.MainPage.Navigation.PushAsync(new PersonalDetailsPage());
        }
        #endregion
    }
}
