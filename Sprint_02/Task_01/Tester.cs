using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_02.Task_01
{
    class Tester : Employee
    {
        private bool isAuthomation;

        public Tester(string name, DateTime hiringDate, bool isAuthomation) : base(name, hiringDate)
        {
            this.isAuthomation = isAuthomation;
        }

        public new void ShowInfo()
        {
            if (isAuthomation)
            {
                Console.WriteLine("{0} is authomated tester and has {1} year(s) of experience", name, Experience());
            }
            else
            {
                Console.WriteLine("{0} is manual tester and has {1} year(s) of experience", name, Experience());
            }
        }
    }
}
