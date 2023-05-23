using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Game
    {
        // Never publicly expose internal state -> private/protected set;
        public Board Board { get; private set; }
        public Snake Snake { get; private set; }
        public Apple Apple { get; private set; }
        public Score Score { get; private set; }

        private const int scoreTextHeight = 1;
        private const int FPS = 16; 


        public Game(int width, int height)
        {
            Board = new Board(width, height);
            Snake = new Snake(width, height);
            Apple = new Apple(width, height, Snake.Position);
            Score = new Score();

            Console.CursorVisible = false;
            Console.SetWindowSize(width, height + scoreTextHeight);
        }

        public void Start()
        {
            Point previousSnakeTail = new Point(Snake.Tail.x, Snake.Tail.y);
            bool isBodyCollision = false;

            while (! isBodyCollision)
            {
                Board.Draw(Snake.Position, previousSnakeTail, Apple.Position);
                previousSnakeTail = Snake.Tail;

                // Snake Movement
                Direction direction = KeyboardManager.GetDirection();
                isBodyCollision = Snake.Move(direction, Board.Width, Board.Height);
                

                // Handle apple eat
                if (Apple.IsEaten(Snake.Head))
                {
                    Snake.IncreaseLength();
                    Score.IncreasePoints();

                    Apple = new Apple(Board.Width, Board.Height, Snake.Position);
                }

                Score.PrintScore(Board.Height);
                Thread.Sleep(1000 / FPS);
            }

            Messages.GameOverMessage(Board.Width, Board.Height, Score.GetPoints());
            Console.ReadLine();
        }
    }
}
