using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProjectCheck.FunctionClasses;
using ProjectCheck.Model;
using ProjectCheck.VM;
using System.Windows.Input;

namespace ProjectCheck.FunctionClasses
{
    class GameCommands
    {
        public static void NewGame()
        {
            int [,] Matrix = new int[,]
        {
            { 0, 2, 0, 2, 0, 2, 0, 2},
            { 2, 0, 2, 0, 2, 0, 2, 0},
            { 0, 2, 0, 2, 0, 2, 0, 2},
            { 1, 0, 1, 0, 1, 0, 1, 0},
            { 0, 1, 0, 1, 0, 1, 0, 1},
            {-2, 0,-2, 0, -2, 0,-2, 0},
            { 0,-2, 0, -2, 0,-2, 0,-2},
            {-2, 0,-2, 0,-2, 0,-2, 0},
        };
            for (int i = 0; i < 8; i++)
            {       
                for (int j = 0; j < 8; j++)
                {
                    Game.Gameboard[i][j].SimpleCell.Num = Matrix[i,j];
                    Game.Gameboard[i][j].SimpleCell.CellImage = Functions.GetImage(Matrix[i, j]);
                }
            }
            Game.Player.Name = "Player 1";
            Game.MultipleMoves.MMove = false;
            Game.MultipleMoves.Started = true;
        }
        public static void SaveGame()
        {
            ObservableCollection<ObservableCollection<CellVM>> my_mat = Game.Gameboard;

            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt"
            };

            if (dialog.ShowDialog() == true)
            {
                using (TextWriter tw = new StreamWriter(dialog.FileName))
                {
                    tw.Write(Game.WinsP1);
                    tw.WriteLine();
                    tw.Write(Game.WinsP2);
                    tw.WriteLine();
                    tw.Write(Game.Player.Name);
                    tw.WriteLine();
                    tw.Write(Game.MultipleMoves.Started);
                    tw.WriteLine();
                    tw.Write(Game.MultipleMoves.MMove);
                    tw.WriteLine();
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            tw.Write(my_mat[i][j].SimpleCell.Num + " ");
                        }
                        tw.WriteLine();
                    }
                }
            }
            MessageBox.Show("Game Saved!");
        }
        public static void OpenGame()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text files(*.txt)|*.txt";
            openFile.ShowDialog();
            string myFileName = openFile.FileName;
            string[] lines = File.ReadAllLines(myFileName);
            Game.WinsP1 = int.Parse(lines[0]);
            Game.WinsP2 = int.Parse(lines[1]);
            Game.Player.Name = lines[2];
            Game.MultipleMoves.Started = bool.Parse(lines[3]);
            Game.MultipleMoves.MMove = bool.Parse(lines[4]);
            lines = lines.Skip(5).ToArray();
            for (int i=0;i<8;i++)
            { 
                string[] numbers = lines[i].Split(' ');
                for(int j=0;j<8;j++)
                {
                    Game.Gameboard[i][j].SimpleCell.Num = int.Parse(numbers[j]);
                    Game.Gameboard[i][j].SimpleCell.CellImage = Functions.GetImage(int.Parse(numbers[j]));
                    if (Functions.IsShadow(Game.Gameboard[i][j].SimpleCell.Num)!=0)
                        Functions.AddShadows(Game.Gameboard[i][j].SimpleCell);
                }
            }
            MessageBox.Show("Game Loaded!");
        }
        public static void Statistics()
        { MessageBox.Show($"Player 1 score: {Game.WinsP1} \nPlayer 2 score: {Game.WinsP2}"); }
 
    }
}
