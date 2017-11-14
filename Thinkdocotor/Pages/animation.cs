using System;
using ThinkDoctor;
using Xamarin.Forms;

namespace Thinkdocotor.Pages
{
    public class animation : ContentPage
    {
        public animation()
        {
            IconView  succ = new IconView
            {
                Source = "succ.png",
                HeightRequest = 100,
                WidthRequest = 100,
                BackgroundColor = Color.Transparent,
                Foreground = Color.FromHex(Config.iconcolor)
            };

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,

                Children = {

                    succ
                }
            };
        }
    }
}

