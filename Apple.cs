using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
{
    public class Apple
    {
        public Point Position { get; private set; }
        public bool IsEaten { get; set; }

        public Apple(int mapWidth, int mapHeight, List<Point> snakePos)
        {
            IsEaten = false;

            SpawnApple(mapWidth, mapHeight, snakePos);
        }

        public void SpawnApple(int mapWidth, int mapHeight, List<Point> snakePos)
        {
            Random rand = new Random();
            Point applePos;

            do
            {
                applePos = new Point(rand.Next(1, mapWidth - 2), rand.Next(1, mapHeight - 2));
            } while (snakePos.Contains(applePos) == true);

            Position = applePos;
        }
    }
}
