using System;
namespace Thinkdocotor.Models
{
    public class Messagecenter
    {
        
    }
    public class NavigationMessage
    {
        public string ViewName{ get; set; }
        public string Parameter { get; set; }

    }
    public enum eNavigationMessage

    {

        ShowTargetView

    }
}
