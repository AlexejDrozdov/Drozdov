#include <Windows.h>
#include <iostream>
#include <vector>
#define EXPORT extern "C" __declspec(dllexport)

namespace RedBlackTreeLibrary
{

	typedef enum { BLACK, RED } nodeColor;  //  структура каждого листа в КЧД
	typedef enum {
		PHONENUMBER, FIRSTNAME, SECONDNAME, THIRDNAME, ADDRESS, BUILDINGNUMBER, CORPNUMBER,
		APPARTEMENTNUMBER
	} CompareCriterion;

	struct Node {
		Node *left;
		Node *right;
		Node *parent;
		nodeColor color;
		char key[30];
		std::vector<void*> addressList;
		Node(Node *l, Node *r, Node *p, nodeColor c, char data[], void * adr) :
			left(l), right(r), parent(p), color(c)
		{
#pragma warning(disable: 4996)
			std::strcpy(key, data);
			addressList.push_back(adr);
		}
	};

	struct Data {
		int number;
		char * firstName;
		char * secondName;
		char * thirdName;
		char * address;
		int buildingNumber;
		int corpNumber;
		int appartementNumber;
		Data(int n, char * fn, char * sn, char * tn, char * adr, int bn, int cn, int an) :
			number(n), firstName(fn), secondName(sn), thirdName(tn), address(adr), buildingNumber(bn),
			corpNumber(cn), appartementNumber(an) {}
	};


	class DataReader
	{
	public:
		DataReader(char * filename);
		Data GetNextRecord();
	};



	class RedBlackTree
	{
	public:
		Node* tnil;
		RedBlackTree(char key[30], void * address);
		void InsertData(char key[30], void * address);
		void InsertNode(Node*root, char key[30], void * address);
		std::vector<void *>*  FindNode(char key[30]);
		~RedBlackTree();
	private:
		Node* root;
		void FixTree(Node * node);
		void RotateLeft(Node * node);
		void RotateRight(Node * node);
		int CompareKeys(char key1[30], char key2[30]);
		Node* nullNode;
	};

}
HANDLE hSharedMemory;
HANDLE hMutex;
void* address;
EXPORT void InitializeMemory();
EXPORT void InitializeTrees();
EXPORT void FindSurname(char surname[], HWND hWnd);
EXPORT void FindAdress(char street[], HWND hWnd);
EXPORT void FindTelephone(char telephone[], HWND hWnd);