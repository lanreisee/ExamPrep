using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExamPrep
{
    public partial class ExamRandomSessionChoice : ContentPage
    {
        public ExamRandomSessionChoice()
        {
            InitializeComponent();
        }

        

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            
            var itemSet = e.Item as ExamModeMenu;
            if (itemSet == null) return;
            if (itemSet.ModeNameId == 1)
            {
                await Navigation.PushAsync(new ExamModeRandomConfigPage());
                
            }
            if (itemSet.ModeNameId == 2)
            {
                await Navigation.PushAsync(new ExamModeConfigPage());
            }
           
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
