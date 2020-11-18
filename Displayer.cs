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

                    if (i == gb.currentPosition[0] && j == gb.currentPosition[1])
                        Console.BackgroundColor = ConsoleColor.DarkYellow;

                    if (gb.Board[i, j] != null)
                    {
                        Console.Write(gb.Board[i, j].Name);
                    }
                    else
                    {
                        Console.Write('十');
                    }
                    
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                //over the river
                if (i != 5)

                    Console.Write(" " + count++);


                Console.WriteLine("");

            }

            Console.WriteLine(" A B C D E F G H I\n");


            //change the color of player
            Console.Write("CurrentPlayer:");

            if (gb.Player == "red")
                Console.BackgroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(gb.Player);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void AskSelectPiece()
        {
            Console.WriteLine("Which piece do you want to move?");
        }
        public void selectError()
        {
            Console.WriteLine("illegal request!You can only move your pieces!");
        }
        public void moveError()
        {
            Console.WriteLine("illegal request!You can't move to this place!");
        }

        public void AskMovePiece()
        {
            Console.WriteLine("Where do you want move it to?");
        }

    }

}
