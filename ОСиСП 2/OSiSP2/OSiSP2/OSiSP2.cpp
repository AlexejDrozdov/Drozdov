// OSiSP2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "ThreadPool.h"
using namespace std;


typedef bool ThreadFunction();
bool Task1();
bool Task2();
bool Task3();
bool Task4();
bool Task5();
bool ExitFunction();
void error();



int _tmain(int argc, _TCHAR* argv[])
{
	#pragma warning(disable: 4996)
	int count;
	puts("Enter number of thread");
	scanf("%d", &count);
	if (count < 0)
		count = 5;
	ThreadPool* threadPool;
	ThreadFunction* task;
	task = Task1;
	threadPool = new ThreadPool(count);
	int n = 0;
	while (n != 13)
	{
		bool Busy = true;
		puts("Enter number of task: 1, 2, 3, 4, 5");
		puts("Press 'Enter' for exit");
		n = _getch();
		switch (n)
		{
		case '1':
			task = Task1;
			break;
		case '2':
			task = Task2;
			break;
		case '3':
			task = Task3; 
			break;
		case '4':
			task = Task4;
			break;
		case '5':
			task = Task5;
			break;
		}
		threadPool->AddTask(task);

	}
	delete threadPool;
    return 0;
}

bool Task1()
{
	try
	{
		Sleep(10000);
		puts("This is task 1");
	}
	catch (...)
	{
		return false;
	}
	return true;
}

bool Task2()
{
	try
	{
		Sleep(1000);
		puts("This is task 2");
	}
	catch (...)
	{
		return false;
	}
	return true;
}

bool Task3()
{
	try
	{
		Sleep(1000);
		puts("This is task 3");
	}
	catch (...)
	{
		return false;
	}
	return true;
}

bool Task4()
{
	try
	{
		Sleep(1000);
		puts("This is task 4");
	}
	catch (...)
	{
		return false;
	}
	return true;
}

bool Task5()
{
	try
	{
		Sleep(1000);
		puts("This is task 5");
	}
	catch (...)
	{
		return false;
	}
	return true;
}

