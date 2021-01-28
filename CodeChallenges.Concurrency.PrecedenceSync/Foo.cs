﻿using System;
using System.Threading;

namespace CodeChallenges.Concurrency.PrecedenceSync
{
    public class Foo
    {
        private readonly Semaphore semaphoreA = new Semaphore(0, 1);
        private readonly Semaphore semaphoreB = new Semaphore(0, 1);
        
        public Foo() 
        {
        
        }

        public void First(Action printFirst)
        {
            printFirst.Invoke();
            semaphoreA.Release(1);
        }

        public void Second(Action printSecond)
        {
            semaphoreA.WaitOne();
            printSecond.Invoke();
            semaphoreB.Release(1);
        }

        public void Third(Action printThird)
        {
            semaphoreB.WaitOne();
            printThird.Invoke();
        }
    }
}