# Semaphores

In this exercise sempahores are used to force syncronization regarding execution order for methods that can run in different 
threads with different schedules. <br>

The order of execution we want is `FirstMethod(), SecondMethod() and ThirdMethod()`.

So in the case that `SecondMethod()` starts execution before `FirstMethod()`, `SecondMethod()` 
goes and makes `Signal()` to the `semaphoreA`, so that way the thread in `SecondMethod()` waits until the `FirstMethod()` releases semaphoreA.
