using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Thinkdocotor
{
public class DropDownMenuView : View
{
	public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(List<string>), typeof(DropDownMenuView));
	public static readonly BindableProperty SelectIndexProperty = BindableProperty.Create("selectindex", typeof(int), typeof(DropDownMenuView),0);
	public static readonly BindableProperty ItemSelectedEventProperty = BindableProperty.Create("ItemSelectedEvent", typeof(Action<int>), typeof(DropDownMenuView));
	public static readonly BindableProperty SetItemSelectionProperty = BindableProperty.Create("SetItemSelection", typeof(Action<int>), typeof(DropDownMenuView));

    public float imageWidth
    {
            get;
            set;
    }
    public float imageHeight
    {
            get;
            set;
    }

        public List<string> ItemsSource
	{
		get { return (List<string>)GetValue(ItemsSourceProperty); }
		set { SetValue(ItemsSourceProperty, value); }
	}

	public Action<int> ItemSelectedEvent
	{
		get { return (Action<int>)GetValue(ItemSelectedEventProperty); }
		set { SetValue(ItemSelectedEventProperty, value); }
	}
	public Action<int> SetItemSelection
	{
		get { return (Action<int>)GetValue(SetItemSelectionProperty); }
		set { SetValue(SetItemSelectionProperty, value); }
	}
    public int selectindex
    {
	get { return (int)GetValue(SelectIndexProperty); }
	set { SetValue(SelectIndexProperty, value); }
	}

}
}
