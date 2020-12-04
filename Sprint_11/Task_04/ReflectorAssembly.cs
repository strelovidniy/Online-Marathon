using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Sprint_11.Task_04
{
    internal class ReflectorAssembly
    {
        public static void WriteAssemblies()
        {
            foreach (var type in Assembly.GetCallingAssembly().GetTypes().Except(new Type[] { typeof(Reflector), typeof(Task) }).ToArray())
            {
                Console.WriteLine((type.IsClass ? "Class" : "Interface") + ": " + type.Name);

                foreach (var method in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static))
                {
                    Console.WriteLine("Method: {0}", method.Name);

                    if (method.GetParameters().Length == 1)
                    {
                        var size = type.Name.ToLower().Remove(type.Name.Length - 3);
                        method.Invoke(null, new object[] { string.IsNullOrWhiteSpace(size) ? "middle" : size });
                    }
                }
            }
        }

        public class LargeBox
        {
            public static void UnPackingBox(string size)
                => Console.WriteLine("I am unpacking {0} box.", size);

            public static void InBox(string size)
                => Console.WriteLine("I am in {0} box.", size);
        }

        public class Box
        {
            public static void UnPackingBox(string size)
                => Console.WriteLine("I am unpacking {0} box.", size);

            public static void InBox(string size)
                => Console.WriteLine("I am in {0} box.", size);
        }

        public class SmallBox
        {
            public static void UnPackingBox(string size)
                => Console.WriteLine("I am unpacking {0} box.", size);

            public static void InBox(string size)
                => Console.WriteLine("I am in {0} box.", size);
        }

        public interface ILookingForBox
        {
            static void LookForBox(string size)
            {

            }
        }

        public interface IPackingBox
        {
            static void PackBox(string size)
            {

            }
        }
    }
}
