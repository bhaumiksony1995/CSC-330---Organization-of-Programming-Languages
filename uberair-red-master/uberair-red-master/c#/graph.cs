using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UberAirRed
{
	public partial class graph 
	{
		// const int maxDist is 3000 miles.

		// Using the day's list of locations (locList), a list whose indexes
		// contain a list of locations will be constructed. Within the inner list,
		// location objects holding the start and end cities and the distance between
		// them will be stored--only if the start and end cities are unique and the
		// distance is less than or equal to the max distance that can be flown in one 
		// trip (3000 miles).
		public List<List<Location> > createGraph( List<Location> locList, int maxDist )
		{
			// A low memory alternative to the adjacency matrix
			List<List<Location> > graph = new List<List<Location> >();

			// For each location available in the daily itinerary...
			foreach( Location start in locList )
			{
				double dist;

				// Create a list to specify the locations whose destination is not
				// the start and whose destination is within the maximum distance
				// that can be travelled in one trip.
				List<Location> pathList = new List<Location>();
			
				// For each location available in the daily itinerary...
				foreach( Location end in locList )
				{
					// Calculate the distance between the start and end locations
					dist = UberAirRed.flightplanner.DistanceEquation( start, end );

					// If the start and end locations are not the same location,
					// and if the distance between two unique locations is within
					// the maximum distance that can be travelled in one trip...
					if( (dist != 0) && (dist <= maxDist) )
					{
						// Create a new location object that holds the start city,
						// the end city, and the distance between them to the path
						// list specific to the start node
						Location l = new Location();
						l.setId( start.getId() );
						l.setCity( start.getCity() );
						l.setDestination( end.getCity() );
						l.setDistance( dist );
						pathList.Add( l );
					}
				}

				graph.Add(pathList);
			}

			return graph;

			// Despite initial thoughts, the flight restraint is 3000 miles before refueling,
			// thus it is not necessary to calculate the fuel for the graph--just the distance.
			// This constant is sent to the graph creation method so as to easily change the
			// flight restrictions for different models/planes/etc.
		}


	}
}
