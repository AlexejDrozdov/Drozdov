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
int countActiveThreads;
HANDLE SemaphoreThread, SemaphoreTask;
bool Terminated = false;

CRITICAL_SECTION criticalSectionForFile;

FILE * logFile;
class ThreadPool
{
public:
	ThreadPool(int count)
	{

		threadsCount = count;
		pool = (HANDLE*)malloc(sizeof(HANDLE)*threadsCount);
		for (int i = 0; i < threadsCount; i++)
		{
			pool[i] = CreateThread(NULL, 0, ThreadProc, (LPVOID)i, 0, NULL);
			if (pool[i] != NULL)
			{
				fprintf(logFile, "Created %d thread.\n", i + 1);
			}
			else
			{
				fprintf(logFile, "Thread %d didn't create.\n", i + 1);
			}
		}
	}

	void AddTask(ThreadFunction* f)
	{
		taskQueue.push(f);
		EnterCriticalSection(&criticalSectionForFile);
		if (!Terminated)
			fprintf(logFile, "Add task\n");
		else
			fprintf(logFile, "Add task of terminated\n");
		LeaveCriticalSection(&criticalSectionForFile);
	}

	~ThreadPool()
	{
		Terminated = true;
		for (int i = 0; i < threadsCount; i++)
		{
			AddTask(&ExitFunction);
		}
		WaitForMultipleObjects(threadsCount, pool, true, 5000);

		for (int i = 0; i < threadsCount; i++)
		{
			if (TerminateThread(pool[i], 0) != NULL)
			{
				EnterCriticalSection(&criticalSectionForFile);
				fprintf(logFile, "Thread %d terminated\n", i + 1);
				LeaveCriticalSection(&criticalSectionForFile);
			}
		}
		free(pool);

	}

private:
	static DWORD WINAPI ThreadProc(LPVOID lParam)
	{
		ThreadFunction* task;
		while (true)
		{
			WaitForSingleObject(SemaphoreTask, INFINITE);

			if (!taskQueue.empty())
			{
				countActiveThreads++;
				task = taskQueue.front();
				taskQueue.pop();
				task();
				ReleaseSemaphore(SemaphoreThread, 1, NULL);
				countActiveThreads--;
			}
		}
		return 0;
	}
	static int threadsCount;
	static HANDLE *pool;
	static queue <ThreadFunction*> taskQueue;
};

int ThreadPool::threadsCount;
HANDLE* ThreadPool::pool;
queue <ThreadFunction*> ThreadPool::taskQueue;

int _tmain(int argc, _TCHAR* argv[])
{

#pragma warning(disable: 4996)
	logFile = fopen("log.txt", "wt");

	int count;
	puts("Enter number of thread");
	scanf("%d", &count);
	if (count < 0)
		count = 5;
	ThreadPool* threadPool;
	InitializeCriticalSection(&criticalSectionForFile);
	countActiveThreads = 0;
	threadPool = new ThreadPool(count);
	SemaphoreThread = CreateSemaphore(NULL, count, count, NULL);
	SemaphoreTask = CreateSemaphore(NULL, 0, count, NULL);
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
			if (countActiveThreads == count)
				puts("All threads are busy\n");
			WaitForSingleObject(SemaphoreThread, INFINITE);
			threadPool->AddTask(&Task1);
			ReleaseSemaphore(SemaphoreTask, 1, NULL);
			break;
		case '2':

			if (countActiveThreads == count)
				puts("All threads are busy\n");
			WaitForSingleObject(SemaphoreThread, INFINITE);
			threadPool->AddTask(&Task2);
			ReleaseSemaphore(SemaphoreTask, 1, NULL);
			break;
		case '3':
			if (countActiveThreads == count)
				puts("All threads are busy\n");
			WaitForSingleObject(SemaphoreThread, INFINITE);
			threadPool->AddTask(&Task3);
			ReleaseSemaphore(SemaphoreTask, 1, NULL);
			break;
		case '4':
			if (countActiveThreads == count)
				puts("All threads are busy\n");
			WaitForSingleObject(SemaphoreThread, INFINITE);
			threadPool->AddTask(&Task4);
			ReleaseSemaphore(SemaphoreTask, 1, NULL);
			break;
		case '5':
			if (countActiveThreads == count)
				puts("All threads are busy\n");
			WaitForSingleObject(SemaphoreThread, INFINITE);
			threadPool->AddTask(&Task5);
			ReleaseSemaphore(SemaphoreTask, 1, NULL);
			break;

		}
	}
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
		fprintf(logFile, " Task 1 completed\n");
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
		fprintf(logFile, " Task 2 completed\n");
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
		fprintf(logFile, " Task 3 completed\n");
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
		fprintf(logFile, " Task 4 completed\n");
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
		fprintf(logFile, " Task 5 completed\n");
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