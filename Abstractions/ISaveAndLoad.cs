using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
   public interface ISaveAndLoad
   {
       void SaveText(string filename, Session currentSession);
       string LoadText(string filename);
        ObservableCollection<MyHistory> GetSavedFiles(string path);
   }
}
