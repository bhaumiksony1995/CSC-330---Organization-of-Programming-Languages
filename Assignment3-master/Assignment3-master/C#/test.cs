#define Default
using System;

int EvenOrNot (long number);

class Collatz
{
    static void Main()
    {
        #include <iostream>
#include <vector>
using namespace std;

bool EvenOrNot (long long int num);
long long int Collatz (long long int number);
void sortArray(vector <long long int> &num);

int main ( int argc, char *argv[] )
{
    long long int number;
    long long int currentSeq;
    cout << "Enter number : ";
    cin >> number;
    
    vector <long long> num(10);
    vector <long long int> seq(10);
    bool duplicate;
    seq.clear();
    num.clear();

    for (int i = 0; i < 10; i++)
    {
        seq[i] = Collatz(i);
        num[i] = i;
    }

    while(number != 1)
    {
        duplicate = false;
        currentSeq = Collatz(number);

        if (currentSeq > seq[0]) //if current sequence found is bigger than smallest sequence in vector, replace and sort
        {
            seq[9] = currentSeq;
            //num[0] = number;
            sortArray(seq);
            //sortArray(num);
            for (int i = 0; i < 10; i++) //keep indexes aligned
            {
                if(seq[i] == currentSeq)
                {
                    num[i] = number;
                }
            }
        }

        else if (currentSeq >= seq[9] && currentSeq <= seq[0]) //if current sequence count is between the biggest and smallest sequence found so far
        {
            for (int i = 0; i < 10; i++)
            {
                if (currentSeq == seq[i]) //if there is a duplicates sequence
                {
                    duplicate = true;
                    if (number < num[i]) //if the duplicate sequence number is smaller than current number replace and sort
                    {
                        num[i] = number;
                        sortArray(seq);
                        //sortArray(num);
                        break;
                     
                        for (int i = 0; i < 10; i++) //keep indexes aligned
                        {
                            if (num[i] == number)
                            {
                               seq[i] = currentSeq;
                            }
                        }
                    }   
                }
            }

            if (duplicate != true) //if no duplicate, but between biggest and smallest seq, replace biggest and sort
            {
                seq[9] = currentSeq;
                //num[9] = number;
                sortArray(seq);
                //sortArray(num);
                for (int i = 0; i < 10; i++) //keep indexes aligned
                {
                    if (seq[i] == currentSeq)
                    {
                        num[i] = number;
                    }
                }
            }
        }
        number--;
    }

    for (int i = 0; i < 10; i++)
    {
        cout << "Sequence : " << seq[i] << "\tNumber : " << num[i] << endl;
    }
}

void sortArray(vector <long long int> &num) //bubble sort array
{
    long long int i, j, flag = 1;
    long long int temp;
    for(i = 0; (i < 10) && flag; i++)
    {
        flag = 0;
        for (j = 0; j < 10; j++)
        {
            if (num[j+1] > num[j])      // ascending order simply changes to <
            {    
                temp = num[j];             // swap elements
                num[j] = num[j+1];
                num[j+1] = temp;
                flag = 1;               // indicates that a swap occurred.
            }
        }
    }

    return;
}

long long int Collatz(long long int number)
{
    long long int seqCount = 0;
    while (number > 1)
    {
        if(EvenOrNot(number) == true)
            number = number / 2;
        else
            number = 3 * number + 1;
        seqCount++;
    }
    return seqCount;
}

        /*long maxic = 0; 
        int end = 0; 
        long j = 2;

        Console.Write("Enter the end of range integer of sequence (Eg. if input 100 = sequence ends at 100) : ");
        end = Convert.ToInt32(Console.ReadLine());

        List<int> maxjarray = new List<ulong>();
        List<int> maxcarray = new List<ulong>();

        while (j <= end)
        {
            long i = j;
            long ic = 0;
            if (EvenOrNot(i) == 1)
            {
                i = i / 2;
            }
            else
            {
                i = (i * 3) + 1;
            }

            if (ic > maxic)
            {
                maxic = ic;
                long maxj = j;

                if (maxj != 0 && maxic != 0)
                {
                    maxjarray.add(maxj);
                    maxicarray.add(maxic);
                }
            }
            j++
        }

        for (int i = 0; i <= end*2; i++)
        {
            if (maxjarray[i] != 0 || maxicarray[i] != 0)
            {
                Console.WriteLine("Number : " << maxjarray[i]  << "\tDigit Count : " << maxicarray[i]);
                                                                }
                                }

    }*/

    public static bool EvenOrNot (long number)
        {
            if (number % 2 == 0)
                return true;
            else
                return false;
        }

}
