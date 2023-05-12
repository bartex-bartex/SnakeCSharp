using System;
using System.Collections.Generic;
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

        public static bool operator== (Point p1, Point p2)
        {
            if(p1.x == p2.x && p1.y == p2.y)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            if (p1.x != p2.x || p1.y != p2.y)
            {
                return true;
            }
            return false;
        }
    }

    public enum Direction { previousDirection, up, right, down, left }


    public class Snake
    {
        public List<Point> Position { get; private set; } = new List<Point>();
        private Direction currentDirection;

        public Snake(int mapWidth, int mapHeight)
        {
            Position = new List<Point>();

            //Spawn snake head in the middle
            Position.Add(new Point(mapWidth / 2, mapHeight / 2));

            //Initial movement
            currentDirection = Direction.up;
        }

        public bool Move(Direction newDirection, int mapWidth, int mapHeight)
        {
            currentDirection = UpdateCurrentDirection(newDirection);

            switch (currentDirection)
            {
                case Direction.up:
                    UpdateSnakePositionList(Direction.up, mapWidth, mapHeight, 
                        new Point(Position[0].x, mapHeight - 2), new Point(Position[0].x, Position[0].y - 1));
                    break;
                case Direction.right:
                    UpdateSnakePositionList(Direction.right, mapWidth, mapHeight,
                        new Point(1, Position[0].y), new Point(Position[0].x + 1, Position[0].y));
                    break;
                case Direction.down:
                    UpdateSnakePositionList(Direction.down, mapWidth, mapHeight,
                        new Point(Position[0].x, 1), new Point(Position[0].x, Position[0].y + 1));
                    break;
                case Direction.left:
                    UpdateSnakePositionList(Direction.left, mapWidth, mapHeight,
                        new Point(mapWidth - 2, Position[0].y), new Point(Position[0].x - 1, Position[0].y));
                    break;
                default:
                    break;
            }
            return CheckIfCollisionWithTail();
        }

        private Direction UpdateCurrentDirection(Direction newDirection)
        {
            if (newDirection != Direction.previousDirection)
            {
                if (Position.Count == 1)
                { 
                    return newDirection;
                }
                if (CheckIfOppositeDirection(newDirection) == true)
                {
                    return currentDirection;
                }
                else
                {
                    return newDirection;
                }
            }
            else
            {
                return currentDirection;
            }
        }

        private bool CheckIfOppositeDirection(Direction newDirection)
        {
            if (currentDirection == Direction.left && newDirection == Direction.right ||
                currentDirection == Direction.right && newDirection == Direction.left ||
                currentDirection == Direction.up && newDirection == Direction.down ||
                currentDirection == Direction.down && newDirection == Direction.up)
            {
                return true;
            }
            return false;
        }

        private bool CheckIfCollisionWithBoundary(Direction direction, int mapWidth, int mapHeight)
        {
            switch (direction)
            {
                case Direction.up:
                    if (Position[0].y - 1 == 0)
                    {
                        return true;
                    }
                    return false;
                case Direction.right:
                    if (Position[0].x + 1 == mapWidth - 1)
                    {
                        return true;
                    }
                    return false;
                case Direction.down:
                    if (Position[0].y + 1 == mapHeight - 1)
                    {
                        return true;
                    }
                    return false;
                case Direction.left:
                    if (Position[0].x - 1 == 0)
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        private void UpdateSnakePositionList(Direction direction, int mapWidth, int mapHeight, Point newHeadPointIfBorderHit, Point newHeadPointIfNormalMove)
        {
            if (CheckIfCollisionWithBoundary(direction, mapWidth, mapHeight) == true)
            {
                Position.Insert(0, newHeadPointIfBorderHit);
            }
            else
            {
                Position.Insert(0, newHeadPointIfNormalMove);
            }
            Position.RemoveAt(Position.Count - 1);
        }

        private bool CheckIfCollisionWithTail()
        {
            if (Position.Skip(1).Contains(Position[0]))
            {
                return true;
            }
            return false;
        }
        
        public void IncreaseLength()
        {
            Position.Add(Position[Position.Count - 1]);
        }
    }
}
