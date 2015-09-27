using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExamPrep
{
   public  class AppCache
    {
        public static Dictionary<Guid, List<Question>> QuestionCache = new Dictionary<Guid, List<Question>>();

        public static int ItemPressedCount { get; set; }

        public static QuestionTemplate CurrentTemplate { get; private set; }
        public Dictionary<Guid, List<Question>> CurrentTemplateDataDictionary { get; private set; }

       public static async Task<List<Question>> GetData(string filename, string other)
       {
           if (QuestionCache != null && Application.Current.Properties.ContainsKey("QuestionTemplate"))
           {
               object currentTemplate = null;
               if (Application.Current.Properties.TryGetValue("QuestionTemplate", out currentTemplate))
               {
                   var currTemplate = currentTemplate as QuestionTemplate;
                   List<Question> retList = null;
                   if (currTemplate != null && QuestionCache != null &&
                       QuestionCache.ContainsKey(currTemplate.UniqueGuid))
                   {
                       CurrentTemplate = currTemplate;
                       if (QuestionCache.TryGetValue(currTemplate.UniqueGuid, out retList))
                       {
                           if (retList != null)
                           {

                               return retList;
                           }
                       }
                   }
               }
           }
           var list = await DependencyService.Get<IQuestionLoader>().GetQuestions("QuestionData.xml", string.Empty);
           ExtractStudyPlanGrouping(list);
            SaveInCache(list);
           return list;
       }

        public static IList<Question> AssignNumberToQuestion(IList<Question> questionList, SessionType type)
        {
            if (questionList == null) return null;
            var totalNumber = questionList.Count;
            for (int i = 0; i < totalNumber; i++)
            {
                questionList[i].DispalyId = i + 1;
                questionList[i].MaxCount = totalNumber;
                questionList[i].SessionMode = type;
                questionList[i].Points = 1; //This line will be removed, it should come from the data
            }
            return questionList;
        }

        private static void ExtractStudyPlanGrouping(List<Question> list)
       {
           
            if (list != null)
            {
                var grps = list.GroupBy(x => x.StudyPlan);
                var grpings = grps.Select(grp1 => new QuestionTemplateCategory
                {
                    CategoryName = grp1.Key, MaxCount = grp1.Count(),
                }).ToList();

                if (CurrentTemplate == null)
                {
                    var curTem = TryGetCurrentTemplate();
                    if (curTem != null)
                    {
                        curTem.CurrentTemplate.StudyCategory = grpings;
                    }
                }
            }
        }

       private static QuestionTemplate TryGetCurrentTemplate()
       {
           
           object currentTemplate = null;
           if (!Application.Current.Properties.TryGetValue("QuestionTemplate", out currentTemplate)) return null;
           var currTemplate = currentTemplate as QuestionTemplate;

           return currTemplate;
       }

       public async void SetData()
       {
           
       }

        private static void SaveInCache(List<Question> list)
        {
            if (CurrentTemplate == null)
            {
                object currentTemplate = null;

                if (Application.Current.Properties.TryGetValue("QuestionTemplate", out currentTemplate))
                {
                    var currTemplate = currentTemplate as QuestionTemplate;
                    if (currentTemplate != null)
                    {
                        CurrentTemplate = currTemplate;
                    }
                    else
                    {
                        //throw application wide exception
                    }
                }
            }
            if (CurrentTemplate != null && !QuestionCache.ContainsKey(CurrentTemplate.UniqueGuid))
            {
                QuestionCache.Add(CurrentTemplate.UniqueGuid, list);
            }
            else
            {
                //throw application wide exception
            }
        }
    }
}
