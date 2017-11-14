using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

//using UIKit;
using Xamarin.Forms;
using Messier16.Forms.Controls;
using System.Text.RegularExpressions;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using System.Net.Http;
using Newtonsoft.Json;
using Thinkdocotor;

namespace ThinkDoctor
{
    public class forgetpasw : ContentPage
    {
		Label cap, capdetail;
		MyEntry email;
        Button  forgetbtn;
        string uri;
	    public forgetpasw()
        {
            
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
			//	BackgroundColor = Color.White;
				BackgroundImage = "Bg.png";
			}
                  


			cap = new Label
			{
				Text = "Forgot your password?",
				TextColor = Color.White ,
				FontSize=25,
				FontAttributes=FontAttributes.Bold,
                HorizontalOptions=LayoutOptions.Center,
                VerticalOptions=LayoutOptions.Center ,
               

            };
			capdetail = new Label
			{
				Text = "Enter your email below to receive your Otp for reset the password",
				TextColor = Color.Gray,
				FontSize = 15,
				HorizontalTextAlignment = TextAlignment.Center,
				FontAttributes=FontAttributes.Bold,
                HorizontalOptions=LayoutOptions.Center,
                VerticalOptions=LayoutOptions.Center ,
               

            };
		StackLayout stkheading = new StackLayout();
		stkheading.Orientation = StackOrientation.Vertical;
		stkheading.HorizontalOptions = LayoutOptions.FillAndExpand;
		stkheading.Children.Add(cap);
		stkheading.Children.Add(capdetail);

          email = new MyEntry
			{
				Placeholder = "Email",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				PlaceholderColor = Color.WhiteSmoke,
				TextColor=Color.White,
				Keyboard = Keyboard.Text,

			};
			email.Unfocused += emailvalidation;
			Image lbluserimg = new Image
			{

				Source = "usericon.png",
				HorizontalOptions = LayoutOptions.Start,


			};


			StackLayout stkFuname = new StackLayout();
			stkFuname.Orientation = StackOrientation.Horizontal;
			stkFuname.HorizontalOptions = LayoutOptions.FillAndExpand;
			stkFuname.Children.Add(lbluserimg);
			stkFuname.Children.Add(email);

			var semiTransparentColor = new Color(0, 0, 0, 0.05);


			CustomFrame Funame = new CustomFrame
		{
			Content = stkFuname,
			HorizontalOptions = LayoutOptions.FillAndExpand,
			Padding = new Thickness(10, 13, 0, 13),
			OutlineColor = Color.White,
			BorderRadius = 20,
			BackgroundColor = semiTransparentColor,
		};


           
            forgetbtn  = new Button
            {
                Text = "Reset Password",
				Margin = new Thickness(20, 0, 20, 0),
                  Style = (Style)Application.Current.Resources["CPButton"],
                FontFamily = Device.OnPlatform("Droid Sans Mono", "Droid Sans Mono", "Droid Sans Mono"),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center ,
            };


			forgetbtn.Clicked += forgetbtn_clicked;
           
           
			BackgroundColor = Color.White ;
          
           StackLayout main = new StackLayout
            {
				HorizontalOptions =LayoutOptions.CenterAndExpand,
				VerticalOptions =LayoutOptions.CenterAndExpand,
				Spacing=25,
				Margin=20,
                Children = {
                    stkheading,Funame,forgetbtn 

                }
            };
			var scroll = new ScrollView();
			scroll.Content = main;
			Content = scroll;
        }

	

async void forgetbtn_clicked(object sender, EventArgs e)
{

	var isConnected = CrossConnectivity.Current.IsConnected;
	if (isConnected == false)
	{
		
		ChkCon consentPage = new ChkCon();
		await Navigation.PushPopupAsync(consentPage);
		await consentPage.PageClosedTask;
		return;
	}
	if (string.IsNullOrEmpty(email.Text))
	{
		DisplayAlert("", "Enter E-mail", "Ok");
		email.Focus();
		return;
	}
	await Navigation.PushPopupAsync(new popup_pleasewait());
	var httpclient = new HttpClient();
	String urlParameters = "?email=" + email.Text + "&forgot=forgot";
	uri = Config.Api + urlParameters;
	var json = await httpclient.GetStringAsync(uri);
	Forgetpasswordresponse response = JsonConvert.DeserializeObject<Forgetpasswordresponse>(json);

			if (response.Status.ToString() == "success")
			{
				await Navigation.PopAllPopupAsync();

				Config.otp = response.otp;
				Config.user_Id = response.userid;
				Config.exptime = response.exptime;
				Config.email = email.Text;
				await Navigation.PushPopupAsync(new OtpPagePopup());
			}
			else if (response.Status == "fail")
			{
				Forgetpassworderror reson = JsonConvert.DeserializeObject<Forgetpassworderror>(json);
				if (reson.Message == "user_not_exits")
				{
					await Navigation.PopAllPopupAsync();
					await DisplayAlert("", "Email not exits", "Ok");
					return;
				}
				else if (reson.Message == "error")
				{
					await Navigation.PopAllPopupAsync();

					await DisplayAlert("", "Otp not generating", "Ok");

					return;
				}
			}

		}
	void emailvalidation(object sender, FocusEventArgs e)
	{
	if (!string.IsNullOrEmpty(email.Text))
	{
		var validemail = IsValidEmail(email.Text);
		if (!validemail)
		{
			DisplayAlert("", "Email id invalid", "Ok");
			return;
		}
	}
}

bool IsValidEmail(string strIn)
{

	return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
}
       
    }
}
