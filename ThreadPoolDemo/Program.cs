using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    class Program
    {
        static void ShowMyText(object state)
        {
            string myText = (string)state;
            Console.WriteLine("Thread: {0} - {1}", Thread.CurrentThread.ManagedThreadId, myText);
        }

        static void Main(string[] args)
        {
            WaitCallback callback = new WaitCallback(ShowMyText);
            ThreadPool.QueueUserWorkItem(callback, "Hello");
            ThreadPool.QueueUserWorkItem(callback, "Hi");
            ThreadPool.QueueUserWorkItem(callback, "Heya");
            ThreadPool.QueueUserWorkItem(callback, "God dag!");
            ThreadPool.QueueUserWorkItem(callback, "Goodbye");
            Console.Read();
        }
    }
}
