using System.Linq;

namespace Sprint_07.Task_01
{
    internal class MyProgram
    {
        public static double EvaluateSumOfElementsOddPositions(double[] inputData)
            => inputData.Where((item, index) => index % 2 != 0).Sum();
    }
}
