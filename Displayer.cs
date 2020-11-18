using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseChess
{
    class Displayer
    {
        public void DisplayBoard(GameBoard gb)
        {
            Console.Clear();
            Console.WriteLine("  |ChineseChess|\n\n");
            int count = 0;

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    
                    if (i == gb.currentPosition[0] && j==gb.currentPosition[1])
                        Console.BackgroundColor = ConsoleColor.DarkYellow;

                    
                    Console.Write(gb.board[i, j]);
                    Console.BackgroundColor = ConsoleColor.Black;

                }

                //over the river
                if (i != 5)
                {
                    Console.Write(" " + count++);
                }

                Console.WriteLine("");
                    
            }

            Console.WriteLine(" A B C D E F G H I\n\n");

            Console.WriteLine("CurrentPlayer: " + gb.Player);
        }

        public void AskSelectPiece()
        {
            Console.WriteLine("Which piece do you want to move?");
        }
        public void AskError()
        {
            Console.WriteLine("illegal request, try again!");
        }

        public void AskMovePiece()
        {
            Console.WriteLine("Where do you want move it to?");
        }

    }

}
