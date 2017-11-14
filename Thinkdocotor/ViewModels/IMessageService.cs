using System;
using System.Threading.Tasks;

namespace Thinkdocotor
{
	public interface IMessageService
	{
		Task ShowAsync(string title, string msg);
	}
}
