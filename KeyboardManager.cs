using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
{
    public static class KeyboardManager
    {
        public static Direction GetKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);


                ClearBuffer();

                switch (key.Key)
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
                        return Direction.previouskey;
                }
            }
            return Direction.previouskey;
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
