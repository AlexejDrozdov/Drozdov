// Lab_1.cpp: ���������� ����� ����� ��� ����������.
//

#include "stdafx.h"
#include "Lab_1.h"

#define MAX_LOADSTRING 100

// ���������� ����������:
HINSTANCE hInst;								// ������� ���������
TCHAR szTitle[MAX_LOADSTRING];					// ����� ������ ���������
TCHAR szWindowClass[MAX_LOADSTRING];			// ��� ������ �������� ����
BOOL fDraw = FALSE;
POINT ptPrevious;
HDC bufDC, bufDCTmp;
HBITMAP bufBitmap, bufBitmapTmp;
RECT client;
int currenttools;


// ��������� ���������� �������, ���������� � ���� ������ ����:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY _tWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPTSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

 	// TODO: ���������� ��� �����.
	MSG msg;
	HACCEL hAccelTable;

	// ������������� ���������� �����
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_MY123, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// ��������� ������������� ����������:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MY123));
	
	// ���� ��������� ���������:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int) msg.wParam;
}



//
//  �������: MyRegisterClass()
//
//  ����������: ������������ ����� ����.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_MY123));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_MY123);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}

//
//   �������: InitInstance(HINSTANCE, int)
//
//   ����������: ��������� ��������� ���������� � ������� ������� ����.
//
//   �����������:
//
//        � ������ ������� ���������� ���������� ����������� � ���������� ����������, � �����
//        ��������� � ��������� �� ����� ������� ���� ���������.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // ��������� ���������� ���������� � ���������� ����������

   hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  �������: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  ����������:  ������������ ��������� � ������� ����.
//
//  WM_COMMAND	- ��������� ���� ����������
//  WM_PAINT	-��������� ������� ����
//  WM_DESTROY	 - ������ ��������� � ������ � ���������.
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;
	HBRUSH brush;

	switch (message)
	{
	case WM_CREATE:
		bufDC = CreateCompatibleDC(NULL); 	
		GetClientRect(hWnd,&client); 
		bufBitmap = CreateCompatibleBitmap(bufDC, client.right, client.bottom); 
		brush = (HBRUSH)GetStockObject(WHITE_BRUSH); 
		SelectObject(bufDC, bufBitmap); 
		SelectObject(bufDC, brush);		
		Rectangle(bufDC, 0, 0, client.right, client.bottom); 
		
		bufDCTmp = CreateCompatibleDC(NULL);  	
		GetClientRect(hWnd, &client); 
		SelectObject(bufDCTmp, brush);		
		Rectangle(bufDC, 0, 0, client.right, client.bottom); 

		break;
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// ��������� ����� � ����:
		switch (wmId)
		{
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		case ID_32772:
			currenttools = 0; // pen
			MessageBox;
			break;
		case ID_32771:
			MessageBox;
			currenttools = 1;  // line
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		if (fDraw)
		{
			BitBlt(hdc, 0, 0, client.right, client.bottom, bufDCTmp, 0, 0, SRCCOPY);
		}
		else
		{
			BitBlt(hdc, 0, 0, client.right, client.bottom, bufDC, 0, 0, SRCCOPY);
		}

		EndPaint(hWnd, &ps);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_LBUTTONDOWN:
		fDraw = TRUE;
		ptPrevious.x = LOWORD(lParam);
		ptPrevious.y = HIWORD(lParam);
		return 0L;

	case WM_LBUTTONUP:
		if (fDraw)
		{
			MoveToEx(bufDC, ptPrevious.x, ptPrevious.y, NULL);
			LineTo(bufDC, LOWORD(lParam), HIWORD(lParam));
		}
		fDraw = FALSE;
		return 0L;

	case WM_MOUSEMOVE:
		if (fDraw)
		{
			if (currenttools == 1)  //if line
			{	
			    bufBitmapTmp = CreateCompatibleBitmap(bufDCTmp, client.right, client.bottom);
				SelectObject(bufDCTmp, bufBitmapTmp); 
				BitBlt(bufDCTmp, 0, 0, client.right, client.bottom, bufDC, 0, 0, SRCCOPY); 
				MoveToEx(bufDCTmp, ptPrevious.x, ptPrevious.y, NULL);
				LineTo(bufDCTmp, LOWORD(lParam), HIWORD(lParam));
				InvalidateRect(hWnd, NULL, false);
				UpdateWindow(hWnd);

	    	}
			if (currenttools == 0)
			{
				bufBitmapTmp = CreateCompatibleBitmap(bufDCTmp, client.right, client.bottom);
				SelectObject(bufDCTmp, bufBitmapTmp); 
				BitBlt(bufDCTmp, 0, 0, client.right, client.bottom, bufDC, 0, 0, SRCCOPY); 
				MoveToEx(bufDC, ptPrevious.x, ptPrevious.y, NULL);
				LineTo(bufDC, ptPrevious.x = LOWORD(lParam),
					          ptPrevious.y = HIWORD(lParam));
				InvalidateRect(hWnd, NULL, false);
				UpdateWindow(hWnd);
			}

		}
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// ���������� ��������� ��� ���� "� ���������".
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}
