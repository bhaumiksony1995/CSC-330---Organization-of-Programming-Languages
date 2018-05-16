import java.util.*;
import java.util.Scanner.*;
import java.io.*;
public class TParse
{
    public static void main (String[] args)
    {
        String infile = args[0];
        String input;
        int WC = 0; //word count
        int SC = 0; //sentence count
        int SYC = 0; //syllable count
        double index = 0; //calculated index
        double FKindex = 0; //calculated Flesch-Kincaid index
        input = getString(infile);
        WC = wordCount(input);
        SC = sentenceCount(input);
        SYC = syllableCount(input);
        index = gradeIndex(WC, SC, SYC);
        FKindex = FleschKincaid (WC, SC, SYC);

        System.out.println("Word count : " + WC);
        System.out.println("Sentence count : " + SC);
        System.out.println("Syllable count : " + SYC);
        System.out.println("Index : " + index);
        System.out.println("Flesch-Kincaid Index : " + FKindex);
    }

    public static String getString(String infile)
    {
        String input = " ";

        BufferedReader br = null;
        FileReader fr = null;

        try
        {
            fr = new FileReader(infile);
            br = new BufferedReader(fr);

            String CurrentLine;

            while ( (CurrentLine = br.readLine() ) != null)
            {
                input = input + CurrentLine;
            }
        }

        catch (IOException e)
        {
            e.printStackTrace(); //diagnostic for exceptions that occur
        }

        return input;
    }

    public static int wordCount(String input)
    {
            int wordCount = -1;

            for (int i = 0; i < input.length(); i++) 
            {
                if (input.charAt(i) == ' ') 
                {
                    wordCount++;
                } 
            }

        return wordCount;
    }

    public static int sentenceCount(String input)
    {
        int sentenceCount = 0;
            
            for (int i = 0; i < input.length(); i++)
            {   
                if ( (input.charAt(i) == '.') || (input.charAt(i) == '!')  || (input.charAt(i) == '?') || (input.charAt(i) == ';') )
                {   
                    sentenceCount++;
                }
            }

        return sentenceCount;
    }

    public static int syllableCount(String input)
    {
        int count = 0;
        input = input.toLowerCase();
        for (int i = 0; i < input.length(); i++) 
        {
            if (input.charAt(i) == '\"' || input.charAt(i) == '\'' || input.charAt(i) == '-' || input.charAt(i) == ',' || input.charAt(i) == ')' || input.charAt(i) == '(') 
            {
                input = input.substring(0,i) + input.substring(i + 1, input.length());
            }
        }
    
        boolean isPrevLetVowel = false;
    
        for (int j = 0; j < input.length(); j++) 
        {
            if (input.contains("a") || input.contains("e") || input.contains("i") || input.contains("o") || input.contains("u")) 
            {
                if ( isVowel( input.charAt(j) ) && !( (input.charAt(j) == 'e') && (j == input.length() - 1) ) ) 
                {
                    if (isPrevLetVowel == false) 
                    {
                        count++;
                        isPrevLetVowel = true;
                    }
                } 

                else 
                {
                    isPrevLetVowel = false;
                }
            }  

            else
            {
                count++;
                break;
            }
        }
    
        return count;
    } 

    public static boolean isVowel(char ch) 
    {
        if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u') 
        {
            return true;
        } 

        else 
        {
            return false;
        }
    }

    public static double gradeIndex(int WC, int SC, int SYC)
    {
        double wordCount = WC;
        double sentCount = SC;
        double sylCount = SYC;
        double alpha = 0.0;
        double beta = 0.0;
        double index = 0.0;

        alpha = sylCount / wordCount;
        beta = wordCount / sentCount;
        index = 206.835 - (alpha * 84.6) - (beta * 1.015);
        return index;       
    }

    public static double FleschKincaid (int WC, int SC, int SYC)
    {
        double wordCount = WC;
        double sentCount = SC;
        double sylCount = SYC;
        double alpha = 0.0;
        double beta = 0.0;
        double index = 0.0;

        alpha = sylCount / wordCount;
        beta = wordCount / sentCount;
        index = (alpha * 11.8) - (beta * 0.39) - 15.59;
        return index;
    }
}

