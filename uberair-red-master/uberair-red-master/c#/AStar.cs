using System;
using System.Collections;

static public Location AStar(Location origin, Graph input)
{
    int distance = 0;
    Location closest;

    //Itterate over each List in the graoh to find the right one for the origin city
    foreach(List<Location> node in graph)
    {
        //Since all locations in a given node have the same city we only need to test the first
        if(origin.getCity() == node[0].getCity())
        {
            //Once found itterate over each location and look for the smallest distance
            foreach(Location city in node)
            {
                if(city.getDistance() < distance)
                {
                    distance = city.getDistance();
                    closest = city;
                }
            } 

            break;
        }
    }
    return closest;
}
