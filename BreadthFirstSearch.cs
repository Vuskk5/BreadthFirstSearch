using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PathFinding
{
    class Program
    {
        public static Point[,] Graph = new Point[40, 25];

        static void Main(string[] args)
        {
            /* Initialize Graph */
            for (int i = 0; i < Graph.GetLength(1); i++)        // Vertical loop
            {
                for (int j = 0; j < Graph.GetLength(0); j++)    // Horizontal loop
                {
                    Graph[j, i] = new Point(j, i);
                    DrawNode(Graph[j, i], '.');
                    Console.Write(" ");
                    Thread.Sleep(1);
                }
                Console.WriteLine();
            }

            /* Init walls */
            int[,] walls = { { 1, 0 }, { 1, 2 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 3, 0 }, { 3, 1 }, { 3, 2 }, { 5, 1 }, { 6, 1 }, { 7, 1 }, { 8, 1 }, { 5, 2 }, { 5, 3 }, { 5, 4 }, { 5, 5 }, { 3, 4 }, { 3, 5 }, { 3, 6 }, { 3, 7 }, { 3, 8 }, { 1, 7 }, { 1, 8 }, { 0, 9 }, { 2, 10 }, { 2, 11 }, { 1, 11 }, { 1, 12 }, { 1, 13 }, { 2, 13 }, { 3, 13 }, { 4, 13 }, { 5, 13 }, { 7, 13 }, { 8, 13 }, { 9, 13 }, { 10, 13 }, { 11, 13 }, { 12, 13 }, { 13, 13 }, { 14, 13 }, { 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 18, 14 }, { 7, 12 }, { 7, 11 }, { 7, 10 }, { 7, 9 }, { 7, 8 }, { 7, 7 }, { 6, 7 }, { 5, 7 }, { 5, 8 }, { 5, 9 }, { 5, 10 }, { 3, 10 }, { 3, 11 }, { 5, 11 }, { 6, 5 }, { 8, 5 }, { 9, 5 }, { 7, 3 }, { 8, 3 }, { 8, 4 }, { 9, 3 }, { 10, 3 }, { 10, 2 }, { 10, 1 }, { 11, 1 }, { 12, 1 }, { 13, 1 }, { 14, 1 }, { 15, 1 }, { 16, 1 }, { 17, 1 }, { 18, 1 }, { 12, 3 }, { 13, 3 }, { 14, 3 }, { 15, 3 }, { 16, 3 }, { 17, 3 }, { 18, 3 }, { 19, 3 }, { 12, 4 }, { 12, 5 }, { 11, 5 }, { 11, 6 }, { 11, 7 }, { 11, 8 }, { 11, 9 }, { 9, 7 }, { 9, 8 }, { 9, 9 }, { 9, 10 }, { 9, 11 }, { 9, 6 }, { 10, 11 }, { 11, 11 }, { 12, 11 }, { 13, 11 }, { 14, 11 }, { 15, 11 }, { 16, 11 }, { 18, 11 }, { 18, 12 }, { 18, 10 }, { 18, 9 }, { 17, 9 }, { 16, 9 }, { 16, 10 }, { 18, 7 }, { 18, 6 }, { 18, 5 }, { 18, 4 }, { 17, 7 }, { 16, 7 }, { 15, 7 }, { 14, 7 }, { 14, 8 }, { 14, 9 }, { 13, 9 }, { 12, 9 }, { 1, 14 }, { 1, 15 }, { 1, 16 }, { 1, 17 }, { 3, 15 }, { 4, 15 }, { 5, 15 }, { 6, 15 }, { 7, 15 }, { 8, 15 }, { 9, 15 }, { 10, 15 }, { 11, 15 }, { 13, 15 }, { 13, 16 }, { 13, 17 }, { 12, 17 }, { 11, 17 }, { 10, 17 }, { 9, 17 }, { 8, 17 }, { 7, 17 }, { 6, 17 }, { 5, 17 }, { 4, 17 }, { 3, 17 }, { 1, 18 }, { 1, 19 }, { 1, 20 }, { 1, 21 }, { 1, 22 }, { 1, 23 }, { 2, 23 }, { 3, 23 }, { 4, 23 }, { 5, 23 }, { 7, 23 }, { 8, 23 }, { 9, 23 }, { 10, 23 }, { 11, 23 }, { 12, 23 }, { 13, 23 }, { 13, 24 }, { 7, 22 }, { 7, 21 }, { 7, 20 }, { 7, 19 }, { 8, 19 }, { 9, 19 }, { 10, 19 }, { 11, 19 }, { 13, 19 }, { 13, 20 }, { 13, 21 }, { 12, 21 }, { 11, 21 }, { 10, 21 }, { 9, 21 }, { 5, 19 }, { 5, 20 }, { 5, 21 }, { 5, 22 }, { 3, 19 }, { 3, 20 }, { 3, 21 }, { 3, 22 }, { 4, 19 }, { 15, 15 }, { 16, 15 }, { 15, 16 }, { 15, 17 }, { 16, 17 }, { 16, 16 }, { 15, 19 }, { 16, 19 }, { 17, 19 }, { 18, 19 }, { 18, 18 }, { 18, 17 }, { 18, 16 }, { 19, 14 }, { 20, 14 }, { 20, 15 }, { 20, 16 }, { 20, 17 }, { 20, 18 }, { 20, 19 }, { 20, 20 }, { 20, 21 }, { 20, 22 }, { 20, 23 }, { 22, 24 }, { 22, 23 }, { 22, 22 }, { 21, 20 }, { 22, 20 }, { 23, 20 }, { 24, 20 }, { 24, 21 }, { 24, 22 }, { 24, 23 }, { 15, 23 }, { 16, 23 }, { 17, 23 }, { 18, 23 }, { 18, 22 }, { 18, 21 }, { 17, 21 }, { 16, 21 }, { 15, 21 }, { 26, 24 }, { 26, 23 }, { 26, 22 }, { 26, 21 }, { 26, 20 }, { 26, 19 }, { 26, 18 }, { 25, 18 }, { 24, 18 }, { 23, 18 }, { 22, 18 }, { 22, 17 }, { 22, 16 }, { 22, 15 }, { 22, 14 }, { 22, 13 }, { 22, 12 }, { 21, 12 }, { 20, 12 }, { 20, 11 }, { 20, 9 }, { 20, 8 }, { 20, 7 }, { 20, 6 }, { 20, 5 }, { 20, 4 }, { 20, 3 }, { 20, 2 }, { 20, 1 }, { 20, 0 }, { 19, 9 }, { 22, 10 }, { 22, 9 }, { 22, 8 }, { 22, 7 }, { 22, 6 }, { 22, 5 }, { 22, 4 }, { 22, 3 }, { 22, 2 }, { 22, 1 }, { 23, 1 }, { 25, 0 }, { 25, 1 }, { 25, 2 }, { 25, 3 }, { 24, 3 }, { 23, 3 }, { 24, 10 }, { 24, 9 }, { 24, 8 }, { 24, 7 }, { 24, 6 }, { 24, 5 }, { 23, 12 }, { 24, 12 }, { 24, 11 }, { 25, 5 }, { 26, 5 }, { 27, 5 }, { 27, 0 }, { 27, 1 }, { 27, 2 }, { 27, 3 }, { 28, 3 }, { 29, 3 }, { 29, 4 }, { 29, 5 }, { 29, 6 }, { 29, 7 }, { 29, 8 }, { 29, 10 }, { 27, 7 }, { 27, 8 }, { 27, 10 }, { 26, 7 }, { 26, 8 }, { 26, 10 }, { 30, 8 }, { 32, 8 }, { 32, 9 }, { 32, 10 }, { 31, 10 }, { 30, 10 }, { 30, 6 }, { 31, 6 }, { 32, 6 }, { 32, 7 }, { 24, 14 }, { 24, 15 }, { 24, 16 }, { 25, 14 }, { 26, 14 }, { 26, 13 }, { 26, 12 }, { 27, 12 }, { 25, 16 }, { 26, 16 }, { 27, 16 }, { 28, 16 }, { 28, 17 }, { 28, 18 }, { 28, 19 }, { 28, 20 }, { 28, 21 }, { 28, 22 }, { 28, 23 }, { 29, 23 }, { 30, 23 }, { 31, 23 }, { 32, 23 }, { 33, 23 }, { 33, 22 }, { 33, 21 }, { 33, 20 }, { 33, 19 }, { 33, 18 }, { 33, 17 }, { 35, 24 }, { 35, 23 }, { 35, 22 }, { 35, 21 }, { 35, 20 }, { 35, 18 }, { 35, 17 }, { 35, 16 }, { 35, 15 }, { 34, 15 }, { 32, 15 }, { 31, 15 }, { 31, 16 }, { 31, 17 }, { 31, 18 }, { 31, 20 }, { 31, 21 }, { 36, 18 }, { 37, 18 }, { 37, 19 }, { 37, 20 }, { 37, 21 }, { 37, 22 }, { 37, 23 }, { 38, 23 }, { 38, 24 }, { 30, 20 }, { 30, 21 }, { 30, 18 }, { 30, 17 }, { 30, 16 }, { 30, 15 }, { 28, 14 }, { 29, 14 }, { 30, 14 }, { 31, 14 }, { 32, 14 }, { 29, 12 }, { 29, 13 }, { 31, 12 }, { 31, 13 }, { 33, 12 }, { 33, 13 }, { 35, 13 }, { 35, 12 }, { 35, 11 }, { 35, 10 }, { 34, 10 }, { 34, 9 }, { 34, 8 }, { 34, 7 }, { 34, 6 }, { 34, 5 }, { 34, 4 }, { 33, 4 }, { 32, 4 }, { 31, 4 }, { 31, 3 }, { 29, 1 }, { 30, 1 }, { 31, 1 }, { 33, 0 }, { 33, 1 }, { 33, 2 }, { 35, 1 }, { 36, 1 }, { 37, 1 }, { 38, 1 }, { 38, 2 }, { 38, 3 }, { 38, 4 }, { 38, 5 }, { 36, 3 }, { 36, 4 }, { 36, 5 }, { 36, 6 }, { 36, 7 }, { 37, 7 }, { 38, 7 }, { 39, 7 }, { 37, 9 }, { 37, 10 }, { 37, 11 }, { 36, 11 }, { 39, 9 }, { 39, 10 }, { 39, 11 }, { 39, 12 }, { 39, 13 }, { 39, 14 }, { 39, 15 }, { 37, 13 }, { 37, 14 }, { 37, 15 }, { 37, 16 }, { 39, 16 }, { 39, 17 }, { 39, 18 }, { 39, 19 }, { 39, 20 }, { 39, 21 }};

            for (int i = 0; i < walls.GetLength(0); i++)
            {
                int x = walls[i, 0];
                int y = walls[i, 1];
                Graph[x, y] = null;
                DrawNode(new Point(x, y), '#');
                Thread.Sleep(1);
            }

            Point Start = Graph[0, 0];
            Point Goal = Graph[39, 24];

            DrawNode(Start, 'V');
            DrawNode(Goal, 'V');

            Queue<Point> frontier = new Queue<Point>();
            frontier.Enqueue(Start);

            Dictionary<Point, Point> came_from = new Dictionary<Point, Point>();
            came_from[Start] = null;

            while (frontier.Count != 0)
            {
                Point current = frontier.Dequeue();

                if (current.Equals(Goal)) break;
                
                foreach (Point next in Neighbors(current))
                {
                    Point prev;
                    if (!came_from.TryGetValue(next, out prev))
                    {
                        frontier.Enqueue(next);
                        came_from[next] = current;
                        DrawNode(next, 'X');
                        Thread.Sleep(20);
                    }
                }
            }

            Point path = Goal;
            while (came_from[path] != null)
            {
                DrawNode(path, 'O');
                path = came_from[path];
                Thread.Sleep(20);
            }
            DrawNode(Start, 'O');
        }

        public static void DrawNode(Point p, char c)
        {
            Console.SetCursorPosition(1 + p.x * 2, p.y);
            Console.ForegroundColor = GetCharColor(c);
            Console.Write("\b" + c);
            Console.ResetColor();
            // Return to bottom
            Console.SetCursorPosition(0, Graph.GetLength(1));
        }

        public static List<Point> Neighbors(Point p)
        {
            Point[] dirs = { new Point(1, 0), new Point(0, 1), new Point(-1, 0), new Point(0, -1) };
            List<Point> Result = new List<Point>();
            foreach (Point dir in dirs)
            {
                if (isBetween(0, Graph.GetLength(0), p.x + dir.x) && isBetween(0, Graph.GetLength(1), p.y + dir.y))
                {
                    Point neighbor = Graph[p.x + dir.x, p.y + dir.y];
                    if (neighbor != null)
                    {
                        if ((neighbor.x >= 0) && (neighbor.x < Graph.GetLength(0)) && (neighbor.y >= 0) && (neighbor.y < Graph.GetLength(1)))
                        {
                            Result.Add(neighbor);
                        }
                    }
                }
            }

            return Result;
        }

        // Check if a value is bigger than min (inclusive) and smaller than max (exclusive)
        public static bool isBetween(int min, int max, int value)
        {
            return (value >= min && value < max);
        }

        public static ConsoleColor GetCharColor(char c)
        {
            switch (c)
            {
                case ('#'):
                    return ConsoleColor.Red;
                case ('X'):
                    return ConsoleColor.Green;
                case ('V'):
                    return ConsoleColor.Blue;
                case ('.'):
                    return ConsoleColor.White;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}
