using System;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class ListViewModel : BaseViewModel
	{
		public ListViewModel ()
		{
		}

		string text;
int id;
		public string Text{
			get{
				return text;
			}set{
				text = value;
				OnPropertyChanged(nameof(Text));
			}
		}
		public int Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
				OnPropertyChanged(nameof(Id));
			}
		}

		bool isselected;
		public bool IsSelected{
			get{
				return isselected;
			}set{
				isselected = value;
				OnPropertyChanged(nameof(IsSelected));
				OnPropertyChanged(nameof(DetailImage));
			}
		}

		public Color TextColor
		{
			get{
				return Color.Black;
			}
		}
			
		public string DetailImage
		{
			get{
				if(IsSelected){
					return "ic_checkmark_active";
				}
				return "ic_checkmark_unactive";
			}
		}
	}
}

