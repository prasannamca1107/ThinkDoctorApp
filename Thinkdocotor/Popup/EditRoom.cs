using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;

using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ThinkDoctor
{
    public class EditRoom : PopupPage
    {

        Button btncontinue,Clear;
        StackLayout main;
        MyEntry addrommtxt;
        CustomFrame FEntry;
        StackLayout stkEntry;
        public Task PageClosedTask
        {
            get { return tcs.Task; }


        }

        private TaskCompletionSource<bool> tcs { get; set; }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            tcs.SetResult(true);

        }
        private string uri = "http://178.238.139.243/ThinkdocotorApi/api/consulting_room";
        // Or provide your own PopAsync function so that when you decide to leave the page explicitly the TaskCompletion is triggered
        public async Task PopAwaitableAsync()
        {
            await Navigation.PopAsync();


            tcs.SetResult(true);
        }
        consulting_room cv;
        List<string> ls1;
        public EditRoom(consulting_room consultingvenue,List<string> ls)
        {
            ls1 = ls;
            cv =consultingvenue;
            tcs = new System.Threading.Tasks.TaskCompletionSource<bool>();



            Label heading = new Label();
            heading.Text = "Edit Room";
            heading.FontSize = 20;
            heading.TextColor = Color.Black;
            heading.HorizontalOptions = LayoutOptions.CenterAndExpand;


            Label addroomlbl = new Label
            {
                Text = "Edit Room",
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            addrommtxt = new MyEntry
            {
                Placeholder = "Title",
                Text=cv.consulting_room_title,
                TextColor = Color.Black,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                PlaceholderColor = Color.Gray,


            };

            FEntry = new CustomFrame
            {
                Content = addrommtxt,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(7),
                OutlineColor = Color.Gray,
                BorderWidth = 1,
                BorderRadius = 5,
                //BackgroundColor = Color.Transparent,

            };

            stkEntry = new StackLayout();
            stkEntry.Orientation = StackOrientation.Vertical;
            stkEntry.HorizontalOptions = LayoutOptions.Fill;
            stkEntry.Children.Add(addroomlbl);
            stkEntry.Children.Add(FEntry);
            stkEntry.Spacing = 2;



            btncontinue = new Button
            {
                Text = "Update",
                Style = (Style)Application.Current.Resources["CPButton"],
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            btncontinue.Clicked += btncontinue_Clicked;

            Clear = new Button
            {
                Text = "Cancel",
                Style = (Style)Application.Current.Resources["CPButton"],
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            Clear.Clicked += Clear_Clinic;

            StackLayout stkh = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 5,
                Children =
                {
                    btncontinue,Clear

                }
            };

            StackLayout stkmain = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,

                Spacing = 10,
                Children =
                {
                    heading,stkEntry,stkh
                }
            };
            Frame Fmain = new Frame
            {
                Content = stkmain,
                OutlineColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20),
                BackgroundColor = Color.White,
                HasShadow = true
            };
            main = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 10,
                Children =
                {
            Fmain
                }
            };
            BackgroundColor = Color.Transparent;
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Margin=20,
                Children = {
                    main
                }
            };
        }
        async void Clear_Clinic(object sender, EventArgs e)
        {
            await Navigation.PopAllPopupAsync();
        }
        async void btncontinue_Clicked(object sender, EventArgs e)
        {
            foreach (var txt in ls1)
            {
                if (addrommtxt.Text == txt)
                {
                    addrommtxt.Text = "";
                    addrommtxt.Placeholder = "Already exits";
                    addrommtxt.PlaceholderColor = Color.Red;

                    if (!stkEntry.AnimationIsRunning("TranslateTo"))
                    {

                        await stkEntry.TranslateTo(-10, 0, 100);
                        await stkEntry.TranslateTo(10, 0, 100);
                        await stkEntry.TranslateTo(0, 0, 100);
                        return;
                    }
                }
                else
                {
                    addrommtxt.Placeholder = "Tilte";
                    addrommtxt.PlaceholderColor = Color.Gray;

                }
            }
            if (string.IsNullOrEmpty(addrommtxt.Text))
            {
                addrommtxt.Placeholder = "Required";
                addrommtxt.PlaceholderColor = Color.Red;
                if (!stkEntry.AnimationIsRunning("TranslateTo"))
                {

                    await stkEntry.TranslateTo(-10, 0, 100);
                    await stkEntry.TranslateTo(10, 0, 100);
                    await stkEntry.TranslateTo(0, 0, 100);
                    return;
                }
            }
            else
            {
                addrommtxt.Placeholder = "Tilte";
                addrommtxt.PlaceholderColor = Color.Gray;
            }
            var consulting_room = new consulting_room
            {
                id=cv.id,
                userid = Config.user_Id,
                consulting_id = cv.id,
                consulting_room_title = addrommtxt.Text,
                created_by = Config.user_Id,
                modified_by = Config.user_Id,
                created = DateTime.Now,
                modifyed = DateTime.Now
            };
            try
            {
                await Navigation.PushPopupAsync(new popup_pleasewait());

                HttpResponseMessage responsePutMethod = ClinicPutRequest("http://178.238.139.243/ThinkdocotorApi/api/consulting_room?id=" + cv.id, consulting_room);

                if (responsePutMethod.IsSuccessStatusCode)
                {
                    Config.roomeditflag = true;
                    await Navigation.PopAllPopupAsync();

                }
                else
                {
                    await Navigation.PopPopupAsync();
                    await DisplayAlert("", "Update room error try again", "Ok");
                    return;
                }


               }
            catch (Exception ex)
            {
                await Navigation.PopPopupAsync();
                await DisplayAlert("", "Add room error try again" + ex.Message, "Ok");
                return;

            }


          
            addrommtxt.Text = "";

           
        }
             private static HttpResponseMessage ClinicPutRequest(string RequestURI, consulting_room clinindetails)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://178.238.139.243/ThinkdocotorApi/api/Clinic_DetailsApi/");
                var json = JsonConvert.SerializeObject(clinindetails);
                HttpContent httpcontent = new StringContent(json);
                httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PutAsync(RequestURI,httpcontent).Result;
                return response;
            }  

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
            //return base.OnBackButtonPressed();
            return false;
        }
        protected override bool OnBackgroundClicked()
        {
            // Return default value - CloseWhenBackgroundIsClicked
            //return base.OnBackgroundClicked();  
            return false;
        }
    }
}





