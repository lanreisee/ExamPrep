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
    public class Answer : INotifyPropertyChanged
    {
        private string _label;

        public string Label
        {
            get { return _label; }
            set { SetProperty(ref _label, value); }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private string _displayLabel;

        public string DisplayLabel
        {
            get { return _displayLabel; }
            set { SetProperty(ref _displayLabel, value); }
        }


        /// <summary>  SetProperty(ref
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
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

       
    }
}
