using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Score
    {
        public int Points { get; private set; } = 0;
        public void PrintScore(int mapHeight)
        {
            Console.SetCursorPosition(0, mapHeight);
            Console.Write($"Your score: {Points}");
        }

        public void IncreasePoints()
        {
            Points++;
        }
    }
}
