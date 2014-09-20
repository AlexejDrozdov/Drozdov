// Lab_1.cpp: определяет точку входа для приложения.
//

#include "stdafx.h"
#include "Lab_1.h"
#include <commdlg.h>

#define MAX_LOADSTRING 100

// Глобальные переменные:
HINSTANCE hInst;								// текущий экземпляр
TCHAR szTitle[MAX_LOADSTRING];					// Текст строки заголовка
TCHAR szWindowClass[MAX_LOADSTRING];			// имя класса главного окна
BOOL fDraw = FALSE;
POINT ptPrevious;
HDC bufDC, bufDCTmp;
HBITMAP bufBitmap, bufBitmapTmp;
RECT client;
int currenttools;
int width = 0;
BYTE R, G, B;
COLORREF RGBcurrent = RGB(0,0,0);


// Отправить объявления функций, включенных в этот модуль кода:
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

 	// TODO: разместите код здесь.
	MSG msg;
	HACCEL hAccelTable;

	// Инициализация глобальных строк
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_MY123, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Выполнить инициализацию приложения:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MY123));
	
	// Цикл основного сообщения:
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
//  ФУНКЦИЯ: MyRegisterClass()
//
//  НАЗНАЧЕНИЕ: регистрирует класс окна.
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
//   ФУНКЦИЯ: InitInstance(HINSTANCE, int)
//
//   НАЗНАЧЕНИЕ: сохраняет обработку экземпляра и создает главное окно.
//
//   КОММЕНТАРИИ:
//
//        В данной функции дескриптор экземпляра сохраняется в глобальной переменной, а также
//        создается и выводится на экран главное окно программы.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // Сохранить дескриптор экземпляра в глобальной переменной

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
//  ФУНКЦИЯ: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  НАЗНАЧЕНИЕ:  обрабатывает сообщения в главном окне.
//
//  WM_COMMAND	- обработка меню приложения
//  WM_PAINT	-Закрасить главное окно
//  WM_DESTROY	 - ввести сообщение о выходе и вернуться.
//
//
void OpenFile(HWND hWnd)
{
	OPENFILENAME file;
	wchar_t FileName[MAX_PATH];
	wchar_t FilePath[MAX_PATH];
	FileName[0] = '\0';
	FilePath[0] = '\0';
	
	file.lStructSize = sizeof(OPENFILENAME);
	file.hwndOwner   = hWnd;
	file.hInstance   = hInst;
	file.lpstrFilter = L"EMF\0*.*\0\0";
	file.lpstrCustomFilter = NULL;
	file.nFilterIndex = 1;
	file.lpstrFile = FilePath;
	file.nMaxFile = MAX_PATH;
	file.lpstrFileTitle = FileName;
	file.nMaxFileTitle = sizeof(FileName);
	file.lpstrInitialDir = NULL;
	file.lpstrDefExt = L"emf";
	file.lpstrTitle = L"Open File";
	file.Flags = OFN_SHOWHELP | OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;
	file.nFileOffset = 0;
	file.nFileExtension = 0;

	if (GetOpenFileName(&file))
	{

		// Open the metafile.  
		HENHMETAFILE hemf = GetEnhMetaFile(file.lpstrFile);

		// Retrieve a handle to a window device context.  
		HDC hDC = GetDC(hWnd);

		// Retrieve the client rectangle dimensions.  
		GetClientRect(hWnd, &client);

		// Draw the picture.  
		PlayEnhMetaFile(hDC, hemf, &client);
		PlayEnhMetaFile(bufDC, hemf, &client);

		// Release the metafile handle.  
		DeleteEnhMetaFile(hemf);

		// Release the window DC.  
		ReleaseDC(hWnd, hDC);
	}
}

void SaveFile(HWND hWnd)
{
	// Obtain a handle to a reference device context.  
	OPENFILENAME file;
	wchar_t FileName[MAX_PATH];
	wchar_t FilePath[MAX_PATH];
	FileName[0] = '\0';
	FilePath[0] = '\0';
	int iWidthMM, iHeightMM, iWidthPels, iHeightPels;

	file.lStructSize = sizeof(OPENFILENAME);
	file.hwndOwner = hWnd;
	file.lpstrFilter = L"EMF\0*.*\0\0";
	file.lpstrCustomFilter = NULL;
	file.lpstrFile = FilePath;
	file.nMaxFile = MAX_PATH;
	file.lpstrFileTitle = FileName;
	file.nMaxFileTitle = sizeof(FileName);
	file.lpstrInitialDir = NULL;
	file.lpstrDefExt = L"emf";
	file.lpstrTitle = L"Save File";
	file.Flags = OFN_PATHMUSTEXIST | OFN_OVERWRITEPROMPT | OFN_HIDEREADONLY | OFN_EXPLORER;

	if (GetSaveFileName(&file))
	{

		HDC hdcRef = GetDC(hWnd);
		// Determine the picture frame dimensions.  

		iWidthMM = GetDeviceCaps(hdcRef, HORZSIZE);   // iWidthMM is the display width in millimeters. 
		iHeightMM = GetDeviceCaps(hdcRef, VERTSIZE);  // iHeightMM is the display height in millimeters. 
		iWidthPels = GetDeviceCaps(hdcRef, HORZRES);  // iWidthPels is the display width in pixels.  
		iHeightPels = GetDeviceCaps(hdcRef, VERTRES); // iHeightPels is the display height in pixels 

		// Retrieve the coordinates of the client  
		// rectangle, in pixels.  

		RECT rectemf;
		GetClientRect(hWnd, &rectemf);
		// Convert client coordinates to .01-mm units.
		client.left = (client.left * iWidthMM * 100) / iWidthPels;       // Use iWidthMM, iWidthPels, iHeightMM, and 
		client.top = (client.top * iHeightMM * 100) / iHeightPels;       // iHeightPels to determine the number of  
		client.right = (client.right * iWidthMM * 100) / iWidthPels;     // .01-millimeter units per pixel in the x-
		client.bottom = (client.bottom * iHeightMM * 100) / iHeightPels; //  and y-directions.  
		// Create the metafile device context.  

		HDC hdcMeta = CreateEnhMetaFile(hdcRef, (LPTSTR)file.lpstrFile, &client, NULL);
		GetClientRect(hWnd, &rectemf);
		PatBlt(hdcMeta, 0, 0, client.right, client.bottom, PATCOPY);
		BitBlt(hdcMeta, 0, 0, client.right, client.bottom, bufDC, 0, 0, SRCCOPY);
		CloseEnhMetaFile(hdcMeta);
		// Release the reference device context.  
		ReleaseDC(hWnd, hdcRef);
	}
}

void LPT(HWND hWnd)
{
	PRINTDLG PrintDialog;


	// Initialize PRINTDLG 
	ZeroMemory(&PrintDialog, sizeof(PrintDialog));
	PrintDialog.lStructSize = sizeof(PrintDialog);
	PrintDialog.hwndOwner = hWnd;
	PrintDialog.hDevMode = NULL;     // Don't forget to free or store hDevMode. 
	PrintDialog.hDevNames = NULL;     // Don't forget to free or store hDevNames. 
	PrintDialog.Flags = PD_USEDEVMODECOPIESANDCOLLATE | PD_RETURNDC;
	PrintDialog.nCopies = 1;
	PrintDialog.nFromPage = 0xFFFF;
	PrintDialog.nToPage = 0xFFFF;
	PrintDialog.nMinPage = 1;
	PrintDialog.nMaxPage = 0xFFFF;

	if (PrintDlg(&PrintDialog) == TRUE)
	{
		int px = GetDeviceCaps(PrintDialog.hDC, LOGPIXELSX);
		int py = GetDeviceCaps(PrintDialog.hDC, LOGPIXELSY);
		DOCINFO docinfo;

		docinfo.cbSize = sizeof(docinfo);
		docinfo.fwType = NULL;
		docinfo.lpszDatatype = NULL;
		docinfo.lpszDocName = L"Printing";
		docinfo.lpszOutput = NULL;

		StartDoc(PrintDialog.hDC, &docinfo);
		StartPage(PrintDialog.hDC);

		GetClientRect(hWnd,&client);

		//client.right *= px*100;
	//	client.bottom *= py*100;
		PatBlt(PrintDialog.hDC, 0, 0, client.right, client.bottom, PATCOPY);
		//BitBlt(PrintDialog.hDC, 0, 0, client.right, client.bottom, GetDC(hWnd), 0, 0, SRCCOPY);
		StretchBlt(PrintDialog.hDC, 0, 0, client.right*px/150, client.bottom*px/150, GetDC(hWnd), 0, 0, client.right, client.bottom, SRCCOPY);
		EndPage(PrintDialog.hDC);
		EndDoc(PrintDialog.hDC);
		DeleteDC(PrintDialog.hDC);
	}

}

void Color(HWND hWnd)
{
	CHOOSECOLOR cc;                 // common dialog box structure  
	static COLORREF acrCustClr[16]; // array of custom colors  
	HBRUSH hbrush;                  // brush handle 
	static DWORD rgbCurrent;        // initial color selection 

	// Initialize CHOOSECOLOR  
	ZeroMemory(&cc, sizeof(cc));
	cc.lStructSize = sizeof(cc);
	cc.hwndOwner = hWnd;
	cc.lpCustColors = (LPDWORD)acrCustClr;
	cc.rgbResult = RGBcurrent;
	cc.Flags = CC_FULLOPEN | CC_RGBINIT;

	if (ChooseColor(&cc) == TRUE)
	{
		hbrush = CreateSolidBrush(cc.rgbResult);
		RGBcurrent = cc.rgbResult;
	}
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;
	HBRUSH brush;
	HPEN pen;


	switch (message)
	{
	case WM_CREATE:
		bufDC = CreateCompatibleDC(GetDC(hWnd)); 	
		GetClientRect(hWnd,&client); 
		client.right = 1920;
		client.bottom = 1080;
		bufBitmap = CreateCompatibleBitmap(GetDC(hWnd), client.right, client.bottom);
		brush = (HBRUSH)GetStockObject(WHITE_BRUSH); 
		pen = CreatePen(BS_SOLID, width, RGB(R, G, B));
		SelectObject(bufDC, bufBitmap); 
		SelectObject(bufDC, brush);		

		SelectObject(bufDC, pen);
		//(bufDC, 0, 0, client.right, client.bottom);
		FillRect(bufDC, &client, brush);
		

		bufDCTmp = CreateCompatibleDC(GetDC(hWnd));
		GetClientRect(hWnd, &client); 
		SelectObject(bufDCTmp, brush);	
		SelectObject(bufDCTmp, pen);
		FillRect(bufDCTmp, &client, brush);

		break;
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Разобрать выбор в меню:
		switch (wmId)
		{
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		case ID_PEN:
			currenttools = 0; // pen
			break;
		case ID_LINE:
			currenttools = 1;  // line
			break;
		case ID_RECTANGLE:
			currenttools = 2;
			break;
		//change width
		case ID_WIDTH1:
			width = 1;
			break;
		case ID_WIDTH2:
			width = 2;
			break;
		case ID_WIDTH3:
			width = 3;
			break;
		case ID_WIDTH4:
			width = 4;;
			break;
		case ID_WIDTH5:
			width = 5;
			break;
		case ID_WIDTH6:
			width = 6;
			break;
		case ID_LOAD:
			OpenFile(hWnd);
			break;
		case ID_SAVE:
			SaveFile(hWnd);
			break;
		case ID_COLOR:
			Color(hWnd);
			break;
		case ID_LPT:
			LPT(hWnd);
			break;
		case ID_CLEAN:
			brush = CreateSolidBrush(RGB(255, 255, 255));
			FillRect(bufDC, &client, brush);
			FillRect(bufDCTmp, &client, brush);
			FillRect(GetDC(hWnd), &client, brush);
			break;

		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		pen = CreatePen(BS_SOLID, width, RGBcurrent);
		//DeleteObject(SelectObject(GetDC(hWnd), pen));
		DeleteObject(SelectObject(bufDC, pen));
		DeleteObject(SelectObject(bufDCTmp, pen));
	//	LineTo(GetDC(hWnd), 200, 200);
		//InvalidateRect(hWnd, NULL, false);



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

			if (currenttools == 1)
			{
				MoveToEx(bufDC, ptPrevious.x, ptPrevious.y, NULL);
				LineTo(bufDC, LOWORD(lParam), HIWORD(lParam));
			}
			if (currenttools == 2)
			{
				MoveToEx(bufDC, ptPrevious.x, ptPrevious.y, NULL);
				Rectangle(bufDC, ptPrevious.x, ptPrevious.y, LOWORD(lParam), HIWORD(lParam));
			}
		}
		fDraw = FALSE;
		return 0L;

	case WM_MOUSEMOVE:
		if (fDraw)
		{
			

			bufBitmapTmp = CreateCompatibleBitmap(GetDC(hWnd), client.right, client.bottom);
			SelectObject(bufDCTmp, bufBitmapTmp);
			BitBlt(bufDCTmp, 0, 0, client.right, client.bottom, bufDC, 0, 0, SRCCOPY);
			if (currenttools == 1)  //if line
			{	
				MoveToEx(bufDCTmp, ptPrevious.x, ptPrevious.y, NULL);
				LineTo(bufDCTmp, LOWORD(lParam), HIWORD(lParam));
	    	}
			if (currenttools == 0)
			{

				MoveToEx(bufDC, ptPrevious.x, ptPrevious.y, NULL);
				LineTo(bufDC, ptPrevious.x = LOWORD(lParam),
					          ptPrevious.y = HIWORD(lParam));;
			}
			
			if (currenttools == 2)
			{
				MoveToEx(bufDCTmp, ptPrevious.x, ptPrevious.y, NULL);
				Rectangle(bufDCTmp, ptPrevious.x, ptPrevious.y, LOWORD(lParam), HIWORD(lParam));
			}
			InvalidateRect(hWnd, NULL, false);
			UpdateWindow(hWnd);
		}
	case WM_MOUSEWHEEL:
		if (LEFT_CTRL_PRESSED)
		{
			if (HIWORD(wParam)>WHEEL_DELTA)
			{
				StretchBlt(bufDCTmp, 0, 0, client.right - 15, client.bottom - 15, bufDC, 0, 0, client.right, client.bottom,SRCCOPY);
				BitBlt(bufDC, 0, 0, client.right, client.bottom, bufDCTmp, 0, 0,SRCCOPY);
				InvalidateRect(hWnd, NULL, false);

			}
			//else
			//{
				//StretchBlt(bufDCTmp, 0, 0, client.right + 15, client.bottom + 15, bufDC, 0, 0, client.right, client.bottom, SRCCOPY);
				//BitBlt(bufDC, 0, 0, client.right, client.bottom, bufDCTmp, 0, 0, SRCCOPY);
				//InvalidateRect(hWnd, NULL, false);
			//}
		}
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// Обработчик сообщений для окна "О программе".
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
