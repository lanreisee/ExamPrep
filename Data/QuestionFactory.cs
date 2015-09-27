using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep.Data
{
    public class QuestionFactory
    {
        public static IList<Question> QuestionList { get; private set; }

        public QuestionFactory()
        {
            //Create question list from template
        }
    }
}
