using System;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using Thinkdocotor;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class Consulting_Service_Hours_edit : ContentPage
	{
		Switch open_close,full_hours;

		StackLayout stkopen_close,stkfull_hours,stkmorfull,stkmortime,stkaftnfull,stkaftntime,stkevntime,stkevnfull,stkmaintime;

		TimeSpan morstartspan,morendspan,aftn_startspan,aftn_endspan,evn_startspan, evn_endspan;
		consulting_hours_details s;

		TimePicker mor_start,mor_end,aftn_start,aftn_end,evn_start,evn_end;










		public Consulting_Service_Hours_edit(consulting_hours_details c)
		{
			s = c;
			Title = c.day_name;
			NavigationPage.SetBackButtonTitle(this, " ");
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

			ToolbarItems.Add(new ToolbarItem("Next", Device.OnPlatform("tick.png", "tick.png", null),testclick));

			#region openclose

			Label opencloselbl = new Label
			{
				Text = "Open / Close",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			open_close = new Switch
			{
				IsToggled = c.open_close,
				HorizontalOptions = LayoutOptions.StartAndExpand,

			};
			open_close.Toggled += open_close_Toggled;

			stkopen_close = new StackLayout();
			stkopen_close.Orientation = StackOrientation.Vertical;
			stkopen_close.HorizontalOptions = LayoutOptions.Fill;
			stkopen_close.Children.Add(opencloselbl);
			stkopen_close.Children.Add(open_close);
			stkopen_close.Spacing = 4;

			#endregion openclose

			#region 24/7

			Label full_hourslbl = new Label
			{
				Text = "24/7",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			full_hours = new Switch
			{
				IsToggled=c.work_24_7,
				HorizontalOptions = LayoutOptions.StartAndExpand,

			};
			full_hours.Toggled += full_hours_Toggled;

			stkfull_hours = new StackLayout();
			stkfull_hours.Orientation = StackOrientation.Vertical;
			stkfull_hours.HorizontalOptions = LayoutOptions.Fill;
			stkfull_hours.Children.Add(full_hourslbl);
			stkfull_hours.Children.Add(full_hours);
			stkfull_hours.Spacing = 4;
			stkfull_hours.IsVisible = false;

			#endregion openclose

			#region maintime 
			Label headingtime = new Label
			{
				Text = "Set Opening Hours",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};


			#region mor
			Label morlbl = new Label
			{
				Text =Config.morning+ "Morning",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};
			if (c.morn_start != null)
			{

				DateTime dtmorstart = DateTime.ParseExact(c.morn_start.Trim(), "hh:mm tt", CultureInfo.InvariantCulture);
				morstartspan = dtmorstart.TimeOfDay;
			}
			else
			{
				morstartspan = new TimeSpan(0, 0, 0);
			}
			mor_start = new TimePicker()
			{
				Time = morstartspan,
				Format = Config.clock+ "hh:mm tt",
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand ,
			};
			if (c.morn_end != null)
			{

				DateTime dtmorend = DateTime.ParseExact(c.morn_end.Trim(), "hh:mm tt", CultureInfo.InvariantCulture);
				morendspan = dtmorend.TimeOfDay;
			}
			else
			{
				morendspan = new TimeSpan(0, 0, 0);
			}
			mor_end = new TimePicker()
			{
				Time = morendspan,
				Format = Config.clock + "hh:mm tt",
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			stkmortime = new StackLayout();
			stkmortime.Orientation = StackOrientation.Horizontal;
			stkmortime.HorizontalOptions = LayoutOptions.FillAndExpand;
			stkmortime.Children.Add(mor_start);
			stkmortime.Children.Add(mor_end);
			stkmortime.Spacing = 5;

			stkmorfull = new StackLayout();
			stkmorfull.Orientation = StackOrientation.Vertical;
			stkmorfull.HorizontalOptions = LayoutOptions.Fill;
			stkmorfull.Children.Add(morlbl);
			stkmorfull.Children.Add(stkmortime);
			stkmorfull.Spacing =4;
			#endregion mor


			#region aftn
			Label aftnlbl = new Label
			{
				Text = Config.aftnoon1 + "Afternoon",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};
			if (c.aftn_start != null)
			{
				DateTime dtaftn_start = DateTime.ParseExact(c.aftn_start.Trim(), "hh:mm tt", CultureInfo.InvariantCulture);
				aftn_startspan = dtaftn_start.TimeOfDay;
			}
			else
			{
				aftn_startspan = new TimeSpan(0, 0, 0);
			}
			aftn_start = new TimePicker()
			{
				Time = aftn_startspan,
				Format = Config.clock + "hh:mm tt",
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			if (c.aftn_end != null)
			{

				DateTime dtaftn_end = DateTime.ParseExact(c.aftn_end.Trim(), "hh:mm tt", CultureInfo.InvariantCulture);
				aftn_endspan = dtaftn_end.TimeOfDay;
			}
			else
			{
				aftn_endspan = new TimeSpan(0, 0, 0);	
			}
			aftn_end = new TimePicker()
			{
				Time = aftn_endspan,
				Format = Config.clock + "hh:mm tt",
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			stkaftntime = new StackLayout();
			stkaftntime.Orientation = StackOrientation.Horizontal;
			stkaftntime.HorizontalOptions = LayoutOptions.FillAndExpand;
			stkaftntime.Children.Add(aftn_start);
			stkaftntime.Children.Add(aftn_end);
			stkaftntime.Spacing = 5;

			stkaftnfull = new StackLayout();
			stkaftnfull.Orientation = StackOrientation.Vertical;
			stkaftnfull.HorizontalOptions = LayoutOptions.Fill;
			stkaftnfull.Children.Add(aftnlbl);
			stkaftnfull.Children.Add(stkaftntime);
			stkaftnfull.Spacing =4;
			#endregion aftn


			#region evn
			Label evnlbl = new Label
			{
				Text = Config.even + "Evening",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};
			if (c.evn_start != null)
			{
				DateTime dtevn_start = DateTime.ParseExact(c.evn_start.Trim(), "hh:mm tt", CultureInfo.InvariantCulture);
				evn_startspan = dtevn_start.TimeOfDay;
			}
			else
			{
				evn_startspan = new TimeSpan(0, 0, 0);
			}
			evn_start = new TimePicker()
			{
				Time = evn_startspan,
				Format = Config.clock + "hh:mm tt",
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			if (c.evn_end != null)
			{

				DateTime dtevn_end = DateTime.ParseExact(c.evn_end.Trim(), "hh:mm tt", CultureInfo.InvariantCulture);
				 evn_endspan = dtevn_end.TimeOfDay;
			}
			else
			{
				 evn_endspan = new TimeSpan(0, 0, 0);
			}
			evn_end = new TimePicker()
			{
				Time =evn_endspan,
				Format = Config.clock + "hh:mm tt",
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			stkevntime = new StackLayout();
			stkevntime.Orientation = StackOrientation.Horizontal;
			stkevntime.HorizontalOptions = LayoutOptions.FillAndExpand;
			stkevntime.Children.Add(evn_start);
			stkevntime.Children.Add(evn_end);
			stkevntime.Spacing = 5;

			stkevnfull = new StackLayout();
			stkevnfull.Orientation = StackOrientation.Vertical;
			stkevnfull.HorizontalOptions = LayoutOptions.Fill;
			stkevnfull.Children.Add(evnlbl);
			stkevnfull.Children.Add(stkevntime);
			stkevnfull.Spacing =4;
			#endregion evn
			#endregion maintime

			stkmaintime = new StackLayout();
			stkmaintime.Orientation = StackOrientation.Vertical;
			stkmaintime.HorizontalOptions = LayoutOptions.Fill;
			stkmaintime.Children.Add(headingtime);
			stkmaintime.Children.Add(stkmorfull);
			stkmaintime.Children.Add(stkaftnfull);
			stkmaintime.Children.Add(stkevnfull);
			stkmaintime.IsVisible = false;

			if (c.open_close)
			{
				stkfull_hours.IsVisible = true;
				if (!c.work_24_7)
				{
					stkmaintime.IsVisible = true;
				}

			}
			StackLayout main = new StackLayout
			{
				Margin=10,
				Spacing=20,
				Children = {
					stkopen_close,stkfull_hours,stkmaintime
				}
			};
			var scroll = new ScrollView();
			scroll.Content = main;
			Content = scroll;
		}

		void full_hours_Toggled(object sender, ToggledEventArgs e)
		{
			var openclosetag = e.Value;
			if (openclosetag)
			{
				
				stkmaintime.IsVisible = false;
			}
			else
			{
				
				stkmaintime.IsVisible = true;
			}
		}

		void open_close_Toggled(object sender, ToggledEventArgs e)
		{
			var openclosetag = e.Value;
			if (openclosetag)
			{
				stkfull_hours.IsVisible = true;
				if (!full_hours.IsToggled)
				{
					stkmaintime.IsVisible = true;
				}
			}
			else
			{
				full_hours.IsToggled = false;
				stkfull_hours.IsVisible = false;
				stkmaintime.IsVisible = false;
			}
		}

		async void testclick()
		{
			var isConnected = CrossConnectivity.Current.IsConnected;
			if (isConnected == false)
			{
				this.Opacity = 0.3;
				ChkCon consentPage = new ChkCon();
				await Navigation.PushPopupAsync(consentPage);
				await consentPage.PageClosedTask;
				this.Opacity = 1;
				return;
			}
			//if (open_close.IsToggled || !full_hours.IsToggled)
			//{
			//	if (mor_start.Time >= mor_end.Time)
			//	{
			//		DisplayAlert("", "Morning end time should be greater than", "Ok");
			//		mor_end.TextColor = Color.Red;
			//		return;
			//	}
			//	else
			//	{
			//		mor_end.TextColor = Color.Black;
			//	}
			//}
			await Navigation.PushPopupAsync(new popup_pleasewait());
			var consultingedit = new consulting_hours();

			//consulting room open 
			if (open_close.IsToggled)
			{
				//check 24/7 is true
				if (full_hours.IsToggled)
				{
					//modify 24/7 true
					consultingedit = new consulting_hours()
					{
						id = s.id,
						userid = s.userid,
						consulting_id = s.consulting_id,
						weeks_id = s.weeks_id,
						open_close = true,
						work_24_7 = true,
						morn_start = null,
						morn_end = null,
						aftn_start = null,
						aftn_end = null,
						evn_start = null,
						evn_end = null,
						created_by = s.userid,
						modified_by = s.userid,
						created=DateTime.Now,
						modifyed = DateTime.Now
					};
				}
				else
				{
					//else update opening time
					DateTime dtmorn_start = new DateTime(2000, 1, 1).Add(mor_start.Time);
					string morn_start_val = string.Format("{0:hh:mm tt}", dtmorn_start);

					DateTime dtmorn_end = new DateTime(2000, 1, 1).Add(mor_end.Time);
					string morn_end_val = string.Format("{0:hh:mm tt}", dtmorn_end);

					DateTime dtaftn_start = new DateTime(2000, 1, 1).Add(aftn_start.Time);
					string aftn_start_val = string.Format("{0:hh:mm tt}", dtaftn_start);

					DateTime dtaftn_end = new DateTime(2000, 1, 1).Add(aftn_end.Time);
					string aftn_end_val = string.Format("{0:hh:mm tt}", dtaftn_end);

					DateTime dtevn_start = new DateTime(2000, 1, 1).Add(evn_start.Time);
					string evn_start_val = string.Format("{0:hh:mm tt}", dtevn_start);

					DateTime dtevn_end = new DateTime(2000, 1, 1).Add(evn_end.Time);
					string evn_end_val = string.Format("{0:hh:mm tt}", dtevn_end);

					consultingedit = new consulting_hours()
					{
						id = s.id,
						userid = s.userid,
						consulting_id = s.consulting_id,
						weeks_id = s.weeks_id,
						open_close = true,
						work_24_7 = false,

						morn_start = morn_start_val,
						morn_end = morn_end_val,
						aftn_start = aftn_start_val,
						aftn_end = aftn_end_val,
						evn_start = evn_start_val,
						evn_end = evn_end_val,
						created_by = s.userid,
						modified_by = s.userid,
						created=DateTime.Now,
						modifyed = DateTime.Now
					};
				}
			}
			else
			{
				//Close the consulting rooms
				consultingedit = new consulting_hours()
				{
					id = s.id,
					userid = s.userid,
					consulting_id = s.consulting_id,
					weeks_id = s.weeks_id,
					open_close = false,
					work_24_7 = false,
					morn_start = null,
					morn_end = null,
					aftn_start = null,
					aftn_end = null,
					evn_start = null,
					evn_end = null,
					created_by = s.userid,
					modified_by = s.userid,
					created=DateTime.Now,
					modifyed = DateTime.Now
				};
			}

			HttpResponseMessage responsePutMethod = consultingPutRequest("http://178.238.139.243/ThinkdocotorApi/api/consulting_hoursApi?id=" + s.id, consultingedit);

			if (responsePutMethod.IsSuccessStatusCode)
			{
				Config.clinicupdateflag = true;
				await Navigation.PopAllPopupAsync();
              //  Application.Current.MainPage = new NavigationPage(new Consulting_Service_Hours(consulting_venues));
				Navigation.PopAsync(); 

			}
			else
			{
				await Navigation.PopPopupAsync();
				await DisplayAlert("", "Update counsting hours error try again", "Ok");
				return;
			}
		}
		private static HttpResponseMessage consultingPutRequest(string RequestURI, consulting_hours cunsltinghoursupdated)
		{
				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri("http://178.238.139.243/ThinkdocotorApi/api/consulting_hoursApi/");
				var json = JsonConvert.SerializeObject(cunsltinghoursupdated);
				HttpContent httpcontent = new StringContent(json);
				httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
				HttpResponseMessage response = client.PutAsync(RequestURI, httpcontent).Result;
				return response;
		}  
	}
}

