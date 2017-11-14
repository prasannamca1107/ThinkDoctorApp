using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Thinkdocotor.ViewModels
{
    public class SettingPageViewModels: BaseViewModel
    {
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        public SettingPageViewModels()
        {
            this._messageService = DependencyService.Get<IMessageService>();
            this._navigationService = DependencyService.Get<INavigationService>();
        }
       
        string _profile_img;

        public string Profile_img
        {
            get
            {
                return _profile_img;
            }
            set
            {
                if (_profile_img != value)
                {
                    _profile_img = value;
                    onPropertyChanged(this);

                }
            }
        }

       
        public async Task loadsettingPage()
        {
            try
            {
                await _navigationService.PushPopupPleaseWait();
                var httpclient = new HttpClient();
                var json = await httpclient.GetStringAsync("http://178.238.139.243/ThinkdocotorApi/api/Settingpagedetails?userid=" + Config.user_Id);
                Userdetails R = JsonConvert.DeserializeObject<Userdetails>(json);
            }
            catch (Exception ex)
            {
                await _navigationService.PopAllPopupAsync();
                return;
            }
        }
    }
}
