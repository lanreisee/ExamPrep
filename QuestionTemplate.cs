using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
    public class QuestionTemplate
    {
        public QuestionTemplate()
        {
            UniqueGuid = Guid.NewGuid();
        }

        public string CompanyName { get; set; }

        public QuestionTemplateDetail CurrentTemplate { get; set; }

        public Dictionary<int, string> Templates { get; set; }

        public Guid UniqueGuid { get; private set; }  
    }

    public class QuestionTemplateDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FileLocation { get; set; }

        public string FileName { get; set; }

        public string Version { get; set; }

        public DateTime YearReleased { get; set; }

        public List<QuestionTemplateCategory> StudyCategory { get; set; }

    }

    public class QuestionTemplateCategory
    {
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public int MaxCount { get; set; }

        public string NameCount
        {
            get { return CategoryName + "   [" + MaxCount.ToString() + "] "; }
        }
    }
}
