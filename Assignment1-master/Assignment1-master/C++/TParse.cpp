#include <iostream>
#include <fstream>
#include <string>
#include <algorithm>
using namespace std;

string getString( string infile );
//string numberFix ( string infile );
int wordCount ( string inpu );
int sentenceCount ( string input );
int syllableCount ( string infile );
bool isVowel( char ch );
int indexCount (int WC, int SC, int SYC);
int FleschKincaidIndex (int WC, int SC, int SYC);

int main ( int argc, char *argv[] )
{
    string infile = argv[1];
    string input;
    int WCount;
    int SCount;
    int SBCount;
    int index;
    int FKindex;
    getString ( infile );

    WCount = wordCount ( infile );
    SCount = sentenceCount( infile );
    SBCount = syllableCount( infile );
    index = indexCount(WCount, SCount, SBCount);
    FKindex = FleschKincaidIndex(WCount, SCount, SBCount);

    cout << "[ Word Count = " << WCount << " ]" << endl;
    cout << "[ Sentence Count = " << SCount << " ]" << endl;
    cout << "[ Syllable Count = " << SBCount << " ] " << endl;
    cout << "[ Calculated Index = " << index << " ] " << endl;
    cout << "[ Flesh-Kincaid Index = " << FKindex << " ] " << endl;    
    return 0;    
}

int wordCount ( string infile )
{
    int WCount = 0;

    fstream file ( infile.c_str(), ios::in | ios::out );

    char ch;
    file.seekg(0);
    while ( file.get(ch) )
    {
        if(ch == ' ') //Each space denotes the end of a word
        {
            WCount++;
            //WCount + 1; //Takes care there not being a space at the end of a sentence
        }
    }

    WCount = WCount + 1; //Takes care of no space at the end of a sentence
    
    return WCount;
}

int sentenceCount ( string infile )
{
    int SCount = 0;

    fstream file ( infile.c_str(), ios::in | ios::out );

    char ch;
    file.seekg(0);
    while ( file.get(ch) )
    {
        if ( (ch == '.') || (ch == '?') || (ch == '!') || (ch == ';') ) //Number of special characters equals the number of sentences
        {
            SCount++;
        }
    }      

    return SCount;
}

/*string numberFix ( string infile ) //Goes through each character and if it is a digit it removes if from the strings and returns the rebuilt string
{
    fstream file (infile.c_str(), ios::in | ios::out);
    string input;
    char ch;
    file.seekg(0);

    while ( file.get(ch) )
    {
        if ( (isalpha(ch)) || (ch == ' ') || (ch == '.') || (ch == '?') || (ch == '!') || (ch == ';') ) //If it is part of the alphabet or special character it builds the string
        {
            input += ch; 
        }

        else if ( isdigit(ch) ) //if it is a number it does not add it to the rebuilt string
        {
            continue;
        }
    }

    return input;
}*/

string getString( string infile )
{
    fstream file ( infile.c_str(), ios::in | ios::out );

    string output;
    char ch;
    file.seekg(0);
    while ( file.get(ch) )
    {
        output = output + ch;
    }

    return output;
}

int syllableCount ( string infile )
{
    fstream file ( infile.c_str(), ios::in | ios::out );
    char adjLets[5000000];
    char sepLets[5000000];
    char ch1;
    char ch2;
    int i = 0;
    int Syllables = 0;
    file.seekg(0);
    while ( file.get(ch1) )
    {
        file.seekg(1);
        while ( file.get(ch2) )
        {
            if ( isVowel(ch1) == true && isVowel(ch2) == true )
            {
                adjLets[i] = ch1;
            }

            else if ( isVowel(ch1) == true && isVowel(ch2) == false)
            {
                sepLets[i] = ch1;
            }

            else if ( isVowel(ch1) == false && isVowel(ch2) == true)
            {
                sepLets[i] = ch2;
            }
        i++;
        }
    }

    for (int i = 0; i <= 5000000; i++)
    {
        if (sepLets[i] != 0)
        {
            Syllables++;
        }
    }

    return Syllables;
}

bool isVowel( char ch ) 
{
    if( (ch=='a') || (ch=='e') || (ch=='i') || (ch=='o') || (ch=='u') )
         return true;
    else 
        return false;
}

int indexCount (int WC, int SC, int SYC)
{
    double alpha = SC / WC;
    double beta = WC / SC;
    int index = 206.835 - (alpha * 84.6) + (beta * 1.015);
    return index;
}

int FleschKincaidIndex (int WC, int SC, int SYC)
{
    double alpha = SC / WC;
    double beta = WC / SC;
    int index = 206.835 - (alpha * 11.8) + (beta * 0.39) - 15.59;
    return index;
}
