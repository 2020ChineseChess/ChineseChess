using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseChess
{

    class GameBoard
    {
        public Boolean isGameOver = false;
        string player = "red";
        public char[,] board;
        public int[] currentPosition = new int[2] { -1, -1 };
        public int[] futurePosition = new int[2] { -1, -1 };

        public string Player { get => player; set => player = value; }

        public GameBoard()
        {
            chessboardBuilding();
        }
        public void SwitchPlayer()
        {
            if (Player == "red")
            {
                Player = "black";
            }
            else
            {
                Player = "red";
            }
        }


        public bool SelectPiece(String flag)
        {
            if (flag.Length != 2)
            {
                return false;
            }

            if ((flag[0] >= 'a' && flag[0] <= 'i') || (flag[0] >= 'A' && flag[0] <= 'I'))
            {
                if (flag[1] >= '0' && flag[1] <= '9')
                {
                    //A1 -> 00 or a1 -> 00
                    this.currentPosition = getIndex(flag);
                    return true;
                }
            }

            return false;
        }

        //translate A ->0 or a ->0
        int[] getIndex(String flag)
        {

            int[] Values = new int[2];

            if ((flag[0] >= 'a' && flag[0] <= 'i'))
            {
                Values[0] = (flag[0] - 97);
            }
            else
            {
                Values[0] = (flag[0] - 65);
            }

            //if over the river, index should + 1
            if(flag[1] - 48 >= 5)
            {
                Values[1] = flag[1] - 47;
            }
            else
            {
                Values[1] = flag[1] - 48;
            }

            int temp = Values[1];
            Values[1] = Values[0];
            Values[0] = temp;

            return Values;

        }



        public Boolean MovePiece(string flag)
        {
            //isValid  
            if (!CalculateValidMoves(flag))
            {
                return false;
            }

            //cancel the illegal move (nothing change
            if((currentPosition[0] == futurePosition[0]) &&  (currentPosition[1] == futurePosition[1]))
            {
                return false;
            }

            char temp = board[currentPosition[0], currentPosition[1]];
            board[currentPosition[0], currentPosition[1]] = board[futurePosition[0], futurePosition[1]];
            board[futurePosition[0], futurePosition[1]] = temp;

            currentPosition[0] = futurePosition[0];
            currentPosition[1] = futurePosition[1];
            return true;

        }

        Boolean CalculateValidMoves(string flag)
        {
            if (flag.Length != 2)
            {
                return false;
            }

            if ((flag[0] >= 'a' && flag[0] <= 'i') || (flag[0] >= 'A' && flag[0] <= 'I'))
            {
                if (flag[1] >= '0' && flag[1] <= '9')
                {
                    //A1 -> 00 or a1 -> 00
                    this.futurePosition = getIndex(flag);
                    return true;
                }
            }

            return false;
        }

        void chessboardBuilding()
        {
            board = new char[11, 9];

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
            board[5, 5] = '汉';
            board[5, 6] = '界';

            //building the RedChess
            board[0, 0] = board[0, 8] = '車';
            board[0, 1] = board[0, 7] = '马';
            board[0, 2] = board[0, 6] = '相';
            board[0, 3] = board[0, 5] = '仕';
            board[0, 4] = '帅';
            board[2, 1] = board[2, 7] = '砲';
            board[3, 0] = board[3, 2] = board[3, 4] = board[3, 6] = board[3, 8] = '兵';

            //building the BlackChess
            board[10, 0] = board[10, 8] = '車';
            board[10, 1] = board[10, 7] = '马';
            board[10, 2] = board[10, 6] = '象';
            board[10, 3] = board[10, 5] = '士';
            board[10, 4] = '将';
            board[8, 1] = board[8, 7] = '炮';
            board[7, 0] = board[7, 2] = board[7, 4] = board[7, 6] = board[7, 8] = '卒';
                
        }
    }
}
