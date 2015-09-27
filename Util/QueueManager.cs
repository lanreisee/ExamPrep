using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
    public class QueueManager
    {
        public QueueManager(Stack<Question> next, Stack<Question> previous, Question startItem)
        {
            Controller = new Stack<Question>();
            Controller.Push(startItem);
            NextQueue = next;
            PreviousQueue = previous;
        }
        public IList<Question> MasterList = new List<Question>(); 
        public Stack<Question> Controller { get; set; }

        public Stack<Question> NextQueue { get; set; }

        public Stack<Question> PreviousQueue { get; set; }

        public void AddFromNext(Question currItem)
        {
            if (Controller == null) return;
            if ( Controller.Count > 0)
            {
                //then pop the item on the controller  and put on the Previous stack
                if (PreviousQueue != null && currItem != null)
                {
                    var item = Controller.Pop();
                    PreviousQueue.Push(item);
                }
            }

           Controller.Push(currItem);
        }

        public void AddFromPrevious(Question currItem)
        {
            if (Controller == null) return;
            if (Controller.Count > 0)
            {
                //then pop the item on the controller  and put on the Previous stack
                if (NextQueue != null && currItem != null)
                {
                    var item = Controller.Pop();
                    NextQueue.Push(item);
                }
            }

            Controller.Push(currItem);
        }
       
    }
}
