using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
    enum Type
    {
        FLOOR = 1,
        WALL = 2
    }

    class Cell
    {
        public int x;
        public int y;
        public bool isVisited;
        public Type type;


        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.isVisited = false;
            this.type = Type.WALL;
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }
}