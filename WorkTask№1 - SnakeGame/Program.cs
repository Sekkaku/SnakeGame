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

        static string PlayerRandomAppearance(string[,] array)
        {
            for (int playerY = new Random().Next(1, 18); ;)
            {
                for (int playerX = new Random().Next(1, 18); ;)
                {
                    array[playerY, playerX] = "#";
                    string snakeHead = array[playerY, playerX];
                    return snakeHead;
                }
            }
        }

        static void FieldDrawing(string[,] gameField)
        {
            for (int y = 0; y < 19; y++)
            {
                for (int x = 0; x < 19; x++)
                {
                    Console.Write(gameField[y, x]);
                }
                Console.WriteLine();
            }
        }

        static void PlayerSnakeWalking(string[,] gameField, string snakeHead)
        {
            int height = 19;
            int width = 19;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    {
                        for (int headX = 0; headX < height; headX++)
                        {
                            for (int headY = 0; headY < width; headY++)
                            {
                                if (gameField[headY, headX] == snakeHead)
                                {
                                    switch (gameField[headY - 1, headX])
                                    {
                                        case " ":
                                            gameField[headY - 1, headX] = snakeHead;
                                            gameField[headY, headX] = " ";
                                            break;

                                        case "#":
                                            Console.WriteLine("Вы проиграли! Нажмите Enter, чтобы выйти:");
                                            Console.ReadLine();
                                            Environment.Exit(0);
                                            break;

                                        case "-":
                                            gameField[18, headX] = snakeHead;
                                            gameField[headY, headX] = " ";
                                            break;

                                        case "@":
                                            gameField[headY - 1, headX] = snakeHead;
                                            gameField[headY, headX] = "#";
                                            AppleRandomPut(gameField);
                                            break;
                                    }
                                }
                            }
                            continue;
                        }
                        Console.Clear();
                        break;
                    }
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    {
                        Console.Clear();
                        for (int headX = 0; headX < height; headX++)
                        {
                            for (int headY = width; headY > 0; headY--)
                            {
                                if (gameField[headY, headX] == snakeHead)
                                {
                                    switch (gameField[headY, headX - 1])
                                    {
                                        case " ":
                                            gameField[headY, headX - 1] = snakeHead;
                                            gameField[headY, headX] = " ";
                                            break;

                                        case "#":
                                            Console.WriteLine("Вы проиграли! Нажмите Enter, чтобы выйти:");
                                            Console.ReadLine();
                                            Environment.Exit(0);
                                            break;

                                        case "|":
                                            gameField[headY, 18] = snakeHead;
                                            gameField[headY, headX] = " ";
                                            break;

                                        case "@":
                                            gameField[headY, headX - 1] = snakeHead;
                                            gameField[headY, headX] = "#";
                                            AppleRandomPut(gameField);
                                            break;
                                    }
                                }
                            }
                            continue;
                        }
                        Console.Clear();
                        break;
                    }
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        Console.Clear();
                        for (int headX = 0; headX < height; headX++)
                        {
                            for (int headY = width; headY > 0; headY--)
                            {
                                if (gameField[headY, headX] == snakeHead)
                                {
                                    switch (gameField[headY + 1, headX])
                                    {
                                        case " ":
                                            gameField[headY + 1, headX] = snakeHead;
                                            gameField[headY, headX] = " ";
                                            break;

                                        case "#":
                                            Console.WriteLine("Вы проиграли! Нажмите Enter, чтобы выйти:");
                                            Console.ReadLine();
                                            Environment.Exit(0);
                                            break;

                                        case "-":
                                            gameField[1, headX] = snakeHead;
                                            gameField[headY, headX] = " ";
                                            break;

                                        case "@":
                                            gameField[headY + 1, headX] = snakeHead;
                                            gameField[headY, headX] = "#";
                                            AppleRandomPut(gameField);
                                            break;
                                    }
                                }
                            }
                            continue;
                        }
                        Console.Clear();
                        break;
                    }
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    {
                        Console.Clear();
                        for (int headX = height; headX >= 0; headX--)
                        {
                            for (int headY = 0; headY < width; headY++)
                            {
                                if (gameField[headY, headX] == snakeHead)
                                {
                                    switch (gameField[headY, headX + 1])
                                    {
                                        case " ":
                                            gameField[headY, headX + 1] = snakeHead;
                                            gameField[headY, headX] = " ";
                                            break;

                                        case "#":
                                            Console.WriteLine("Вы проиграли! Нажмите Enter, чтобы выйти:");
                                            Console.ReadLine();
                                            Environment.Exit(0);
                                            break;

                                        case "|":
                                            gameField[headY, 1] = snakeHead;
                                            gameField[headY, headX] = " ";
                                            break;

                                        case "@":
                                            gameField[headY, headX + 1] = snakeHead;
                                            gameField[headY, headX] = "#";
                                            AppleRandomPut(gameField);
                                            break;
                                    }
                                }
                            }
                            continue;
                        }
                        Console.Clear();
                        break;
                    }
                default:
                    break;
            }
        }

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

            string snakeHead;

            snakeHead = PlayerRandomAppearance(gameField);

            AppleRandomPut(gameField);

            while (true)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Console.Write(gameField[y, x]);
                    }
                    Console.WriteLine();
                }

                PlayerSnakeWalking(gameField, snakeHead);

            }

            

            // Отображение массива
        }
    }
}
