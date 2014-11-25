// osisp.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <Windows.h>
#include <iostream>


int _tmain(int argc, _TCHAR* argv[])
{
	HANDLE mutex = CreateMutex(NULL, false, L"Global//ProcessMutex");
	HANDLE map = CreateFileMapping(NULL, NULL, FILE_MAP_WRITE, 0, 0x010, L"Map");
	int i;
	std::cin >> i;
	if (map != NULL)
	{
		void* address = MapViewOfFile(map, NULL, 0, 0, 255);
		while (true)
		{
			WaitForSingleObject(mutex, INFINITE);
			std::cout << "Do something" << std::endl;
			//do something
			Sleep(10000);
			ReleaseMutex(mutex);
			break;
		}
		std::cout << "Unmap" << std::endl;
		Sleep(10000);
		UnmapViewOfFile(address);
	}
	return 0;
}

