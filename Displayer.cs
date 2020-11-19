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
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  |ChineseChess|    ");
            Console.WriteLine("                    ");
            int count = 0;

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    if (i == gb.currentPosition[0] && j == gb.currentPosition[1])
                        Console.BackgroundColor = ConsoleColor.DarkYellow;

                    if (gb.Board[i, j] != null)
                    {

                        if (gb.Board[i, j].Player == "red")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (gb.Board[i, j].Player == "black")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        
                        Console.Write(gb.Board[i, j].Name);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        if(i == 5)
                        {
                            Console.Write(gb.river[j]);
                        }
                        else
                        {
                            Console.Write('十');
                        }
                    }

                    
                }

                //over the river
                if (i != 5)
                {
                    Console.Write(" " + count++);
                }
                else
                {
                    Console.Write("  ");
                }


                Console.WriteLine("");

            }

            Console.WriteLine(" A B C D E F G H I  \n");

            Console.BackgroundColor = ConsoleColor.Black;
            //change the color of player
            Console.Write("CurrentPlayer:");
            Console.BackgroundColor = ConsoleColor.DarkGray;
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
