using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Forms;
using System.Net.Http;
using Thinkdocotor.Models;
using ThinkDoctor;

namespace Thinkdocotor
{
	public class LoginViewModel : BaseViewModel
	{
		private readonly IMessageService _messageService;
		private readonly INavigationService _navigationService;

        private string UsersLoginUrl = "http://178.238.139.243/MedicalPracticeApi/api/LoginApi/";

        public LoginViewModel()
		{
            this._messageService = DependencyService.Get<IMessageService>();
			this._navigationService = DependencyService.Get<INavigationService>();
		}

		string _password;

		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				if (_password != value)
				{
					_password = value;
					onPropertyChanged(this);
				}
			}
		}

		string _username;

		public string Username
		{
			get
			{
				return _username;
			}
			set
			{
				if (_username != value)
				{
					_username = value;
					onPropertyChanged(this);
				}
			}
		}

		ICommand _doLogin;
		public ICommand DoLogin
		{
			get
			{
				_doLogin = _doLogin ?? new Command(async () => await Login());
				return _doLogin;
			}
		}

		ICommand _doForgotPassword;
		public ICommand DoForgotPassword
		{
			get
			{
				_doForgotPassword = _doForgotPassword ?? new Command(async () => await ForgotPassword());
				return _doForgotPassword;
			}
		}

        ICommand _register;
        public ICommand DoRegister
        {
            get
            {
                    _register = _register ?? new Command(async () => await ShowRegister());
                return _register;
            }
        }

        protected async Task ShowRegister()
        {
            var isConnected = CrossConnectivity.Current.IsConnected;
            if (isConnected == false)
            {
                await _navigationService.PushPopupCheckConnection();
                return;
            }
            await this._navigationService.PushRegisterPage();
        }

		protected async Task Login()
		{
			var isConnected = CrossConnectivity.Current.IsConnected;
			if (isConnected == false)
			{
				//ChkCon consentPage = new ChkCon();
				//await Navigation.PushPopupAsync(consentPage);
				//await consentPage.PageClosedTask;
				await this._messageService.ShowAsync("Network Error", "Error communicating with the server.\nPlease check your internet connection.");
				return;
			}
			if (string.IsNullOrEmpty(this.Username))
			{
              //  MessagingCenter.Unsubscribe<NavigationMessage>(this, eNavigationMessage.ShowTargetView.ToString());
                MessagingCenter.Send<NavigationMessage>(new NavigationMessage() { ViewName="Username", Parameter = Username }, eNavigationMessage.ShowTargetView.ToString());
				
				return;
			}
			else if (string.IsNullOrEmpty(this.Password))
			{
                //MessagingCenter.Unsubscribe<NavigationMessage>(this, eNavigationMessage.ShowTargetView.ToString());
                MessagingCenter.Send<NavigationMessage>(new NavigationMessage() { ViewName="Password", Parameter = Password }, eNavigationMessage.ShowTargetView.ToString());
                return;
			}

			var usname_obj = this.Username;
			var passw_obj = this.Password;

			await this._navigationService.PushPopupPleaseWait();

			var httpclient = new HttpClient();
			var json = await httpclient.GetStringAsync(UsersLoginUrl + usname_obj + "/" + passw_obj);
			loginResponse response = JsonConvert.DeserializeObject<loginResponse>(json);
		
			if (response.Status.ToString() == "success")
			{
				await this._navigationService.PopAllPopupAsync();
				
                //Application.Current.MainPage = (new ThinkDoctorMP.Menu.UserMasterDetailPage());
                try
                {
                    bool rc = (bool)response.user.registration_complete;
                    Config.user_Id = Convert.ToInt32(response.user.id);
                    _navigationService.PushRootPage(rc);
                }
                catch(Exception ex)
                {
                    await _messageService.ShowAsync("Error", ex.ToString());
                }
				return;
			}
			else if (response.Status == "Fail")
			{
				Responseerror reson = JsonConvert.DeserializeObject<Responseerror>(json);
				if (reson.Message == "user_not_exits")
				{
					await this._navigationService.PopAllPopupAsync();
					await this._messageService.ShowAsync("Alert!", "User does not exists");
					return;
				}
				if (reson.Message == "wrong_password")
				{
					await this._navigationService.PopAllPopupAsync();
					await this._messageService.ShowAsync("Alert!", "Incorrect Password");
					return;
				}
				if (reson.Message == "email_not_confirm")
				{
					await this._navigationService.PopAllPopupAsync();
					await this._messageService.ShowAsync("Alert!", "Account not activated");
					return;
				}
                if (reson.Message == "user_inactive")
                {
                    await this._navigationService.PopAllPopupAsync();
                    await this._messageService.ShowAsync("Alert!", "Account not active. Contact Administrator!");
                    return;
                }
            }

			//await LoadingLoginNoCancel("Logging you in ...");
			//App.IsLoggedIn = true;
			//((App)App.Current).PresentMainPage();
		}

		protected async Task ForgotPassword()
		{
			if (String.IsNullOrEmpty(Username))
			{
				//await PromptCommand(InputType.Email);
			}
			else
			{
				//await LoadingLoginNoCancel("Requested password reset for " + Username, 3000);
			}
		}
	}
}
