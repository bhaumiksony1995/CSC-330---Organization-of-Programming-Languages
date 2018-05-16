using System;

public class Runway
{
    public bool isOpen;
    private string type;
    private int length;

    public Runway(isOpen, type, length)
    {
        this.isOpen = isOpen;
        this.type = type;
        this.length = length;
    }

    public Runway(type, length) //Defaults to open
    {
        this.isOpen = true;
        this.type=type;
        this.length=length;
    }

    public Runway(length)       //Defaults to open and CONC
    {
        this.isOpen = true;
        this.type = "CONC";
    }

    

    
}
