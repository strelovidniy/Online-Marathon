namespace Sprint_01.Task_05
{
    internal class Person
    {
        protected int yearOfBirth;
        protected string healthInfo;
        protected string name;

        public string GetHealthStatus() 
            => name + ": " + yearOfBirth + ". " + healthInfo;

        public Person(int yearOfBirth, string name, string healthInfo)
        {
            this.yearOfBirth = yearOfBirth;
            this.name = name;
            this.healthInfo = healthInfo;
        }
    }
}
