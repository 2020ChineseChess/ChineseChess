using System;
using System.Data;

namespace ChineseChess
{
    class Program
    {

        static void Main(string[] args)
        {
         
         GameBoard gb = new GameBoard();
         Displayer dp = new Displayer();
         Boolean isGameOver = false;
         int turn = 1;

            while (!isGameOver)
            {
                //change the player
                turn *= (-1);

                switch (turn)
                {
                    case 1:
                        //redMove();
                        dp.DisplayBoard(gb);
                        dp.AskMovePiece(gb);
                        Console.ReadLine();
                        break;
                    case 2:
                        //blackMove();
                        dp.DisplayBoard(gb);
                        dp.AskMovePiece(gb);
                        Console.ReadLine();
                        break;
                }

            }

        }
    }

}
