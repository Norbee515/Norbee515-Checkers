using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectCheck.FunctionClasses;
using ProjectCheck.Model;
using ProjectCheck.VM;
namespace ProjectCheck.VM
{
    class Game
    {
        public static int[,] Matrix { get; set; }

        public static Player Player { get; set; }

        Move mvp;

        public static List<Cell> Shadows = new List<Cell>();
        public static int WinsP1 { get; set; } 
        public static int WinsP2 { get; set; }

        public static bool Eated { get; set; }
        public static MultipleMoves MultipleMoves { get; set; }
        public Game()
        {
            Matrix = new int[,]
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
            ObservableCollection<ObservableCollection<Cell>> board = Functions.InitGameBoard(Matrix);
            mvp = new Move(board,Matrix);

            Gameboard = CellToCellVM(board);

            Functions.ReadScores();

            Player = new Player();

            MultipleMoves = new MultipleMoves(false);
        } 
        private ObservableCollection<ObservableCollection<CellVM>> CellToCellVM(ObservableCollection<ObservableCollection<Cell>> board)
        {
            ObservableCollection<ObservableCollection<CellVM>> result = new ObservableCollection<ObservableCollection<CellVM>>();
            for (int i = 0; i < board.Count; i++)
            {
                ObservableCollection<CellVM> line = new ObservableCollection<CellVM>();
                for (int j = 0; j < board[i].Count; j++)
                {
                    Cell c = board[i][j];
                    CellVM cellVM = new CellVM(c.X, c.Y, c.CellImage,c.Num,mvp);
                    line.Add(cellVM);
                }
                result.Add(line);
            }
            return result;
        }
        public static ObservableCollection<ObservableCollection<CellVM>> Gameboard { get; set; }


    }
}
