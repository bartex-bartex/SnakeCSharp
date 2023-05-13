using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Game
    {
        public Board Board { get; set; }
        public Snake Snake { get; set; }
        public Apple Apple { get; set; }
        public Score Score { get; set; }

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
            Point previousSnakeTail = new Point(Snake.GetSnakeTail().x, Snake.GetSnakeTail().y);
            while (true)
            {
                Board.Draw(Snake.Position, previousSnakeTail, Apple.Position);
                previousSnakeTail = Snake.GetSnakeTail();

                // Snake Movement
                Direction direction = KeyboardManager.GetDirection();
                bool isBodyCollision = Snake.Move(direction, Board.Width, Board.Height);
                if (isBodyCollision) break;
                

                // Handle apple eat
                if (Apple.CheckIfEaten(Snake.GetSnakeHead()))
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
