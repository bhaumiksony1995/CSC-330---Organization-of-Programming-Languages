using System;

public class Runway
{
	private int id;
	public bool isOpen;
	private bool isLit;
	private string type;
	private int length;

	public Runway(int id, bool isOpen, bool isLit, string type, int length)
	{
		this.id = id;
		this.isOpen = isOpen;
		this.isOpen = isLit;
		this.type = type;
		this.length = length;
	}

	public Runway(bool isOpen, string type, int length)
	{
		this.isOpen = isOpen;
		this.isOpen = true;
		this.type = type;
		this.length = length;
	}

	public Runway(string type, int length) //Defaults to open
	{
		this.isOpen = true;
		this.isLit = true;
		this.type=type;
		this.length=length;
	}

	public Runway(int length)       //Defaults to open and CONC
	{
		this.isOpen = true;
		this.isLit = true;
		this.type = "CONC";
	}


	public int getId(){
		return this.id;
	}

	public bool getOpen(){
		return this.isOpen;
	}

	public bool getLit(){
		return this.isLit;
	}

	public string getType(){
		return this.type;
	}

	public int getLength(){
		return this.length;
	}

}
