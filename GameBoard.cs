using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseChess
{
    
    class GameBoard
    {
        public char[,] board;

        public GameBoard()
        {
            chessboardBuilding();
        }
        public void SwitchPlayer()
        {
            //if(Player == red)
        }

        void SelectPiece()
        {

        }


        void MovePiece()
        {

        }

        void CalculateValidMoves()
        {

        }

        void chessboardBuilding()
        {
            board = new char[12, 10];

            //building the grid
            for(int i = 0; i < 11; i++)
            {
                for(int j = 0; j< 9; j++)
                {
                    board[i,j] = '十';
                }
            }


            //building the river
            board[5, 0] = board[5, 1] = board[5, 4] = board[5, 7] = board[5, 8] = '一';
            board[5, 2] = '楚';
            board[5, 3] = '河';
            board[5, 6] = '汉';
            board[5, 6] = '界';

            //building the RedChess
            board[0, 0] = board[0, 8] = '車';
            board[0, 1] = board[0, 7] = '马';
            board[0, 2] = board[0, 6] = '相';
            board[0, 3] = board[0, 5] = '仕';
            board[0, 4] = '帅';
            board[2, 1] = board[2, 7] = '炮';
            board[3, 0] = board[3, 2] = board[3, 4] = board[3, 6] = board[3, 8] = '兵';

            //building the BlackChess
            board[10, 0] = board[10, 8] = '車';
            board[10, 1] = board[10, 7] = '马';
            board[10, 2] = board[10, 6] = '相';
            board[10, 3] = board[10, 5] = '仕';
            board[10, 4] = '将';
            board[8, 1] = board[8, 7] = '炮';
            board[7, 0] = board[7, 2] = board[7, 4] = board[7, 6] = board[7, 8] = '卒';
        }
    }
}
