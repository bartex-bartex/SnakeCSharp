using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
{
    public class Game
    {
        private Board board;


        public Game(int width, int height)
        {
            board = new Board(width, height);
            Console.CursorVisible = false;
        }

        public void Run()
        {
            while(true)
            {
                Draw();
                Move();
            }

        }

        private void Draw()
        {
            Console.Clear();

            DrawBoundaries();

            Console.SetCursorPosition(board[0].x, board[0].y);
            Console.Write("O");

            for (int i = 0; i < board.GetSnakePositionCount(); i++)
            {
                Console.SetCursorPosition(board[i].x, board[i].y);
                Console.Write("o");
            }
        }

        private void DrawBoundaries() //totally bad idea -> SetCursorPosition? - check out how good it is.
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("+");
            Console.SetCursorPosition(board.Width - 1, 0);
            Console.Write("+");
            Console.SetCursorPosition(0, board.Height - 1);
            Console.Write("+");
            Console.SetCursorPosition(board.Width - 1, board.Height - 1);
            Console.Write("+");

            Console.SetCursorPosition(1, 0);
            for (int i = 0; i < board.Width - 2; i++) Console.Write("-");

            Console.SetCursorPosition(1, board.Height - 1);
            for (int i = 0; i < board.Width - 2; i++) Console.Write("-");

            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < board.Height - 2; i++) Console.WriteLine("|");


            for (int i = 0; i < board.Height - 3; i++)
            {
                Console.SetCursorPosition(board.Width - 1, i + 1);
                Console.Write("|");
            }
        }

        private void Move()
        {
            switch (KeyboardManager.GetDirection())
            {
                case eDirection.Up:
                    board[0] = new Point(board[0].x, board[0].y - 1);
                    break;
                case eDirection.Down:
                    board[0] = new Point(board[0].x, board[0].y + 1);
                    break;
                case eDirection.Left:
                    board[0] = new Point(board[0].x - 1, board[0].y);
                    break;
                case eDirection.Right:
                    board[0] = new Point(board[0].x + 1, board[0].y);
                    break;
            }
        }
    }
}
