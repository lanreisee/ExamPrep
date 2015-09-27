using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExamPrep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
        }

        bool isEditing;
        ToolbarItem editButton, endEditButton;
        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (isEditing) return;
            var itemSet = e.Item as AppMenu;
            if (itemSet == null) return;
            if (itemSet.MenuId == 1)
            {
                await this.Navigation.PushAsync(new ExamRandomSessionChoice());
            }
            if (itemSet.MenuId == 2)
            {
               await this.Navigation.PushAsync(new StudyPlanPage());
            }
            if (itemSet.MenuId == 3)
            {
                await this.Navigation.PushAsync(new MyHistoryPage());
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
    }
}
