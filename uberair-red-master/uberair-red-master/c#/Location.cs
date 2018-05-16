#define Default
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public partial class Location
{
	private int id;
	private int zipcode;
	private double latitude;
	private double longitude;
	private double distance;		// For Graph Creation
	private string city;
	private string destination;	// For Graph Creation
	private string state;
	private string country;
	
	public Location(int id, int zipcode, double latitude, double longitude, string city, string state, string country){
		this.id = id;
		this.zipcode = zipcode;
		this.latitude = latitude;
		this.longitude = longitude;
		this.city = city;
		this.state = state;
		this.country = country;
		this.destination = null;
		this.distance = -1;
	}

	public Location(){
		this.id = -1;
		this.zipcode = -1;
		this.latitude = -1;
		this.longitude = -1;
		this.city = null;
		this.state = null;
		this.country = null;
		this.destination = null;
		this.distance = -1;
	}

	public int getId(){
		return this.id;
	}

	public double getDistance(){
		return this.distance;
	}

	public string getDestination(){
		return this.destination;
	}

	public void setId(int id){
		this.id = id;
	}

	public void setDestination( string city ){
		this.destination = city;
	}

	public void setDistance( double dist ){
		this.distance = dist;
	}

	public void setZip(int zipcode){
		this.zipcode = zipcode;
	}

	public void setLat(double lat){
		this.latitude = lat;
	}

	public void setLong(double longitude){
		this.longitude = longitude;
	}

	public void setCity(string city){
		this.city = city;
	}

	public void setState(string state){
		this.state = state;
	}

	public void setCountry(string country){
		this.country = country;
	}

	public string getCity(){
		return this.city;
	}

	public double getZip(){
		return this.zipcode;
	}

	public double getLat(){
		return this.latitude;
	}

	public double getLong(){
		return this.longitude;
	}

	public string getState(){
		return this.state;
	}

	public string getCounty(){
		return this.country;
	}

	public int getZipFromLatLong(int latitude, int longitude){
		if( (this.latitude == latitude) && (this.longitude == longitude) ){
			return this.zipcode;
		}
		return -1;
	}

	public int getZipFromCity(string city){
		if( this.city == city ){
			return this.zipcode;
		}
		return -1;
	}

	public string getCityFromLatLong(int latitude, int longitude){
		if( (this.latitude == latitude) && (this.longitude == longitude) ){
			return this.city;
		}
		return null;
	}

	public string getCityFromZip(int zipcode){
		if( this.zipcode == zipcode ){
			return this.city;
		}
		return null; 
	}

	public double getLatFromCity(string city){
		if( this.city == city ){
			return this.latitude;
		}
		return -1;
	}

	public double getLongFromCity(string city){
		if( this.city == city ){
			return this.longitude;
		}
		return -1;
	}

/*
	private static string City;

	   public static void Main () 
	   {   
	   splitCSV();
	   City = Console.ReadLine(); //Put quote around input. Eg. "Atlanta"
	   Console.WriteLine("The city {0} has a Longitude of {1} and a latitude of {2} Latitude", City, getLongfromCity(City), getLatfromCity(City));
	   }

	   public static void splitCSV ()
	   {
	   using(var reader = new StreamReader(@"zip_codes_states.csv"))
	   {
	   while (!reader.EndOfStream)
	   {
	   var line = reader.ReadLine();
	   var values = line.Split(',');
	   listZipCodes.Add(values[0]);
	   listLatitudes.Add(values[1]);
	   listLongitudes.Add(values[2]);
	   listCity.Add(values[3]);
	   listState.Add(values[4]);
	   listCounty.Add(values[5]);
	   }

	   for (int i = 0; i < listZipCodes.Count; i++)
	   {
	   Console.WriteLine("{0}, \t{1}, \t{2}, \t{3}, \t{4}, \t{5}", listZipCodes[i], listLatitudes[i], listLongitudes[i], listCity[i], listState[i], 
	   listCounty[i]);
	   }
	   }
	   }
*/

}
