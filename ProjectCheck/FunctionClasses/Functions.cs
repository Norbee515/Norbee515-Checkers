using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjectCheck.FunctionClasses;
using ProjectCheck.Model;
using ProjectCheck.VM;
namespace ProjectCheck.FunctionClasses
{
    class Functions
    {

        public static ObservableCollection<ObservableCollection<Cell>> InitGameBoard(int[,] matrix)
        {

            ObservableCollection<ObservableCollection<Cell>> board = new ObservableCollection<ObservableCollection<Cell>>();

            for (int i = 0; i < 8; i++)
            {
                ObservableCollection<Cell> line = new ObservableCollection<Cell>();
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        Cell c = new Cell(i, j, GetImage(0),0);
                        line.Add(c);
                    }
                    else if (matrix[i, j] == 1)
                    {
                        Cell c = new Cell(i, j, GetImage(1),1);
                        line.Add(c);
                    }
                    else if (matrix[i, j] == 2)
                    {
                        Cell c = new Cell(i, j, GetImage(2),2);
                        line.Add(c);
                    }
                    else if (matrix[i, j] == -2)
                    {
                        Cell c = new Cell(i, j, GetImage(-2),-2);
                        line.Add(c);
                    }
                    else if (matrix[i, j] == 3)
                    {
                        Cell c = new Cell(i, j, GetImage(3),3);
                        line.Add(c);
                    }
                    else if (matrix[i, j] == -3)
                    {
                        Cell c = new Cell(i, j, GetImage(-3),-3);
                        line.Add(c);
                    }
                    else if (matrix[i, j] == 4)
                    {
                        Cell c = new Cell(i, j, GetImage(4), 4);
                        line.Add(c);
                    }
                    else if (matrix[i, j] == -4)
                    {
                        Cell c = new Cell(i, j, GetImage(-4), -4);
                        line.Add(c);
                    }
                    else if (matrix[i, j] == 5)
                    {
                        Cell c = new Cell(i, j, GetImage(5), 5);
                        line.Add(c);
                    }
                    else if (matrix[i, j] == -5)
                    {
                        Cell c = new Cell(i, j, GetImage(-5), -5);
                        line.Add(c);
                    }

                }
                board.Add(line);
            }
            return board;
            ;
        }

        public static string GetImage(int index)
        { switch (index) 
            { 
                case 1:
                    return "/ProjectCheck;component/Images/ProjectCheck_Black.png";
                case 2:
                    return "/ProjectCheck;component/Images/ProjectCheck_WhiteN.png";
                case -2:
                    return "/ProjectCheck;component/Images/ProjectCheck_BlackN.png";
                case 3:
                    return "/ProjectCheck;component/Images/ProjectCheck_WhiteK.png";
                case -3:
                    return "/ProjectCheck;component/Images/ProjectCheck_BlackK.png";
                case 4:
                    return "/ProjectCheck;component/Images/ProjectCheck_WhiteS.png";
                case -4:
                    return "/ProjectCheck;component/Images/ProjectCheck_BlackS.png";
                case 5:
                    return "/ProjectCheck;component/Images/ProjectCheck_WhiteKS.png";
                case -5:
                    return "/ProjectCheck;component/Images/ProjectCheck_BlackKS.png";
                default:
                    return "/ProjectCheck;component/Images/ProjectCheck_White.png";
            } }

        public static void AddShadows(Cell aux) =>Game.Shadows.Add(aux); 

        public static Cell PrevCell { get; set; }
        public static void KickShadow(Cell aux) => Game.Shadows.Remove(aux);
        public static void DeleteShadows()
        {
            foreach (Cell aux in Game.Shadows)
            { 
                    aux.CellImage = GetImage(1);
                    aux.Num = 1;
            }
            Game.Shadows.Clear();
        }

        public static void ReadScores()
        {
            string scores = "scoresFile.txt";
            if (File.Exists(scores))
            {
                string [] lines = File.ReadAllLines(scores);
                Game.WinsP1 = int.Parse(lines[0]);
                Game.WinsP2 = int.Parse(lines[1]);
            }
            else { Game.WinsP1 = 0;
                Game.WinsP2 = 0;
            }
        }
        public static void WriteScores()
        {
            string[] lines = { Game.WinsP1.ToString(), Game.WinsP2.ToString() };
            System.IO.File.WriteAllLines((System.IO.Path.GetFullPath("scoresFile.txt")), lines);
        }

        public static void CheckWin()
        {
            int whiteNumber = 0;
            int blackNumber = 0;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    whiteNumber += IsWhitePiece(Game.Gameboard[i][j].SimpleCell.Num);
                    blackNumber += IsBlackPiece(Game.Gameboard[i][j].SimpleCell.Num);
                }
            if (whiteNumber == 0)
            {
                Game.WinsP2 += 1;
                WriteScores();
                MessageBox.Show("Player 2 Won!");
                GameCommands.NewGame();
            }
            else if (blackNumber == 0)
            {
                Game.WinsP1 += 1;
                WriteScores();
                MessageBox.Show("Player 1 Won!");
                GameCommands.NewGame();
            }
        }

        public static void ChangeToKing(Cell cell)
        { if(cell.Num==2)
            { cell.Num = 3;
                cell.CellImage = GetImage(3);
            }
        else if(cell.Num==-2)
            { cell.Num = -3;
                cell.CellImage = GetImage(-3);
            }
        }
        public static void EatPiece(Cell cell)
        {
            int x = cell.X - PrevCell.X;
            int y = cell.Y - PrevCell.Y;
            if (x == -2 && y == -2)
            {
                if(IsPiece(Game.Gameboard[cell.X+1][cell.Y+1].SimpleCell.Num)!=0)
                { Game.Gameboard[cell.X + 1][cell.Y + 1].SimpleCell.Num = 1;
                   Game.Gameboard[cell.X + 1][cell.Y + 1].SimpleCell.CellImage = GetImage(1);
                    Game.Eated = true;
                }
            }
            if(x == -2 && y == 2)
            {
                if (IsPiece(Game.Gameboard[cell.X + 1][cell.Y - 1].SimpleCell.Num) != 0)
                {
                    Game.Gameboard[cell.X + 1][cell.Y - 1].SimpleCell.Num = 1;
                    Game.Gameboard[cell.X + 1][cell.Y - 1].SimpleCell.CellImage = GetImage(1);
                    Game.Eated = true;
                }
            }
            if(x == 2 && y == 2)
            {
                if (IsPiece(Game.Gameboard[cell.X - 1][cell.Y - 1].SimpleCell.Num) != 0)
                {
                    Game.Gameboard[cell.X - 1][cell.Y - 1].SimpleCell.Num = 1;
                    Game.Gameboard[cell.X - 1][cell.Y - 1].SimpleCell.CellImage = GetImage(1);
                    Game.Eated = true;
                }
            }
            if(x == 2 && y == -2)
            {
                if (IsPiece(Game.Gameboard[cell.X - 1][cell.Y + 1].SimpleCell.Num) != 0)
                {
                    Game.Gameboard[cell.X - 1][cell.Y + 1].SimpleCell.Num = 1;
                    Game.Gameboard[cell.X - 1][cell.Y + 1].SimpleCell.CellImage = GetImage(1);
                    Game.Eated = true;
                }
            }
        }
        public static int IsWhitePiece(int c)
        {
            if (c == 3 || c == 2)
                return c;
            return 0;
        }
        public static int IsBlackPiece(int c)
        {
            if (c == -3 || c == -2)
                return c;
            return 0;
        }

        public static int IsPiece(int c)
        {
            if (c == 3 || c == 2 || c == -3 || c == -2)
                return c;
            return 0;
        }
        public static int IsShadow(int c)
        {
            if (c == 5 || c == -5 || c == 4 || c == -4)
                return c;
            return 0;
        }
        
        public static int SameColor(int a,int b) 
        {
            if (IsBlackPiece(a)!=0 && IsBlackPiece(b)!=0)
                return 1;
            if (IsWhitePiece(a) != 0 && IsWhitePiece(b) != 0)
                return 1;          
            return 0;
        }
    }
}
