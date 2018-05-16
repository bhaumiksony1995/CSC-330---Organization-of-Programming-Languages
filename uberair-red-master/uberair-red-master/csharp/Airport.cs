using System;

public class Airport : Location     //Location contains coordinates
{
    private bool isOpen;
    private Runway [] runways; //Contains type and length properties and if the runway is open   

    public Airport(bool isOpen, Runway [] runways)
    {
        this.isOpen = isOpen;
        this.runway = runways;
    }

    public Airport(Runway [] runways)
    {
        this.isOpen = true;
        this.runways = runways;
    }

    public bool hasOpenRunway()
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

}
