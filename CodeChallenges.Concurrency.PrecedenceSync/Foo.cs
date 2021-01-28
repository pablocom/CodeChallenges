using System;
using System.Threading;

namespace CodeChallenges.Concurrency.PrecedenceSync
{
    public class Foo
    {
        private readonly Semaphore _semaphoreA = new Semaphore(0, 1);
        private readonly Semaphore _semaphoreB = new Semaphore(0, 1);
        
        public Foo() 
        {
        
        }

        public void First(Action printFirst)
        {
            // printFirst() outputs "first". Do not change or remove this line.
            printFirst.Invoke();
            _semaphoreA.Release();
        }

        public void Second(Action printSecond)
        {
            _semaphoreA.WaitOne();
            // printSecond() outputs "second". Do not change or remove this line.
            printSecond.Invoke();
            _semaphoreB.Release();
        }

        public void Third(Action printThird)
        {
            _semaphoreB.WaitOne();
            // printThird() outputs "third". Do not change or remove this line.
            printThird.Invoke();
        }
    }
}