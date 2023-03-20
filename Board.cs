using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Board
    {
        public List<Point> Snake { get; } = new List<Point>();
        public readonly int Width;
        public readonly int Height;

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            Console.SetWindowSize(Width, Height);

            //Spawn snake head
            Snake.Add(new Point(Width / 2, Height / 2));
        }
    }
}
