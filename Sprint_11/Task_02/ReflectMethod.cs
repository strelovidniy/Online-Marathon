using System;
using System.Linq;
using System.Reflection;

namespace Sprint_11.Task_02
{
    internal class ReflectMethod
    {
        public static void InvokeMethod(params string[] parameters)
            => new Methods().GetType().GetMethods(
                BindingFlags.Public | 
                BindingFlags.Instance | 
                BindingFlags.DeclaredOnly | 
                BindingFlags.Static)
                .ToList().ForEach(method =>
                    parameters.ToList().ForEach(parameter => method.Invoke(null, new object[] {parameter})));

        internal class Methods
        {
            public static void Hello(string parameter)
                => Console.WriteLine("Hello:parameter={0}", parameter);

            public static void Welcome(string parameter)
                => Console.WriteLine("Welcome:parameter={0}", parameter);

            public static void Bye(string parameter)
                => Console.WriteLine("Bye:parameter={0}", parameter);
        }
    }
}
