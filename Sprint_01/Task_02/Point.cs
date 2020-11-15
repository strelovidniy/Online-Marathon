using System;

namespace Sprint_01.Task_02
{
    internal class Point
    {
        private int x;
        private int y;

        public static explicit operator double(Point point) 
            => Math.Sqrt(point.x * point.x + point.y * point.y);

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal int[] GetXYPair()
            => new int[] { x, y };

        protected internal double Distance(int x, int y)
            => Math.Sqrt((this.x - x) * (this.x - x) + (this.y - y) * (this.y - y));

        protected internal double Distance(Point point) 
            => Math.Sqrt((this.x - point.x) * (this.x - point.x) + (this.y - point.y) * (this.y - point.y));
    }
}
