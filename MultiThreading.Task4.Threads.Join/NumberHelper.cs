using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreading.Task4.Threads.Join
{
    internal delegate void ResultCallbackDelegate(int result);

    internal class NumberHelper
    {
        private int _number;
        private readonly ResultCallbackDelegate _resultCallbackDelegate;
        private readonly Semaphore _sem =new Semaphore(1, 1);


        public NumberHelper(int number, ResultCallbackDelegate resultCallbackDelegate)
        {
            _number = number;
            _resultCallbackDelegate = resultCallbackDelegate ?? throw new ArgumentNullException(nameof(resultCallbackDelegate));

        }
        
        public void Decrement()
        {
            _number -= 1;
            _resultCallbackDelegate(_number);
        }

        public void DecrementWithSem()
        {
            _sem.WaitOne();
            _number -= 1;
            _resultCallbackDelegate(_number);
            _sem.Release();
        }
    }
}
