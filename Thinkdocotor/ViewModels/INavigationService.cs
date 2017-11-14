using System;
using System.Threading.Tasks;

namespace Thinkdocotor
{
	public interface INavigationService
	{
        Task PopCurrentPage();

        Task PopAllPopupAsync();
		Task PushPopupPleaseWait();
        Task PushPopupCheckConnection();

        //signup Page
        Task PushTermsConditionsPage();

        //Login Page
        Task PushRegisterPage();
        void PushRootPage(bool rc);

        //Registration Pages
        Task PushPersonalDetailsPage();
    }
}
