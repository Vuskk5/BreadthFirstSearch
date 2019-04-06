using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PathFinding
{
    class BreadthFirstSearch
    {
        public static Cell[,] Graph = new Cell[45, 25];

        static void Main(string[] args)
        {
            /* Initialize Graph */
            for (int i = 0; i < Graph.GetLength(1); i++)        // Vertical loop
            {
                for (int j = 0; j < Graph.GetLength(0); j++)    // Horizontal loop
                {
                    Graph[j, i] = new Cell(j, i);
                    DrawNode(Graph[j, i], '#');
                    Console.Write(" ");
                    Thread.Sleep(1);
                }
                Console.WriteLine();
            }

            /* Define start & end points */
            Cell Start = Graph[1, 1];
            Cell Goal = Graph[Graph.GetLength(0)-2, Graph.GetLength(1)-2];

            /* Initialize start point */
            Start.isVisited = true;
            Start.type = Type.FLOOR;
            DrawNode(Start, '.');

            Cell Current = Start;

            Dictionary<Cell, Cell> came_from = new Dictionary<Cell, Cell>();
            came_from[Start] = null;

            /* Recursively create a maze */
            do
            {
                List<Cell> neighbors = WallNeighbors(Current);
                DrawNode(Current, '.');
                if (neighbors.Count > 0)
                {
                    Cell GoTo = neighbors[(new Random()).Next(neighbors.Count)];
                    Cell Between = Graph[Current.x + Math.Sign(GoTo.x - Current.x), Current.y + Math.Sign(GoTo.y - Current.y)];

                    DrawNode(GoTo, '.');
                    DrawNode(Between, '.');

                    GoTo.type = Type.FLOOR;
                    Between.type = Type.FLOOR;

                    came_from[GoTo] = Current;
                    Current = GoTo;
                    DrawNode(Current, 'O');
                }
                else
                {
                    Current.isVisited = true;
                    Current = came_from[Current];
                    DrawNode(Current, 'O');
                }
                Thread.Sleep(10);
            } while (Current != Start);

            DrawNode(Start, 'V');
            DrawNode(Goal, 'V');

            Queue<Cell> frontier = new Queue<Cell>();
            frontier.Enqueue(Start);

            came_from = new Dictionary<Cell, Cell>();
            came_from[Start] = null;

            while (frontier.Count != 0)
            {
                Cell current = frontier.Dequeue();

                if (current.Equals(Goal)) break;
                
                foreach (Cell next in Neighbors(current))
                {
                    Cell prev;
                    if (!came_from.TryGetValue(next, out prev))
                    {
                        frontier.Enqueue(next);
                        came_from[next] = current;
                        DrawNode(next, 'X');
                        Thread.Sleep(10);
                    }
                }
            }

            Cell path = Goal;
            while (came_from[path] != null)
            {
                DrawNode(path, 'O');
                path = came_from[path];
                Thread.Sleep(10);
            }
            DrawNode(Start, 'O');
        }

        public static void DrawNode(Cell p, char c)
        {
            Console.SetCursorPosition(1 + p.x * 2, p.y);
            Console.ForegroundColor = GetCharColor(c);
            Console.Write("\b" + c);
            Console.ResetColor();
            // Return to bottom
            Console.SetCursorPosition(0, Graph.GetLength(1));
        }

        public static List<Cell> Neighbors(Cell p)
        {
            Cell[] dirs = { new Cell(1, 0), new Cell(0, 1), new Cell(-1, 0), new Cell(0, -1) };
            List<Cell> Result = new List<Cell>();
            foreach (Cell dir in dirs)
            {
                if (isBetween(0, Graph.GetLength(0), p.x + dir.x) && isBetween(0, Graph.GetLength(1), p.y + dir.y))
                {
                    Cell neighbor = Graph[p.x + dir.x, p.y + dir.y];
                    if (neighbor.type.Equals(Type.FLOOR))
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

        public static List<Cell> WallNeighbors(Cell p)
        {
            Cell[] dirs = { new Cell(2, 0), new Cell(0, 2), new Cell(-2, 0), new Cell(0, -2) };
            List<Cell> Result = new List<Cell>();
            foreach (Cell dir in dirs)
            {
                if (isBetween(0, Graph.GetLength(0), p.x + dir.x) && isBetween(0, Graph.GetLength(1), p.y + dir.y))
                {
                    Cell neighbor = Graph[p.x + dir.x, p.y + dir.y];
                    if (neighbor != null)
                    {
                        if ((neighbor.x >= 0) && (neighbor.x < Graph.GetLength(0)) && (neighbor.y >= 0) && (neighbor.y < Graph.GetLength(1)))
                        {
                            if (neighbor.type.Equals(Type.WALL) && !neighbor.isVisited) Result.Add(neighbor);
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
