using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
{
    public class Score
    {
        public int points { get; private set; } = 0;
        public void PrintScore(int mapHeight)
        {
            Console.SetCursorPosition(0, mapHeight);
            Console.Write($"Your score: {points}");
        }

        public void IncreasePoints()
        {
            points++;
        }
    }
}
