using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCheck.FunctionClasses;
using ProjectCheck.Model;
using ProjectCheck.VM;

namespace ProjectCheck.Model
{
    class MultipleMoves : INotifyPropertyChanged
    {
            private bool mmove;
            public bool MMove
            {
                get { return mmove; }
                set
                {
                mmove = value;
                NotifyPropertyChanged("MMove");
            }
            }

            public MultipleMoves(bool mmove)
            {
                this.mmove=mmove;
                started = true; 
        }

        private bool started=true;
        public bool Started
        {
            get { return started; }
            set
            {
                started = value;
                NotifyPropertyChanged("Started");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        
    }
}
