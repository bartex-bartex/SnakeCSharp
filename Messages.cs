using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
{
    public static class Messages
    {
        public static void GameOverMessage(int mapWidth, int mapHeight, int score)
        {
            Console.SetCursorPosition(mapWidth / 4, mapHeight / 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GAME OVER");
            Console.SetCursorPosition(mapWidth / 4, mapHeight / 2 + 1);
            Console.WriteLine($"Your score was: {score}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
