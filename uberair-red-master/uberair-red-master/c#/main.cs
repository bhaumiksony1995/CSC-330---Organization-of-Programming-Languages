using System;
using System.IO;
using System.Collections.Generic;
//using namespace UberAirRed;
namespace UberAirRed
{
	public class main
	{
		static public void Main(string[] args)
		{
			// Static Class Instances
				graph g = new graph();

			// Object and Object List Instances
				List<Location> locList = new List<Location>();
			//	List<Passenger> paxList = new List<Passenger>();
				//Learjet plane = new Learjet();			

			List<Passenger> inputPass = new List<Passenger>();

			//test passengers
			//plane.setNewPassenger(new Passenger());

			// Number of Command Line Arguments determines whether
			// passengers are input by CSV file or keyboard input.
			// Unaccommodated passengers are outputted during either
			// function call.
			if ( args.Length != 0 )
			{
				// Command Line Process Function Call
			}
			else
			{
				// Keyboard Input Process Function Call
			}
			
			List<double> lats = new List<double>();
			List<Runway> validrw = new List<Runway>();
			//	double latitude = 0.0, longitude = 0.0;
			//	int lineCount = 0;
			int index = 0;

			string [] runwayLines = File.ReadAllLines("runways.csv");

			// Here we construct the list of runways that are valid.
			// This will be used to determine what airports we will be capable of landing at
			// by using the airport id number in runways.csv
			foreach(string line in runwayLines)
			{

				string[] rwstring = line.Split(',');

				int length = 0;
				
				Int32.TryParse(rwstring[3], out length);

				// If the runway is over 3000 ft long and is made of either concrete or turg
				// it is a vaild runway, so it is added to the list
				if(length > 3000)
				{
					if(rwstring[5].ToLower().Contains("turf") || rwstring[5].ToLower().Contains("con"))
					{
						int id = 0;
						Int32.TryParse(rwstring[1], out id);
						Runway test = new Runway(id,true,true,rwstring[5],length);
						validrw.Add(test);
						index = index + 1;
					}
				}

			}

			string[] airportLineInput = File.ReadAllLines("airports.csv");
			List<string> airportLines = new List<string>();

			foreach(string line in airportLineInput)
			{
				string[] apstring = line.Split(',');

				if(apstring[2].ToLower().Contains("heliport"))
				{
					
				}else
				{
					airportLines.Add(line);
				}

				//airportLines.Add(line);
			}

			// Set up the list of locations for the airports to create the graph
			// using the runways to identify valid airports
			foreach(Runway run in validrw)
			{

				for(int i = 0; i < airportLines.Count; i++)
				{

					string[] apstring = airportLines[i].Split(',');

					int id = 0;
					double lat = 0;
					double lng = 0;

					Int32.TryParse(apstring[0], out id);
					Double.TryParse(apstring[4], out lat);
					Double.TryParse(apstring[5], out lng);

					if(run.getId() == id)
					{
						locList.Add(new Airport(id, -1, lat, lng, "none", "none", "none"));
						//Console.WriteLine("success");
						break;
					}

				}

			}


			Console.WriteLine("The number of airports " + locList.Count);

			Console.WriteLine("First airport: " + locList[0].getId() + " Second airport: " + locList[1].getId());

			// Create the List of Location Lists that contain today's 
			// possible destinations for each starting city.
				List<List<Location> > map = g.createGraph( locList, 3000 );	
			
			//generate the plan for the day or run through the planes stops
			//	(different interpertations same outcome)
		
			Console.WriteLine("The number of items in lists " + map.Count);	
            

			Learjet plane = new Learjet(locList[0]);
			plane.setNewPassengers(new Passenger(locList[0], locList[1]));
            plane.setNewPassengers(new Passenger(locList[0], locList[1]));
            plane.setNewPassengers(new Passenger(locList[1], locList[2]));
            plane.setNewPassengers(new Passenger(locList[1], locList[3]));
            plane.setNewPassengers(new Passenger(locList[2], locList[3]));
Console.WriteLine("before adding");            
            inputPass.Add(new Passenger(locList[0], locList[1]));
            inputPass.Add(new Passenger(locList[0], locList[1]));
            inputPass.Add(new Passenger(locList[1], locList[2]));
            inputPass.Add(new Passenger(locList[1], locList[3]));
            inputPass.Add(new Passenger(locList[2], locList[3]));

			List<List <int> > histogram = new List<List <int> >();
Console.WriteLine("Before loops");
			for (int i = 0; i < inputPass.Count; i++)
			{
				if(histogram.Count == 0)
                {
Console.WriteLine("first loop");
    				histogram[i].Add(inputPass[i].getOrigin().getId());
                }

                else if(inputPass[i].getOrigin().getId() == histogram[i][i])
                {
Console.WriteLine("second loop");
                    histogram[i][i] = histogram[i][i] + 1;
                }
			}

			while(plane.getNumPassenger() > 0)
			{
				for(int i = 0; i < inputPass.Count; i++)
                {
					if(inputPass[i].getOrigin().getId() == plane.getLocation().getId())
                    {
						//plane.setNewPassengers();
						inputPass.RemoveAt(i);
					}
				}

				for(int i = 0; i < plane.getNumPassenger(); i++)
				{
					if(plane.getPassenger(i).getDestination().getId() == plane.getLocation().getId())
					{
						plane.removePassenger(i);
					}
				}

			}

		}
	}
}
