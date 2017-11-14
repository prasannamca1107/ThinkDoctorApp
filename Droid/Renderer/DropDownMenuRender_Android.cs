using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Support.V4.View;
using System.ComponentModel;
using Java.Lang;
using Thinkdocotor;
using Thinkdocotor.Droid.Renderer;

[assembly: ExportRenderer(typeof(DropDownMenuView), typeof(DropDownMenuRender_Android))]
namespace Thinkdocotor.Droid.Renderer
{
    public class DropDownMenuRender_Android : ViewRenderer<DropDownMenuView, Android.Views.View>, Spinner.IOnItemSelectedListener
    {
        Spinner _nativeView;
        Spinner.IOnItemSelectedListener _itemSelected;
        DropDownMenuView _dropDownView;
        SpinnerAdapter _adapter;
        ArrayAdapter<string> adapter;

        protected override void OnElementChanged(ElementChangedEventArgs<DropDownMenuView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                _dropDownView = (DropDownMenuView)e.NewElement;

                if (Control == null)
                {
                    Android.Widget.RelativeLayout wraper = new Android.Widget.RelativeLayout(Android.App.Application.Context);
                    //ContextThemeWrapper theme = new ContextThemeWrapper(Android.App.Application.Context, Resource.Layout.);
                    //ContextThemeWrapper theme = new ContextThemeWrapper(Android.App.Application.Context, ThinkDoctorMP.Droid.Resource.Style.Widget_AppCompat_Light_DropDownItem_Spinner);
                    //ContextThemeWrapper theme = new ContextThemeWrapper(Android.App.Application.Context, ThinkDoctorMP.Droid.Resource.Style.ThemeOverlay_AppCompat_Light);
                    //_nativeView = new Spinner(theme);
                    _nativeView = new Spinner(Android.App.Application.Context);
                    _nativeView.OnItemSelectedListener = this;
                    //if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.M)
                    //    _nativeView.SetBackgroundResource(FJKApp3.Droid.Resource.Drawable.border);
                    //else
                    //    wraper.SetBackgroundResource(FJKApp3.Droid.Resource.Drawable.border);
                    _nativeView.LayoutParameters = new Android.Widget.RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                    _nativeView.DropDownWidth = LayoutParams.MatchParent;
                    _dropDownView.SetItemSelection = (i) => {
                        _nativeView.SetSelection(i);
                    };

                    //ImageView downIcon = new ImageView(Android.App.Application.Context);
                    //var param = new Android.Widget.RelativeLayout.LayoutParams(20, 20);
                    //param.AddRule(LayoutRules.AlignParentRight);
                    //param.AddRule(LayoutRules.CenterInParent);
                    //param.SetMargins(0, 0, 14, 0);
                    //downIcon.LayoutParameters = param;
                    ////downIcon.SetImageResource(FJKApp3.Droid.Resource.Drawable.ic_arrow_drop_down_black);
                    //downIcon.SetImageResource(ThinkDoctorMP.Droid.Resource.Drawable.ddarrow);

                    wraper.AddView(_nativeView);
                    //wraper.AddView(downIcon);
                    SetNativeControl(wraper);
                }

                if (_dropDownView.ItemsSource != null)
                    SetApdater();
            }
        }

        private void SetApdater()
        {
            if (_dropDownView.ItemsSource != null)
            {

                //if (adapter == null)
                //{
                //    //adapter = new ArrayAdapter<string>(Android.App.Application.Context,
                //    //    Android.Resource.Layout.SimpleSpinnerItem, _dropDownView.ItemsSource);
                //    //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

                //    adapter = new ArrayAdapter<string>(Android.App.Application.Context,
                //       Resource.Layout.spinner_item, _dropDownView.ItemsSource);
                //    adapter.SetDropDownViewResource(Resource.Layout.myspinner);

                //    _nativeView.Adapter = adapter;
                //}

                if (_adapter == null)
                {
                    _adapter = new SpinnerAdapter(_dropDownView.ItemsSource);
                    _nativeView.Adapter = _adapter;
                }
                else
                    _adapter.SetData(_dropDownView.ItemsSource);
            }
        }

        class SpinnerAdapter : BaseAdapter
        {
            private List<string> _datas;
            public SpinnerAdapter(List<string> datas)
            {
                _datas = datas;
            }

            public override int Count
            {
                get
                {
                    return _datas != null ? _datas.Count : 0;
                }
            }

            public void SetData(List<string> datas)
            {
                _datas = datas;
                NotifyDataSetChanged();
            }

            public override Java.Lang.Object GetItem(int position)
            {
                return _datas[position];
                //return null;
            }

            public override long GetItemId(int position)
            {
                return position;
                //return 0;
            }

            public override Android.Views.View GetDropDownView(int position, Android.Views.View convertView, ViewGroup parent)
            {
                Android.Views.View item = (Android.Views.View)Android.Views.View.Inflate(Android.App.Application.Context, Resource.Layout.spinner_item, null) as LinearLayout;
                TextView text = item.FindViewById<TextView>(Resource.Id.text1);
                text.Text = _datas[position];
                //if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.M)
                //{
                //    item.SetBackgroundResource(FJKApp3.Droid.Resource.Drawable.border);
                //    item.FindViewById(FJKApp3.Droid.Resource.Id.line).Visibility = ViewStates.Gone;
                //}
                return item;
            }

            public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
            {
                Android.Views.View item = (Android.Views.View)Android.Views.View.Inflate(Android.App.Application.Context, Resource.Layout.myspinner, null);
                TextView text = item.FindViewById<TextView>(Resource.Id.spinnertext);
                text.Text = _datas[position];
                //if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.M)
                //{
                //    item.SetBackgroundResource(FJKApp3.Droid.Resource.Drawable.border);
                //    item.FindViewById(FJKApp3.Droid.Resource.Id.line).Visibility = ViewStates.Gone;
                //}
                return item;
            }

            //public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
            //{
            //    var item = (Android.Views.View)Android.Views.View.Inflate(Android.App.Application.Context, Resource.Layout.spinner_item, null);
            //    TextView text = item.FindViewById<TextView>(FJKApp3.Droid.Resource.Id.txtSpinnerText1);
            //    text.Text = _datas[position];
            //    //if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.M)
            //    //{
            //    //    item.SetBackgroundResource(FJKApp3.Droid.Resource.Drawable.border);
            //    //    item.FindViewById(FJKApp3.Droid.Resource.Id.line).Visibility = ViewStates.Gone;
            //    //}
            //    return item;
            //}
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            SetApdater();
        }

        public void OnItemSelected(AdapterView parent, Android.Views.View view, int position, long id)
        {
            //_nativeView.SetSelection(position);
            //_dropDownView.SetItemSelection(position);
            if (_dropDownView.ItemSelectedEvent != null)
            {
                _dropDownView.ItemSelectedEvent.Invoke(position);
            }
        }

        public void OnNothingSelected(AdapterView parent)
        {
            if (_dropDownView.ItemSelectedEvent != null)
            {
                _dropDownView.ItemSelectedEvent.Invoke(-1);
            }
        }
    }
}