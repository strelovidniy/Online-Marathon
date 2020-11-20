namespace Sprint_07.Task_05
{
    internal class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Worker Manager { get; set; }
        
        public Department()
        {

        }

        public Department(string name, int id, Worker manager)
        {
            this.Name = name;
            this.Id = id;
            this.Manager = manager;
        }
    }
}
