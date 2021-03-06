#include <iostream>
#include <string>
#include <fstream>
using namespace std;

class Vigenere
{
public:
	string key;

	Vigenere(string key)
	{
		this->key = key;
	}

	string encrypt(string text)
	{
		string out;
		int asc;
		int vasc;
		int temp;
		char in;
		cout << key << endl << key.length() << endl;
		for (int i = 0, j = 0; i < text.length(); i++)
		{
			char c = text[i];
			asc = (int)c;
			vasc = (int)key[j];
			temp = asc + vasc;
			//temp = temp % 128;
			in = (char)temp;
			out += in;
			j = (j + 1) % key.length();
		}

		return out;
	}

	string decrypt(string text)
	{
		string out;
		int asc;
		int vasc;
		int temp;
		char in;
		for (int i = 0, j = 0; i < text.length(); ++i)
		{
			char c = text[i];
			asc = (int)c;
			vasc = (int)key[j];
			temp = asc - vasc;
			//temp = temp % 128;
			in = (char)temp;
			out += in;
			j = (j + 1) % key.length();
		}

		return out;
	}
};

int main()
{
	fstream myfile;
	myfile.open("book.txt");
	string line;
	string text;
	if (myfile.is_open())
	{
		while (getline(myfile, line))
		{
			text += line + "\n";
		}
		myfile.close();
	}
	else cout << "Unable to open file book.txt";
	string vector;
	cout << vector;
	int vLength = 0;
	char input;
	int asci;
	cout << "enter length of vector " << endl;
	cin >> vLength;
	cout << "enter vector in numbers, one by one" << endl;
	for (int i = 0; i < vLength; i++)
	{
		cin >> asci;
		asci = asci % 128;
		input = (char)asci;
		cout << input <<endl ;
		
		vector += input;
	}
	cout << "encrypting file: " << endl;
	Vigenere cipher(vector);
	string encrypted = cipher.encrypt(text);
	myfile.open("encrypt.txt");
	if (myfile.is_open())
	{
		myfile << encrypted;
		myfile.close();
		cout << "encrypted text saved in file encrypt.txt:" << endl;
	}
	else cout << "Unable to open file encrypt.txt";
	cout << "Reading from encrypted file encrypt.txt"<<endl;
	text = "";
	line = "";
	myfile.open("encrypt.txt");
	if (myfile.is_open())
	{
		while (getline(myfile, line))
		{
			text += line + "\n";
		}
		myfile.close();
	}
	else cout << "Unable to open file encrypt.txt";
	cout << "decrypting file read from encrypt.txt" << endl;
	string decrypted = cipher.decrypt(text);
	cout << "saving decrypted text to file decrypt.txt" << endl;
	myfile.open("decrypt.txt");
	if (myfile.is_open())
	{
		myfile << decrypted;
		myfile.close();
	}
	else cout << "Unable to open file decrypt.txt";
	cout << "the files can now be seen in the folder \cypher\cypher in the project" << endl;
	return 0;
	system("pause");
};