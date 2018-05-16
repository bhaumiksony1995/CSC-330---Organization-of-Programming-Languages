using System;
using System.Collections.Generic;

namespace UberAirRed
{

	public partial class Learjet
	{

		//Array to hold passenger objects, These will be the passengers
		//	that will determine the path taken during the day
		List<Passenger> passengers;

		//Distance that can be traveled given max fuel
		double maxFuelDist = 3000;

		Location curLoc;

		//Constructor for a default Learjet object
		public Learjet(Location start)
		{
			this.curLoc = start;
			this.passengers = new List<Passenger>();
			//this.test = 0;
	
		}
	
		//Since we will be running through this simulation on separate
		//	days, we will want to be able to change the set of
		//	passengers for the next day
		public void setNewPassengers(Passenger person)
		{
			this.passengers.Add(person);
		}

		public void removePassenger(int id){
			this.passengers.RemoveAt(id);
		}

		public int getNumPassenger(){
			return this.passengers.Count;
		}	

		public Passenger getPassenger(int locale)
		{
			return this.passengers[locale];
		}

		public void  setLocation(Location inputLoc)
		{
			this.curLoc = inputLoc;
		}

		public Location getLocation()
		{
			return this.curLoc;
		}

		public void setTest(double a)
		{
			this.maxFuelDist = a;
		}

		public double getTest()
		{
			return this.maxFuelDist;
		}
	}
}
