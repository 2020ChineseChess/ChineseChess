using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseChess
{
    class PieceGerneral : Piece
    {
        public PieceGerneral(String player, int x, int y) : base(player, x, y)
        {
            if (this.Player == "black")
            {
                this.Name = '將';
            }
            else
            {
                this.Name = '帥';
            }
        }

        public override bool ValidMoves(int x, int y, GameBoard gb)
        {
            int CurrentX = this.X;
            int CurrentY = this.Y;


            if (Player == "black")//  Black on top and red on the bottom
            {
                if (x < 0 || x > 2)
                {
                    return false;
                }

            }
            else
            {
                if (x < 8 || x > 10)
                {
                    return false;
                }
            }

            if (y < 3 || y > 5)
            {
                return false;
            }

            //judge the pieces are owner
            if (Math.Abs(CurrentX - x) > 1 || Math.Abs(CurrentY - y) > 1)
            {
                return false;
            }


            //此处写判断帅将的移动位置
            //水平移动
            if (CurrentX == x && CurrentY != y)
            {
                //go right
                if (y > CurrentY)
                {
                    if (gb.Board[x, CurrentY + 1] != null)
                        return false;
                }

                else
                {
                    //go left
                    if (gb.Board[x, CurrentY - 1] != null)
                        return false;
                }

                return true;

            }

            //竖直移动
            if (x != CurrentX && y == CurrentY)
            {

                if (x > this.X)
                {
                    //go down
                    if (gb.Board[CurrentX + 1, y] != null)
                        return false;
                }
                else
                {
                    //go up
                    if (gb.Board[CurrentX - 1, y] != null)
                        return false;
                }
                return true;
            }

            return false;
        }
    }
}
