using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExamPrep
{
    public partial class ExamModeConfigPage : ContentPage
    {
        public List<Question> QuestionList { get; set; }

        public ExamModeConfigPage()
        {
            InitializeComponent();
            GetQuestionMasterList();
            DataContextType = new ExamModeQuestionNo();
            SelectedCategories = new List<QuestionTemplateCategory>();
            this.BindingContext = DataContextType;
            StartButton.Clicked += async (sender, e) =>
            {
                StringBuilder thisCompose = new StringBuilder();
                const string display = "Exam Session Details:";
                thisCompose.AppendLine();
                thisCompose.Append("Total Questions -  ");
                thisCompose.Append(DataContextType.NoOfQuestions.ToString());
                thisCompose.AppendLine();
                if (this.TimeSwitch.IsToggled)
                {
                    thisCompose.Append("Session Duration -  ");
                    thisCompose.Append(DataContextType.NoOfQuestions.ToString());
                    thisCompose.Append(" mins");
                    thisCompose.AppendLine();
                }
                if (DataContextType.NoOfQuestions == 0)
                {
                    await DisplayAlert("Alert", "Unable to proceed with 0 question", "OK");
                    return;
                }

               var action = await  DisplayAlert(display, thisCompose.ToString(), "Start Test", "Cancel");
                if (action)
                {
                    var ctx = AllStudyPlan.BindingContext;
                    if (ctx != null)
                    {
                        var selct = SelectedCategories;
                        if (QuestionList == null)
                        {
                            GetQuestionMasterList();
                        }
                        var quesBuild = new List<Question>();
                        foreach (var questionTemplateCategory in SelectedCategories)
                        {
                            quesBuild.AddRange(QuestionList.Where(x => x.StudyPlan.Equals(questionTemplateCategory.CategoryName)).ToList());
                        }
                        if (quesBuild.Count == 0) return;
                        foreach (var ert in QuestionList)
                        {
                            if (ert != null) ert.RefreshForRandom();
                        }
                        var dataCtx = new QuestionSessionManager(AppCache.AssignNumberToQuestion(quesBuild, SessionType.ExamMode).ToList(), SessionType.ExamMode);
                       await Navigation.PushModalAsync(new ExamQuestionPage(dataCtx, 0));
                    }
                }
            };
        }

        private void GetQuestionMasterList()
        {
            var list = AppCache.GetData(null, null);
            QuestionList = list.Result;
        }

        public ExamModeQuestionNo DataContextType { get; set; }

        public List<QuestionTemplateCategory> SelectedCategories { get; set; } 

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
                    if (!SelectedCategories.Contains(getly))
                    { SelectedCategories.Add(getly);}
                        DataContextType.NoOfQuestions = DataContextType.NoOfQuestions + getly.MaxCount;
                }
                else
                {
                    if (SelectedCategories.Contains(getly))
                    { SelectedCategories.Remove(getly); }
                    DataContextType.NoOfQuestions = DataContextType.NoOfQuestions - getly.MaxCount;
                }
            }
        }

        
    }
}
