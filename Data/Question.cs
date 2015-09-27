using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;


namespace ExamPrep
{
    enum QuestionType { Objective = 1, MultipleChoice, Essay };

    public partial class Question : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Members & Properties
        private string _id;

        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private int _dispalyId;

        public int DispalyId
        {
            get { return _dispalyId; }
            set { SetProperty(ref _dispalyId, value); }
        }

        private string _questionText;

        public string QuestionText
        {
            get { return _questionText; }
            set { SetProperty(ref _questionText, value); }
        }


        private int _studyPlanId;

        public int StudyPlanId
        {
            get { return _studyPlanId; }
            set { SetProperty(ref _studyPlanId, value); }
        }

        private string _studyPlam;

        public string StudyPlan
        {
            get { return _studyPlam; }
            set { SetProperty(ref _studyPlam, value); }
        }

        private int _questionType;

        public int QuestionType
        {
            get { return _questionType; }
            set { SetProperty(ref _questionType, value); }
        }


        private string _userAnswerChoice;

        public string UserAnswerChoice
        {
            get { return _userAnswerChoice; }
            set { _userAnswerChoice = value; }
        }



        private string _answerChoiceA;

        public string AnswerChoiceA
        {
            get { return _answerChoiceA; }
            set { SetProperty(ref _answerChoiceA, value); }
        }

        private string _answerChoiceALabel = "A";

        public string AnswerChoiceALabel
        {
            get { return _answerChoiceALabel; }
            set { SetProperty(ref _answerChoiceALabel, value); }
        }

        private string _answerChoiceB;

        public string AnswerChoiceB
        {
            get { return _answerChoiceB; }
            set { SetProperty(ref _answerChoiceB, value); }
        }

        private string _answerChoiceBLabel = "B";

        public string AnswerChoiceBLabel
        {
            get { return _answerChoiceBLabel; }
            set { SetProperty(ref _answerChoiceBLabel, value); }
        }

        private string _answerChoiceC;

        public string AnswerChoiceC
        {
            get { return _answerChoiceC; }
            set
            {

                SetProperty(ref _answerChoiceC, value);
            }
        }

        private string _answerChoiceCLabel = "C";

        public string AnswerChoiceCLabel
        {
            get { return _answerChoiceCLabel; }
            set { SetProperty(ref _answerChoiceCLabel, value); }
        }

        private string _answerChoiceD;

        public string AnswerChoiceD
        {
            get { return _answerChoiceD; }
            set { SetProperty(ref _answerChoiceD, value); }
        }

        private string _answerChoiceDLabel = "D";

        public string AnswerChoiceDLabel
        {
            get { return _answerChoiceDLabel; }
            set
            {
                SetProperty(ref _answerChoiceDLabel, value);
            }
        }

        private string _answerChoiceE;

        public string AnswerChoiceE
        {
            get { return _answerChoiceE; }
            set { SetProperty(ref _answerChoiceE, value); }
        }

        private string _answerChoiceELabel = "E";

        public string AnswerChoiceELabel
        {
            get { return _answerChoiceELabel; }
            set { SetProperty(ref _answerChoiceELabel, value); }
        }

        private string _answerChoiceF;

        public string AnswerChoiceF
        {
            get { return _answerChoiceF; }
            set { SetProperty(ref _answerChoiceF, value); }
        }

        private string _answerChoiceFLabel = "F";

        public string AnswerChoiceFLabel
        {
            get { return _answerChoiceFLabel; }
            set { SetProperty(ref _answerChoiceFLabel, value); }
        }

        private string _answerChoiceG;

        public string AnswerChoiceG
        {
            get { return _answerChoiceG; }
            set { SetProperty(ref _answerChoiceG, value); }
        }

        private string _answerChoiceGLabel = "G";

        public string AnswerChoiceGLabel
        {
            get { return _answerChoiceGLabel; }
            set { SetProperty(ref _answerChoiceGLabel, value); }
        }

        private string _answerChoiceH;

        public string AnswerChoiceH
        {
            get { return _answerChoiceH; }
            set { SetProperty(ref _answerChoiceH, value); }
        }

        private string _answerChoiceHLabel = "H";

        public string AnswerChoiceHLabel
        {
            get { return _answerChoiceHLabel; }
            set { SetProperty(ref _answerChoiceHLabel, value); }
        }

        private IList<Answer> _answers;

        public IList<Answer> Answers
        {
            get { return _answers; }
            set { SetProperty(ref _answers, value); }
        }

        private string _rationale;

        public string Rationale
        {
            get { return _rationale; }
            set { SetProperty(ref _rationale, value); }
        }

        private string _correctAnswer;

        public string CorrectAnswer
        {
            get { return _correctAnswer; }
            set { SetProperty(ref _correctAnswer, value); }
        }
        #endregion


        public bool CheckAnswer(string ans)
        {
            return ans != null && ans.Equals(CorrectAnswer);

        }

        /// <summary>  SetProperty(ref
        /// Method to compare and replace a field's value and raise a 
        /// PropertyChanged notification if it was altered.
        /// </summary>
        /// <returns><c>true</c>, if field was set, <c>false</c> otherwise.</returns>
        /// <param name="field">Field.</param>
        /// <param name="value">Value.</param>
        /// <param name="propertyName">Property name.</param>
        /// <typeparam name="T">Field type.</typeparam>
        bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (!object.Equals(field, value))
            {
                field = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        private bool? _answeredCorrectly;

        public bool? AnsweredCorrectly
        {
            get { return _answeredCorrectly; }
            set { SetProperty(ref _answeredCorrectly, value); }
        }

        private bool _unAnswered;

        public bool Unanswered
        {
            get { return _unAnswered; }
            set { SetProperty(ref _unAnswered, value); }
        }
        private bool? _isFavorite;

        public bool? IsFavorite
        {
            get { return _isFavorite; }
            set { SetProperty(ref _isFavorite, value); }
        }

        public ICommand CheckAnswerCommand { protected set; get; }


        public ICommand SingleChoceCommand { protected set; get; }

        public Question()
        {

            this.CheckAnswerCommand = new Command<string>((key) =>
            {
                switch (key)
                {
                    case "A":
                        this.IsChoiceASelected = false;
                        if (CorrectAnswer.Equals(_answerChoiceALabel))
                        {
                            ShowRightAnswerA = true;
                        }
                        else
                        {
                            ShowWrongAnswerA = true;
                        }
                        break;
                    case "B":
                        this.IsChoiceBSelected = false;
                        if (CorrectAnswer.Equals(_answerChoiceBLabel))
                        {
                            ShowRightAnswerB = true;
                        }
                        else
                        {
                            ShowWrongAnswerB = true;
                        }
                        break;
                    case "C":
                        this.IsChoiceCSelected = false;
                        if (CorrectAnswer.Equals(_answerChoiceCLabel))
                        {
                            ShowRightAnswerC = true;
                        }
                        else
                        {
                            ShowWrongAnswerC = true;
                        }
                        break;
                    case "D":
                        this.IsChoiceDSelected = false;
                        if (CorrectAnswer.Equals(_answerChoiceDLabel))
                        {
                            ShowRightAnswerD = true;
                        }
                        else
                        {
                            ShowWrongAnswerD = true;
                        }
                        break;
                    case "E":
                        this.IsChoiceESelected = false;
                        if (CorrectAnswer.Equals(_answerChoiceELabel))
                        {
                            ShowRightAnswerE = true;
                        }
                        else
                        {
                            ShowWrongAnswerE = true;
                        }
                        break;
                    case "F":
                        this.IsChoiceFSelected = false;
                        if (CorrectAnswer.Equals(_answerChoiceFLabel))
                        {
                            ShowRightAnswerF = true;
                        }
                        else
                        {
                            ShowWrongAnswerF = true;
                        }
                        break;
                    case "G":
                        this.IsChoiceGSelected = false;
                        if (CorrectAnswer.Equals(_answerChoiceGLabel))
                        {
                            ShowRightAnswerG = true;
                        }
                        else
                        {
                            ShowWrongAnswerG = true;
                        }
                        break;
                    case "H":
                        this.IsChoiceHSelected = false;
                        if (CorrectAnswer.Equals(_answerChoiceHLabel))
                        {
                            ShowRightAnswerH = true;
                        }
                        else
                        {
                            ShowWrongAnswerH = true;
                        }
                        break;
                }
            }
            );
        }

        #region Answer Selection A
        private bool _isChoiceASelected = true;

        public bool IsChoiceASelected
        {
            get { return _isChoiceASelected; }
            set { SetProperty(ref _isChoiceASelected, value); }
        }

        private bool _showRightAnswerA;

        public bool ShowRightAnswerA
        {
            get { return _showRightAnswerA; }
            set { SetProperty(ref _showRightAnswerA, value); }
        }

        private bool _showWrongAnswerA;

        public bool ShowWrongAnswerA
        {
            get { return _showWrongAnswerA; }
            set { SetProperty(ref _showWrongAnswerA, value); }
        }
        #endregion

        #region Answer Selection B

        private bool _isChoiceBSelected = true;

        public bool IsChoiceBSelected
        {
            get { return _isChoiceBSelected; }
            set { SetProperty(ref _isChoiceBSelected, value); }
        }

        private bool _showRightAnswerB;

        public bool ShowRightAnswerB
        {
            get { return _showRightAnswerB; }
            set { SetProperty(ref _showRightAnswerB, value); }
        }

        private bool _showWrongAnswerB;

        public bool ShowWrongAnswerB
        {
            get { return _showWrongAnswerB; }
            set { SetProperty(ref _showWrongAnswerB, value); }
        }
        #endregion

        #region Answer Selection C
        private bool _isChoiceCSelected = true;

        public bool IsChoiceCSelected
        {
            get { return _isChoiceCSelected; }
            set { SetProperty(ref _isChoiceCSelected, value); }
        }

        private bool _showRightAnswerC;

        public bool ShowRightAnswerC
        {
            get { return _showRightAnswerC; }
            set { SetProperty(ref _showRightAnswerC, value); }
        }

        private bool _showWrongAnswerC;

        public bool ShowWrongAnswerC
        {
            get { return _showWrongAnswerC; }
            set { SetProperty(ref _showWrongAnswerC, value); }
        }
        #endregion

        #region Answer Selection D
        private bool _isChoiceDSelected = true;

        public bool IsChoiceDSelected
        {
            get { return _isChoiceDSelected; }
            set { SetProperty(ref _isChoiceDSelected, value); }
        }

        private bool _showRightAnswerD;

        public bool ShowRightAnswerD
        {
            get { return _showRightAnswerD; }
            set { SetProperty(ref _showRightAnswerD, value); }
        }

        private bool _showWrongAnswerD;

        public bool ShowWrongAnswerD
        {
            get { return _showWrongAnswerD; }
            set { SetProperty(ref _showWrongAnswerD, value); }
        }
        #endregion

        #region Answer Selection E
        private bool _isChoiceESelected = true;

        public bool IsChoiceESelected
        {
            get { return _isChoiceESelected; }
            set { SetProperty(ref _isChoiceESelected, value); }
        }

        private bool _showRightAnswerE;

        public bool ShowRightAnswerE
        {
            get { return _showRightAnswerE; }
            set { SetProperty(ref _showRightAnswerE, value); }
        }

        private bool _showWrongAnswerE;

        public bool ShowWrongAnswerE
        {
            get { return _showWrongAnswerE; }
            set { SetProperty(ref _showWrongAnswerE, value); }
        }
        #endregion

        #region Answer Selection F

        private bool _isChoiceFSelected = true;

        public bool IsChoiceFSelected
        {
            get { return _isChoiceFSelected; }
            set { SetProperty(ref _isChoiceFSelected, value); }
        }

        private bool _showRightAnswerF;

        public bool ShowRightAnswerF
        {
            get { return _showRightAnswerF; }
            set { SetProperty(ref _showRightAnswerF, value); }
        }

        private bool _showWrongAnswerF;

        public bool ShowWrongAnswerF
        {
            get { return _showWrongAnswerF; }
            set { SetProperty(ref _showWrongAnswerF, value); }
        }
        #endregion

        #region Answer Selection G
        private bool _isChoiceGSelected = true;

        public bool IsChoiceGSelected
        {
            get { return _isChoiceGSelected; }
            set { SetProperty(ref _isChoiceGSelected, value); }
        }

        private bool _showRightAnswerG;

        public bool ShowRightAnswerG
        {
            get { return _showRightAnswerG; }
            set { SetProperty(ref _showRightAnswerG, value); }
        }

        private bool _showWrongAnswerG;

        public bool ShowWrongAnswerG
        {
            get { return _showWrongAnswerG; }
            set { SetProperty(ref _showWrongAnswerG, value); }
        }
        #endregion

        #region Answer Selection H
        private bool _isChoiceHSelected = true;

        public bool IsChoiceHSelected
        {
            get { return _isChoiceHSelected; }
            set { SetProperty(ref _isChoiceHSelected, value); }
        }

        private bool _showRightAnswerH;

        public bool ShowRightAnswerH
        {
            get { return _showRightAnswerH; }
            set { SetProperty(ref _showRightAnswerH, value); }
        }

        private bool _showWrongAnswerH;

        public bool ShowWrongAnswerH
        {
            get { return _showWrongAnswerH; }
            set { SetProperty(ref _showWrongAnswerH, value); }
        }
        #endregion

        public int MaxCount
        {
            get; set;
        }

        public void Refresh()
        {
            ShowRightAnswerA = false;
            ShowRightAnswerB = false;
            ShowRightAnswerC = false;
            ShowRightAnswerD = false;
            ShowRightAnswerE = false;
            ShowRightAnswerF = false;
            ShowRightAnswerG = false;
            ShowRightAnswerH = false;
            ShowWrongAnswerA = false;
            ShowWrongAnswerB = false;
            ShowWrongAnswerC = false;
            ShowWrongAnswerD = false;
            ShowWrongAnswerE = false;
            ShowWrongAnswerF = false;
            ShowWrongAnswerG = false;
            ShowWrongAnswerH = false;
            IsChoiceASelected = true;
            IsChoiceBSelected = true;
            IsChoiceCSelected = true;
            IsChoiceDSelected = true;
            IsChoiceESelected = true;
            IsChoiceFSelected = true;
            IsChoiceGSelected = true;
            IsChoiceHSelected = true;
        }


        #region Points
        //This specifies the maximum point a student can score for this question//
        private int _points;

        //This specifies the maximum point a student can score for this question//
        public int Points
        {
            get { return _points; }
            set { SetProperty(ref _points, value); }
        }
        #endregion

        #region Duration
        //This specifies how long a student is expected to stay on this question//
        private float _duration;

        //This specifies how long a student is expected to stay on this question//
        public float Duration
        {
            get { return _duration; }
            set { SetProperty(ref _duration, value); }
        }
        #endregion



        private SessionType sessionModeType;

        public SessionType SessionMode
        {
            get { return sessionModeType; }
            set
            {
                if (value.Equals(SessionType.ExamMode))
                {
                    WireUpSelectSingleChoiceAnswer();
                }
                sessionModeType = value;

            }
        }

        private void WireUpSelectSingleChoiceAnswer()
        {
            this.SingleChoceCommand = new Command<string>((key) =>
            {
                switch (key)
                {
                    case "A":
                        this.IsChoiceASelected = false;
                        this.IsChoiceBSelected = true;
                        this.IsChoiceCSelected = true;
                        this.IsChoiceDSelected = true;
                        this.IsChoiceESelected = true;
                        this.IsChoiceFSelected = true;
                        this.IsChoiceGSelected = true;
                        this.IsChoiceHSelected = true;
                        ShowRightAnswerA = true;
                        ShowRightAnswerB = false;
                        ShowRightAnswerC = false;
                        ShowRightAnswerD = false;
                        ShowRightAnswerE = false;
                        ShowRightAnswerF = false;
                        ShowRightAnswerG = false;
                        ShowRightAnswerH = false;
                        UserAnswerChoice = _answerChoiceALabel;
                        break;
                    case "B":
                        this.IsChoiceBSelected = false;
                        this.IsChoiceASelected = true;
                        this.IsChoiceCSelected = true;
                        this.IsChoiceDSelected = true;
                        this.IsChoiceESelected = true;
                        this.IsChoiceFSelected = true;
                        this.IsChoiceGSelected = true;
                        this.IsChoiceHSelected = true;
                        ShowRightAnswerA = false;
                        ShowRightAnswerB = true;
                        ShowRightAnswerC = false;
                        ShowRightAnswerD = false;
                        ShowRightAnswerE = false;
                        ShowRightAnswerF = false;
                        ShowRightAnswerG = false;
                        ShowRightAnswerH = false;
                        UserAnswerChoice = _answerChoiceBLabel;
                        break;
                    case "C":
                        this.IsChoiceCSelected = false;
                        this.IsChoiceBSelected = true;
                        this.IsChoiceASelected = true;
                        this.IsChoiceDSelected = true;
                        this.IsChoiceESelected = true;
                        this.IsChoiceFSelected = true;
                        this.IsChoiceGSelected = true;
                        this.IsChoiceHSelected = true;
                        ShowRightAnswerA = false;
                        ShowRightAnswerB = false;
                        ShowRightAnswerC = true;
                        ShowRightAnswerD = false;
                        ShowRightAnswerE = false;
                        ShowRightAnswerF = false;
                        ShowRightAnswerG = false;
                        ShowRightAnswerH = false;
                        UserAnswerChoice = _answerChoiceCLabel;
                        break;
                    case "D":
                        this.IsChoiceDSelected = false;
                        this.IsChoiceBSelected = true;
                        this.IsChoiceASelected = true;
                        this.IsChoiceCSelected = true;
                        this.IsChoiceESelected = true;
                        this.IsChoiceFSelected = true;
                        this.IsChoiceGSelected = true;
                        this.IsChoiceHSelected = true;
                        ShowRightAnswerA = false;
                        ShowRightAnswerB = false;
                        ShowRightAnswerC = false;
                        ShowRightAnswerD = true;
                        ShowRightAnswerE = false;
                        ShowRightAnswerF = false;
                        ShowRightAnswerG = false;
                        ShowRightAnswerH = false;
                        UserAnswerChoice = _answerChoiceDLabel;
                        break;
                    case "E":
                        this.IsChoiceESelected = false;
                        this.IsChoiceBSelected = true;
                        this.IsChoiceASelected = true;
                        this.IsChoiceCSelected = true;
                        this.IsChoiceDSelected = true;
                        this.IsChoiceFSelected = true;
                        this.IsChoiceGSelected = true;
                        this.IsChoiceHSelected = true;
                        ShowRightAnswerA = false;
                        ShowRightAnswerB = false;
                        ShowRightAnswerC = false;
                        ShowRightAnswerD = false;
                        ShowRightAnswerE = true;
                        ShowRightAnswerF = false;
                        ShowRightAnswerG = false;
                        ShowRightAnswerH = false;
                        UserAnswerChoice = _answerChoiceELabel;
                        break;
                    case "F":
                        this.IsChoiceFSelected = false;
                        this.IsChoiceBSelected = true;
                        this.IsChoiceASelected = true;
                        this.IsChoiceCSelected = true;
                        this.IsChoiceDSelected = true;
                        this.IsChoiceESelected = true;
                        this.IsChoiceGSelected = true;
                        this.IsChoiceHSelected = true;
                        ShowRightAnswerA = false;
                        ShowRightAnswerB = false;
                        ShowRightAnswerC = false;
                        ShowRightAnswerD = false;
                        ShowRightAnswerE = false;
                        ShowRightAnswerF = true;
                        ShowRightAnswerG = false;
                        ShowRightAnswerH = false;
                        UserAnswerChoice = _answerChoiceFLabel;
                        break;
                    case "G":
                        this.IsChoiceGSelected = false;
                        this.IsChoiceBSelected = true;
                        this.IsChoiceASelected = true;
                        this.IsChoiceCSelected = true;
                        this.IsChoiceDSelected = true;
                        this.IsChoiceESelected = true;
                        this.IsChoiceFSelected = true;
                        this.IsChoiceHSelected = true;
                        ShowRightAnswerA = false;
                        ShowRightAnswerB = false;
                        ShowRightAnswerC = false;
                        ShowRightAnswerD = false;
                        ShowRightAnswerE = false;
                        ShowRightAnswerF = false;
                        ShowRightAnswerG = true;
                        ShowRightAnswerH = false;
                        UserAnswerChoice = _answerChoiceGLabel;
                        break;
                    case "H":
                        this.IsChoiceHSelected = false;
                        this.IsChoiceBSelected = true;
                        this.IsChoiceASelected = true;
                        this.IsChoiceCSelected = true;
                        this.IsChoiceDSelected = true;
                        this.IsChoiceESelected = true;
                        this.IsChoiceFSelected = true;
                        this.IsChoiceGSelected = true;
                        ShowRightAnswerA = false;
                        ShowRightAnswerB = false;
                        ShowRightAnswerC = false;
                        ShowRightAnswerD = false;
                        ShowRightAnswerE = false;
                        ShowRightAnswerF = false;
                        ShowRightAnswerG = false;
                        ShowRightAnswerH = true;
                        UserAnswerChoice = _answerChoiceHLabel;
                        break;
                }
            }
           );
        }

        public void RefreshForRandom()
        {
            this.IsChoiceASelected = true;
            this.IsChoiceBSelected = true;
            this.IsChoiceCSelected = true;
            this.IsChoiceDSelected = true;
            this.IsChoiceESelected = true;
            this.IsChoiceFSelected = true;
            this.IsChoiceGSelected = true;
            this.IsChoiceHSelected = true;
            ShowRightAnswerA = false;
            ShowRightAnswerB = false;
            ShowRightAnswerC = false;
            ShowRightAnswerD = false;
            ShowRightAnswerE = false;
            ShowRightAnswerF = false;
            ShowRightAnswerG = false;
            ShowRightAnswerH = false;
            UserAnswerChoice = string.Empty;
        }

        public void MarkAnswerForReport(Question quest)
        {
            if (quest.CheckAnswer(quest.UserAnswerChoice)) return;
            //Set wrong answer
            switch (quest.UserAnswerChoice)
            {
                case "A":
                    ShowRightAnswerA = false;
                    ShowWrongAnswerA = true;
                    IsChoiceASelected = false;
                    break;
                case "B":
                    ShowRightAnswerB = false;
                    ShowWrongAnswerB = true;
                    IsChoiceBSelected = false;
                    break;
                case "C":
                    ShowRightAnswerC = false;
                    ShowWrongAnswerC = true;
                    IsChoiceCSelected = false;
                    break;
                case "D":
                    ShowRightAnswerD = false;
                    ShowWrongAnswerD = true;
                    IsChoiceDSelected = false;
                    break;
                case "E":
                    ShowRightAnswerE = false;
                    ShowWrongAnswerE = true;
                    IsChoiceESelected = false;
                    break;
                case "F":
                    ShowRightAnswerF = false;
                    ShowWrongAnswerF = true;
                    IsChoiceFSelected = false;
                    break;
                case "G":
                    ShowRightAnswerG = false;
                    ShowWrongAnswerG = true;
                    IsChoiceGSelected = false;
                    break;
                case "H":
                    ShowRightAnswerH = false;
                    ShowWrongAnswerH = true;
                    IsChoiceHSelected = false;
                    break;

            }
            switch (quest.CorrectAnswer)
            {
                case "A":
                    ShowRightAnswerA = true;
                    ShowWrongAnswerA = false;
                    IsChoiceASelected = false;
                    break;
                case "B":
                    ShowRightAnswerB = true;
                    ShowWrongAnswerB = false;
                    IsChoiceBSelected = false;
                    break;
                case "C":
                    ShowRightAnswerC = true;
                    ShowWrongAnswerC = false;
                    IsChoiceCSelected = false;
                    break;
                case "D":
                    ShowRightAnswerD = true;
                    ShowWrongAnswerD = false;
                    IsChoiceDSelected = false;
                    break;
                case "E":
                    ShowRightAnswerE = true;
                    ShowWrongAnswerE = false;
                    IsChoiceESelected = false;
                    break;
                case "F":
                    ShowRightAnswerF = true;
                    ShowWrongAnswerF = false;
                    IsChoiceFSelected = false;
                    break;
                case "G":
                    ShowRightAnswerG = true;
                    ShowWrongAnswerG = false;
                    IsChoiceGSelected = false;
                    break;
                case "H":
                    ShowRightAnswerH = true;
                    ShowWrongAnswerH = false;
                    IsChoiceHSelected = false;
                    break;

            }
        }
    }
}
