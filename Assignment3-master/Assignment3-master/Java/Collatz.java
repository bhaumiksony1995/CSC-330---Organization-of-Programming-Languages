import java.util.*;

public class Collatz
{
    public static void main(String[] args)
    {
        long number = 0;
        int finish = 0;
        int numCount = 0;
        int numCountCopy = 0;
        int longestSequence = 0;
        System.out.print("Enter the end of range integer of sequence (Eg. if input 100 = sequence ends at 100) : ");
        Scanner scanner = new Scanner(System.in);
        finish = scanner.nextInt();
    
        for (int i = 2; i <= finish; i++) //number should not start under 1
        {   
            number = i; //resets number to next value that needs to be tested
            numCount = 0; //resets sequence count to 0 every time
    
            while (number != 1) //keep going til number hits 1
            {   
                if (EvenOrNot(number) == 1) //evaluates if number is even or odd, if it is do the even calculations
                {
                    number = number / 2;
                    numCount++;
                }
                else //if its odd, do the odd calculations
                {
                    number = (number * 3) + 1;
                    numCount++;
                 }
            }
        
            if (numCount > numCountCopy) //if the prev sequence count is bigger then current keep that value, the biggest value gets left in longestSequence
            {
                longestSequence = i;
                numCountCopy = numCount;
            }
        }
    
        System.out.println("Number with biggest sequence is : " + longestSequence);
    }

    public static int EvenOrNot (long number)
    {
        if ( number % 2 == 0)
            return 1;
        else
            return 0;
    }

}

