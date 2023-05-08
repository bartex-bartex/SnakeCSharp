using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
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

        public void Draw(List<Point> snakePos, Point applePos)
        {
            // Draw Boundaries
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < Width; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine();
            for (int i = 0; i < Height - 2; i++)
            {
                Console.Write("#");
                for (int j = 0; j < Width - 2; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("#");
            }
            for (int i = 0; i < Width; i++)
            {
                Console.Write("#");
            }

            // Draw Snake
            for (int i = 0; i < snakePos.Count; i++)
            {
                Console.SetCursorPosition(snakePos[i].x, snakePos[i].y);
                if(i == 0)
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

            // Draw Apple
            Console.SetCursorPosition(applePos.x, applePos.y);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("@");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
