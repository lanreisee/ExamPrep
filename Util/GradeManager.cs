using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
   public class GradeManager
    {
       public static Result GradeSession(List<Question> question)
       {
           var totalAvailablePoints = default(int);
           var totalPointsScored = default(int);
           foreach (var quest in question)
           {
               totalAvailablePoints += quest.Points;
               if (!(string.IsNullOrEmpty(quest.UserAnswerChoice)) && quest.CheckAnswer(quest.UserAnswerChoice))
               {
                   totalPointsScored += quest.Points;
               }
           }

           double result = ((double)totalPointsScored / totalAvailablePoints) * 100;

            return new Result
            {
                TotalAvailablePoints = totalAvailablePoints,
                TotalPointsScored = totalPointsScored,
                PercentScore = result
            };
       }
    }
}
