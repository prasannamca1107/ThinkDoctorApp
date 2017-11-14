using System;
using Thinkdocotor.Pages;
using Thinkdocotor.Pages.Users;
using Thinkdocotor.Test;
using ThinkDoctor;
using Xamarin.Forms;

namespace Thinkdocotor
{
    public class App : Application
    {
        static public int ScreenWidth;
        static public int ScreenHight;
        static public string deviceid;
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        public App()
        {
            
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();

            Resources = AppStyles.test();

            this._messageService = DependencyService.Get<IMessageService>();
            this._navigationService = DependencyService.Get<INavigationService>();

            var consulting_venues = new consulting_venues
            {
                id = 12

            };
            MainPage = new NavigationPage(new SettingPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
