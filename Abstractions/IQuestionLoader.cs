using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
   public interface IQuestionLoader
   {
       Task<List<Question>> GetQuestions(string filename, string text);
   }
}
