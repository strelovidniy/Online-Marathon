﻿using System;

namespace Sprint_02.Task_01
{
    internal class Employee
    {
        internal string name;
        private DateTime hiringDate;

        public Employee(string name, DateTime hiringDate)
        {
            this.name = name;
            this.hiringDate = hiringDate;
        }

        public int Experience() 
            => DateTime.Now.Year - hiringDate.Year - Convert.ToInt32(DateTime.Now.DayOfYear < hiringDate.DayOfYear);

        public void ShowInfo() 
            => Console.WriteLine("{0} has {1} years of experience", name, Experience());
    }
}
