using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Sprint_01
{
    class Point
    {
        private int x;

        private int y;

        public static explicit operator double(Point point)
        {
            return Math.Sqrt(point.x * point.x + point.y * point.y);
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal int[] GetXYPair()
        {
            return new int[] { x, y };
        }

        protected internal double Distance(int x, int y)
        {
            return Math.Sqrt((this.x - x) * (this.x - x) + (this.y - y) * (this.y - y));
        }

        protected internal double Distance(Point point)
        {
            return Math.Sqrt((this.x - point.x) * (this.x - point.x) + (this.y - point.y) * (this.y - point.y));
        }
    }
}
