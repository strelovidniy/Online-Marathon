using System;

namespace Sprint_01.Task_01
{
    internal class MyAccessModifiers
    {
        private int birthYear;
        protected string personalInfo;
        private protected string IdNumber;
        public byte averageMiddleAge = 50;

        public MyAccessModifiers(int birthYear, string IdNumber, string personalInfo)
        {
            this.birthYear = birthYear;
            this.IdNumber = IdNumber;
            this.personalInfo = personalInfo;
        }

        public int Age 
            => DateTime.Now.Year - birthYear;

        internal string Name { get; set; }

        public string NickName { get; internal set; }

        protected internal bool HasLivedHalfOfLife()
            => Age > averageMiddleAge;

        public static bool operator ==(MyAccessModifiers m1, MyAccessModifiers m2)
            =>  m1.Age == m2.Age && 
                m1.Name == m2.Name && 
                m1.personalInfo == m2.personalInfo;

        public static bool operator !=(MyAccessModifiers m1, MyAccessModifiers m2)
            => !(m1 == m2);

        public override int GetHashCode() 
            => Age + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;

        public override bool Equals(object obj)
            => obj is MyAccessModifiers myAccessModifiers
               && myAccessModifiers.Name == this.Name
               && myAccessModifiers.Age == this.Age
               && myAccessModifiers.personalInfo == this.personalInfo;
    }
}
