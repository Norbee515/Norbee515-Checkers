using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCheck.FunctionClasses;
using ProjectCheck.Model;
using ProjectCheck.VM;
namespace ProjectCheck.FunctionClasses
{
    class PieceClick
    {
        public static void Click_BlackNForShadow(Cell cell)
        {
            Functions.PrevCell = cell;
            Click_UpRowForNeighb(cell,-4);
            Click_BlackNForShadowJump(cell);
        }
        public static void Click_WhiteNForShadow(Cell cell)
        {
            Functions.PrevCell = cell;
            Click_DownRowForNeighb(cell,4);
            Click_WhiteNForShadowJump(cell);
        }
        public static void Click_WhiteKForShadow(Cell cell)
        {
            Functions.PrevCell = cell;
            Click_UpRowForNeighb(cell, 5);
            Click_DownRowForNeighb(cell, 5);
            Click_WhiteKForShadowJump(cell);
        }
        public static void Click_BlackKForShadow(Cell cell)
        {
            Functions.PrevCell = cell;
            Click_UpRowForNeighb(cell, -5);
            Click_DownRowForNeighb(cell, -5);
            Click_BlackKForShadowJump(cell);
        }     
        public static void Click_TheShadow(Cell cell,int num)
        {
            Game.Eated = false;
            int x = cell.X;
            int y = cell.Y;    
            Game.Gameboard[x][y].SimpleCell.CellImage = Functions.GetImage(num);
            Game.Gameboard[x ][y].SimpleCell.Num = num;
            Functions.KickShadow(cell);
            Functions.DeleteShadows();   
            if(Functions.PrevCell !=null)
            {
                Functions.EatPiece(cell);
                if (Functions.IsPiece(Functions.PrevCell.Num) != 0)
                {
                    Functions.PrevCell.Num = 1;
                    Functions.PrevCell.CellImage = Functions.GetImage(1);
                }               
            }
            if (x == 0 || x == 7)
            {
                Functions.ChangeToKing(Game.Gameboard[x][y].SimpleCell);
            }
            if (Game.MultipleMoves.MMove == true && Game.Eated == true)
            {
                if (Game.Player.Name == "Player 2")
                {
                    Functions.DeleteShadows();
                    if(cell.Num==-2)
                    Click_BlackNForShadowJump(cell);
                    if(cell.Num==-3)
                    Click_BlackKForShadowJump(cell);
                    if (Game.Shadows.Count > 0)
                    {
                        Move.MovePiece(Game.Shadows[0]);
                    }
                }
                else
                {
                    Functions.DeleteShadows();
                    if (cell.Num == 2)
                        Click_WhiteNForShadowJump(cell);
                    if (cell.Num == 3)
                        Click_WhiteKForShadowJump(cell);
                    if (Game.Shadows.Count > 0)
                    {
                        Move.MovePiece(Game.Shadows[0]);
                    }
                }
                
            }
        }     
        public static void ChangeCell(int x,int y,int num)
        {
            if (Functions.IsPiece(Game.Gameboard[x][y].SimpleCell.Num) == 0)
            {
                Game.Gameboard[x][y].SimpleCell.CellImage = Functions.GetImage(num);
                Game.Gameboard[x][y].SimpleCell.Num = num;
                Functions.AddShadows(Game.Gameboard[x][y].SimpleCell);
            }
        }
        public static void Click_BlackNForShadowJump(Cell cell)
        {
            Functions.PrevCell = cell;
            Click_UpRowForJumpNeighb(cell, -4);

        }
        public static void Click_WhiteNForShadowJump(Cell cell)
        {
            Functions.PrevCell = cell;
            Click_DownRowForJumpNeighb(cell, 4);
        }
        public static void Click_WhiteKForShadowJump(Cell cell)
        {
            Functions.PrevCell = cell;
            Click_UpRowForJumpNeighb(cell, 5);
            Click_DownRowForJumpNeighb(cell, 5);
        }
        public static void Click_BlackKForShadowJump(Cell cell)
        {
            Functions.PrevCell = cell;
            Click_UpRowForJumpNeighb(cell, -5);
            Click_DownRowForJumpNeighb(cell, -5);
        }

        public static void Click_UpRowForNeighb(Cell cell,int aux)
        {
            int x = cell.X;
            int y = cell.Y;
            Functions.PrevCell = cell;
            if (x - 1 >= 0 && y - 1 >= 0 && Game.Gameboard[x - 1][y - 1].SimpleCell.Num == 1)
            {
                ChangeCell(x - 1, y - 1, aux);
            }
            if (x - 1 >= 0 && y + 1 < 8 && Game.Gameboard[x - 1][y + 1].SimpleCell.Num == 1)
            {
                ChangeCell(x - 1, y + 1, aux);
            }

        }
        public static void Click_DownRowForNeighb(Cell cell,int aux)
        {
            Functions.PrevCell = cell;
            int x = cell.X;
            int y = cell.Y;
            if (x + 1 < 8 && y - 1 >= 0 && Game.Gameboard[x + 1][y - 1].SimpleCell.Num == 1)
            {
                ChangeCell(x + 1, y - 1, aux);
            }
            if (x + 1 < 8 && y + 1 < 8 && Game.Gameboard[x + 1][y + 1].SimpleCell.Num == 1)
            {
                ChangeCell(x + 1, y + 1, aux);
            }
        }

        public static void Click_UpRowForJumpNeighb(Cell cell,int aux)
        {
            int x = cell.X;
            int y = cell.Y;
            Functions.PrevCell = cell;
            if (x - 2 >= 0 && y + 2 < 8 && Functions.SameColor(Game.Gameboard[x - 1][y + 1].SimpleCell.Num,cell.Num) == 0)
            {
                if (Functions.IsPiece(Game.Gameboard[x - 1][y + 1].SimpleCell.Num) != 0)
                    ChangeCell(x - 2, y + 2, aux);
            }
            if (x - 2 >= 0 && y - 2 >= 0 && Functions.SameColor(Game.Gameboard[x - 1][y - 1].SimpleCell.Num, cell.Num) == 0)
            {
                if (Functions.IsPiece(Game.Gameboard[x - 1][y - 1].SimpleCell.Num) != 0)
                    ChangeCell(x - 2, y - 2, aux);
            }

        }
        public static void Click_DownRowForJumpNeighb(Cell cell, int aux)
        {
            Functions.PrevCell = cell;
            int x = cell.X;
            int y = cell.Y;
            if (x + 2 < 8 && y - 2 >= 0 && Functions.SameColor(Game.Gameboard[x + 1][y - 1].SimpleCell.Num, cell.Num) == 0)
            {
                if(Functions.IsPiece(Game.Gameboard[x + 1][y - 1].SimpleCell.Num)!=0)
                ChangeCell(x + 2, y - 2, aux);
            }
            if (x + 2 < 8 && y + 2 < 8 && Functions.SameColor(Game.Gameboard[x + 1][y + 1].SimpleCell.Num, cell.Num) == 0)
            {
                if (Functions.IsPiece(Game.Gameboard[x + 1][y + 1].SimpleCell.Num) != 0)
                    ChangeCell(x + 2, y + 2, aux);
            }
        }
    }
}
