/*
 * 1.	Write a program, which creates an array of 100 Tasks, runs them and waits all of them are not finished.
 * Each Task should iterate from 1 to 1000 and print into the console the following string:
 * “Task #0 – {iteration number}”.
 */
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MultiThreading.Task1._100Tasks
{
    class Program
    {
        const int TaskAmount = 100;
        const int MaxIterationsCount = 1000;

        static void Main(string[] args)
        {
            Console.WriteLine(".Net Mentoring Program. Multi threading V1.");
            Console.WriteLine("1.	Write a program, which creates an array of 100 Tasks, runs them and waits all of them are not finished.");
            Console.WriteLine("Each Task should iterate from 1 to 1000 and print into the console the following string:");
            Console.WriteLine("“Task #0 – {iteration number}”.");
            Console.WriteLine();
            
            HundredTasks();

            Console.ReadLine();
           
        }

        /// <summary>
        /// Creates Hundred tasks, executes all them, waits all of them finishing their tasks.  
        /// </summary>
        static void HundredTasks()
        {
            var tasks = Enumerable.Range(1, TaskAmount)
                .Select(x => Task.Run(() => IterateTask(x)));

            Task.WaitAll(tasks.ToArray());
        }

        /// <summary>
        /// Iterates task with task number
        /// </summary>
        /// <param name="taskNumber"></param>
        private static void IterateTask(int taskNumber)
        {
            for (int i = 0; i < MaxIterationsCount; i++)
            {
                Output(taskNumber, i);
            }
        }

        /// <summary>
        /// Prints console line by by with task number and iteration number. 
        /// </summary>
        /// <param name="taskNumber"></param>
        /// <param name="iterationNumber"></param>
        static void Output(int taskNumber, int iterationNumber)
        {
            Console.WriteLine($"Task #{taskNumber} – {iterationNumber}");
        }
    }
}
