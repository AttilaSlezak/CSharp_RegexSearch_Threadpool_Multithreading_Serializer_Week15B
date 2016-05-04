using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    class Program
    {
        static void Counting()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Count: {0} - Thread: {1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }

        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Counting);
            Thread first = new Thread(threadStart);
            Thread second = new Thread(threadStart);

            first.Start();
            second.Start();

            first.Join();
            second.Join();
        }
    }
}
