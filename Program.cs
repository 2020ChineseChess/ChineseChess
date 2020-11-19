using System;

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
                //打印棋盘
                dp.DisplayBoard(gb);

                //判断游戏是否结束
                while (gb.judgeIsGameOver())
                {
                    //结束时显示游戏结束 并跳出循环
                    dp.GameOver();
                    return;
                }

                //提示选择棋子
                dp.AskSelectPiece();

                //判断所选棋子是否合法
                while (!gb.SelectPiece(Console.ReadLine()))
                    dp.selectError(); //若不合法 报错

                //打印棋盘 和提示选择目的地
                dp.DisplayBoard(gb);
                dp.AskMovePiece();

                //判断所选目的地是否合法
                while (!gb.MovePiece(Console.ReadLine()))
                    dp.moveError();//若不合法 报错

                //交换执棋者
                gb.SwitchPlayer();
            }



        }

    }
}

