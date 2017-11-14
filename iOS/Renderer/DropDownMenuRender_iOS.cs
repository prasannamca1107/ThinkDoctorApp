using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System;
using UIKit;
using Foundation;
using CoreGraphics;
using ThinkDoctor;
using ThinkDoctor.iOS;
using Thinkdocotor;
using Thinkdocotor.iOS.Renderer;

[assembly: ExportRenderer(typeof(DropDownMenuView), typeof(DropDownMenuRender_iOS))]

namespace Thinkdocotor.iOS.Renderer
{
    public class DropDownMenuRender_iOS : ViewRenderer<DropDownMenuView, UIView>
    {
        DropDownMenuView _dropDownView;
        UITableView tableView;
        UIView wrapper;
        UILabel label;
        UIImageView arrow;
        int selectedIndex = 0;
        UIView cover;

        protected override void OnElementChanged(ElementChangedEventArgs<DropDownMenuView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                _dropDownView = (DropDownMenuView)e.NewElement;
                if (Control == null)
                {
                    wrapper = new UIView();
                    wrapper.Layer.BorderColor = ColorExtensions.ToCGColor(Color.Transparent);
                    wrapper.Layer.BorderWidth = 1;
                    wrapper.Frame = this.Frame;
                    //wrapper.BackgroundColor = UIColor.Red;
                    wrapper.AddGestureRecognizer(new UITapGestureRecognizer(() => {
                        ButtonClickHanlde();
                    }));

                    arrow = new UIImageView();
                    arrow.Image = new UIImage("arowdown.png");
                    arrow.Frame = new CGRect(10, 10, 50, 30);
                    wrapper.AddSubview(arrow);


                    label = new UILabel();
                    label.TextColor = UIColor.White;
                    label.Frame = new CGRect(10, 10, 50, 30);
                    if (_dropDownView != null && _dropDownView.ItemsSource != null)
                        label.Text = _dropDownView.ItemsSource[0];
                    wrapper.AddSubview(label);
                    tableView = new UITableView();
                    //tableView
                    tableView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
                    tableView.Frame = wrapper.Frame;
                    tableView.Layer.BorderWidth = 1;
                    tableView.Layer.BorderColor = ColorExtensions.ToCGColor(Color.White);
                    tableView.WeakDelegate = this;
                    tableView.WeakDataSource = this;
                    _dropDownView.SetItemSelection += (obj) => {
                        //if(label!=null)
                        selectedIndex = obj;
                        label.Text = _dropDownView.ItemsSource[obj];
                        if (_dropDownView.ItemSelectedEvent != null)
                            _dropDownView.ItemSelectedEvent.Invoke(obj);
                    };
                    SetNativeControl(wrapper);
                }
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && tableView != null)
                tableView.RemoveFromSuperview();

            base.Dispose(disposing);
        }

        public override CGRect Frame
        {
            get
            {
                return base.Frame;
            }
            set
            {
                base.Frame = value;

                if (label != null && wrapper != null && value != CGRect.Empty)
                {
                    //label.BackgroundColor = UIColor.Green;
                    //label.Frame = new CGRect(8, 2, value.Size.Width - 10, value.Size.Height - 4);

                    nfloat labelW = value.Size.Width - (_dropDownView.imageWidth + 2) - 10;
                    label.Frame = new CGRect(2, 2, labelW, value.Size.Height - 4);
                    this.LayoutSubviews();
                }
                if (arrow != null && wrapper != null && value != CGRect.Empty)
                {
                    //arrow.BackgroundColor = UIColor.Blue;
                    //arrow.Frame = new CGRect(value.Size.Width - 20, (value.Size.Height - 10) / 2, 10, 10);

                    nfloat imgX = value.Size.Width - _dropDownView.imageWidth - 10;
                    nfloat imgY = (value.Size.Height - _dropDownView.imageHeight) / 2;
                    arrow.Frame = new CGRect(imgX, imgY, _dropDownView.imageWidth, _dropDownView.imageHeight);
                    this.LayoutSubviews();
                }


            }
        }

        public void UpdateButton(string name)
        {

        }

        bool isShowDialog = false;
        private void ButtonClickHanlde()
        {
            if (wrapper == null)
                return;
            isShowDialog = !isShowDialog;
            if (isShowDialog)
            {
                var rect = wrapper.ConvertRectToView(wrapper.Frame, AppDelegate.AppWindow);
                nfloat height = AppDelegate.AppWindow.Bounds.Height - rect.Y - 10;
                CGRect r = new CGRect(rect.X, rect.Y, rect.Width, height);
                int listCount = _dropDownView == null ? 0 : _dropDownView.ItemsSource.Count;

                cover = new UIView();
                cover.Frame = new CGRect(0, 0, 50, 50);
                cover.BackgroundColor = UIColor.Clear;

                AppDelegate.Instance.ShowSubviewAt(r, cover, tableView, () => {
                    if (selectedIndex < listCount)
                        tableView.ScrollToRow(NSIndexPath.FromRowSection(selectedIndex, 0), UITableViewScrollPosition.Top, false);
                });

            }
            else
            {
                //AppDelegate.Instance.removeDropDownViewCover();
                if(cover != null)
                    cover.RemoveFromSuperview();
                if(tableView != null)
                    tableView.RemoveFromSuperview();
            }

        }


        [Export("tableView:numberOfRowsInSection:")]
        public nint RowsInSection(UITableView tableView, nint section)
        {
            return _dropDownView == null ? 0 : _dropDownView.ItemsSource.Count;
        }


        [Export("tableView:cellForRowAtIndexPath:")]
        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var simpleTableIdentifier = @"SimpleTableItem";

            var cell = tableView.DequeueReusableCell(simpleTableIdentifier);

            if (cell == null)

            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, simpleTableIdentifier);
            }

            cell.TextLabel.Text = _dropDownView.ItemsSource[indexPath.Row];
            return cell;
        }

        [Export("numberOfSectionsInTableView:")]
        public virtual nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }


        [Export("tableView:didSelectRowAtIndexPath:")]
        public void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            selectedIndex = indexPath.Row;
            ButtonClickHanlde();
            tableView.DeselectRow(indexPath, true);
            label.Text = _dropDownView.ItemsSource[indexPath.Row];
            if (_dropDownView.ItemSelectedEvent != null)
                _dropDownView.ItemSelectedEvent.Invoke(indexPath.Row);
        }

        [Export("tableView:heightForRowAtIndexPath:")]
        public virtual nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 50;
        }

    }
}