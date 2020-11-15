namespace Sprint_01.Task_05
{
    internal class Adult : Person
    {
        private string passportNumber;
        
        public Adult(int yearOfBirth, string name, string healthInfo, string passportNumber) : base(yearOfBirth, name, healthInfo)
            => this.passportNumber = passportNumber;

        public override string ToString()
            => $"{base.name} {passportNumber}";
    }
}
