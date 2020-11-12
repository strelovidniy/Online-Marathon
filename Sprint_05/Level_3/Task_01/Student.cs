using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Sprint_05.Level_3.Task_01
{
    class Student
    {
        public int ID { get; }
        public string Name { get; }

        public Student(int ID, string Name)
        {
            this.ID = ID;
            

            if (Name == null)
            {
                this.Name = "";
            }
            else
            {
                this.Name = Name;
            }
        }

        public static HashSet<Student> GetCommonStudents(List<Student> list1, List<Student> list2)
        {
            var hashSet = new HashSet<Student>();

            foreach (var student1 in list1)
            {
                foreach (var student2 in list2)
                {
                    if (student1.Equals(student2))
                    {
                        hashSet.Add(student1);
                    }
                }
            }

            return hashSet;
        }

        public override int GetHashCode() => ID * Name.GetHashCode();

        public override bool Equals(object obj) 
            => obj.GetHashCode() == this.GetHashCode();
    }
}
