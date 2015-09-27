using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ExamPrep
{
    public partial class MyHistoryPage : ContentPage
    {
        public MyHistoryPage()
        {
            InitializeComponent();
            TryGetSavedHistory();
        }

        private void TryGetSavedHistory()
        {
            this.BindingContext = DependencyService.Get<ISaveAndLoad>().GetSavedFiles(string.Empty);
            
        }


        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var filter = e.Item as MyHistory;
            if (filter != null)
            {
                var text = DependencyService.Get<ISaveAndLoad>().LoadText(filter.Path);
                
                var back = JsonConvert.DeserializeObject<Session>(text);

                if (back == null) return;
                var list = back.SessionQuestion;
                if (list != null && list.Count > 0)
                    await
                        Navigation.PushAsync(new ExamQuestionReportPage(list, 0, back));
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
