using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
{
    public enum eDirection { Up, Down, Right, Left, None }

    public static class KeyboardManager
    {
        public static eDirection GetDirection()
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.A:
                    return eDirection.Left;
                case ConsoleKey.D:
                    return eDirection.Right;
                case ConsoleKey.W:
                    return eDirection.Up;
                case ConsoleKey.S:
                    return eDirection.Down;
                default:
                    return eDirection.None;
            }
        }
    }
}
