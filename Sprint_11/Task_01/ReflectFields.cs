using System;
using System.Linq;

namespace Sprint_11.Task_01
{
    public class ReflectFields
    {
        public static string Name;
        public static int MeasureX;
        public static int MeasureY;
        public static int MeasureZ;

        public static void OutputFields()
            => new ReflectFields().GetType().GetFields().ToList().ForEach(field =>
                Console.WriteLine("{0} ({1}) = {2}",
                    field.Name,
                    field.FieldType.ToString().Split(new char[] { '.', '3', '6' })[1].ToLower(),
                    field.GetValue(null)));
    }
}
