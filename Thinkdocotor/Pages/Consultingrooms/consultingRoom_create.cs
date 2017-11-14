using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using ThinkDoctor;
using Xamarin.Forms;

namespace Thinkdocotor
{
    public class consultingRoom_create : ContentPage
    {
         StackLayout maniclone;
        private string uri = "http://178.238.139.243/ThinkdocotorApi/api/consulting_room/1";
        consulting_venues cv;
        List<string> ls;
        public consultingRoom_create( consulting_venues consultingvenue )
        {
            cv = consultingvenue;
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
                //  BackgroundColor = Color.White;
                BackgroundImage = "Bg.png";
            }
            Title = "Add Room";
            loadjsonAsync();
            ToolbarItems.Add(new ToolbarItem("add", Device.OnPlatform("Docotor/addfile.png", "addtoolbar.png", null), async () =>
             {
                 Tapadd_Tapped();
             }));


            maniclone = new StackLayout();
            StackLayout Content1 = new StackLayout
            {
                Margin = 10,
                Children = {
                    maniclone
                }
            };
            var scroll = new ScrollView();
            scroll.Content = Content1;
            Content = scroll;
        }
        private async void Tapadd_Tapped()
        {
            try
            {
                Config.roomsaveflag = false;
                AddRoom consentPage = new AddRoom(cv,ls);
                await Navigation.PushPopupAsync(consentPage);
                await consentPage.PageClosedTask;
                if (Config.roomsaveflag)
                {
                    maniclone.Children.Clear();
                    await DisplayAlert("", "Saved ", "Ok");
                    loadjsonAsync();
                }


            }
            catch (Exception ex)
            {

                await DisplayAlert("", "Add clinic error try again" + ex.Message, "Ok");
                return;

            }
        }
        private async System.Threading.Tasks.Task loadjsonAsync()
        {
            try
            {
                  await Navigation.PushPopupAsync(new popup_pleasewait());
                ls = new List<string>();
                var httpclient = new HttpClient();
                var json = await httpclient.GetStringAsync(uri);
                consultingRoomlistinfo responsemain = JsonConvert.DeserializeObject<consultingRoomlistinfo>(json);
                var count = responsemain.consulting_room.Count();
                if (count >= 1)
                {
                    foreach (consulting_room v in responsemain.consulting_room)
                    {

                        maniclone.Children.Add(createstk(new consulting_roomStackviewmodel(v)));
                        ls.Add(v.consulting_room_title);

                    }
                    await Navigation.PopAllPopupAsync();
                }
                else
                {
                    await Navigation.PopAllPopupAsync();
                    Tapadd_Tapped();

                }
            }

            catch (Exception ex)
            {

                DisplayAlert("", "SomthSomething to worng\n" + ex.Message, "Ok");
                await Navigation.PopAllPopupAsync();
                return;
            }

        }
        private StackLayout createstk(consulting_roomStackviewmodel c)
        {

            Image imgdeleteclinic = new Image()
            {
                Source = Device.OnPlatform("Docotor/deleteclinic.png", "deleteclinic.png", null),
                HorizontalOptions = LayoutOptions.End,
                WidthRequest = 25,
                HeightRequest=25

            };

            var tapbtndelete = new TapGestureRecognizer();
            tapbtndelete.SetBinding(TapGestureRecognizer.CommandParameterProperty, "Id");
            tapbtndelete.Tapped += Btndelete_Clicked;
            imgdeleteclinic.GestureRecognizers.Add(tapbtndelete);

            Image imgeditclinic = new Image()
            {
                Source = Device.OnPlatform("Docotor/editclinic.png", "editclinic.png", null),
                //Foreground = Color.White,
                HorizontalOptions = LayoutOptions.End,
                WidthRequest = 25,
                HeightRequest = 25
            };

            var tapbtnedit = new TapGestureRecognizer();
            tapbtnedit.SetBinding(TapGestureRecognizer.CommandParameterProperty, "editdetails");
            tapbtnedit.Tapped += Btnedit_Clicked;
            imgeditclinic.GestureRecognizers.Add(tapbtnedit);

          
            Label consultingroomtitle = new Label()
            {
                Text = c.Consulting_room_title,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 15

            };


            StackLayout firstrow = new StackLayout();
            firstrow.HorizontalOptions = LayoutOptions.FillAndExpand;
            firstrow.Orientation = StackOrientation.Horizontal;
            firstrow.Children.Add(consultingroomtitle);
            firstrow.Children.Add(imgeditclinic);
            firstrow.Children.Add(imgdeleteclinic);

           



           
            CustomFrame frm = new CustomFrame()
            {
                Content = firstrow,
                OutlineColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BorderRadius = 5,
                Padding = 10,
                BackgroundColor = Color.Transparent
            };
            StackLayout mainstk = new StackLayout();
            mainstk.HorizontalOptions = LayoutOptions.FillAndExpand;
            mainstk.Children.Add(frm);
            mainstk.BindingContext = c;
            return mainstk;
        }
        async void Btndelete_Clicked(object sender, EventArgs e)
        {
            try
            {
            var answer = await DisplayAlert("", "Delete Room", "Yes", "No");
            if (answer)
            {
                if (Device.OS == TargetPlatform.Android)
                {

                    await Navigation.PushPopupAsync(new popup_pleasewait());

                }
                if (Device.OS == TargetPlatform.iOS)
                {

                    await Navigation.PushPopupAsync(new popup_pleasewait());
                    await Navigation.PushPopupAsync(new popup_pleasewait());

                }
                var item = (Image)sender;
                TapGestureRecognizer t = (TapGestureRecognizer)item.GestureRecognizers[0];
                var roomid = t.CommandParameter;
                HttpResponseMessage responsePutMethod = clinicDeleteRequest("http://178.238.139.243/ThinkdocotorApi/api/consulting_room?id=" + roomid);
                if (responsePutMethod.IsSuccessStatusCode)
                {
                    await Navigation.PopAllPopupAsync();
                    await DisplayAlert("", "Deleted ", "Ok");
                    maniclone.Children.Clear();
                    loadjsonAsync();

                }
                else
                {
                    await Navigation.PopAllPopupAsync();
                    DisplayAlert("", "Erorr deleting try again", "Ok");

                    return;
                }
            }
        }


            catch (Exception ex)
            {
                await Navigation.PopAllPopupAsync();

                DisplayAlert("", "Something went to worng\n" + ex.Message, "Ok");

                return;
            }
        }
        async void Btnedit_Clicked(object sender, EventArgs e)
        {
            try{
                
            var item = (Image)sender;
            TapGestureRecognizer t = (TapGestureRecognizer)item.GestureRecognizers[0];
            string[] editdetial = t.CommandParameter.ToString().Split('$');

                var consulting_room = new consulting_room
                {
                    id = Convert.ToInt32(editdetial[0].ToString()),
                    userid = Config.user_Id,
                    consulting_id = Convert.ToInt32(editdetial[1]),
                    consulting_room_title = editdetial[2].ToString(),
                    created_by = Config.user_Id,
                    modified_by = Config.user_Id,
                     created = DateTime.Now,
                        modifyed = DateTime.Now
};
                chk(consulting_room);
            }
            catch (Exception ex)
            {

                DisplayAlert("", "Something went to worng\n" + ex.Message, "Ok");

                return;
            }
        }
        async void chk(consulting_room editdetails)
        {
            Config.roomeditflag = false;
            EditRoom consentPage = new EditRoom(editdetails,ls);
            await Navigation.PushPopupAsync(consentPage);
            await consentPage.PageClosedTask;
            if (Config.roomeditflag)
            {
                maniclone.Children.Clear();
                await DisplayAlert("", "Updated ", "Ok");
                loadjsonAsync();
            }


        }
        private static HttpResponseMessage clinicDeleteRequest(string RequestURI)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri( "http://178.238.139.243/ThinkdocotorApi/api/consulting_room/");
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = client.DeleteAsync(RequestURI).Result;
            return response;;
        }  

    }
}

