using System;

namespace ChineseChess
{
    class Program
    {

        static void Main(string[] args)
        {
            GameBoard gb = new GameBoard();
            Displayer dp = new Displayer();

            while (!gb.isGameOver)
            {
                dp.DisplayBoard(gb);
                dp.AskSelectPiece();

                while (!gb.SelectPiece(Console.ReadLine()))
                    dp.selectError();

                dp.DisplayBoard(gb);
                dp.AskMovePiece();

                while (!gb.MovePiece(Console.ReadLine()))
                    dp.moveError();

                gb.SwitchPlayer();
            }

        }

    }
}

