using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
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

    public enum Direction { previouskey, up = 1, right = 2, down = 3, left = 4 }


    public class Snake
    {
        public List<Point> SnakePos { get; } = new List<Point>();
        private Direction currentDirection;

        public Snake(int width, int height)
        {
            SnakePos = new List<Point>();

            //Spawn snake head
            SnakePos.Add(new Point(width / 2, height / 2));

            //Initial direction
            currentDirection = Direction.up;
        }

        public void Move(Direction direction, int mapWidth, int mapHeight)
        {
            // Set variables, prevent turning back when length > 1
            if(direction != Direction.previouskey)
            {
                UpdateDirection(direction);
            }


            switch (currentDirection)
            {
                case Direction.up:
                    if (SnakePos.Count == 1 || SnakePos[0].y - 1 != SnakePos[1].y)
                    {
                        if (CheckForCollision(Direction.up, mapWidth, mapHeight) == true)
                        {
                            SnakePos.Insert(0, new Point(SnakePos[0].x, mapHeight - 2));
                            SnakePos.RemoveAt(SnakePos.Count - 1);
                        }
                        else
                        {
                            SnakePos.Insert(0, new Point(SnakePos[0].x, SnakePos[0].y - 1));
                            SnakePos.RemoveAt(SnakePos.Count - 1);
                        }
                    }
                    break;
                case Direction.right:
                    if (SnakePos.Count == 1 || SnakePos[0].x + 1 != SnakePos[1].x)
                    {
                        if (CheckForCollision(Direction.right, mapWidth, mapHeight) == true)
                        {
                            SnakePos.Insert(0, new Point(1, SnakePos[0].y));
                            SnakePos.RemoveAt(SnakePos.Count - 1);
                        }
                        else
                        {
                            SnakePos.Insert(0, new Point(SnakePos[0].x + 1, SnakePos[0].y));
                            SnakePos.RemoveAt(SnakePos.Count - 1);
                        }
                    }
                    break;
                case Direction.down:
                    if (SnakePos.Count == 1 || SnakePos[0].y + 1 != SnakePos[1].y)
                    {
                        if (CheckForCollision(Direction.down, mapWidth, mapHeight) == true)
                        {
                            SnakePos.Insert(0, new Point(SnakePos[0].x, 1));
                            SnakePos.RemoveAt(SnakePos.Count - 1);
                        }
                        else
                        {
                            SnakePos.Insert(0, new Point(SnakePos[0].x, SnakePos[0].y + 1));
                            SnakePos.RemoveAt(SnakePos.Count - 1);
                        }
                    }
                    break;
                case Direction.left:
                    if (SnakePos.Count == 1 || SnakePos[0].x - 1 != SnakePos[1].x)
                    {
                        if (CheckForCollision(Direction.left, mapWidth, mapHeight) == true)
                        {
                            SnakePos.Insert(0, new Point(mapWidth - 2, SnakePos[0].y));
                            SnakePos.RemoveAt(SnakePos.Count - 1);
                        }
                        else
                        {
                            SnakePos.Insert(0, new Point(SnakePos[0].x - 1, SnakePos[0].y));
                            SnakePos.RemoveAt(SnakePos.Count - 1);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void UpdateDirection(Direction direction)
        {
            if (SnakePos.Count == 1)
            {
                currentDirection = direction;
            }
            else if (currentDirection == Direction.left && direction != Direction.right ||
                currentDirection == Direction.up && direction != Direction.down ||
                currentDirection == Direction.right && direction != Direction.left ||
                currentDirection == Direction.down && direction != Direction.up)
            {
                currentDirection = direction;
            }          
        }

        /// <summary>
        /// Checks for a collision with boundary before making move
        /// </summary>
        /// <returns>return true if collision occures</returns>
        private bool CheckForCollision(Direction direction, int mapWidth, int mapHeight)
        {
            switch (direction)
            {
                case Direction.up:
                    if (SnakePos[0].y - 1 == 0)
                    {
                        return true;
                    }
                    return false;
                case Direction.right:
                    if (SnakePos[0].x + 1 == mapWidth - 1)
                    {
                        return true;
                    }
                    return false;
                case Direction.down:
                    if (SnakePos[0].y + 1 == mapHeight - 1)
                    {
                        return true;
                    }
                    return false;
                case Direction.left:
                    if (SnakePos[0].x - 1 == 0)
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }
        public bool CheckForCollisionWithTail()
        {
            if (SnakePos.Skip(1).Contains(SnakePos[0]))
            {
                return true;
            }
            return false;
        }

        public void IncreaseLength()
        {
            SnakePos.Add(SnakePos[SnakePos.Count - 1]);
        }
    }
}
