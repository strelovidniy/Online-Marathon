using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_01
{
    class Child : Person
    {
        private string childIDNumber;

        public Child (int yearOfBirth, string name, string healthInfo, string childIDNumber) : base(yearOfBirth, name, healthInfo)
        {
            this.childIDNumber = childIDNumber;
        }

        public override string ToString()
            => $"{base.name} {childIDNumber}";
    }
}
