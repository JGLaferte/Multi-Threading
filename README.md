# Multi-Threading #
----------

## What is the program? ##

![](https://raw.githubusercontent.com/JGLaferte/Multi-Threading/master/AshycMultiThreadingProject/Img/MultiThreading.gif)

It a visual studio project in c# design to compare multi-threading and single threading. Each method execute the exact same process and the time elapse is compared to see which method is the faster. 
## Why I’ve made the program ?##

I’ve made this program for an educational purpose. I think you learn a lot faster by simple looking clear, well wrote, well commented and simple code. I think that one source code worth 1 000 explication.


## What to know ? ##

To understand the project you need to understand the basic of multithreading in c#.

- Task ->[https://msdn.microsoft.com/en-us/library/system.threading.tasks.task(v=vs.110).aspx ](https://msdn.microsoft.com/en-us/library/system.threading.tasks.task(v=vs.110).aspx )

- Difference between asynchronous  and synchronous threads. >[http://stackoverflow.com/questions/748175/asynchronous-vs-synchronous-execution-what-does-it-really-mean](http://stackoverflow.com/questions/748175/asynchronous-vs-synchronous-execution-what-does-it-really-mean)

- Thread Pool ->[https://msdn.microsoft.com/en-us/library/windows/desktop/ms686760(v=vs.85).aspx](https://msdn.microsoft.com/en-us/library/windows/desktop/ms686760(v=vs.85).aspx)

- async/await keyword ->[https://msdn.microsoft.com/en-us/magazine/jj991977.aspx](https://msdn.microsoft.com/en-us/magazine/jj991977.aspx)


## Why learning multithreading ? ##

Multi-threading is a really useful think to know and understand. 
First for processes usage, most of the computer now a day have multicore (even cell phone). Multi-threading is design to take advantage of the number of core a machine have. It allow your computer to do multiple task in the same time and use all core when u need it.

Second it make everything more responsive. For example, if you have to do some processing in the background and also remain responsive to UI input, you can use multiple threads. Without it, the user interface would hang every time you tried to do any heavy processing.

## Danger of multi-threading? ##

This is the big possible cons of it. Multi-threading add lot of complexity to your work and lot of possible problem/bug.
The most common is cross-threading (A cross-thread operation in C# is a call that accesses components from a different thread.) For example, if u call the update() method of a control like a label on a different thread other than the UI ,it will raise u an cross threading error. Most comment work around this is using some invoke() or Lock() method.

## When using Multi-threading? ##

You simply use it when it worth it. Multi-threading Help heavily when u need to do some heavy processing. If you have a very light processing program it not very worth it to add that much complexity for a not noticeable change. If your client want a more responsive design it could worth it. Simple as that.
