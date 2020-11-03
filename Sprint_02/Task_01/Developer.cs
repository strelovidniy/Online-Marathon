using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_02.Task_01
{
    class Developer : Employee
    {
        private string programmingLanguage;
        
        public Developer(string name, DateTime hiringDate, string programmingLanguage) : base(name, hiringDate)
        {
            this.programmingLanguage = programmingLanguage;
        }

        public new void ShowInfo()
        {
            Console.WriteLine("{0} has {1} years of experience.\n{2} is {3} programmer", name, Experience(), name, programmingLanguage);
        }
    }
}
