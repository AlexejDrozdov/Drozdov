#include "stdafx.h"
#include "ThreadPool.h"


static DWORD WINAPI StaticThreadProc(LPVOID lParam)
{
	ThreadPool* pool = (ThreadPool*)lParam;
	pool->ThreadProc(lParam);
	return 0;
}
static bool exitFunction()
{
	return false;
}

ThreadPool::ThreadPool(int count)
{


	threadsCount = count;
	Terminated = false;
#pragma warning(disable: 4996)
	logFile = fopen("log.txt", "wt");
	InitializeCriticalSection(&criticalSectionForThread);
	InitializeCriticalSection(&criticalSectionForFile);
	SemaphoreThread = CreateSemaphore(NULL, count, count, NULL);
	SemaphoreTask = CreateSemaphore(NULL, 0, count, NULL);
	pool = (HANDLE*)malloc(sizeof(HANDLE)*threadsCount);
	for (int i = 0; i < threadsCount; i++)
	{
		pool[i] = CreateThread(NULL, 0, StaticThreadProc, (LPVOID)this, 0, NULL);
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

void ThreadPool::AddTask(ThreadFunction* f)
{
	if (countActiveThreads == threadsCount)
		puts("All threads are busy\n");
	WaitForSingleObject(SemaphoreThread, INFINITE);
	EnterCriticalSection(&criticalSectionForThread);
	taskQueue.push(f);
	LeaveCriticalSection(&criticalSectionForThread);
	if (!Terminated)
		fprintf(logFile, "Add task\n");
	else
		fprintf(logFile, "Add task of terminated\n");
	ReleaseSemaphore(SemaphoreTask, 1, NULL);
}

ThreadPool::~ThreadPool()
{
	Terminated = true;
	for (int i = 0; i < threadsCount; i++)
	{
		AddTask(exitFunction);
	}
	WaitForMultipleObjects(threadsCount, pool, true, 5000);

	for (int i = 0; i < threadsCount; i++)
	{
		if (TerminateThread(pool[i], 0) != NULL)
		{
			EnterCriticalSection(&criticalSectionForThread);
			fprintf(logFile, "Thread %d terminated\n", i + 1);
			LeaveCriticalSection(&criticalSectionForThread);
		}
	}
	free(pool);
	fprintf(logFile, "Terminated program.\n");
	fclose(logFile);

}
DWORD WINAPI ThreadPool::ThreadProc(LPVOID lParam)
{
	ThreadFunction* task;
	while (true)
	{
		WaitForSingleObject(SemaphoreTask, INFINITE);
		EnterCriticalSection(&criticalSectionForThread);
		countActiveThreads++;
		task = taskQueue.front();
		taskQueue.pop();
		LeaveCriticalSection(&criticalSectionForThread);
		ReleaseSemaphore(SemaphoreThread, 1, NULL);
		if (task())
		{
			EnterCriticalSection(&criticalSectionForFile);
			fprintf(logFile, "Task completed. Result true\n");
			LeaveCriticalSection(&criticalSectionForFile);
		}
		else
		{
			EnterCriticalSection(&criticalSectionForFile);
			fprintf(logFile, "Task completed. Result false\n");
			LeaveCriticalSection(&criticalSectionForFile);
		}
		countActiveThreads--;

	}
	return 0;
}

