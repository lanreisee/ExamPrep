using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExamPrep
{
    public class CellWithHeight : ViewCell
    {
        public CellWithHeight()
        {
            var label = new Label { HeightRequest = 10, FontSize = 10, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.FillAndExpand};
            label.SetBinding(Label.TextProperty, "MenuName");
            View = label;
        }
    }
}
