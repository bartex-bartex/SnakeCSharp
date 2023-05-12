using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public static class KeyboardManager
    {
        public static Direction GetDirection()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                ClearBuffer();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        return Direction.right;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        return Direction.down;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        return Direction.left;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        return Direction.up;
                    default:
                        return Direction.previousDirection;
                }
            }
            return Direction.previousDirection;
        }

        private static void ClearBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}
