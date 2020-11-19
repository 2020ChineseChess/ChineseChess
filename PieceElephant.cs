using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseChess
{
    class PieceElephant : Piece
    {
        public PieceElephant(String player, int x, int y) : base(player, x, y)
        {
            if (this.Player == "black")
            {
                this.Name = '象';
            }
            else
            {
                this.Name = '相';
            }
        }

        public override bool ValidMoves(int x, int y, GameBoard gb)
        {
            int CurrentX = this.X;
            int CurrentY = this.Y;

            
            //the elephant could not over river;
            if (CurrentX <= 5)
                if (x > 5)
                    return false;

            if (CurrentX >= 6)
                if (x < 5)
                    return false;


            //判断是否符合符合运子规则
            if (x - CurrentX == 2 || x - CurrentX == -2)
            {
                if (y - CurrentY == 2 || y - CurrentY == -2)
                {
                    //判断“田”字路径中间有没有子
                    if (gb.Board[(x + CurrentX) / 2, (y + CurrentY) / 2] == null)
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