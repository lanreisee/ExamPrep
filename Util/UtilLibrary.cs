using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
   public class UtilLibrary
    {
       public   static IList<Question> GetRandoms(Question[] sampleList)
       {
           return GetRandoms(sampleList, 0);
       }

       public   static IList<Question> GetRandoms(Question[] sampleList, int nosToGet)
        {
            var rand = new Random();
            var result = new Question[nosToGet];
            var count = sampleList.Length;

            for (int i = 0; i < nosToGet; i++)
            {
                var index = rand.Next(count);
                result[i] = sampleList[index];
                sampleList[index] = sampleList[--count];
            }
            return result;
        }
    }
}
