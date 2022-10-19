/*
 * 4.	Write a program which recursively creates 10 threads.
 * Each thread should be with the same body and receive a state with integer number, decrement it,
 * print and pass as a state into the newly created thread.
 * Use Thread class for this task and Join for waiting threads.
 * 
 * Implement all of the following options:
 * - a) Use Thread class for this task and Join for waiting threads.
 * - b) ThreadPool class for this task and Semaphore for waiting threads.
 */

using System;
using System.Threading;

namespace MultiThreading.Task4.Threads.Join
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("4.	Write a program which recursively creates 10 threads.");
            Console.WriteLine("Each thread should be with the same body and receive a state with integer number, decrement it, print and pass as a state into the newly created thread.");
            Console.WriteLine("Implement all of the following options:");
            Console.WriteLine();
            Console.WriteLine("- a) Use Thread class for this task and Join for waiting threads.");
            Console.WriteLine("- b) ThreadPool class for this task and Semaphore for waiting threads.");

            Console.WriteLine();


            Console.WriteLine("- a) Use Thread class for this task and Join for waiting threads.");
            NumberHelper obj = new NumberHelper(10, PrintResultCallBackMethod);
            WithThreadClass(obj);

            Console.WriteLine("- b) ThreadPool class for this task and Semaphore for waiting threads.");
            NumberHelper obj2 = new NumberHelper(10, PrintResultCallBackMethod);
            WithSemThreadClass(obj2);

            Console.ReadLine();
        }

        private static void WithThreadClass(NumberHelper obj, int threadCount = 1)
        {
            if (threadCount > 10)
            {
                return;
            }

            Thread thread = new Thread(obj.Decrement);
            thread.Start();
            thread.Join();

            WithThreadClass(obj, threadCount + 1);

        }


        private static void WithSemThreadClass(NumberHelper obj, int threadCount = 1)
        {
            if (threadCount > 10)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(state => obj.DecrementWithSem());

            WithSemThreadClass(obj, threadCount + 1);
        }


        /// <summary>
        /// Prints the result thread's call back method with thread id in case to understand how to works thread pool. 
        /// </summary>
        /// <param name="result"></param>
        public static void PrintResultCallBackMethod(int result)
        {
            Console.WriteLine($"TreadId : {Thread.CurrentThread.ManagedThreadId} -  The Result is  " + result);
        }
    }
}
