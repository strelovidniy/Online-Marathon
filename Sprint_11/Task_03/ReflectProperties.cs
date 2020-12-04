using System;
using System.Linq;
using System.Reflection;

namespace Sprint_11.Task_03
{
    public class ReflectProperties
    {
        public static void WriteProperties()
            => new TestProperties().GetType().GetProperties(
                    BindingFlags.Public | 
                    BindingFlags.Instance |
                    BindingFlags.NonPublic)
                .ToList().ForEach(property => 
                Console.WriteLine($"Property name: {property.Name}" + 
                                  Environment.NewLine + $"Property type: {property.PropertyType}" + 
                                  Environment.NewLine + $"Read-Write:    {property.CanRead && property.CanWrite}" + 
                                  Environment.NewLine + $"Accessibility level: {property.AccessModifier()}" + 
                                  Environment.NewLine));

        public class TestProperties
        {
            public string FirstName { get; set; }
            internal string LastName { get; set; }
            protected int Age { get; set; }
            private string PhoneNumber { get; set; }
        }
    }
}
