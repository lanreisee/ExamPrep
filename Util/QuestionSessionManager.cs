using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
    public enum SessionType { ExamMode = 1, PractiseMode }
    public class QuestionSessionManager
    {

        public QuestionSessionManager(List<Question> questList, SessionType sesMode)
        {
            SessionMode = sesMode;
            QuestionList = questList;
        }

        public List<Question> QuestionList { get; set; }

        public SessionType SessionMode { get; set; }

       
    }
}
