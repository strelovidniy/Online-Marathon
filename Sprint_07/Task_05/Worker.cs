using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sprint_07.Task_05
{
    internal class Worker
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("Full name")]
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public Department Department { get; set; }

        public string Serialize()
            => JsonSerializer.Serialize(
                this, 
                new JsonSerializerOptions() 
                {
                    WriteIndented = true,
                    IgnoreNullValues = true
                });

        public static Worker Deserialize(string serializedItem)
            => JsonSerializer.Deserialize<Worker>(serializedItem);

        public Worker()
        {

        }

        public Worker(string name, decimal salary, Department department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }
    }
}