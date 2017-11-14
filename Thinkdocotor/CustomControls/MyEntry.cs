using Xamarin.Forms;

namespace ThinkDoctor
{
	public class MyEntry : Entry
	{

		public static readonly BindableProperty MaxLengthProperty =BindableProperty.Create("MaxLength", typeof(int), typeof(MyEntry), int.MaxValue);


public int MaxLength
{
	get { return (int)GetValue(MaxLengthProperty); }
	set { SetValue(MaxLengthProperty, value); }
	}


	}
}
