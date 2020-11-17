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

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    Console.Write(gb.board[i, j]);

                }
                Console.Write(" " + (i + 1) + "\n");
            }


            Console.Write(" A B C D E F G H I\n\n");
        }

        public void AskMovePiece(GameBoard gb)
        {
            // gb.SwitchPlayer();
            Console.WriteLine("Which piece do you want to move?");
            String flag;
            flag = Console.ReadLine();

            if (isValid(flag))
            {
                Console.WriteLine("Where do u want moving " + flag + " to?");
                string flag2 = Console.ReadLine();

               // isValid(flag);

                gb.MovePiece(flag, flag2);

                DisplayBoard(gb);
            }
            else
            {
                Console.WriteLine("illegal request, try again!");
            }


        }

        Boolean isValid(string flag)
        {
            if (!(flag.Length == 2 || flag.Length == 3))
            {
                Console.WriteLine("error1");
                return false;
            }

            char temp = flag[0];
            string[] arr = flag.Split(temp);

            Console.WriteLine(flag[0]);
            Console.WriteLine(flag[1]);

            if ((flag[0] >= 'a' && flag[0] <= 'i') || (flag[0] >= 'A' && flag[0] <= 'I'))
            {
                Console.WriteLine("COME1");
                if (flag[1] >= '1' && flag[1] <= '9')
                {
                    return true;
                }
            }

            return false;

        }


    }

}
