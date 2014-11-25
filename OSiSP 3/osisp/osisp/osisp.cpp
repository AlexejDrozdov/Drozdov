// osisp.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <Windows.h>
#include <time.h>
#include <iostream>


char * CurrentTime();
int _tmain(int argc, _TCHAR* argv[])
{
	HANDLE mutex = CreateMutex(NULL, false, L"Global//ProcessMutex");
	HANDLE map = CreateFileMapping(NULL, NULL, PAGE_READWRITE, 0, 0x010, L"Map");
	int i;
	std::cout  << CurrentTime()<< std::endl;
	std::cin >> i;
	if (map != NULL)
	{
		void* addressMap = MapViewOfFile(map, FILE_MAP_WRITE, 0, 0, 255);
		while (true)
		{
			char str[255];
			if (strcmp(str, "qqq") == 0)
				break;
			WaitForSingleObject(mutex, INFINITE);
			std::cout << "Write in map "<<CurrentTime()  << std::endl;
	
			std::cin >> str;
			memcpy(addressMap, str, 255);
			Sleep(3000);
			ReleaseMutex(mutex);
			WaitForSingleObject(mutex, INFINITE);
			std::cout << "Read from map "<<CurrentTime() <<std::endl;
			memcpy(str, addressMap, 255);
			std::cout << str << std::endl;
			ReleaseMutex(mutex);
		}
		std::cout << "Unmap" << CurrentTime() <<std::endl;
		Sleep(3000);
		UnmapViewOfFile(addressMap);
	}
	return 0;
}
char timeBuffer[80];
char * CurrentTime()
{
	struct tm* timeinfo = new tm;
	time_t rawtime;

	time(&rawtime);
	localtime_s(timeinfo, &rawtime);
	strftime(timeBuffer, 80, "%I:%M:%S", timeinfo);
	return timeBuffer;
}