using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Apple
    {
        public Point Position { get; private set; }

        public Apple(int mapWidth, int mapHeight, List<Point> snakePosition)
        {
            Spawn(mapWidth, mapHeight, snakePosition);
        }

        private void Spawn(int mapWidth, int mapHeight, List<Point> snakePosition)
        {
            Random rand = new Random();
            Point applePosition;

            do
            {
                applePosition = new Point(rand.Next(1, mapWidth - 2), rand.Next(1, mapHeight - 2));
            } while (snakePosition.Contains(applePosition) != false);

            Position = applePosition;
        }

        public bool IsEaten(Point SnakeHeadPosition)
        {
            return SnakeHeadPosition == Position;
        }
    }
}
