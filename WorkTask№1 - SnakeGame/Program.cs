using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public struct MyVector2
    {
        public int X;
        public int Y;

        public MyVector2(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Start
    {
        static void Main(string[] args)
        {
            var Snake = new SnakeGame();
            Snake.StartGame();
        }
    }

    class SnakeGame
    {
        public void StartGame()
        {
            int[,] snake = new int[1, 2];

            int appleX = 0;
            int appleY = 0;

            int snakeX = 0;
            int snakeY = 0;

            int snakeLength = 2;

            var random = new Random();

            var width = WidthSetter();
            var height = HeightSetter();

            Console.Clear();

            SetStartParameters(random, width, height, snakeX, snakeY, appleX, appleY, snake);

            FieldDrawing(width, height);

            GameLoop(random, width, height, snakeX, snakeY, appleX, appleY, snakeLength, snake);
        }

        private int WidthSetter()
        {
            Console.Write("Введите длину поля: ");

            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверное значение длины - ", Console.ReadLine());
            }

            return 0;
        }

        private int HeightSetter()
        {
            Console.Write("Введите высоту поля: ");

            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверное значение высоты - ", Console.ReadLine());
            }

            return 0;
        }
        private void SetStartParameters(Random random, int width, int height, int snakeX, int snakeY, int appleX, int appleY, int[,] snake)
        {
             // стоило сделать эти переменные локальными через оператор var, это более правильная работа с памятью
            snakeX = random.Next(1, width - 1);
            snakeY = random.Next(1, height - 1);

            snake[0, 0] = snakeX;
            snake[0, 1] = snakeY;

            Console.CursorVisible = false;

            appleX = random.Next(1, width - 1); 
            appleY = random.Next(1, height - 1);
        }

        private void GameLoop(Random random, int width, int height, int snakeX, int snakeY, int appleX, int appleY, int snakeLength, int[,] snake)
        {
            while (true)
            {
                var vector = UserInput();

                vector.X = snakeX;
                vector.Y = snakeY;

                Walk(snakeX, snakeY);
                AppleEating(random, width, height, snakeX, snakeY, appleX, appleY, snakeLength, snake);
                WallLogicY(height, snakeX, snakeY, snakeLength);
                WallLogicX(width, snakeX, snakeY, snakeLength);
                Death(snakeX, snakeY, snakeLength);
                System.Threading.Thread.Sleep(1000);
            }
        }

        private MyVector2 UserInput()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    return new MyVector2(0, 1);
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    return new MyVector2(0, -1);
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    return new MyVector2(1, 0);
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    return new MyVector2(-1, 0);
            }

            return new MyVector2();
        }

        private void Walk(int snakeX, int snakeY)
        {
            WritePointSnake(snakeX, snakeY);
        }

        private void AppleEating(Random random, int width, int height, int snakeX, int snakeY, int appleX, int appleY, int snakeLength, int[,] snake)
        {
            if (snakeY == appleY && snakeX == appleX)
            {
                snakeLength++;
                appleX = random.Next(2, (height - 1));
                appleY = random.Next(2, (width - 1));
                for (int i = snakeLength; i >= 0; i--)
                {
                    if (appleX == snakeX && appleY == snakeY)
                    {
                        appleX = random.Next(2, (height - 1));
                        appleY = random.Next(2, (width - 1));
                    }
                }
                SnakeGrowth(snakeLength, snake, snakeX, snakeY);

                Drawing(snakeX, snakeY, appleX, appleY, snakeLength);
            }
        }

        private void SnakeGrowth(int snakeLength, int[,] snake, int snakeX, int snakeY)
        {
            for (int i = snakeLength; i > 1; i--)
            {
                snakeX[i - 1] = snakeX[i - 2];
                snakeY[i - 1] = snakeY[i - 2];
            }
        }

        private void FieldDrawing(int width, int height)
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

        private void WritePointSnake(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("#");
        }

        private void WritePointApple(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("@");
        }

        private void Drawing(int snakeX, int snakeY, int appleX, int appleY, int snakeLength)
        {
            for (int i = 0; i < snakeLength; i++)
            {
                WritePointSnake(snakeX, snakeY);
                WritePointApple(appleX, appleY);
            }
        }

        private void WallLogicX(int width, int snakeX, int snakeY, int snakeLength)
        {
        if (snakeX == 0)
             {
                 snakeX = width - 1;
                 snakeX--;
                 for (int i = snakeLength; i > 1; i--)
                 {
                     snakeX[i - 1] = snakeX[i - 2];
                     snakeY[i - 1] = snakeY[i - 2];
                 }
             }
             if (snakeX == width - 1)
             {
                 snakeX = 1;
                snakeX++;
                 for (int i = snakeLength; i > 1; i--)
                 {
                     snakeX[i - 1] = snakeX[i - 2];
                     snakeY[i - 1] = snakeY[i - 2];
                 }
        }
    }

    private void WallLogicY(int height, int snakeX, int snakeY, int snakeLength)
     {
         if (snakeY == 0)
         {
             snakeY = height - 1;
                snakeY--;
             for (int i = snakeLength; i > 1; i--)
             {
                 snakeX[i - 1] = snakeX[i - 2];
                 snakeY[i - 1] = snakeY[i - 2];
             }
         }
         if (snakeY == height - 1)
         {
             snakeY = 1;
                snakeY++;
             for (int i = snakeLength; i > 1; i--)
             {
                 snakeX[i - 1] = snakeX[i - 2];
                 snakeY[i - 1] = snakeY[i - 2];
             }
         }
     }

    private void Death(int snakeX, int snakeY, int snakeLength)
    {
        for (int i = snakeLength; i > 0; i--)
        {
            if (snakeX == snakeX[i] && snakeY[0] == snakeY[i])
            {
                Console.WriteLine("Вы проиграли! Нажмите Enter, чтобы выйти:");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
  }
}
