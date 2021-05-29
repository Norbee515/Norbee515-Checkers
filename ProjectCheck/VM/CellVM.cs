using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using ProjectCheck.FunctionClasses;
using ProjectCheck.Model;
using ProjectCheck.VM;
namespace ProjectCheck.VM
{
    class CellVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        Move mvp;
        public CellVM(int x, int y, string displayed, int num, Move mvp)
        {
            SimpleCell = new Cell(x, y, displayed,num);
            this.mvp = mvp;
        }
        private Cell simpleCell;
        public Cell SimpleCell
        {
            get { return simpleCell; }
            set
            {
                simpleCell = value;
                NotifyPropertyChanged("SimpleCell");            
            }
        }

        private ICommand clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                {                   
                    clickCommand = new RelayCommand<Cell>(mvp.ClickAction);      
                }               
                return clickCommand;
            }
        }
    }
}
