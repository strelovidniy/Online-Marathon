using System.Collections.Generic;
using System.Linq;

namespace Sprint_05.Level_3.Task_01
{
    class Student
    {
        public int ID { get; }
        public string Name { get; }

        public Student(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name ?? "";
        }

        public static HashSet<Student> GetCommonStudents(List<Student> list1, List<Student> list2)
            => list1.Intersect(list2).ToHashSet();
        
        public override int GetHashCode() 
            => ID * Name.GetHashCode();

        public override bool Equals(object obj)
            => obj is Student student && student.ID == this.ID && student.Name == this.Name;
    }
}
