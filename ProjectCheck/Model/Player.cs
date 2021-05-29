using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCheck.Model
{
    class Player : INotifyPropertyChanged
    {
        private string name;
        public string Name  
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public Player()
        {
            Name = "Player 1";
        }
        public void ChangePlayer()
        { 
            if(Name == "Player 2")
                Name= "Player 1";
            else 
                Name = "Player 2";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
