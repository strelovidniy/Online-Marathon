using System;
using System.Threading.Tasks;

namespace Sprint_08.Task_01
{
    internal class ParallelUtils<T, TR>
    {
        public TR Result { get; private set; }
        private readonly Task<TR> task;

        public ParallelUtils(Func<T, T, TR> operation, T firstOperand, T secondOperand)
            => task = new Task<TR>(() => operation(firstOperand, secondOperand));

        public void StartEvaluation()
            => task.Start();

        public void Evaluate()
        {
            StartEvaluation();
            task.Wait();
            Result = task.Result;
        }
    }
}
