// CSC 330 - Group Project: Flight Planner
// Date: 12-8-2017
// Uber Air - Red Team Members: Caleb Holt, Andrew McBryde, Hannah Gulle, Bhaumik Sony, Jay Hinson, & Vincent Raymond
// ------------------------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.IO;

namespace UberAirRed{
	public partial class flightplanner
	{
		/*    static public void Main(string[] args)
		      {
		      string url = "http://theochem.mercer.edu/csc330/data/zip_codes_states.csv";
		//string url = "http://theochem.mercer.edu/csc330/data/airports.csv";
		int lineCount = 0;
		double[] lats = new double[52336]; // latitude array
		double[] longs = new double[52336]; // longitude array

		// distance and the 4 parameters (alpha1, alpha2, beta1, beta2)
		double distance = 0.0, alpha1 = 0.0, alpha2 = 0.0, beta1 = 0.0, beta2 = 0.0;

		processWebFile(url, ref lineCount, ref lats, ref longs);

		// Assign values for the 4 parameters   
		//alpha1 = lats[1];
		//beta1 = longs[1];
		//alpha2 = lats[9]; 
		//beta2 = longs[9];

		// Geographic Coordinates (in degrees)
		alpha1 = 42.1014800;
		beta1 = -72.5898100;
		alpha2 = 40.8153800;
		beta2 = -73.0451100;

		// Calculating the distnace using the Haversine equation w/ the four parameters
		distance = DistanceEquation(ref alpha1, ref beta1, ref alpha2, ref beta2);

		// Display distance to screen
		Console.WriteLine("The distance is: {0:F0} miles", distance);

		}*/
		static public void processWebFile(string url, ref int lineCount, ref double[] lats, ref double[] longs)
		{
			double latitude = 0.0, longitude = 0.0;
			int index = 0;
			try
			{
				WebClient client = new WebClient();
				client.DownloadFile(url,"zip_codes_states.csv");
				// client.DownloadFile(url,"airports.csv");
				string[] lines = File.ReadAllLines("zip_codes_states.csv");
				//string[] lines = File.ReadAllLines("airports.csv");
				foreach (string line in lines)
				{
					string[] substrings = line.Split(',');
					// Console.WriteLine(substrings[1] + " " + substrings[2]);        

					Double.TryParse(substrings[1], out latitude);
					Double.TryParse(substrings[2], out longitude);
					//Double.Parse(substrings[2]);
					lats[index] = latitude;
					longs[index] = longitude;

					//  Console.WriteLine(lats[index] + "  " + longs[index]);
					index++;
					lineCount++;
				} 

			}
			catch(WebException ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("WEB URL NOT FOUND.");
			}

		}

		static public double DistanceEquation(Location start, Location end)
		{
			double alpha1, beta1, alpha2, beta2;
			
			alpha1 = start.getLat();
			beta1 = start.getLong();
			alpha2 = end.getLat();
			beta2 = end.getLong();
			
			double tempDistance = 0.0, deltaLat = 0.0, deltaLon = 0.0, R = 0.0;
			// Convert to radians
			alpha1 = alpha1 * (Math.PI/ 180.0);  
			alpha2 = alpha2 * (Math.PI/ 180.0);  
			beta1 = beta1 * (Math.PI/ 180.0);  
			beta2 = beta2 * (Math.PI/ 180.0);  

			// Computing the delta's in latitude & longitude
			deltaLat = alpha2 - alpha1;
			deltaLon = beta2 - beta2;

			deltaLat /= 2.0;
			deltaLon /= 2.0;

			// The equatorial radius of Earth
			R = 6373.0 / 1.609;

			// Calculating distance
			tempDistance = 2.0 * R * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(deltaLat), 2.0) + (Math.Cos(alpha1) * Math.Cos(alpha2) * Math.Pow(Math.Sin(deltaLon),2.0)) ));

			return tempDistance;

		}

	}} 
