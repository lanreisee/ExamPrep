using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ExamPrep.Annotations;

namespace ExamPrep
{
    public class AppMenuFactory
    {
        public static IList<AppMenu> MenuList { get; private set; }

        public static IList<MyHistory> HistoryList { get; private set; }

        public static IList<ExamModeMenu> ExamMenuList { get; private set; }


        private readonly List<string> _menuList = new List<string>(new String[] { "Exam Mode", "Practise Mode", "Topics", "MyHistory", "Share" });

        private readonly List<string> _myHistoryList = new List<string>(new String[] { "Answered Correctly", "Answered Incorrectly", "Unanswered", "Favorties" });

        private readonly List<string> _examModeQuestionNo = new List<string>(new String[] { "10", "20", "30", "40", "50", "60", "70", "80", "90", "100", "150" }); 

        private const string EXAM_MODE = "Exam Mode";
        private const string PRACTISE_MODE = "Practise Mode";
        private const string TOPIC = "Topics";
        private const string MY_PROGRESS = "My Progress";
        private const string SHARE = "Share";
        private const string ANSWERED_CORRECTLY = "Answered Correctly";
        private const string ANSWERED_INCORRECTLY = "Answered Incorrectly";
        private const string UNANSWERED = "Unanswered";
        private const string FAVORITES = "Favorites";
        private const string MNEMONICS = "Mnemonics";
        private const string TERMINOLOGY = "Terminology";



        static AppMenuFactory()
        {
            MenuList = new ObservableCollection<AppMenu>
            {
                new AppMenu
                {
                    MenuId = 1,
                    MenuName = EXAM_MODE
                },
                new AppMenu
                {
                    MenuId = 2,
                    MenuName = PRACTISE_MODE
                },
                new AppMenu
                {
                    MenuId = 3,
                    MenuName = MY_PROGRESS
                },
                new AppMenu
                {
                    MenuId = 4,
                    MenuName = MNEMONICS
                },
                new AppMenu
                {
                    MenuId = 5,
                    MenuName = TERMINOLOGY
                },
                new AppMenu
                {
                    MenuId = 6,
                    MenuName = SHARE
                },
            };

            HistoryList = new ObservableCollection<MyHistory>
            {
                new MyHistory
                {
                    Name = ANSWERED_CORRECTLY,
                    DisplayName = ANSWERED_CORRECTLY,
                    MyHistoryId = 1
                },
                new MyHistory
                {
                    Name = ANSWERED_INCORRECTLY,
                    DisplayName = ANSWERED_INCORRECTLY,
                    MyHistoryId = 2
                },
                 new MyHistory
                {
                    Name = UNANSWERED,
                    DisplayName = UNANSWERED,
                    MyHistoryId = 3
                },
                new MyHistory
                {
                    Name = FAVORITES,
                    DisplayName = FAVORITES,
                    MyHistoryId = 4
                },

            };

            ExamMenuList = new ObservableCollection<ExamModeMenu>
            {
                new ExamModeMenu
                {
                   ModeName = "Random Session",
                   ModeNameId = 1
                },
               new ExamModeMenu
                {
                   ModeName = "Category Session",
                   ModeNameId = 2
                }


            };


        }

        public static ObservableCollection<MyHistory> CreateHistoryList(List<string> list)
        {
            
            var ret = list.Select(lis => new MyHistory
            {
                Name = lis, DisplayName = lis,
            }).ToList();
            return new ObservableCollection<MyHistory>(ret.OrderBy(x => x.MyHistoryId));
        }
    }

    public class ExamModeQuestionNo : INotifyPropertyChanged
    {
        public ExamModeQuestionNo()
        {
            try
            {
                Category = AppCache.CurrentTemplate.CurrentTemplate.StudyCategory;
            }
            catch (Exception ex)
            {
                    
                throw new Exception("Unable to get ");
            }
            

        }

        public int MaxQuestionNo
        {
            get { return Category != null ? Category.Sum(x => x.MaxCount) : 0; } 
            
        }


        private int _noOfQuestions;

        public int NoOfQuestions
        {
            get { return _noOfQuestions; }
            set { SetProperty(ref _noOfQuestions, value); }
        }

        public List<QuestionTemplateCategory> Category { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
        public const string TEN = "10";
        public const string TWENTY = "20";
        public const string THIRTY = "30";
        public const string FOURTY = "40";
        public const string FIFTY = "50";
        public const string SIXTY = "60";
        public const string SEVENTY = "70";
        public const string EIGHTY = "80";
        public const string NINETY = "90";
        public const string HUNDRED = "100";
        public const string ONETWENTY = "120";
        public const string ONEFIFTY = "150";

        private string _ten = TEN;

        public string Ten
        {
            get { return _ten; }
            set { SetProperty(ref _ten, value); }
        }


        private string _twenty = TWENTY;

        public string Twenty
        {
            get { return _twenty; }
            set { SetProperty(ref _twenty, value); }
        }

        private string _thirty = THIRTY;

        public string Thirty
        {
            get { return _thirty; }
            set { SetProperty(ref _thirty, value); }
        }

        private string _forty = FOURTY;

        public string Forty
        {
            get { return _forty; }
            set { SetProperty(ref _forty, value); }
        }

        private string _fifty = FIFTY;

        public string Fifty
        {
            get { return _fifty; }
            set { SetProperty(ref _fifty, value); }
        }

        private string _sixty = SIXTY;

        public string Sixty
        {
            get { return _sixty; }
            set { SetProperty(ref _sixty, value); }
        }

        private string _seventy = SEVENTY;

        public string Seventy
        {
            get { return _seventy; }
            set { SetProperty(ref _seventy, value); }
        }

        private string _eighty = EIGHTY;

        public string Eighty
        {
            get { return _eighty; }
            set { SetProperty(ref _eighty, value); }
        }

        private string ninety = NINETY;

        public string Ninety
        {
            get { return ninety; }
            set { SetProperty(ref ninety, value); }
        }

        private string _hundred = HUNDRED;

        public string Hundred
        {
            get { return _hundred; }
            set { SetProperty(ref _hundred, value); }
        }

        private string _oneTwenty = ONETWENTY;

        public string OneTwenty
        {
            get { return _oneTwenty; }
            set { SetProperty(ref _oneTwenty, value); }
        }

        private string _oneFifty = ONEFIFTY;

        public string OneFifty
        {
            get { return _oneFifty; }
            set { SetProperty(ref _oneFifty, value); }
        }


        bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (!object.Equals(field, value))
            {
                field = value;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
    }

    public static class AppFontFamily
    {
        public static string HelveticaNeue = "Helvetica Neue";
        public static string Avenir = "Avenir";
        public static string Baskerville = "Baskerville";
        public static string Hoefler = "Hoefler Text";
        public static string Verdana = "Verdana";

        public static string Droid_Gentium = "Gentium";
        public static string Droid_RobotoSans = "Roboto Sans";
        public static string Droid_RobotoSansMono = "Roboto Sans Mono";
        public static string Droid_RobotoSerif = "Roboto Serif";
        //other Android Fonts to research - Open Sans, Roboto, Lato, PT Sans, Source Sans Pro, Exo, Exo2, Ubuntu, Istok Web, Nobile
        //Other top five are Alte Haas Grotesk, Anivers, DozenPro, Nobile, Roboto
        //https://www.template.net/design-templates/web-elements/45-stunning-android-fonts-make-your-device-more-lookable/
    }
}
