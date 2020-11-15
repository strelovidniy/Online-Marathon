using System.Collections.Generic;
using System.Linq;

namespace Sprint_05.Level_3.Task_01
{
    internal class Student
    {
        public int Id { get; }
        public string Name { get; }

        public Student(int id, string name)
        {
            this.Id = id;
            this.Name = name ?? "";
        }

        public static HashSet<Student> GetCommonStudents(List<Student> list1, List<Student> list2)
            => list1.Intersect(list2).ToHashSet();
        
        public override int GetHashCode() 
            => Id * Name.GetHashCode();

        public override bool Equals(object obj)
            => obj is Student student && student.Id == this.Id && student.Name == this.Name;
    }
}
