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
    public class AppMenu : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly List<string> _menuList = new List<string>(new String[] {"Exam Mode", "Practise Mode", "Topics", "MyHistory", "Share"}); 

        private readonly List<string> _myHistoryList = new List<string>(new String[] { "Answered Correctly", "Answered Incorrectly", "Unanswered", "Favorties"}); 
        private string _menuName;

        public string MenuName
        {
            get { return _menuName; }
            set { SetProperty(ref _menuName, value); }
        }

        private int _menuId;

        public int MenuId
        {
            get { return _menuId; }
            set { SetProperty(ref _menuId, value); }
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
    }
}
