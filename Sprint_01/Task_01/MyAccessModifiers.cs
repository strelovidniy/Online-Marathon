using System;

namespace Sprint_01.Task_01
{
    class MyAccessModifiers
    {
        private int birthYear;
        protected string personalInfo;
        private protected string IdNumber;
        public byte averageMiddleAge = 50;
        private string name;
        private string nickName;

        public MyAccessModifiers(int birthYear, string IdNumber, string personalInfo)
        {
            this.birthYear = birthYear;
            this.IdNumber = IdNumber;
            this.personalInfo = personalInfo;
        }

        public int Age
        {
            get => DateTime.Now.Year - birthYear;
        }

        internal string Name
        {
            get => name;
            set => name = value;
        }

        public string NickName
        {
            get => nickName;
            internal set => this.nickName = value;
        }

        protected internal bool HasLivedHalfOfLife()
        {
            return Age > averageMiddleAge;
        }

        public static bool operator ==(MyAccessModifiers m1, MyAccessModifiers m2)
        {
            return m1.Age == m2.Age && 
                m1.Name == m2.Name && 
                m1.personalInfo == m2.personalInfo;
        }

        public static bool operator !=(MyAccessModifiers m1, MyAccessModifiers m2)
        {
            return !(m1 == m2);
        }

        public override int GetHashCode()
        {
            return Age + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MyAccessModifiers))
                return false;

            return Name == ((MyAccessModifiers)obj).Name &&
                Age == ((MyAccessModifiers)obj).Age &&
                personalInfo == ((MyAccessModifiers)obj).personalInfo;
        }
    }
}
