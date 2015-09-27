using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
    public class Session
    {
        public Result SessionResult { get; set; }

        public List<Question> SessionQuestion { get; set; }

        public TimeSpan SessionDuration { get; set; }

        public int SessionId { get; set; }
    }
}
