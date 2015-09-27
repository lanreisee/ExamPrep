using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExamPrep
{
    public partial class QuestionListPage : ContentPage
    {
        public static IList<Question> QuestionList { get; private set; }

        public string StudyPlan { get; set; }
        public QuestionListPage(IList<Question> questionList, string filter, AppEnums.QuestionListFilter filterType )
        {
            
            InitializeComponent();
           
            switch (filterType)
            {
               
                case AppEnums.QuestionListFilter.UnAnswered:
                    {
                            QuestionList = questionList.Where(x => x.Unanswered).ToList();
                            StudyPlan = filter;
                            this.BindingContext = AppCache.AssignNumberToQuestion(QuestionList, SessionType.PractiseMode);

                        break;
                    }
                case AppEnums.QuestionListFilter.AnsweredCorrectly:
                    {
                       
                            QuestionList =
                                questionList.Where(x => x.AnsweredCorrectly != null && x.AnsweredCorrectly.Value).ToList();
                            StudyPlan = filter;
                            this.BindingContext = AppCache.AssignNumberToQuestion(QuestionList, SessionType.PractiseMode);

                        break;
                    }
                case AppEnums.QuestionListFilter.AnsweredIncorrectly:
                    {

                        QuestionList =
                            questionList.Where(x => x.AnsweredCorrectly != null && x.AnsweredCorrectly.Value.Equals(false)).ToList();
                        StudyPlan = filter;
                        this.BindingContext = AppCache.AssignNumberToQuestion(QuestionList, SessionType.PractiseMode);

                        break;
                    }
                case AppEnums.QuestionListFilter.StudyPlan:
                    {
                        QuestionList = questionList.Where(x => x.StudyPlan.Equals(filter)).ToList();
                        StudyPlan = filter;
                        this.BindingContext = AppCache.AssignNumberToQuestion(QuestionList, SessionType.PractiseMode);
                        break;
                    }
                case AppEnums.QuestionListFilter.Favorite:
                    {
                            QuestionList = questionList.Where(x => x.IsFavorite != null && x.IsFavorite.Value).ToList();
                            StudyPlan = filter;
                            this.BindingContext = AppCache.AssignNumberToQuestion(QuestionList, SessionType.PractiseMode);
                        break;
                    }
                default:
                    this.BindingContext = AppCache.AssignNumberToQuestion(QuestionList, SessionType.PractiseMode);
                    break;
            }
            
        }

       

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Question;
            var questions = QuestionList.Where(x => x.StudyPlan.Equals(StudyPlan)).ToList();
            var dataCtx = new QuestionSessionManager(questions, SessionType.PractiseMode);
            await Navigation.PushAsync(new QuestionPage(dataCtx, item != null ? item.DispalyId : 0));
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
