/*
 * 2.	Write a program, which creates a chain of four Tasks.
 * First Task – creates an array of 10 random integer.
 * Second Task – multiplies this array with another random integer.
 * Third Task – sorts this array by ascending.
 * Fourth Task – calculates the average value. All this tasks should print the values to console.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MultiThreading.Task2.Chaining
{
    class Program
    {
        private static Random random = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine(".Net Mentoring Program. MultiThreading V1 ");
            Console.WriteLine("2.	Write a program, which creates a chain of four Tasks.");
            Console.WriteLine("First Task – creates an array of 10 random integer.");
            Console.WriteLine("Second Task – multiplies this array with another random integer.");
            Console.WriteLine("Third Task – sorts this array by ascending.");
            Console.WriteLine("Fourth Task – calculates the average value. All this tasks should print the values to console");
            Console.WriteLine();


            // creates an array of 10 random integer.
            Task<int[]> firstTask = Task.Run(() =>
            {
                var array =  Enumerable.Range(1, 10).Select(x => random.Next(1, 20)).ToArray();
                PrintArray(1,array);
                return array;
            });

            //multiplies this array with another random integer
            Task<int[]> secondTask = firstTask.ContinueWith(x =>
            {
                var randomNumber = random.Next(1, 5);
                var modifiedArray = x.Result.Select(item => item * randomNumber).ToArray();
                PrintArray(2,modifiedArray);
                return modifiedArray;
            });

            //sorts this array by ascending.
            Task<int[]> thirdTask = secondTask.ContinueWith(x =>
            {
                var modifiedArray = x.Result.OrderBy(k => k).ToArray();
                PrintArray(3,modifiedArray);
                return modifiedArray;
            });

            //calculates the average value
            Task<double> fourthTask = thirdTask.ContinueWith(x => x.Result.Average());

            Console.WriteLine($"Step 4- {fourthTask.Result}");

            Console.ReadLine();
        }

        /// <summary>
        /// It's a kind of extension which show array as string with step no. 
        /// </summary>
        /// <param name="stepNo"></param>
        /// <param name="array"></param>
        private static void PrintArray(int stepNo, int[] array)
        {
            Console.WriteLine( $"Step {stepNo} -[{string.Join(',', array)}]");
        }
    }
}
