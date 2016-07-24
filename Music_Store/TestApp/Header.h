#include "stdafx.h"
#include <iostream>
#include "bass.h"
#include <fstream>
#include<string>
#include<Windows.h>
#include <stdio.h>
#include <stdlib.h>
#include<thread>
#include<mutex>
#include "bass.h"
using namespace std;


std::mutex mu;

 string loc2 = "Sound\\";
 char i = 219;	 
 void playDesign(string *x){
	 cout << "\n\t\t\t";
	 mu.lock();
	 for (int j = 0; j <= 60; j++)
	 {
		 cout << i;
		 if (*x == "x" || *x == "0")
			 break;
		 Sleep(1500);
		 

	 }
	 mu.unlock();
 }
 void line(){
	 char w = 219;
	 cout << "\t\t\t";
	 for (int j = 0; j < 70; j++)
		 cout << w;
	 cout << endl;
 }
 string locate(int key){
	 string loc, sing, alb, ext, nam, a, pric;
	 int num;
	 ifstream read;
	 read.open("album.dat");
	 if (!read)
		 cout << "Error in File Opening";
	 else
	 {

		 while (!read.eof()){
			 read >> num >> nam >> sing >> alb >> ext >> pric;
			 if (key == num){
			   return ext;
			 } 
		 }
		 return "non";
	 }
 }
 void Play(string l,string *x ){
	 char b = 219;
	 system("cls");
	 cout << "\t\t\t\t\t\t\t\t\t\t\t\tMain Menu Press 0\r";
	 line();
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << setw(65) << "Music Player" << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 line();
	 HSTREAM streamHandle; // Handle for open stream

	 /* Initialize output device */
	 BASS_Init(-1, 44100, 0, 0, NULL);

	 /* Load your soundfile and play it */
	 streamHandle = BASS_StreamCreateFile(FALSE, l.c_str(), 0, 0, 0);//c_str() is used to show string as file location

	 BASS_ChannelPlay(streamHandle, FALSE);
	 cout << "\n\n";
	 cout << "\t\t\t\t\t\t  Enter X to exit:\n";
	 thread t1((playDesign), x);
	 cin >> *x;
	 if (*x == "x"||*x=="0")
	 {
		 t1.join();
		 BASS_Free();
		
	 }
}
 void Loading(){
	 cout << endl << endl << endl << endl << endl;
	 char c = 177, b = 219;
	 char f[100] = "SADIA.............ABDULLAH................AHMED";
	 cout << "\n\n\n\n\n\n\n\n\n\t\t\tPlease wait while loading\n\n";
	 cout << "\t";
	 for (int i = 0; i <= 100; i++){


		 cout << f[i];
		 Sleep(50);
	 }
	 cout << "\r\t";
	 for (int i = 0; i <= 50; i++)
	 {
		 cout << b;
		 Sleep(40);
	 }
 }
 void LoginMenu(int *a){
	 system("cls");
	 line();
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << setw(70) << " | PRESS(1) TO SIGN UP |" << endl;
	 cout << setw(70) << " | PRESS(2) TO SIGN IN |" << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 line();
	 cout << "---->";
	 cin >> *a;
	 
 }
 void MainMenu(int *b){
	 system("cls");
	 line();
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << setw(70) << "Welcome to Main Menu" << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 line();

cout << "\n\n\r\t\t\t\t\t\t| 1# Accoutn information |"<< endl;
cout << "\r\t\t\t\t\t\t| 2# Show Music Library  | "<< endl;
cout << "\r\t\t\t\t\t\t| 3# Play Top Songs      |" << endl;
cout << "\r\t\t\t\t\t\t| 4# Search              |" << endl;
cout << "\r\t\t\t\t\t\t| 5# Add New Song        |" << endl<<endl;
line();
cout << "\t\t\t\t\t\tEnter Your Choice: ";
cin >> *b;

	 
 }
 void signUp(){
	 system("cls");
	 line();
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << setw(70) << "Welcome Sign_UP Menu" << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 line();
	 std::string userName, passWord, firstName, lastName, CNIC, eMail;
	 int ammount;
	 ofstream signUp;
	 signUp.open("Credential.dat", ios::app);
	 if (!signUp)
		 cout << "Sorry, file can not be open!!!" << endl;
	 else
	 {


		 cout << "\n";
		 cout << "\t\t\tEnter FirstName:";
		 cin >> firstName;
		 cout << "\t\t\tEnter LastName:";
		 cin >> lastName;
		 cout << "\t\t\tEnter Your Email:";
		 cin >> eMail;
		 cout << "\t\t\tEnter CNIC:";
		 cin >> CNIC;
		 cout << "\t\t\tEnter Ammount:";
		 cin >> ammount;
		 cout << "\t\t\tEnter Username:";
		 cin >> userName;
		 cout << "\t\t\tEnter Pasword:";
		 cin >> passWord;
		 signUp << endl << userName << "\t" << passWord << "\t" << firstName << "\t" << lastName << "\t" << CNIC << "\t" << eMail << "\t" << ammount;
		 cout << "Congratulation...... Your account has been Created";
		 getchar();
		 system("cls");
		 {
			 cout << "\t" << endl;
			 for (int i = 0; i < 80; i++)
				 cout << "*";
			 cout << endl << endl;
			 cout << "|| UserName ||\t||      FirstName      ||\t||   Last name  ||\t|| Ammount ||" << endl << endl << "\t" << endl;
			 cout << " " << userName << "\t" << "     " << firstName << " " << lastName << "\t" << "         " << ammount << "$" << endl;

			 for (int i = 0; i < 80; i++)
				 cout << "*";
			 cout << endl;

		 }
		 getchar();
		 signUp.close();
	 }

 }
 void infoAccount()
 {
	 system("cls");
	 cout << "\t\t\t\t\t\t\t\t\t\t\t\tMain Menu Press 0\r";
	 line();
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << setw(70) << "Welcome to Account Menu" << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	 line();
	 ifstream infoAccount;
	 string userName, passWord, fName, lName, CNIC, ammount,email;


	 infoAccount.open("Credential.dat", ios::out);
	 if (!infoAccount)
		 cout << "Sorry, file can not be open!!!" << endl;
	 cout << "\n|| UserName ||\t||   First Name      ||\t||   Last name  ||\t||        Email       ||\t|| Ammount ||" << endl<<endl;
	 for (int j = 0; j < 120; j++)
		 cout << i;
	 cout << endl;
	 while (!infoAccount.eof())
	 {

		 infoAccount >> userName >> passWord >> fName >> lName >> CNIC >>email>> ammount;
		 cout <<"   "<< userName << "\t     " << fName << "\t\t     " << lName << "\t\t     " << email << "\t\t    " << ammount <<"$"<< endl;



	 }
	 getchar();
	 getchar();
	 infoAccount.close();

 }
void Title()
{
	cout << "\t";
	for (int i = 0; i < 75; i++)
		cout << *"*";
	cout << endl<<endl;
	cout << "\t||No.#||\t||Song||\t||Singer||\t||Album||\t||Price||" << endl<<endl << "\t";
	for (int i = 0; i < 75; i++)
		cout << *"*";
	cout << endl;
}
class library{
private:
	string name;
	string singer;
	string ext;
	string album;
	string location;
	int position;

public:
	
	void Add();
	void Remove();
	void Play(string);
	void Search();
	void Display();
	void sorting();
	


};
void library::Add(){
	system("cls");
	cout << "\t\t\t\t\t\t\t\t\t\t\t\tMain Menu Press 0\r";
	line();
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	cout << setw(70) << "Welcome to Adding Song Menu" << endl;
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	line();
	string nam, loc, sing, alb, ex1,a,pric="100";
	int num = 0;
	
	cout << "Enter song file int the form of abc.mp3 in this folder" << endl;
	Sleep(2000);
	ShellExecute(NULL, NULL, L"Sound", NULL, NULL, SW_SHOWNORMAL); //Function to open Folder
	cout << "Enter the exact file Name int the form of `abc.mp3`";
	cin >> ex1;
	loc = loc2 + ex1;
	cout << "Enter The name of Song:";
	cin>>nam;
	cout << "Enter the Singer:";
	cin  >> sing;
	cout << "Enter the Album name:";
	cin  >> alb;
	ifstream obj1;
	ofstream obj2;
	obj1.open("album.dat", ios::in);
	obj2.open("album.dat", ios::app);
	while (!obj1.eof())
	{
		getline(obj1, a);//TO count Lines
		num++;

	}
	obj2 << endl <<num<< "\t" << nam << "\t" << sing << "\t" << alb <<"\t" << loc << "\t"<<pric;
		
	cout << "\nSong has successfully added....!!!";
	getchar();
	obj1.close();
	obj2.close();



}
void library::Display(){
	
	system("cls");
	cout << "\t\t\t\t\t\t\t\t\t\t\t\tMain Menu Press 0\r";
	line();
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	cout << setw(70) << "Welcome to Library" << endl;
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	line();
	string nam, sing, alb, ex1,pric,ext,num;
	ifstream obj;
	obj.open("album.dat");
	Title();
	while (!obj.eof()){
		obj >> num >> nam >> sing  >> alb  >> ext  >> pric;
		cout << "\t  " << num << "\t\t " << nam << "\t\t  " << sing << "\t\t  " << alb << "\t\t  " << pric <<"$"<< endl;
	}
	obj.close();
}
void search()
{
	int s = 0;
	system("cls");
	line();
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	cout << setw(70) << "Welcome to Search Menu" << endl;
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	line();
	string key, nam, sing,num, alb, ex1, pric, loc;
	cout << "Enter Name,Singer or Album to find:";
	cin >> key;
	ifstream obj;
	obj.open("album.dat");
	if (!signUp)
		cout << "Sorry, file can not be open!!!" << endl;
	else
	{
		cout << "\n\tSearching";
		for (int k = 0; k < 5; k++){


			cout << ".";
			Sleep(300);
		}
		while (!obj.eof()){
			obj >> num >> nam >> sing >> alb >> ex1 >> pric;
			if (key == nam || key == sing || key == alb)
			{
				cout << "Result Found..........\n\n";
				Title();
				cout << "\t  "<<num<<"\t\t  "<<nam << "\t\t  " << sing << "\t\t  " << alb << "\t\t  " << pric << "$" << endl;
				s = 1;
			}
		}
		if (s!=1)
		cout << "No Result Found.........!!";
	}
	getchar();
	getchar();
}

void signIn(int *cho){
	system("cls");
	line();
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	cout << setw(70) << "Welcome to Sign_IN Menu" << endl;
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	cout << "\t\t\t" << i << i << i << "\t\t\t\t\t\t\t\t   " << i << i << i << endl;
	line();
	string userName, passWord, compare_U, compare_P;
	ifstream signIn;


	signIn.open("Credential.dat", ios::out);
	if (!signIn)
		cout << "Sorry, file can not be open!!!" << endl;
	
		cout << "Enter Username:";
		cin >> compare_U;
		cout << "Enter Pasword:";
		cin >> compare_P;
		while (!signIn.eof())
		{
			signIn >> userName >> passWord;
			if (userName == compare_U || passWord == compare_P)
			{

				cout << "Access Granted.....................";
				*cho = 1;
				break;
			}
			else
				cout << "Either Username or Password is incorrect\n\nPlease Try Again\n" << endl;
			break;

		}
	signIn.close();
	system("pause");
}
void sorting(string val1,string val2){
	int ascii_1,ascii_2;
	ascii_1 = int(val1[1]);
	ascii_2 = int(val2[1]);
	if (ascii_1 > ascii_2)
	{
		string temp;
		temp = val1;
		val1 = val2;
		val2 = val1;
	}

}
