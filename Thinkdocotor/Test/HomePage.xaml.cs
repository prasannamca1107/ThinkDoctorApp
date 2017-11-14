using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Thinkdocotor.Test
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.iOS)
            {


                if (App.ScreenWidth == 320 && App.ScreenHight == 568)
                {
                    BackgroundImage = "BG/Bg320x568.png";
                }
                else if (App.ScreenWidth == 375 && App.ScreenHight == 667)
                {
                    BackgroundImage = "BG/Bg375x667.png";
                }
                else if (App.ScreenWidth == 414 && App.ScreenHight == 736)
                {
                    BackgroundImage = "BG/Bg414x736.png";
                }
                else if (App.ScreenWidth == 768 && App.ScreenHight == 1024)
                {
                    BackgroundImage = "BG/Bg768x1024.png";
                }
                else if (App.ScreenWidth == 1536 && App.ScreenHight == 2048)
                {
                    BackgroundImage = "BG/Bg1536x2048.png";
                }
                else
                {
                    BackgroundImage = "Bg.png";
                }
            }
            else
            {
                BackgroundImage = "Bg.png";
            }

        }
    }
}
