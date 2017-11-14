using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using Messier16.Forms.iOS.Controls;
using UIKit;

namespace Thinkdocotor.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private UIWindow appWindow;
        private static AppDelegate myClass;
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            Messier16Controls.InitAll();
            App.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
            App.ScreenHight = (int)UIScreen.MainScreen.Bounds.Height;
            App.deviceid = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();


            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
        public AppDelegate()
        {
            Instance = this;
            //AppWindow = Instance.Window;
        }

        public static UIWindow AppWindow
        {
            get
            {
                return UIApplication.SharedApplication.KeyWindow;
            }
        }
        public static AppDelegate Instance
        {
            get
            {
                return myClass;
            }
            set
            {
                myClass = value;
            }
        }
        public void ShowSubviewAt(CGRect rect, UIView cover, UIView subView, Action didFinishAnimation)
        {
            //UIView cover = new UIView();
            cover.Frame = new CGRect(0, 0, AppWindow.Bounds.Width, AppWindow.Bounds.Height);
            ////cover.Frame = new CGRect(0, 0, 200, 200);
            ////cover.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            ////cover.Opaque = true;
            //cover.BackgroundColor = UIColor.Yellow;
            cover.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                if (subView != null)
                    cover.RemoveFromSuperview();

                if (subView != null)
                    subView.RemoveFromSuperview();

            }));
            AppWindow.AddSubview(cover);
            subView.Frame = new CGRect(rect.X, rect.Y, rect.Width, 250);
            AppWindow.AddSubview(subView);
            //subView.Frame = new CGRect(rect.X, rect.Y, rect.Width, 0);
            //UIView.Animate(0.2, () =>
            //{
            //    subView.Frame = new CGRect(rect.X, rect.Y, rect.Width, rect.Height);
            //    AppWindow.AddSubview(subView);
            //}, didFinishAnimation);
        }

        public void removeDropDownViewCover()
        {
            foreach (UIView v in AppWindow.Subviews)
            {
                if (v.AccessibilityIdentifier.Equals("DDCoverView"))
                {
                    v.RemoveFromSuperview();
                    break;
                }
            }
        }

    }
}
