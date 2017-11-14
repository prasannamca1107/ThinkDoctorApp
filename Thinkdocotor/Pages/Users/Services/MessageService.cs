using System;
using System.Threading.Tasks;

namespace Thinkdocotor
{
	public class MessageService : IMessageService
	{
		public MessageService()
		{
		}

		public async Task ShowAsync(string title, string msg)
		{
			await App.Current.MainPage.DisplayAlert(title, msg, "ok");
		}
	}
}
