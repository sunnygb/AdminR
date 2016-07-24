#include "stdafx.h"
#include <iostream>
#include "bass.h"
#include <iomanip>
#include <string>
#include <fstream>
#include "Header.h"
#include <Windows.h>
#include <cstdlib>





using namespace std;


int main()
{
	string r;
	
	
	int ce;
	library obj;
	bool b;

	system("Color f0");
	int a;
	Loading();
	do
	{
		int choice = 0;
		LoginMenu(&a);
		if (a == 1)
			signUp();
		else if (a == 2){


			signIn(&choice);
			if (choice == 1)
				break;
		}
		else
		{


			cout << "Invalid Entry Try again Later.....";
			getchar();
			getchar();
		}
	} while (true);

	do
	{
		string v = "1";
		system("cls");
		MainMenu(&a);
		if (a == 1)
		{ 
			infoAccount();
		}
		else if (a == 2){
			obj.Display();
			cout << "\n\n\t\t\tEnter Song number to play:";
			cin >> ce;
			if (ce != 0)
			{
				do
				{
					r = locate(ce);
					if (r != "\0")
						Play(r,&v);
				} 
				while (v!="0");
				
		
			}

		}
		else if (a == 3)
		{
			
			for (int i = 1; i < 11; i++){

				r = locate(i);
				if (r != "non")
					Play(r,&v);
				if (v == "0")
					break;
			}
			
		}
		else if (a == 4){
			search();
		}

		else if (a == 5)
		{
			obj.Add();
		}
		else if (a == 6){
			break;
		}
		else
		{
			cout << "\n\t\t\tInvalid Entry.........\n\t\t\tPlease Try Again";
		}
	} while (true);


}