﻿using System;
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

            //could not go out of 3*3 grid;
            if (Player == "black")
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

            //could only move 1 step;
            if (Math.Abs(CurrentX - x) > 1 || Math.Abs(CurrentY - y) > 1)
            {
                return false;
            }


            //move horizontal
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

            //move vertical
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
