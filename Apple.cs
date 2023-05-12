using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Apple
    {
        public Point Position { get; private set; }
        public bool IsEaten { get; private set; }

        public Apple(int mapWidth, int mapHeight, List<Point> snakePosition)
        {
            IsEaten = false;

            SpawnApple(mapWidth, mapHeight, snakePosition);
        }

        private void SpawnApple(int mapWidth, int mapHeight, List<Point> snakePosition)
        {
            Random rand = new Random();
            Point applePosition;

            do
            {
                applePosition = new Point(rand.Next(1, mapWidth - 2), rand.Next(1, mapHeight - 2));
            } while (snakePosition.Contains(applePosition) != false);

            Position = applePosition;
        }

        public bool CheckIfEaten(Point SnakeHeadPosition)
        {
            if(SnakeHeadPosition == Position)
            {
                IsEaten = true;
                return true;
            }
            return false;
        }
    }
}
