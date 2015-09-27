using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExamPrep
{
    public partial class ExamModeRandomConfigPage : ContentPage
    {
        public List<Question> QuestionList { get; set; }
        public ExamModeRandomConfigPage()
        {
            InitializeComponent();
            var list = AppCache.GetData(null, null);
            DataContextType = new ExamModeQuestionNo();
            this.BindingContext = DataContextType;
        }

        public ExamModeQuestionNo DataContextType { get; set; }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {

        }



        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            var swi = sender as Switch;
            if (swi != null && swi.IsToggled)
            {
                this.TimeLabel.Text = "Timed";
            }
            else
            {
                this.TimeLabel.Text = "Not Timed";
            }
        }

        private void Stepper_OnValueChanged(object sender, ValueChangedEventArgs e)
        {

            LabelQuestionSelection.Text = e.NewValue.ToString();
        }

        private void SwitchCell_OnOnChanged(object sender, ToggledEventArgs e)
        {

            var mat = sender as SwitchCell;
            var getly = mat.BindingContext as QuestionTemplateCategory;
            if (getly != null)
            {

                if (mat.On)
                {
                    DataContextType.NoOfQuestions = DataContextType.NoOfQuestions + getly.MaxCount;
                }
                else
                {
                    DataContextType.NoOfQuestions = DataContextType.NoOfQuestions - getly.MaxCount;
                }
            }
        }

        async void Button_OnClicked(object sender, EventArgs e)
        {
            StringBuilder thisCompose = new StringBuilder();
            const string display = "Exam Session Details:";
            thisCompose.AppendLine();
            thisCompose.Append("Total Questions -  ");
            thisCompose.Append(LabelQuestionSelection.Text);
            thisCompose.AppendLine();
            if (this.TimeSwitch.IsToggled)
            {
                thisCompose.Append("Session Duration -  ");
                thisCompose.Append(LabelQuestionSelection.Text);
                thisCompose.Append(" mins");
                thisCompose.AppendLine();
            }

            var result = default(int);
            if (!int.TryParse(LabelQuestionSelection.Text, out result)) return;

            if (result == 0)
            {
                await DisplayAlert("Alert", "Unable to proceed with 0 question", "OK");
                return;
            }

            var action = await DisplayAlert(display, thisCompose.ToString(), "Start Test", "Cancel");
            if (!action) return;
            
            var _rand = new Random();
            if (QuestionList == null)
            {
                GetQuestionMasterList();
            }
            if (QuestionList == null) return;
            var quesBuild = new List<Question>();
            quesBuild = UtilLibrary.GetRandoms(QuestionList.ToArray(), result).ToList();
            if (quesBuild.Count == 0) return;
            foreach (var ert in QuestionList)
            {
                if (ert != null) ert.RefreshForRandom();
            }
            var dataCtx =
                new QuestionSessionManager(
                    AppCache.AssignNumberToQuestion(quesBuild, SessionType.ExamMode).ToList(),
                    SessionType.ExamMode);
            await Navigation.PushModalAsync(new ExamQuestionPage(dataCtx, 0));
        }

        private void GetQuestionMasterList()
        {
            var list = AppCache.GetData(null, null);
            QuestionList = list.Result;
        }
    }

   
}
    

