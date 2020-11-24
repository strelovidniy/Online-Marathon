using System.Threading;

namespace Sprint_08.Task_06
{
    internal class Buyer : PersonInTheShop
    {
        private static readonly Semaphore _semaphore = new Semaphore(10, 10);

        public Buyer(string threadName)
            => new Thread(
                () =>
                {
                    _semaphore.WaitOne();
                    Enter();
                    SelectGroceries();
                    Pay();
                    Leave();
                    _semaphore.Release();
                }
                ) {Name = threadName}.Start();
    }
}