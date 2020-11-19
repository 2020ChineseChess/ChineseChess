using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseChess
{
    class PieceSoldier : Piece
    {
        public PieceSoldier(String player, int x, int y) : base(player, x, y)
        {
            if (this.Player == "Black")
                this.Name = '卒';
            else
                this.Name = '兵';
        }

        public override bool ValidMoves(int x, int y, GameBoard gb)
        {
            int CurrentX = this.X;
            int CurrentY = this.Y;

 
            if (Player == "black")
            {
                //it hasn't passed the river 
                if (CurrentX <= 4)
                {
                    //down
                    if (x == CurrentX + 1 && y == CurrentY)
                        return true;

                    if (x == CurrentX + 2 && y == CurrentY)
                        return true;
                }
                //it has passed the river
                else
                {
                    //down
                    if (x == CurrentX + 1 && y == CurrentY)
                        return true;
                    //left or right
                    if ((y == CurrentY - 1 && x == CurrentX) || (x == CurrentX && y == CurrentY + 1))
                        return true;
                }
            }
            //black side
            else
            {
                //it hasn't passed the river 
                if (CurrentX >= 6)
                {
                    //up
                    if (x == CurrentX - 1 && y == CurrentY)
                        return true;

                    if (x == CurrentX - 2 && y == CurrentY)
                        return true;
                }
                //it has passed the river
                else
                {
                    //up
                    if (x == CurrentX - 1 && y == CurrentY)
                        return true;
                    //left or right
                    if ((y == CurrentY - 1 && x == CurrentX) || (x == CurrentX && y == CurrentY + 1))
                        return true;
                }
            }
            return false;
        }
    }
}
