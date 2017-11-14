using System;
using Thinkdocotor;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class maintabbedpage : TabbedPage
	{
		consulting_venues cv;
		public maintabbedpage(consulting_venues consultingvenue)
		{
			cv = consultingvenue;
            NavigationPage.SetHasBackButton(this, false);
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
			Title = "Document Upload";
			var Consulting_Files = new  Consulting_Files(cv);
			Consulting_Files.Icon = "file.png";
			Consulting_Files.Title = "Files";
			var Consulting_Upload = new Consulting_Upload(cv);
			Consulting_Upload.Icon = "upload.png";
			Consulting_Upload.Title = "Upload";
			//var Consulting_Share =new Consulting_Share(cv);
			//Consulting_Share.Icon = "share.png";
			//Consulting_Share.Title = "Share";
		

   		 	Children.Add (Consulting_Files);
			Children.Add (Consulting_Upload);

            this.CurrentPageChanged +=(sender, e) => 
            {
                
            };
			//Children.Add (Consulting_Share);
    		
		}
	}
}

