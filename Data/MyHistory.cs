using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ExamPrep.Annotations;

namespace ExamPrep
{
    public class MyHistory : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _displayName;

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        private int _myHistoryId;

        public int MyHistoryId
        {
            get { return _myHistoryId; }
            set { _myHistoryId = value; }
        }

        public string Path { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

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
    }
}
