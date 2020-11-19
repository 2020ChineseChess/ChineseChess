using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseChess
{
    class PieceCar : Piece
    {
        public PieceCar(string player, int intX, int intY) : base(player, intX, intY)
        {
            this.Name = '車';
        }

        public PieceCar(char name) : base(name)
        {
            this.Name = name;
        }

        public override bool ValidMoves(int x, int y, GameBoard gb)
        {
            int CurrentX = this.X;
            int CurrentY = this.Y;

            //后面写具体的判断
            //move horizontally
            if (CurrentX == x && CurrentY != y)
            {
                //go right
                if (y > CurrentY)
                {
                    for (int i = CurrentY + 1; i < y; i++)
                        if (gb.Board[x, i] != null)
                            return false;
                }
                else
                {
                    //go left
                    for (int i = CurrentY - 1; i > y; i--)
                        if (gb.Board[x, i] != null)
                            return false;
                }
                return true;
            }

            //move vertically
            if (x != CurrentX && y == CurrentY)
            {
                //go down
                if (x > CurrentX)
                {
                    for (int i = CurrentX + 1; i < x; i++)
                        if (gb.Board[i, y] != null)
                            return false;
                }
                else
                {
                    //go up
                    for (int i = CurrentX - 1; i > x; i--)
                        if (gb.Board[i, y] != null)
                            if (gb.Board[i, y] != null)
                                return false;

                }
                return true;
            }
            return false;
        }

    }
}