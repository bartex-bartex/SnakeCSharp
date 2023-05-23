using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.x == p2.x && p1.y == p2.y);
        }


        public static bool operator !=(Point p1, Point p2)
        {
            return (p1.x != p2.x || p1.y != p2.y);

        }
    }

    public enum Direction { previousDirection, up, right, down, left }


    public class Snake
    {
        public Point Head { get { return Position[0]; } }
        public Point Tail { get { return Position[^1]; } }
        public List<Point> Position { get; private set; }
        private Direction currentDirection;

        public Snake(int mapWidth, int mapHeight)
        {
            Position = new List<Point>();

            //Spawn snake head in the middle
            Position.Add(new Point(mapWidth / 2, mapHeight / 2));

            //Initiate movement
            currentDirection = Direction.up;
        }

        public bool Move(Direction newDirection, int mapWidth, int mapHeight)
        {
            currentDirection = UpdateCurrentDirection(newDirection);

            switch (currentDirection)
            {
                case Direction.up:
                    UpdatePosition(Direction.up, mapWidth, mapHeight, 
                        new Point(Position[0].x, mapHeight - 2), new Point(Position[0].x, Position[0].y - 1));
                    break;

                case Direction.right:
                    UpdatePosition(Direction.right, mapWidth, mapHeight,
                        new Point(1, Position[0].y), new Point(Position[0].x + 1, Position[0].y));
                    break;

                case Direction.down:
                    UpdatePosition(Direction.down, mapWidth, mapHeight,
                        new Point(Position[0].x, 1), new Point(Position[0].x, Position[0].y + 1));
                    break;

                case Direction.left:
                    UpdatePosition(Direction.left, mapWidth, mapHeight,
                        new Point(mapWidth - 2, Position[0].y), new Point(Position[0].x - 1, Position[0].y));
                    break;

                default:
                    break;
            }
            return IsCollisionWithTail();
        }

        private Direction UpdateCurrentDirection(Direction newDirection)
        {
            // One line 'if' without brackets very readible

            if (newDirection == Direction.previousDirection) return currentDirection;

            if (Position.Count == 1) return newDirection;

            return ChangedDirection(newDirection) ?
                currentDirection : newDirection;
        }

        private bool ChangedDirection(Direction newDirection)
        {
            return (currentDirection == Direction.left && newDirection == Direction.right ||
                currentDirection == Direction.right && newDirection == Direction.left ||
                currentDirection == Direction.up && newDirection == Direction.down ||
                currentDirection == Direction.down && newDirection == Direction.up);
        }

        private bool IsCollisionWithBoundary(Direction direction, int mapWidth, int mapHeight)
        {
            switch (direction)
            {
                case Direction.up:
                    return (Position[0].y - 1 == 0);

                case Direction.right:
                    return (Position[0].x + 1 == mapWidth - 1);

                case Direction.down:
                    return (Position[0].y + 1 == mapHeight - 1);

                case Direction.left:
                    return (Position[0].x - 1 == 0);

                default:
                    return false;
            }
        }

        private void UpdatePosition(Direction direction, int mapWidth, int mapHeight, Point newHeadPointIfBorderHit, Point newHeadPointIfNormalMove)
        {
            if (IsCollisionWithBoundary(direction, mapWidth, mapHeight))
            {
                Position.Insert(0, newHeadPointIfBorderHit);
            }

            else
            {
                Position.Insert(0, newHeadPointIfNormalMove);
            }

            Position.RemoveAt(Position.Count - 1);
        }

        private bool IsCollisionWithTail()
        {
            return (Position.Skip(1).Contains(Position[0]));

        }
        
        public void IncreaseLength()
        {
            Position.Add(Position[Position.Count - 1]);
        }
    }
}
