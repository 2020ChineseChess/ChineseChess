using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseChess
{
    class PieceAdvisor : Piece
    {
        public PieceAdvisor(string Player, int intX, int intY) : base(Player, intX, intY)
        {
            if (this.Player == "black")
            {
                this.Name = '士';
            }
            else
            {
                this.Name = '仕';
            }
        }

        public override bool ValidMoves(int x, int y, GameBoard gb)
        {
            {
                int CurrentX = this.X;
                int CurrentY = this.Y;

                //judge the player is the black or red
                if (this.Player == "black")
                {
                    //判断终点是否在米字格里 judge the destination if is in the 3*3 grid
                    if (x <= 2 && x >= 0 && y <= 5 && y >= 3)
                    {
                        //判断是否对角线移动 judge the move if conforms to the diagonal rule
                        if ((x - CurrentX == 1 || x - CurrentX == -1) && (y - CurrentY == 1 || y - CurrentY == -1))
                        {
                            //判断目标位置是否有子
                            if (gb.Board[x, y] != null)
                            {
                                //若有子，则判断目标位置的棋子是否为己方
                                if (gb.Board[x, y].Player == this.Player)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                    }
                }
                else if (this.Player == "red")
                {
                    //判断终点是否在米字格里
                    if (x <= 9 && x >= 7 && y <= 5 && y >= 3)
                    {
                        if ((x - CurrentX == 1 || x - CurrentX == -1) && (y - CurrentY == 1 || y - CurrentY == -1))
                        {
                            //判断目标位置是否有子
                            if (gb.Board[x, y] != null)
                            {
                                //若有子，则判断目标位置的棋子是否为己方
                                if (gb.Board[x, y].Player == this.Player)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
