using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTask_1___SnakeGame
{
    class Program
    {
        // Яблочко
        static string[,] AppleRandomPut(string[,] array)
        {
            for (int appley = new Random().Next(1, 18); ;)
            {
                for (int applex = new Random().Next(1, 18); ;)
                {
                    switch (array[appley, applex])
                    {
                        case "#":
                        appley = new Random().Next(1, 18);
                        applex = new Random().Next(1, 18);
                        continue;

                        default:
                        array[appley, applex] = "@";
                        return array;
                    }
                }
            }
        }

        static string[,] PlayerRandomAppearance(string[,] array)
        {
            for (int playerY = new Random().Next(1, 18); ;)
            {
                for (int playerX = new Random().Next(1, 18); ;)
                {
                    array[playerY, playerX] = "#";
                    return array;
                }
            }
        }

        //static string[,] PlayerSnakeWalking(string[,] array, string snakeHead)
        //{
        //    Console.ReadKey();
        //    switch (Console.ReadKey().Key)
        //    {
        //        case ConsoleKey.UpArrow:
        //        case ConsoleKey.W:
        //            {
        //                int x, y;



        //            }
        //            break;
        //        case ConsoleKey.LeftArrow:
        //        case ConsoleKey.A:
        //            break;
        //        case ConsoleKey.DownArrow:
        //        case ConsoleKey.S:
        //            break;
        //        case ConsoleKey.RightArrow:
        //        case ConsoleKey.D:
        //            break;
        //    }
        //}

        static void Main(string[] args)
        {

            // Создание массива

            int height = 20;
            int width = 20;

            string[,] gameField = new string[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || x == 19)
                    {
                        gameField[y, x] = "|";
                    }

                    else if (y > 0 & y < 19)
                    {
                        gameField[y, x] = " ";
                    }

                    else 
                    {
                        gameField[y, x] = "-";
                    }
                }
            }

            PlayerRandomAppearance(gameField);

            AppleRandomPut(gameField);

            //playersnakewalking(gamefield, snakehead);

            // Отображение массива

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(gameField[y, x]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
