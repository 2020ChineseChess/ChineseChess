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

           

         while (true)
         {
                dp.DisplayBoard(gb);
                Console.ReadLine();
         }

        }
    }

}
