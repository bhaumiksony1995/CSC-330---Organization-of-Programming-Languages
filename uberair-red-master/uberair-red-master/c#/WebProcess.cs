using System.Net;
using System;
using System.IO;
public class webprocess
{
	static public void Main(string[] args)
	{
		if (args.Length == 0)
			Console.WriteLine("No command line args.\n");
		else
			Console.WriteLine("The number of command line args: " + args.Length + "\n");

		string url = "http://theochem.mercer.edu/csc330/data/airports.csv";
		string url1 = "http://theochem.mercer.edu/csc330/data/zip_codes_states.csv";
		string url2 =  "http://theochem.mercer.edu/csc330/data/runways.csv";
		string url3 =  "http://theochem.mercer.edu/csc330/data/cityzipcodes.csv";
		int lineCount = 0;
		
		processWebFile(url, ref lineCount, "airports.csv");

		processWebFile(url1, ref lineCount, "zip_codes_states.csv");

		processWebFile(url2, ref lineCount, "runways.csv");

		processWebFile(url3, ref lineCount, "cityzipcodes.csv");

		Console.WriteLine("The number of lines: " + lineCount); 
	}

	static public void processWebFile(string url, ref int lineCount, string filename)
	{
		try
		{
			WebClient client = new WebClient();                 // Constructing WebClient object
			// client.DownloadFile(url,"airports.csv");          // Downloads file airports.csv
			client.DownloadFile(url,filename);    // Downloads file zip_codes_states.csv

			// Read each line of the file into a string array called lines.
			// Each element of the array is one line of the file "airports.csv"  

			//string[] lines = File.ReadAllLines("airports.csv");        // System.IO.File.ReadAllLines 
			string[] lines = File.ReadAllLines(filename);  // System.IO.File.ReadAllLines 

			foreach (string line in lines) // for each loop in C#
			{
				//Console.WriteLine(line);
				lineCount++;
			} 
		}
		catch (WebException ex)
		{
			// handle the exception error.
			Console.WriteLine(ex.Message);
			Console.WriteLine("WEB URL NOT FOUND.");
		}

	}
}
