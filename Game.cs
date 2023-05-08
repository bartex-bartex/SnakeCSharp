using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
{
    public class Game
    {
        // Normal name convention practice
        public Board Board { get; set; }
        public Snake Snake { get; set; }
        public Apple Apple { get; set; }
        public Score Score { get; set; }


        public Game(int width, int height)
        {
            Board = new Board(width, height);
            Snake = new Snake(width, height);
            Apple = new Apple(width, height, Snake.SnakePos);
            Score = new Score();

            Console.CursorVisible = false;
            // Additional line for score
            Console.SetWindowSize(width, height + 1);
        }

        public void Start()
        {
            while (true)
            {
                Board.Draw(Snake.SnakePos, Apple.Position);

                Direction direction = KeyboardManager.GetKey();
                Snake.Move(direction, Board.Width, Board.Height);
                if(Snake.CheckForCollisionWithTail() == true)
                {
                    break;
                }

                if (Snake.SnakePos[0] == Apple.Position)
                {
                    Apple.IsEaten = true;
                    Snake.IncreaseLength();
                    Score.IncreasePoints();

                    Apple = new Apple(Board.Width, Board.Height, Snake.SnakePos);
                }

                Score.PrintScore(Board.Height);
                Thread.Sleep(1000/16);
            }

            Messages.GameOverMessage(Board.Width, Board.Height, Score.points);
            Console.ReadLine();
        }
    }
}
