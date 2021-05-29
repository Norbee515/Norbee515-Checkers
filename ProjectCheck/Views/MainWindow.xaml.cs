using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectCheck.FunctionClasses;
using ProjectCheck.Model;
using ProjectCheck.VM;
namespace ProjectCheck.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Window about = new About();
            about.Show();
        }
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            GameCommands.NewGame();
        }
        private void SaveGame_Click(object sender, RoutedEventArgs e)
        {
            GameCommands.SaveGame();
        }
        private void OpenGame_Click(object sender, RoutedEventArgs e)
        {
            GameCommands.OpenGame();
        }
        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            GameCommands.Statistics();
        }
    }
}
