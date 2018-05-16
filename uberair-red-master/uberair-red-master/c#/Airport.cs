using System;
using System.Collections.Generic;

public class Airport : Location     //Location contains coordinates
{
	//private int id;
	private bool isOpen;
	private List<Runway> runways; //Contains type and length properties and if the runway is open   

	public Airport(bool isOpen)  //Constructor 
	{
		this.isOpen = isOpen;
	}

	public Airport(int id, int zipcode, double latitude, double longitude, string city, string state, string country) : base(id, zipcode, latitude, longitude, city, state, country)   //Constructor that assumes airport is open
	{
		//this.id = id;
		this.isOpen = true;
	}

	public bool hasOpenRunway()     //Itterates over each runway and checks if its open
	{   
		foreach(Runway element in runways)
		{
			if(element.isOpen)
			{
				return true;
			}
		}

		return false;
	}

	public void addRunway(Runway run){

		runways.Add(run);

	}
/*
	public int getId(){
		return this.id;
	}
*/
	public bool getOpen(){
		return this.isOpen;
	}

}
