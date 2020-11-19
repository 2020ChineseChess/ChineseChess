using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseChess
{

    class GameBoard
    {
        string player = "red"; //default palyer
        private Piece[,] board;
        public string river = "一一楚河一汉界一一"; //river
        public int[] currentPosition = new int[2] { -1, -1 }; //current position
        public int[] futurePosition = new int[2] { -1, -1 }; //future position

        public string Player { get => player; set => player = value; }
        internal Piece[,] Board { get => board; set => board = value; }
        

        public GameBoard()
        {
            chessboardBuilding();
        }

        //交换玩家
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
            //if valid
            if (flag.Length != 2)
            {
                return false;
            }

            //if valid
            if ((flag[0] >= 'a' && flag[0] <= 'i') || (flag[0] >= 'A' && flag[0] <= 'I'))
            {
                if (flag[1] >= '0' && flag[1] <= '9')
                {
                    //translate A1 to 00 or a1 to 00
                    this.currentPosition = getIndex(flag);

                    //if piece exist.
                    if (board[currentPosition[0], currentPosition[1]] != null){
                        //if the piece belong to player;
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

            //could not eating owner piece
            if (Board[futurePosition[0], futurePosition[1]] != null)
                if (Board[futurePosition[0], futurePosition[1]].Player == Board[currentPosition[0], currentPosition[1]].Player)
                    return false;


            //new one sign to old one
            board[futurePosition[0], futurePosition[1]] = board[currentPosition[0], currentPosition[1]];

            //change the position of piece
            board[futurePosition[0], futurePosition[1]].X = futurePosition[0];
            board[futurePosition[0], futurePosition[1]].Y = futurePosition[1];

            //delete old one
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

        public Boolean judgeIsGameOver()
        {
            int count = 0;

            for (int i = 8; i <= 10; i++)
                for (int j = 3; j <= 5; j++)
                    if (board[i, j] != null)
                        if (board[i, j].Name == '帥')
                            count++;

            for (int i = 0; i <= 2; i++)
                for (int j = 3; j <= 5; j++)
                    if (board[i, j] != null)
                        if (board[i, j].Name == '將')
                            count++;

            if (count != 2)
                return true;
                

            return false;
        }

        void chessboardBuilding()
        {
            board = new Piece[11, 9];

            //building the BlackChess
            Board[0, 0] = new PieceCar("black", 0, 0); //车
            Board[0, 1] = new PieceHorse("black", 0, 1); //马
            Board[0, 2] = new PieceElephant("black", 0, 2); //相
            Board[0, 3] = new PieceAdvisor("black", 0, 3); //士
            Board[0, 4] = new PieceGerneral("black", 0, 4); //将
            Board[0, 5] = new PieceAdvisor("black", 0, 5);
            Board[0, 6] = new PieceElephant("black", 0, 6);
            Board[0, 7] = new PieceHorse("black", 0, 7);
            Board[0, 8] = new PieceCar("black", 0, 8);

            Board[2, 1] = new PieceCannon("black", 2, 1);
            Board[2, 7] = new PieceCannon("black", 2, 7);

            Board[3, 0] = new PieceSoldier("black", 3, 0);
            Board[3, 2] = new PieceSoldier("black", 3, 2);
            Board[3, 4] = new PieceSoldier("black", 3, 4);
            Board[3, 6] = new PieceSoldier("black", 3, 6);
            Board[3, 8] = new PieceSoldier("black", 3, 8);


            //building the RedChess
            Board[10, 0] = new PieceCar("red", 10, 0);
            Board[10, 1] = new PieceHorse("red", 10, 1);
            Board[10, 2] = new PieceElephant("red", 10, 2);
            Board[10, 3] = new PieceAdvisor("red", 10, 3);
            Board[10, 4] = new PieceGerneral("red", 10, 4);
            Board[10, 5] = new PieceAdvisor("red", 10, 5);
            Board[10, 6] = new PieceElephant("red", 10, 6);
            Board[10, 7] = new PieceHorse("red", 10, 7);
            Board[10, 8] = new PieceCar("red", 10, 8);

            Board[8, 1] = new PieceCannon("red", 8, 1);
            Board[8, 7] = new PieceCannon("red", 8, 7);

            Board[7, 0] = new PieceSoldier("red", 7, 0);
            Board[7, 2] = new PieceSoldier("red", 7, 2);
            Board[7, 4] = new PieceSoldier("red", 7, 4);
            Board[7, 6] = new PieceSoldier("red", 7, 6);
            Board[7, 8] = new PieceSoldier("red", 7, 8);

        }
    }
}
