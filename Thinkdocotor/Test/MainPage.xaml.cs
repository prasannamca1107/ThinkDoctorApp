using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Thinkdocotor.Test
{
    public partial class MainPage 
    {
        public MainPage()
        {
            
            InitializeComponent();
          
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            Title = CurrentPage?.Title;
        }
    }
}
