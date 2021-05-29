using System.Collections.ObjectModel;
using ProjectCheck.FunctionClasses;
using ProjectCheck.Model;
using ProjectCheck.VM;
namespace ProjectCheck.FunctionClasses
{
    class Move
    {
        private ObservableCollection<ObservableCollection<Cell>> Cells { get; set; }

        public Move(ObservableCollection<ObservableCollection<Cell>> cells,int[,] matrix)
        {
            this.Cells = cells;
            Game.Matrix = matrix;
        }
        public static void MovePiece(Cell currentCell)
        {
            if (currentCell.Num == -4)
                PieceClick.Click_TheShadow(currentCell,-2);
            if (currentCell.Num == 4)
                PieceClick.Click_TheShadow(currentCell,2);
            if (currentCell.Num == 5)
                PieceClick.Click_TheShadow(currentCell,3);
            if (currentCell.Num == -5)
                PieceClick.Click_TheShadow(currentCell,-3);
        }
        public void CheckMovesBlack(Cell currentCell)
        {
            if (currentCell.Num == -2)
                PieceClick.Click_BlackNForShadow(currentCell);
            if (currentCell.Num == -3)
                PieceClick.Click_BlackKForShadow(currentCell); 
        }
        public void CheckMovesWhite(Cell currentCell)
        {
            if (currentCell.Num == 2)
                PieceClick.Click_WhiteNForShadow(currentCell);
            if (currentCell.Num == 3)
                PieceClick.Click_WhiteKForShadow(currentCell);
        } 
        public void ClickAction(Cell obj)
        {
            Game.MultipleMoves.Started = false;

                if (Functions.IsPiece(obj.Num) != 0)
                {
                    Functions.DeleteShadows();
                    if (Game.Player.Name == "Player 1")
                        CheckMovesWhite(obj);  
                    else
                        CheckMovesBlack(obj);
                }
                else if (Functions.IsShadow(obj.Num) != 0)
                {
                    MovePiece(obj);
                    Game.Player.ChangePlayer();
                    Functions.WriteScores();
                    Functions.CheckWin();
                }
                else
                Functions.DeleteShadows();                       
        }
    }
}
