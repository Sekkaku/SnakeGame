using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class SnakeGame
    {
        int height = 20;
        int width = 20;

        int[] snakeX = new int[20];
        int[] snakeY = new int[20];

        int appleX;
        int appleY;

        int snakeLength = 2;

        Random random = new Random();
        public SnakeGame()
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
                    if (x == 0 || x == 19)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("|");
                    }

                    else if (y == 0 || y == 19)
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
                snakeX[0] = 19;
                snakeX[0]--;
                for (int i = snakeLength; i > 1; i--)
                {
                    snakeX[i - 1] = snakeX[i - 2];
                    snakeY[i - 1] = snakeY[i - 2];
                }
                Drawing();
            }
            if (snakeX[0] == 19)
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
                snakeY[0] = 19;
                snakeY[0]--;
                for (int i = snakeLength; i > 1; i--)
                {
                    snakeX[i - 1] = snakeX[i - 2];
                    snakeY[i - 1] = snakeY[i - 2];
                }
                Drawing();
            }
            if (snakeY[0] == 19)
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
            for (int i = snakeLength; i > 1; i--)
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
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    snakeY[0]++;
                    Console.Clear();
                    WallLogicY();
                    Death();
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    snakeX[0]++;
                    Console.Clear();
                    WallLogicX();
                    Death();
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    snakeX[0]--;
                    Console.Clear();
                    WallLogicX();
                    Death();
                    break;
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
            SnakeGame Snake = new SnakeGame();
            Snake.FieldDrawing();
            while (true)
            {
                Snake.WalkingLogic();

                Snake.FieldDrawing();
            }
        }
    }
}
