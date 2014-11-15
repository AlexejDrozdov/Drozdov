#pragma once
#include <conio.h>
#include <Windows.h>
#include <queue>
#include <iostream>
typedef bool ThreadFunction();

class ThreadPool
{
public:
	ThreadPool(int count);
	void AddTask(ThreadFunction* f);
	~ThreadPool();
	DWORD WINAPI ThreadProc(LPVOID lParam);
private:
	bool Terminated;
	FILE * logFile;
	CRITICAL_SECTION criticalSectionForThread, criticalSectionForFile;
	int threadsCount;
	int countActiveThreads;
	HANDLE *pool;
	HANDLE SemaphoreThread, SemaphoreTask;
	std::queue <ThreadFunction*> taskQueue;

};

