using System;
using System.Linq;
using System.Reflection;

namespace Sprint_11.Task_05
{
    internal class ReflectFullClass
    {
        public static void WriteAllInClass(Type type)
        {
            Console.WriteLine("Hello, {0}!", type.Name);
            var fields = type.GetFields();
            Console.WriteLine("There are {0} fields in {1}:", fields.Length, type.Name);
            foreach (var field in fields) Console.Write(field.Name + ", ");

            var properties = type.GetProperties();
            Console.WriteLine("\nThere are {0} properties in {1}:", properties.Length, type.Name);
            foreach (var property in properties) Console.Write(property.Name + ", ");

            var methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .Where(method => !method.Name.Contains("get_") && !method.Name.Contains("set_"))
                .ToList();
            Console.WriteLine("\nThere are {0} methods in {1}:", methods.Count(), type.Name);
            foreach (var method in methods) Console.Write(method.Name + ", ");

            var interfaces = type.GetNestedTypes();
            Console.WriteLine("\nThere are {0} interfaces in {1}:", interfaces.Length, type.Name);
            foreach (var @interface in interfaces) Console.Write(@interface.Name + ", ");
        }
    }
}
