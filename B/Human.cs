using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B
{
    public class Human : INotifyPropertyChanged
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

        public string address = "역촌동";
        public string Address
        {
            get { return address; }
            set
            {
                address = value;

                OnPropertyChanged("Address");
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
