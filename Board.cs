using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{

    public class Board
    {
        public readonly int Width;
        public readonly int Height;

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Draw(List<Point> snakePosition, Point previousSnakeTail, Point applePosition)
        {
            DrawBoard();

            DrawSnake(snakePosition, previousSnakeTail);

            DrawApple(applePosition);
        }

        private static void DrawApple(Point applePosition)
        {
            Console.SetCursorPosition(applePosition.x, applePosition.y);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("@");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static void DrawSnake(List<Point> snakePosition, Point previousSnakeTail)
        {
            for (int i = 0; i < snakePosition.Count; i++)
            {
                Console.SetCursorPosition(snakePosition[i].x, snakePosition[i].y);
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("O");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write("o");
                }
            }
            // Instead of redrawing whole Board just clear previous Snake tail
            Console.SetCursorPosition(previousSnakeTail.x, previousSnakeTail.y);
            Console.Write(" ");
        }

        private void DrawBoard()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < Width; i++)
            {
                Console.Write("#");
            }

            Console.WriteLine();
            for (int i = 0; i < Height - 2; i++)
            {
                Console.Write("#");
                Console.SetCursorPosition(Width - 1, i + 1);
                Console.WriteLine("#");
            }

            for (int i = 0; i < Width; i++)
            {
                Console.Write("#");
            }
        }
    }
}
