using System;

namespace Sprint_02.Task_01
{
    internal class Developer : Employee
    {
        private readonly string programmingLanguage;

        public Developer(string name, DateTime hiringDate, string programmingLanguage) : base(name, hiringDate)
        {
            this.programmingLanguage = programmingLanguage;
        }

        public new void ShowInfo() 
            => Console.WriteLine("{0} has {1} years of experience.\n{2} is {3} programmer", name, Experience(), name,
                programmingLanguage);
    }
}