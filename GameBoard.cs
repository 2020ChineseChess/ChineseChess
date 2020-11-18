using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseChess
{

    class GameBoard
    {
        public Boolean isGameOver = false;
        string player = "red";
        private Piece[,] board;
        public int x0 =-1, y0 = -1;
        public int x1 = -1, y1 = -1;
        public int[] currentPosition = new int[2] { -1, -1 };
        public int[] futurePosition = new int[2] { -1, -1 };

        public string Player { get => player; set => player = value; }
        internal Piece[,] Board { get => board; set => board = value; }

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

                    if (board[currentPosition[0], currentPosition[1]] != null){
                        if(board[currentPosition[0], currentPosition[1]].Player == this.player)
                            return true;
                        return false;
                    }
                    else
                    {
                        return false;
                    }
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
            //is the input valid
            if (!CalculateValidMoves(flag))
            {
                return false;
            }

            //cancel the illegal move (nothing change
            if ((currentPosition[0] == futurePosition[0]) && (currentPosition[1] == futurePosition[1]))
            {
                return false;
            }

            //is the move follow the chess rules
            if(!(board[currentPosition[0], currentPosition[1]].ValidMoves(futurePosition[0], futurePosition[1], this)))
            {
                return false;
            }


            board[futurePosition[0], futurePosition[1]] = board[currentPosition[0], currentPosition[1]];

            board[futurePosition[0], futurePosition[1]].X = currentPosition[0];
            board[futurePosition[0], futurePosition[1]].X = currentPosition[1];

            

            board[currentPosition[0], currentPosition[1]] = null;

            //sign the last step;
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
            board = new Piece[11, 9];

            //building the river
            Board[5, 0] = new PieceCar('一');
            Board[5, 1] = new PieceCar('一');
            Board[5, 4] = new PieceCar('一');
            Board[5, 7] = new PieceCar('一');
            Board[5, 8] = new PieceCar('一');

            Board[5, 2] = new PieceCar('楚');
            Board[5, 3] = new PieceCar('河');
            Board[5, 5] = new PieceCar('汉');
            Board[5, 6] = new PieceCar('界');

            //building the RedChess
            Board[0, 0] = new PieceCar("red", 0, 0);
            Board[0, 1] = new PieceCar("red", 0, 1);
            Board[0, 2] = new PieceCar("red", 0, 2);
            Board[0, 3] = new PieceCar("red", 0, 3);
            Board[0, 4] = new PieceCar("red", 0, 4);
            Board[0, 5] = new PieceCar("red", 0, 5);
            Board[0, 6] = new PieceCar("red", 0, 6);
            Board[0, 7] = new PieceCar("red", 0, 7);
            Board[0, 8] = new PieceCar("red", 0, 8);

            Board[2, 1] = new PieceCar("red", 2, 1);
            Board[2, 7] = new PieceCar("red", 2, 7);

            Board[3, 0] = new PieceCar("red", 3, 0);
            Board[3, 2] = new PieceCar("red", 3, 2);
            Board[3, 4] = new PieceCar("red", 3, 4);
            Board[3, 6] = new PieceCar("red", 3, 6);
            Board[3, 8] = new PieceCar("red", 3, 8);


            //building the BlackChess
            board[10, 0] = new PieceCar("black", 10, 0);
            board[10, 1] = new PieceCar("black", 10, 1);
            board[10, 2] = new PieceCar("black", 10, 2);
            board[10, 3] = new PieceCar("black", 10, 3);
            board[10, 4] = new PieceCar("black", 10, 4);
            board[10, 5] = new PieceCar("black", 10, 5);
            board[10, 6] = new PieceCar("black", 10, 6);
            board[10, 7] = new PieceCar("black", 10, 7);
            board[10, 8] = new PieceCar("black", 10, 8);

            board[8, 1] = new PieceCar("black", 8, 1);
            board[8, 7] = new PieceCar("black", 8, 7);

            board[7, 0] = new PieceCar("black", 7, 0);
            board[7, 2] = new PieceCar("black", 7, 2);
            board[7, 4] = new PieceCar("black", 7, 4);
            board[7, 6] = new PieceCar("black", 7, 6);
            board[7, 8] = new PieceCar("black", 7, 8);

        }
    }
}
