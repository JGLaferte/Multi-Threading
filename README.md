# Multithreading #
----------

## Description ##

![](https://raw.githubusercontent.com/JGLaferte/Multi-Threading/master/AshycMultiThreadingProject/Img/MultiThreading.gif)

It is a Visual Studio project in C# to compare multithreaded and single threaded applications. Each method executes the same number of processes and the time elapse is compared to see which one is the fastest. 

## Why I’ve made this program ? ##

I have made this program mainly for an educational purpose. I think you will learn a lot faster by simply looking at this simple and efficient code. I think that reading the code is worth a lot more than elaborated explication.


## What you need to know ##

To understand the project you need to understand the basics of multithreading in C#.

- Tasks ->[https://msdn.microsoft.com/en-us/library/system.threading.tasks.task(v=vs.110).aspx ](https://msdn.microsoft.com/en-us/library/system.threading.tasks.task(v=vs.110).aspx )

- Difference between asynchronous and synchronous threads. >[http://stackoverflow.com/questions/748175/asynchronous-vs-synchronous-execution-what-does-it-really-mean](http://stackoverflow.com/questions/748175/asynchronous-vs-synchronous-execution-what-does-it-really-mean)

- Thread Pool ->[https://msdn.microsoft.com/en-us/library/windows/desktop/ms686760(v=vs.85).aspx](https://msdn.microsoft.com/en-us/library/windows/desktop/ms686760(v=vs.85).aspx)

- Async/Await Keywords ->[https://msdn.microsoft.com/en-us/magazine/jj991977.aspx](https://msdn.microsoft.com/en-us/magazine/jj991977.aspx)


## Why should you learning multithreading ##

Multithreading is a really useful concept to know and understand. 
First for computing efficiency, most of the computers nowadays have multiple cores even on cell phones. Multithreading is designed to take advantage of all the cores of a processor. It allows your computer to do multiple tasks at the same time and use all cores of your computer.

Secondly it makes everything more responsive. For example, if you have to do some processing in the background and keep the UI responsive to inputs you can use a thread for processing another for the UI. If the UI and processing use the same thread, the user interface will hang every time you try to do any processing.

## Danger of multithreading ##

Multithreading does not come only with advantages. It adds complexity to your work and it is a possible source of problems and bugs if not done properly.
The most common problem is cross-threading issues. A cross-thread operation in C# is a call that accesses components from a different thread. For example, if you call the update() method of a control like a label from a different thread than the UI thread it will raise a cross-thread error. Most common workaround is using the invoke() or lock() method.

## When should you use multithreading ##

You should use it when it is worth it. Multithreading makes a huge difference when you need to do some heavy processing. If you have a very light processing program it not really worth it to add complexity for an unnoticeable change. If your client wants a more responsive design it is worth it. Simple as that.
