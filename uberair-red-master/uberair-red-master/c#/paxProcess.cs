// The "paxProcess" partial class handles all CSV and keyboard input that 
// relates passenger information to the necessary data structures. For this 
// program, both options are available and are outlined in this file.
// Private integer "paxCount" denotes the initial number of passengers. This 
// may vary in actuality for passengers that could not be accomodated at this
// time.
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public partial class paxProcess{
    
    // Total Number of passengers in the initial file or keyboard input
    private int paxCount = 0;
    
    // If no Passenger Input CSV File is Given At Compile Time, then
    // User Input will be taken from the keyboard one passenger at
    // a time.
    static public List<Passenger> userInputProcesser(List<Location> locList)
    {
    	// Initial Passenger Info Request
    	Console.WriteLine("Input the following passenger information:");
    	string addPax = "Y";
    	
    	// List of all accomodated passengers
        List<Passenger> paxList = new List<Passenger>();
        
        // List of all unaccommodated passengers
        List<Passenger> unaccomodated = new List<Passenger>(); 
        
        // Passenger information per comma separation in separate indices of
        // the "paxInfo" array (strings)
    	string[] paxInfo = new string[6];
    	
    	// While the user gives consent to retrieve additional passenger
    	// information from the keyboard, read the passenger info into a
    	// passenger object.
    	while (addPax == "Y")
    	{
    	    // New Passenger object with each consented retrieval
    		Passenger pax;
    
    		Console.Write("First Name: ");
    		paxInfo[0] = Console.ReadLine();
    
    		Console.Write("\nLast Name: ");
    		paxInfo[1] = Console.ReadLine();
    
    		Console.Write("\nOrigin City: ");
    		paxInfo[2] = Console.ReadLine();
    
    		Console.Write("\nOrigin State: ");
    		paxInfo[3] = Console.ReadLine();
    		
    		while ( paxInfo[3].length() != 2)
    		{
    		    Console.WriteLine("Invalid 2 Letter State Acronym. Try Again.");
    		    paxInfo[3] = Console.ReadLine();
    		}
    
    		Console.Write("\nDestination City: ");
    		paxInfo[4] = Console.ReadLine();
    
    		Console.Write("\nDestination State: ");
    		paxInfo[5] = Console.ReadLine();
    
            while ( paxInfo[5].length() != 2)
    		{
    		    Console.WriteLine("Invalid 2 Letter State Acronym. Try Again.");
    		    paxInfo[5] = Console.ReadLine();
    		}
    
            // Check for passenger accomodation and fill the appropriate lists
            // with the retrieved passenger object in comparison to the day's
            // valid locations
            checkAccom(paxInfo, paxList, unaccomodated, locList);
    
            // Retrieve consent to input additional passengers from the 
            // keyboard. Continue to ask until a valid input is given (Y/N).
    		do
    		{
    			Console.Write("\nInput Additional Passengers? Y/N");
    			addPax = Console.ReadLine();
    		}
    		while ( (addPax != "Y") && (addPax != "N") );
   	} 
    	
    	
    	// Apologize to Unaccommodated Guests to the Screen
    	Console.WriteLine("We deeply regret to inform you that Telfair cannot accomodate the following guests:");
    	for ( int i = 0; i < unaccommodated.size(); i++)
    	{
    		Console.WriteLine(unaccommodated[i].Name);
    	}
    }
    
    static public List<Passenger> csvPaxProcesser(string filePath, List<Location> locations)
    {
    	// CSV Order: first name, last name, origin city, origin state,
    	// destination city, destination state
    	string line;
    	
    	// List of initial passenger inputs from the csv as passenger objects
        List<Passenger> paxList = new List<Passenger>();
        // List of unaccomodated passengers
        List<Passenger> unaccomodated = new List<Passenger>();
    
    	// Input each passenger value as a string in array "paxInfo"
    	string[] paxInfo = new string[6];
    	int counter = 1;	// Used for Line Error/Exception Output
    
    	// Retrieve and Parse each line of Passenger Information from the CSV
    	System.IO.StreamReader infile = new System.IO.StreamReader(@filePath);
    	while( (line = infile.ReadLine()) != null)
    	{
    		Passenger pax;
    		// Parse Information
    		try
    		{
    			for(int i = 0; i < 6; i++)
    			{
    				paxInfo[i] = line.substring(0, line.indexOf(',')+1).trim();
    				
    				// Ensure ALL Fields are Filled
    				if ( paxInfo[i].length() == 0 )
    				{
    					Console.WriteLine("All Fields Must be Filled; Line " + counter + "!");
    					// XXX: Unsure what exit code should go here
    					Environment.Exit(1);
    				}
    			}
    		}
    		catch (ArgumentOutOfRangeException ex)
    		{
    			Console.WriteLine("Invalid Line; Must be Comma Separated; at Line: " + counter + "!");
    		}
    
    		// Check for State Acronym Anomolies
    		// All State Acronymns Should be Exactly 2 Letters
    		if ( (originState.length() != 2) || (destState.length() != 2))
    		{
    			Console.WriteLine("Invalid 2 Letter State Acronym at Line " + counter + "!");
    			// XXX: Unsure what exit code should go here
    			Environment.Exit(1);
    		}
    
    		checkAccom(paxInfo, paxList, unaccomodated, locList);

    
    		counter++;
    	}
    
    	// Apologize to Unaccommodated Guests to the Screen
    	Console.WriteLine("We deeply regret to inform you that Telfair cannot accomodate the following guests:");
    	for ( int i = 0; i < unaccommodated.size(); i++)
    	{
    		Console.WriteLine(unaccommodated[i].Name);
    	}
    	return paxList;
}

    static public void checkAccom(string[] paxInfo, List<Passenger> paxList, List<Passenger> unaccomodated, List<Location> locList)
    {
        int unaccom = 0;
		for(int j = 0; j < locations.size(); j++)
    	{
    	       // If the passenger's origin and destination are in the day's
    	       // flight schedule, the passenger is to be added to the 
    	       // approved passenger list.
    		if ( (locations[j].state == paxInfo[3]) && (locations[j].state == paxInfo[5]) &&
    			(locations[j].city == paxInfo[2]) && (locations[j].city == paxInfo[4]))
    		    {
    				paxList.add(new Passenger(paxInfo[0], paxInfo[1], paxInfo[2], paxInfo[3], paxInfo[4], paxInfo[5]));
    			}
    		// Otherwise, this passenger cannot be accomodated. :(
    		else
    		{
    		    unaccomodated.add(new Passenger(paxInfo[0], paxInfo[1], paxInfo[2], paxInfo[3], paxInfo[4], paxInfo[5]));
    		}
    	}
    }
}
