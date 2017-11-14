using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Thinkdocotor.Models;
using Newtonsoft.Json;
using Thinkdocotor.Models.TableClass;

namespace Thinkdocotor.ViewModels
{
    public class SignupViewModel : BaseViewModel
    {
        private string UsersRegisterUrl = "http://178.238.139.243/MedicalPracticeApi/api/RegistrationApi";
        

        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;

        Dictionary<string, int> countriesDic;

        public SignupViewModel()
        {
            this._messageService = DependencyService.Get<IMessageService>();
            this._navigationService = DependencyService.Get<INavigationService>();
        }

        #region properties
        string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(_name != value)
                {
                    _name = value;
                    onPropertyChanged(this);
                    validateDetails();
                }
            }
        }

        string _Mname;
        public string MName
        {
            get
            {
                return _Mname;
            }
            set
            {
                if (_Mname != value)
                {
                    _Mname = value;
                    onPropertyChanged(this);
                    validateDetails();
                }
            }
        }

        string _Lname;
        public string LName
        {
            get
            {
                return _Lname;
            }
            set
            {
                if (_Lname != value)
                {
                    _Lname = value;
                    onPropertyChanged(this);
                    validateDetails();
                }
            }
        }

        //string _hospitalName;
        //public string HospitalName
        //{
        //    get
        //    {
        //        return _hospitalName;
        //    }
        //    set
        //    {
        //        if(_hospitalName != value)
        //        {
        //            _hospitalName = value;
        //            onPropertyChanged(this);
        //            validateDetails();
        //        }
        //    }
        //}

        string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if(_email != value)
                {
                    _email = value;
                    onPropertyChanged(this);
                    validateDetails();
                }
            }
        }

        string _phoneNo;
        public string PhoneNo
        {
            get
            {
                return _phoneNo;
            }
            set
            {
                if(_phoneNo != value)
                {
                    _phoneNo = value;
                    onPropertyChanged(this);
                    validateDetails();
                }
            }
        }

        int _countrySelectedIndex;
        public int CountrySelectedIndex
        {
            get
            {
                return _countrySelectedIndex;
            }
            set
            {
                if (_countrySelectedIndex != value)
                {
                    _countrySelectedIndex = value;
                    onPropertyChanged(this);
                    //validateDetails();
                    setCountryCode(value);
                }
            }
        }

        //string _pass;
        //public string Pass
        //{
        //    get
        //    {
        //        return _pass;
        //    }
        //    set
        //    {
        //        if(_pass != value)
        //        {
        //            _pass = value;
        //            onPropertyChanged(this);
        //        }
        //    }
        //}

        //string _passC;
        //public string PassC
        //{
        //    get
        //    {
        //        return _passC;
        //    }
        //    set
        //    {
        //        if (_passC != value)
        //        {
        //            _passC = value;
        //            onPropertyChanged(this);
        //        }
        //    }
        //}

        List<string> countriesItemSource;
        public List<string> CountriesItemSource
        {
            get
            {
                return countriesItemSource;
            }
            set
            {
                countriesItemSource = value;
                onPropertyChanged(this);
            }
        }

        string countriesSelectedItem;
        public string CountriesSelectedItem
        {
            get
            {
                return countriesSelectedItem;
            }
            set
            {

                if (countriesSelectedItem != value)
                {
                    countriesSelectedItem = value;
                    onPropertyChanged(this);
                }
            }
        }

        bool _acceptTerms = false;
        public bool AccepTerms
        {
            get
            {
                return _acceptTerms;
            }
            set
            {
                if(_acceptTerms != value)
                {
                    _acceptTerms = value;
                    onPropertyChanged(this);
                    validateDetails();
                }
            }
        }

        bool _isAllDetailsValid = false;
        public bool IsAllDetailsValid
        {
            get
            {
                return _isAllDetailsValid;
            }
            set
            {
                _isAllDetailsValid = value;
                onPropertyChanged(this);
                doRegister.ChangeCanExecute();
            }
        }
        #endregion

        #region Commands
        Command _showTerms;
        public Command showTerms
        {
            get
            {
                _showTerms = _showTerms ?? new Command(async () => await ShowTerms());
                return _showTerms;
            }
        }

        Command _register;
        public Command doRegister
        {
            get
            {
                _register = _register ?? new Command(async () => await Register(), () => IsAllDetailsValid);
                return _register;
            }
        }

        protected void setCountryCode(int pos)
        {
            //int pos = CountrySelectedIndex;
            //string cc = "";
            //bool res = countriesDic.TryGetValue(CountriesItemSource[pos], out cc);
            //if(res)
            //{
            //    this.CountriesSelectedItem = cc;
            //}
            //else
            //{
            //    await _messageService.ShowAsync("Alert!", "Error fetching Country code.");
            //}
            this.CountriesSelectedItem = CountriesItemSource[pos];
        }

        protected async Task ShowTerms()
        {
            await _navigationService.PushTermsConditionsPage();
        }

        protected async Task Register()
        {
            try
            {
                //if (string.IsNullOrEmpty(Name) || 
                //    string.IsNullOrEmpty(HospitalName) || 
                //    string.IsNullOrEmpty(Email) ||
                //    string.IsNullOrEmpty(PhoneNo)
                //{
                //    await _messageService.ShowAsync("Alert!", "Please fill all the details Correctly.");
                //    return;
                //}

                if(!IsValidEmail(Email))
                {
                    await _messageService.ShowAsync("Alert!", "Email id not valid.");
                    return;
                }

                //if(Pass != PassC)
                //{
                //    await _messageService.ShowAsync("Alert!", "Passwords did not match.");
                //    return;
                //}

                var isConnected = CrossConnectivity.Current.IsConnected;
                if (isConnected == false)
                {
                    await _navigationService.PushPopupCheckConnection();
                    return;
                }
                await addMP();
                
            }
            catch (Exception ex)
            {
                await _messageService.ShowAsync("Failed", "Following Error Occurred : " + ex.ToString());
            }
        }
        #endregion

        #region functions

        //private Timer _tmrDelaySearch;
        //private const int DelayedTextChangedTimeout = 750;

        //private void textBox_TextUpdate(object sender, EventArgs e)
        //{
        //    //raiseControlDataUpdatedEvent();

        //    if (_tmrDelaySearch != null)
        //        _tmrDelaySearch.Stop();

        //    if (_tmrDelaySearch == null)
        //    {
        //        _tmrDelaySearch = new Timer();
        //        _tmrDelaySearch.Tick += _tmrDelaySearch_Tick;
        //        _tmrDelaySearch.Interval = DelayedTextChangedTimeout;
        //    }

        //    _tmrDelaySearch.Start();
        //}

        //private void _tmrDelaySearch_Tick(object sender, EventArgs e)
        //{
        //    if (_tmrDelaySearch != null)
        //        _tmrDelaySearch.Stop();
        //}

        //async void getuserexits(object s, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(wemail.Text))
        //    {
        //        var validemail = IsValidEmail(wemail.Text);
        //        if (!validemail)
        //        {
        //            DisplayAlert("", "Email id invalid", "Ok");
        //            return;
        //        }
        //        await Navigation.PushPopupAsync(new popup_pleasewait());
        //        var httpclient = new HttpClient();
        //        var json = await httpclient.GetStringAsync("http://178.238.139.243/ThinkdocotorApi/api/DoctorRegsApi/" + wemail.Text + "/");
        //        var response = JsonConvert.DeserializeObject(json);
        //        if (response.ToString() == "pass")
        //        {
        //            await Navigation.PopAllPopupAsync();
        //            DisplayAlert("", "Email id allready used", "Ok");
        //            return;
        //        }
        //        else
        //        {
        //            await Navigation.PopAllPopupAsync();
        //        }
        //    }
        //}

        public async Task getCountriesList()
        {
            try
            {
                ////HttpClient httpclient = new HttpClient();
                ////string cc_string = await httpclient.GetStringAsync(countryCodesUrl);
                ////List<CountryCodes> ccl = JsonConvert.DeserializeObject<List<CountryCodes>>(cc_string);

                ////var toDict = ccl.Select(p => ).ToDictionary(x => x.countryName, x => x.countryCode);
                //countriesDic = ccl.ToDictionary(x => x.CountryName, x => x.CountryCode);
                //CountriesItemSource = countriesDic.Keys.ToList();

                var result = await AppStyles.countries_list();
                //countriesDic = result.ToDictionary(x => x.CountryName, x => x.CountryCode);
                countriesDic = result.ToDictionary(x => x.CountryName, x => x.CountryId);
                CountriesItemSource = countriesDic.Keys.ToList();
            }
            catch (Exception ex)
            {
                await _messageService.ShowAsync("Alert!", "Error retrieving countries list.");
                return;
            }
        }

        bool IsValidEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        void validateDetails()
        {
            if (!string.IsNullOrEmpty(Name) &&
                !string.IsNullOrEmpty(LName) &&
                //!string.IsNullOrEmpty(HospitalName) &&
                !string.IsNullOrEmpty(Email) &&
                !string.IsNullOrEmpty(PhoneNo) &&
                AccepTerms)
            {
                IsAllDetailsValid = true;
            }
            else
            {
                IsAllDetailsValid = false;
            }
        }

        public async Task addMP()
        {

            //var doctors = new User_Registration
            //{
            //    FirstName = this.Name,
            //    MiddleName = this.MName,
            //    LastName = this.LName,
            //    HospitalName = this.HospitalName,
            //    EmailID1 = this.Email,
            //    MobileNo = this.PhoneNo,
            //    category_id = 2,
            //    Deviceid = devid
            //};
            int countryId;
            countriesDic.TryGetValue(this.CountriesSelectedItem, out countryId);

            users userMP = new users
            {
                user_type_id = 1
            };
            user_personal_details userMP_personal_details = new user_personal_details
            {
                firstname = this.Name,
                middlename = this.MName,
                lastname = this.LName,
                email1 = this.Email,
                tel1 = this.PhoneNo,
                CountryCodes_id = countryId,

            };

            Registration reg = new Registration
            {
                users = userMP,
                user_personal_details = userMP_personal_details
            };

            try
            {
                await _navigationService.PushPopupPleaseWait();

                var json = JsonConvert.SerializeObject(reg);
                HttpContent httpcontent = new StringContent(json);
                httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var httpclient = new HttpClient();
                var result = await httpclient.PostAsync(UsersRegisterUrl, httpcontent);
                await _navigationService.PopAllPopupAsync();

                this.Name = "";
                this.MName = "";
                this.LName = "";
               // this.HospitalName = "";
                this.Email = "";
                this.PhoneNo = "";
                this.AccepTerms = false;
                if (result.IsSuccessStatusCode)
                {
                    await _messageService.ShowAsync("Alert!", "User id and password sent to your mail id.");
                    await _navigationService.PopCurrentPage();
                }
                else
                {
                    await _messageService.ShowAsync("", "Error"+result.RequestMessage);
                }
            }
            catch (Exception ex)
            {
                await _navigationService.PopAllPopupAsync();
                await _messageService.ShowAsync("Alert!", "Registration failed try again.");
                return;
            }
        }
        #endregion
    }
}
