// OSiSP2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <conio.h>
#include <Windows.h>
#include <queue>
#include <iostream>
using namespace std;


typedef bool ThreadFunction();
bool Task1();
bool Task2();
bool Task3();
bool Task4();
bool Task5();
bool ExitFunction();
void error();
HANDLE SemaphoreThread, SemaphoreTask;
bool endOfWork = false;

struct ThreadParam
{
	bool access;
	bool remove;
	ThreadFunction* function;
}param;
CRITICAL_SECTION criticalSectionForFile;

FILE * logFile;
class ThreadPool
{
public:
	ThreadPool(int count)
	{

		threadsCount = count;
		pool = (HANDLE*)malloc(sizeof(HANDLE)*threadsCount);
		fprintf(logFile, "Created %d threads.\n", threadsCount);
		for (int i = 0; i < threadsCount; i++)
		{
			pool[i] = CreateThread(NULL, 0, ThreadProc, (LPVOID)i, 0, NULL);
		}
	}

	int CountOfThread()
	{
		return threadsCount;
	}
	void AddTask(ThreadFunction* f)
	{
		taskQueue.push(f);
	}

	~ThreadPool()
	{
		for (int i = 0; i < threadsCount; i++)
		{
			AddTask(&ExitFunction);
		}
		WaitForMultipleObjects(threadsCount, pool, true, 5000);
		
		for (int i = 0; i < threadsCount; i++)
		{
			TerminateThread(pool[i], 0);
		}
		free(pool);
		free(param);

	}

private:
	static DWORD WINAPI ThreadProc(LPVOID lParam)
	{
		ThreadFunction* task;
		while (true)
		{
			if (!endOfWork)
			{

				WaitForSingleObject(SemaphoreTask, INFINITE);

				if (!taskQueue.empty())
				{

					task = taskQueue.front();
					taskQueue.pop();
					task();
					ReleaseSemaphore(SemaphoreThread, 1, NULL);
				}
			}
			else
				return 0;

		}
		return 0;
	}
	static int threadsCount;
	static HANDLE *pool;
	static ThreadParam  *param;
	static queue <ThreadFunction*> taskQueue;
};

int ThreadPool::threadsCount;
HANDLE* ThreadPool::pool;
ThreadParam* ThreadPool::param;
queue <ThreadFunction*> ThreadPool::taskQueue;

int _tmain(int argc, _TCHAR* argv[])
{

#pragma warning(disable: 4996)
	logFile = fopen("log.txt", "wt");

	int n;
	puts("Enter number of thread");
	scanf("%d", &n);
	if (n < 0)
		n = 5;
	ThreadPool* threadPool;
	threadPool = new ThreadPool(n);
	SemaphoreThread = CreateSemaphore(NULL, n, n, NULL);
	SemaphoreTask = CreateSemaphore(NULL, 0, n, NULL);
	InitializeCriticalSection(&criticalSectionForFile);

	while (n != 13)
	{
		bool Busy = true;
		puts("Enter number of task: 1, 2, 3, 4, 5");
		puts("Press 'Enter' for exit");
		n = _getch();
		switch (n)
		{
		case '1':
			WaitForSingleObject(SemaphoreThread, INFINITE);
			threadPool->AddTask(&Task1);
			ReleaseSemaphore(SemaphoreTask, 1, NULL);
			break;
		case '2':
			WaitForSingleObject(SemaphoreThread, INFINITE);
			threadPool->AddTask(&Task2);
			ReleaseSemaphore(SemaphoreTask, 1, NULL);
			break;
		case '3':
			WaitForSingleObject(SemaphoreThread, INFINITE);
			threadPool->AddTask(&Task3);
			ReleaseSemaphore(SemaphoreTask, 1, NULL);
			break;
		case '4':
			WaitForSingleObject(SemaphoreThread, INFINITE);
			threadPool->AddTask(&Task4);
			ReleaseSemaphore(SemaphoreTask, 1, NULL);
			break;
		case '5':
			WaitForSingleObject(SemaphoreThread, INFINITE);
			threadPool->AddTask(&Task5);
			ReleaseSemaphore(SemaphoreTask, 1, NULL);
			break;

		}
	}
	//threadPool->~ThreadPool();
	delete threadPool;
	fprintf(logFile, "Terminated program.\n");
	fclose(logFile);
	return 0;
}

bool Task1()
{
	try
	{
		Sleep(1000);
		puts("This is task 1");
	}
	catch (...)
	{
		error;
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
		error;
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
		error;
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
		error;
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
		error;
	}
	return true;
}

bool ExitFunction()
{
	return false;
}

void error()
{
	EnterCriticalSection(&criticalSectionForFile);
	fprintf(logFile, "Error of executing users function.\n");
	LeaveCriticalSection(&criticalSectionForFile);
}