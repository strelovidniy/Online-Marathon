using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_01.Task_04
{
    public class DisposePatternImplementer : CloseableResource, IDisposable
    {
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Disposing by developer");
                }
                else
                {
                    Console.WriteLine("Disposing by GC");
                }
                base.Close();
                
                disposed = true;
            }
        }

        public void SomeMethod()
        {

        }

        ~DisposePatternImplementer()
        {
            Dispose(false);
        }
    }
}
