using System;
using System.Collections.Generic;
using System.Text;

namespace Echecs.Plat
{
    public class Position
    {
        private int x;
        private int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Position(Position p)
        {
            this.x = p.X;
            this.y = p.Y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public bool IsLine(Position p)
        {

            int deltaX = X - p.X;
            int deltaY = Y - p.Y;

            return deltaX == 0 ^ deltaY == 0;
            
        }

        public bool IsDiag(Position p)
        {
            // Un point n'est pas un segment
            if (Equals(p))
            {
                return false;
            }

            int deltaX = X - p.X;
            int deltaY = Y - p.Y;

            return Math.Abs(deltaX) == Math.Abs(deltaY);
        }

        public static bool operator ==(Position p1, Position p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }
        public static bool operator !=(Position p1, Position p2) => !(p1 == p2);

        public override bool Equals(Object pos)
        {
            if (pos is Position)
            {
                return ((Position)pos).X == x && ((Position)pos).Y == y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return x * 1024 + y;
        }

        public override string ToString()
        {
            string str = "[" + x + ";" + y + "]";
            return str;
        }
    }
}
