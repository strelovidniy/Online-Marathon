using System.Collections.Generic;

namespace Sprint_04.Task_04
{
    class RoomComparerByVolume<T> : IComparer<Room<T>> where T : IShape
    {
        public int Compare(Room<T> x, Room<T> y)
            => x.Volume() > y.Volume() ? 1 : -1;
    }
}
