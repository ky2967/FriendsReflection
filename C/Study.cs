using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C
{
    public class Study : INotifyPropertyChanged
    {
        public string name = "홍길동";
        public string Name
        {
            get { return name; }
            set 
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string school = "충암고";
        public string School
        {
            get { return school; }
            set 
            {
                school = value;
                OnPropertyChanged("School");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(info));
        }
    }
}
