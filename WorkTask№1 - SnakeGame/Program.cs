using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class SnakeGame
    {
        int height;
        int width;

        int[] snakeX = new int[20];
        int[] snakeY = new int[20];

        int appleX;
        int appleY;

        int snakeLength = 2;

        Random random = new Random();

        public void WidthChecker()
        {
            try
            {
                width = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверное значение длины - ", Console.ReadLine());
            }
        }

        public void HeightChecker()
        {
            try
            {
                height = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверное значение высоты - ", Console.ReadLine());
            }
        }
        public void StartGame()
        {
            snakeX[0] = random.Next(1, width - 1);
            snakeY[0] = random.Next(1, height - 1);
            Console.CursorVisible = false;
            appleX = random.Next(1, width - 1);
            appleY = random.Next(1, height - 1);
        }

        public void FieldDrawing()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || x == width - 1)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("|");
                    }

                    else if (y == 0 || y == height - 1)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("-");
                    }
                }
            }
        }

        public void WritePointSnake(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("#");
        }

        public void WritePointApple(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("@");
        }

        public void Drawing() 
        {
            for (int i = 0; i < snakeLength; i++)
            {
                WritePointSnake(snakeX[i], snakeY[i]);
                WritePointApple(appleX, appleY);
            }
        }

        public void WallLogicX()
        {
            if (snakeX[0] == 0)
            {
                snakeX[0] = width - 1;
                snakeX[0]--;
                for (int i = snakeLength; i > 1; i--)
                {
                    snakeX[i - 1] = snakeX[i - 2];
                    snakeY[i - 1] = snakeY[i - 2];
                }
                Drawing();
            }
            if (snakeX[0] == width - 1)
            {
                snakeX[0] = 0;
                snakeX[0]++;
                for (int i = snakeLength; i > 1; i--)
                {
                    snakeX[i - 1] = snakeX[i - 2];
                    snakeY[i - 1] = snakeY[i - 2];
                }
                Drawing();
            }
        }

        public void WallLogicY()
        {
            if (snakeY[0] == 0)
            {
                snakeY[0] = height - 1;
                snakeY[0]--;
                for (int i = snakeLength; i > 1; i--)
                {
                    snakeX[i - 1] = snakeX[i - 2];
                    snakeY[i - 1] = snakeY[i - 2];
                }
                Drawing();
            }
            if (snakeY[0] == height - 1)
            {
                snakeY[0] = 0;
                snakeY[0]++;
                for (int i = snakeLength; i > 1; i--)
                {
                    snakeX[i - 1] = snakeX[i - 2];
                    snakeY[i - 1] = snakeY[i - 2];
                }
                Drawing();
            }
        }

        public void Death()
        {
            for (int i = snakeLength; i > 0; i--)
                {
                if (snakeX[0] == snakeX[i] && snakeY[0] == snakeY[i])
                {
                    Console.WriteLine("Вы проиграли! Нажмите Enter, чтобы выйти:");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
        }

        public void WalkingLogic()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    snakeY[0]--;
                    Console.Clear();
                    WallLogicY();
                    Death();
                    FieldDrawing();
                    Drawing();
                    System.Threading.Thread.Sleep(1000);
                    if (Console.ReadKey().Key == ConsoleKey.W || Console.ReadKey().Key == ConsoleKey.UpArrow)
                    {
                        return;
                    }
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    while (Console.ReadKey().Key == ConsoleKey.S || Console.ReadKey().Key == ConsoleKey.DownArrow)
                    {
                        snakeY[0]++;
                        Console.Clear();
                        WallLogicY();
                        Death();
                        FieldDrawing();
                        Drawing();
                        System.Threading.Thread.Sleep(1000);
                    }
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    while (true)
                    {
                        snakeX[0]++;
                        Console.Clear();
                        WallLogicX();
                        Death();
                        FieldDrawing();
                        Drawing();
                        System.Threading.Thread.Sleep(1000);
                    }
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    while (true)
                    {
                        snakeX[0]--;
                        Console.Clear();
                        WallLogicX();
                        Death();
                        FieldDrawing();
                        Drawing();
                        System.Threading.Thread.Sleep(1000);
                    }
            }
            if (snakeY[0] == appleY && snakeX[0] == appleX)
            {
                snakeLength++;
                    appleX = random.Next(2, (height - 1));
                    appleY = random.Next(2, (width - 1));
                    for (int i = snakeLength; i >= 0; i--)
                    {
                        if (appleX == snakeX[i] && appleY == snakeY[i])
                        {
                            appleX = random.Next(2, (height - 1));
                            appleY = random.Next(2, (width - 1));
                        }
                    }
                Drawing();
            }
            for (int i = snakeLength; i > 1; i--)
            {
                snakeX[i - 1] = snakeX[i - 2];
                snakeY[i - 1] = snakeY[i - 2];
            }
            Drawing();
        }

        static void Main(string[] args)
        {
            var Snake = new SnakeGame();

            Console.Write("Введите длину поля: ");
            Snake.WidthChecker();

            Console.Write("Введите высоту поля: ");
            Snake.HeightChecker();

            Console.Clear();

            Snake.StartGame();

            Snake.FieldDrawing();

            Snake.WalkingLogic();
        }
    }
}
