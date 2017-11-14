using System;
using System.Collections.Generic;
using System.IO;
using Plugin.Media;
using Thinkdocotor.ViewModels;
using ThinkDoctor;
using Xamarin.Forms;

namespace Thinkdocotor.Pages.Users
{
    public class SettingPage : CustomPageWithGradient
    {
        RoundImage img_person,img_edit;
        Picker imagpick;
        bool pickerflag = false;
        Dictionary<string, string> pickerlist = new Dictionary<string, string>
        {
            {
              "Take a Picture ","_takePic"
            },
             {
              "Image From Gallery","_galleryPic"
             }

        };
         Label lblUserName;
        SettingPageViewModels SettingViewModel;
        public SettingPage()
        {
            SettingViewModel = new SettingPageViewModels();
            BindingContext = SettingViewModel;

            StartColor = Color.FromHex("#3a527d");
            EndColor = Color.FromHex("#24334e");

            Title = "Setting";
            img_person = new RoundImage();

           // img_person.Source = "defalutdoctor.png";
            img_person.HorizontalOptions = LayoutOptions.Center;
            img_person.VerticalOptions = LayoutOptions.Center;
            img_person.HeightRequest = 110;
            img_person.WidthRequest = 110;
            img_person.Aspect = Aspect.AspectFill;
            img_person.SetBinding(Image.SourceProperty, "Profile_img");

            img_edit = new RoundImage();
            img_edit.Source = "editphoto.png";
            img_edit.HorizontalOptions = LayoutOptions.Center;
            img_edit.VerticalOptions = LayoutOptions.Center;
            img_edit.HeightRequest = 30;
            img_edit.WidthRequest = 30;
            img_edit.Aspect = Aspect.AspectFill;

            imagpick = new Picker
            {
                Title = "Choose",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsVisible = false,
                IsEnabled = false


            };
            foreach (string colorName in pickerlist.Keys)
            {
                imagpick.Items.Add(colorName);
            }
           // imagpick.SelectedIndexChanged += imagpick_SelectedIndexChanged;
            imagpick.SelectedIndex = -1;




            lblUserName = new Label();
            lblUserName.Text = "....";
            lblUserName.TextColor = Color.Black;
            lblUserName.HorizontalOptions = LayoutOptions.Center;
            lblUserName.VerticalOptions = LayoutOptions.Center;
            lblUserName.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            BoxView boxView = new BoxView
            {
                Color = Color.FromHex("#CEE8FA"),
                WidthRequest = 700,
                HeightRequest = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            RelativeLayout layout = new RelativeLayout();
            layout.WidthRequest = 150;
            layout.HeightRequest = 150;
            layout.HorizontalOptions = LayoutOptions.Center;
            layout.VerticalOptions = LayoutOptions.Center;
            //layout.BackgroundColor = Color.White ;
            layout.Children.Add(img_person,
                Constraint.Constant(25),
                Constraint.Constant(25),
                               //Constraint.RelativeToParent((parent) => { return parent.Width; }),
                               //Constraint.RelativeToParent((parent) => { return parent.Height; })
                               Constraint.Constant(110), Constraint.Constant(110));

            layout.Children.Add(img_edit,
                Constraint.Constant(105),
                Constraint.Constant(105),
                                //Constraint.RelativeToParent((parent) => { return parent.Width; }),
                                //Constraint.RelativeToParent((parent) => { return parent.Height; }));
                                Constraint.Constant(30), Constraint.Constant(30));


            var tapImgtest = new TapGestureRecognizer();
            //tapImgtest.Tapped += Loadimage;
            layout.GestureRecognizers.Add(tapImgtest);

            StackLayout stack_user = new StackLayout();
            stack_user.BackgroundColor = Color.FromHex("#CEE8FA");
            //stack_user.BackgroundColor = Color.Transparent;
            stack_user.HorizontalOptions = LayoutOptions.Fill;
            stack_user.VerticalOptions = LayoutOptions.Start;
            stack_user.Orientation = StackOrientation.Vertical;
            stack_user.Padding = new Thickness(0);

            stack_user.Children.Add(layout);
            stack_user.Children.Add(lblUserName);
            stack_user.Children.Add(boxView);

            Content = new StackLayout
            {
                Children = {
                    
                    stack_user
                }
            };
        }
        protected async override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            await SettingViewModel.loadsettingPage();
        }


    }
}

