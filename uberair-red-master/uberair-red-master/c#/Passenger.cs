using System;


namespace UberAirRed{
	public partial class Passenger
    {
	    private Location origin;
	    private Location destination;
        private double payment; 
		public Passenger(Location origin, Location destination)
		{
			this.origin = origin;
			this.destination = destination;
			this.payment = calcPayment();
		}

		private double calcPayment()
		{

			double dist = UberAirRed.flightplanner.DistanceEquation(this.origin,this.destination);

			double cost = dist*1.25;

			return cost;

		}

		public Location getOrigin()
		{
			return this.origin;
		}

		public Location getDestination()
		{
			return destination;
		}
	}
}
