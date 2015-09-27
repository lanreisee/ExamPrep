using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamPrep
{
    public class StudyPlan : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _category;

        public string Category
        {
            get { return _category; }
            set { SetProperty(ref _category, value); }
        }

        private string _courseCode;

        public string CourseCode
        {
            get { return _courseCode; }
            set { SetProperty(ref _courseCode, value); }
        }

        private List<string> _webAddress;

        public List<string> WebAddress
        {
            get { return _webAddress; }
            set { SetProperty(ref _webAddress, value); }
        }



        /// <summary>
        /// Method to compare and replace a field's value and raise a 
        /// PropertyChanged notification if it was altered.
        /// </summary>
        /// <returns><c>true</c>, if field was set, <c>false</c> otherwise.</returns>
        /// <param name="field">Field.</param>
        /// <param name="value">Value.</param>
        /// <param name="propertyName">Property name.</param>
        /// <typeparam name="T">Field type.</typeparam>
        bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (!object.Equals(field, value))
            {
                field = value;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("{0}",
                this.Name);
        }
    }
}
