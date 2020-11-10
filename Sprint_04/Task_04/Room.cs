using System;

namespace Sprint_04.Task_04
{
    class Room<T> : ICloneable, IComparable where T : IShape
    {
        public double Height { get; set; }

        public T Floor { get; set; }

        public double Volume() => Height * Floor.Area();

        public int CompareTo(object obj)
            => this.Floor.Area() > (obj as Room<IShape>).Floor.Area() ? 1 : -1;

        public object Clone()
            => new Room<T> { Floor = (T)this.Floor.Clone(), Height = this.Height, };
    }
}
