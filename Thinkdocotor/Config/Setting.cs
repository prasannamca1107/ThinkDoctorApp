using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ThinkDoctor
{
	public static class Setting
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}

		}
		#region Setting Constants

		private const string UsernameKey = "Username_key";
		private static readonly string UsernameDefault = string.Empty;

		private const string PaswKey = "Pasw_key";
		private static readonly string PaswDefault = string.Empty;


		private const string RemberunameKey = "remberuname_key";
		private static readonly string RemberunameDefault = string.Empty;

        private const string RemberpaswKey = "remberpasw_key";
        private static readonly string RemberpaswDefault = string.Empty;

        private const string TermsKey = "Terms_key";
        private static readonly string TermsDefault = string.Empty;

		#endregion


		public static string UsernameSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(UsernameKey, UsernameDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(UsernameKey, value);
			}
		}
		public static string PaswSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(PaswKey, PaswDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(PaswKey, value);
			}
		}
        public static string RemberunameSetting
        {
	        get
	        {
		        return AppSettings.GetValueOrDefault(RemberunameKey, RemberunameDefault);
	        }
	        set
	        {
		        AppSettings.AddOrUpdateValue(RemberunameKey, value);
	        }
		}
        public static string RemberpaswSetting
        {
	        get
	        {
		        return AppSettings.GetValueOrDefault(RemberpaswKey, RemberpaswDefault);
	        }
	        set
	        {
		        AppSettings.AddOrUpdateValue(RemberpaswKey, value);
	        }
		}

        public static string termsSetting
        {
	        get
	        {
		        return AppSettings.GetValueOrDefault(TermsKey, TermsDefault);
	        }
	        set
	        {
		        AppSettings.AddOrUpdateValue(TermsKey, value);
	        }
		}
	}
}
