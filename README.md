# Multi-Threading #
----------
## Why?  ##
### **1.Keep a Process Responsive**  ###

Everyone has already made the acquaintance of a program that when a button activated the entire program freeze. 

This problem is created by using only one thread. Basically the program waits until the thread is released to 

continue. Multithreading avoided this problem by allowing to use multiple thread.

### **2.Keep a Processor Busy** ###

If a processor has no task to perform, he does nothing, so why not using it?

## Understand the program ? ##

### To understand the program you needs some basic knowledge on C # Library and threading. ###

#### **1.Asynchronous/Synchronous** ####

In the code where an **asynchronous** thread is run to perform a task, the thread is simply started and the code 

perform normally. But if it a **synchronous** thread program code will continue only after the task is finished. The 

two methods are useful depending on the situation.

#### **2.Thread Pool** ####

C# class that represent a collection of Asynchronous task that is queued one father the other.

#### **3.Task** ####

C# class that an asynchronous operation.

#### **4.asyc/await** ####

Key word for making an Asynchronous thread more Synchronous. Making the code wait until de task is completed to 

continue.

## Objective of the program ? ##
### 1. **Educational** ###

I did this program for an educational purpose. Feel free to use it, modify it or simply analyse it.

### 2. **Easy to understand Code** ###

Well commented and short and straight forward function.

### 3. **Compare single and multi threading** ###

You can test both with a timer, at the same time or not in the program. Obviously the speed will be difference for everyone in function of the computer used to run the program. (Number of core)

## Danger? ##
### 1. **Complexity** ###

Managing Multi-thread can add a lot of complexity in the code of a program. Only use it if the performance boost worth the added complexity. It usually worth in heavy possessing program, not in light one.

### 2. **Safety** ###

IF you don't know what you are doing it can cause lot of problem and bug hard to solve in a program. one of the 

more common is cross-thread with the UI. When you try to do something with the UI (for example updating a label)

if you start a task for doing it you can't update the graphic of the label without interfering with the UI thread.

Typically in this situation we use the keyword "Invoke" for calling the method update from the UI thread.

## Example ?##
It all well commented , go ahead and download it.

![](https://raw.githubusercontent.com/JGLaferte/Multi-Threading/master/AshycMultiThreadingProject/Img/MultiThreading.gif)


Feel free to follow my git, more will come.
