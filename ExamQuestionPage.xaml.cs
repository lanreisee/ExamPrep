using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace ExamPrep
{
    public partial class ExamQuestionPage : ContentPage
    {
       
        public ExamQuestionPage(QuestionSessionManager mgr, int selectedId)
        {
            //BindingContext = mgr;
            InitializeComponent();
            //for  test only
            Initialize(mgr, selectedId);
            
            
        }


        private Stack<Question> _next = new Stack<Question>();

        public QueueManager QueueDirector { get; set; }


        public Question DisplayItem { get; set; }

        public Stack<Question> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        private Stack<Question> _prev;

        public Stack<Question> Prev
        {
            get { return _prev; }
            set { _prev = value; }
        }

        private void Initialize(QuestionSessionManager mgr, int selectedId)
        {
            
            var list = mgr.QuestionList;
            var indexOfSelectedItem = 0;
            if (selectedId != 0)
            {
                //we wont have id of zero
                indexOfSelectedItem = list.FindIndex(a => a.DispalyId == selectedId);
            }
            var listToProcess = list.GetRange(indexOfSelectedItem + 1, list.Count - 1 - indexOfSelectedItem);
            var currItem = list[indexOfSelectedItem];
            listToProcess.Reverse();
            _next = new Stack<Question>(listToProcess);
            _prev = new Stack<Question>(list.GetRange(0, indexOfSelectedItem));
            SetBindingContext(currItem);
            SetNavButtons();
            StopButton.Clicked += async (sender, e) =>
            {
                var action = await DisplayAlert("End Session?", "This will end current session", "YES", "NO");
                if (action)
                {
                   // Acr.UserDialogs()
                 Result result =   GradeManager.GradeSession(mgr.QuestionList);
                    if (result == null) return;
                    var action1 =
                        await
                            DisplayActionSheet("SESSION RESULT", "CLOSE", "SAVE", "EXIT VIEW", "Answered Correctly - " + result.TotalPointsScored.ToString(),
                              "Answered Incorecctly - " + (result.TotalAvailablePoints - result.TotalPointsScored).ToString(),
                             "Total Questions - " + result.TotalAvailablePoints.ToString(),
                              "Total Score - " + string.Format("{0:0.##}", result.PercentScore) + "%");

                    if (action1.Equals("SAVE"))
                    {
                        var sess = PrepSessionData(result, mgr);
                        DependencyService.Get<ISaveAndLoad>().SaveText("temp.txt", sess);
                        await Navigation.PopModalAsync();
                    }
                    else if (action1.Equals("EXIT VIEW"))
                    {
                        await Navigation.PopModalAsync();
                    }
                }
            };
            
        }

        private Session PrepSessionData(Result result, QuestionSessionManager mgr)
        {
            Session thisSession = new Session
            {
                SessionResult = result,
                SessionQuestion = mgr.QuestionList
            };

            return thisSession;
        }

        private void SetNavButtons()
        {
            if (_next.Count > 0)
            {
                NextButton.IsEnabled = true;
            }
            else
            {

                NextButton.IsEnabled = false;

            }
            if (_prev.Count > 0)
            {
                PreviousButton.IsEnabled = true;
            }
            else
            {

                PreviousButton.IsEnabled = false;

            }
        }

        private void SetBindingContext(Question currItem)
        {
            if (currItem == null) return;
            QueueDirector = new QueueManager(_next, _prev, currItem);
            //Always push the first Item
            QueueDirector.Controller.Push(currItem);
            this.BindingContext = currItem;
        }

        private void PreviousButton_OnClicked(object sender, EventArgs e)
        {
            var item = _prev.Peek();
            item = _prev.Pop();
            QueueDirector.AddFromPrevious(item);
            this.BindingContext = item;
            SetNavButtons();
        }

        private void NextButton_OnClicked(object sender, EventArgs e)
        {
            var item = _next.Peek();
            item = Next.Pop();
            QueueDirector.AddFromNext(item);
            this.BindingContext = item;
            SetNavButtons();
        }

        private void AnswerALabel_OnClicked(object sender, EventArgs e)
        {

        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {

           await DisplayAlert("Test", "Blah Blah", "Test");

           
        }

        protected override bool OnBackButtonPressed()
        {
           
            return true;
        }
    }
}
