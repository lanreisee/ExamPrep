using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ExamPrep
{
    public static class StudyPlanFactory
    {
        public static IList<StudyPlan> StudyPlans { get; private set; }

        static StudyPlanFactory() //this will call a deserializer object to get data, for now manually generating it
        {
            if (AppCache.CurrentTemplate == null)
            {
                var list = AppCache.GetData(null, null);
            }
            if (AppCache.CurrentTemplate == null) return;
            var temp = AppCache.CurrentTemplate.CurrentTemplate.StudyCategory;
            StudyPlans = new ObservableCollection<StudyPlan>();
            foreach (var studyPlan in temp)
            {
                StudyPlans.Add(new StudyPlan
                {
                    Name = studyPlan.CategoryName,
                    Category = studyPlan.CategoryName,
                });
            }
        }
    }
}
