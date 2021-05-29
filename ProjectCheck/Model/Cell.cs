using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCheck.FunctionClasses;
using ProjectCheck.Model;
using ProjectCheck.VM;
namespace ProjectCheck.Model
{
    class Cell : INotifyPropertyChanged
    {
        private int x;
        private int y;
        private int num;
        private string cellImage;
        public int X
        {
            get { return x; }
            set
            {
                x = value;
                NotifyPropertyChanged("X");
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                NotifyPropertyChanged("Y");
            }
        }
        public int Num
        {
            get { return num; }
            set
            {
                num = value;
                NotifyPropertyChanged("Num");
            }
        }
        public string CellImage
        {
            get { return cellImage; }
            set
            {
                cellImage = value;
                NotifyPropertyChanged("CellImage");
            }
        }
        public Cell(int x, int y, string img,int num)
        {
            this.X = x;
            this.Y = y;
            this.CellImage = img;
            this.Num = num;
        }
   
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
