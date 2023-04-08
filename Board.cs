using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        private List<Point> SnakePosition { get; set; } = new List<Point>();
        public readonly int Width;
        public readonly int Height;

        /// <summary>
        /// Indexer to SnakePosition list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Point this[int index]
        {
            get
            {
                return SnakePosition[index];
            }
            set
            {
                SnakePosition[index] = value;
            }
        }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            Console.SetWindowSize(Width, Height);

            //Spawn snake head
            SnakePosition.Add(new Point(Width / 2, Height / 2));
        }

        public int GetSnakePositionCount() => SnakePosition.Count;
    }
}
