using System;
using System.Data;

namespace ChineseChess
{
    class Program
    {

        static void Main(string[] args)
        {
            GameBoard gb = new GameBoard();

            DisplayBoard();

            while (true)
            {
                AskSelectPiece();

            }
        }


        static void DisplayBoard()
        {
            Console.WriteLine("0 ┏━┳━┳━┳━┳━┳━┳━┳━┓\n" +
                              "  ┃ ┃ ┃ ┃╲┃╱┃ ┃ ┃ ┃\n" +
                              "1 ┣━╋━╋━╋━╋━╋━╋━╋━┫ \n" +
                              "  ┃ ┃ ┃ ┃╱┃╲┃ ┃ ┃ ┃ \n" +
                              "2 ┣━╋━╋━╋━╋━╋━╋━╋━┫ \n" +
                              "  ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ \n" +
                              "3 ┣━╋━╋━╋━╋━╋━╋━╋━┫ \n" +
                              "  ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ \n" +
                              "4 ┣━┻━┻━┻━┻━┻━┻━┻━┫ \n" +
                              "  ┃               ┃ \n" +
                              "5 ┣━┳━┳━┳━┳━┳━┳━┳━┫ \n" +
                              "  ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ \n" +
                              "6 ┣━╋━╋━╋━╋━╋━╋━╋━┫ \n" +
                              "  ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ \n" +
                              "7 ┣━╋━╋━╋━╋━╋━╋━╋━┫ \n" +
                              "  ┃ ┃ ┃ ┃╲┃╱┃ ┃ ┃ ┃ \n" +
                              "8 ┣━╋━╋━╋━╋━╋━╋━╋━┫ \n" +
                              "  ┃ ┃ ┃ ┃╱┃╲┃ ┃ ┃ ┃ \n" +
                              "9 ┗━┻━┻━┻━┻━┻━┻━┻━┛ \n" +
                              "   a b c d e f g h i ");


            //we want to store it in char[][];
            //and using the state value of the char[1][1] is 0 for 1 2 3  piece.
        }

        static void AskSelectPiece()
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
                DisplayBoard();
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

        static void AskMovePiece(char row, char column, GameBoard gb)
        {
            gb.SwitchPlayer();
        }
    }
}
