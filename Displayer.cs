using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseChess
{
    class Displayer
    {
      public  void DisplayBoard(GameBoard gb)
        {
            Console.WriteLine("  中国象棋欢迎您\n\n");

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(gb.board[i,j]);
                }
                Console.Write("\n");
            }

        }

        void AskSelectPiece()
        {
            string flag;
            char temp;

            //gameBorad gb = gameborad;


            //WriteAt("\nwhich piece you want to move? (e.g.: a2",0,21);
            //WriteAt("", 0, 22);
            flag = Console.ReadLine();

            if (flag[0] >= 'a' && flag[0] <= 'i')
            {
                temp = flag[0];
                string[] arr = flag.Split(temp);

                //  WriteAt("Where do u want moving " + flag + " to?", 0,23);
                flag = Console.ReadLine();

                if ((flag[0] >= 'a' && flag[0] <= 'i') && (flag[1] >= 1 && flag[1] <= 9))
                    //if (valid())

                    Console.Clear();
                //WriteAt("TEST", flag[0]+3,2*flag[1]);
                //store game borad to class 'gb'
                //could using int char[][] to store all element?
                //change the value of [row][column] to change element.

                //AskMovePiece(flag[1], flag[0], gb);

            }
            else
            {
                Console.WriteLine("illegal request, try again!");
            }
        }

        void AskMovePiece(char row, char column, GameBoard gb)
        {
            gb.SwitchPlayer();
        }
    }

}
