/*
 * 5. Write a program which creates two threads and a shared collection:
 * the first one should add 10 elements into the collection and the second should print all elements
 * in the collection after each adding.
 * Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.
 */
using System;
using System.Collections.Generic;
using System.Threading;

namespace MultiThreading.Task5.Threads.SharedCollection
{
    class Program
    {
        private static readonly AutoResetEvent _autoEvent1 = new AutoResetEvent(false); // writing
        private static readonly AutoResetEvent _autoEvent2 = new AutoResetEvent(false); // reading
        private static readonly List<int> list = new List<int>();
        private static readonly int _elementCount = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("5. Write a program which creates two threads and a shared collection:");
            Console.WriteLine("the first one should add 10 elements into the collection and the second should print all elements in the collection after each adding.");
            Console.WriteLine("Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.");
            Console.WriteLine();

            // feel free to add your code

            var inserterThread = new Thread(AddElement);
            var readerThread = new Thread(ReadElement);

            inserterThread.Start();
            readerThread.Start();

            inserterThread.Join();
            readerThread.Join();


            Console.ReadLine();
        }

        /// <summary>
        /// Inserter Thread
        /// </summary>
        private static void AddElement()
        {
            for (int i = 0; i < _elementCount; i++)
            {
                _autoEvent1.WaitOne();
                list.Add(i);
                _autoEvent2.Set();
            }
        }


        /// <summary>
        /// Reader Thread
        /// </summary>
        private static void ReadElement()
        {
            while (true)
            {

                _autoEvent1.Set();
                _autoEvent2.WaitOne();

                if (list.Count > _elementCount)
                {
                    return;
                }

                Console.WriteLine(string.Join(",", list));
            }
        }
    }
}
