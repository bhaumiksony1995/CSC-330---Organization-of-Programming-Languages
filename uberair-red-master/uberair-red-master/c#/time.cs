using System;
//Time Standard Class: Jay Hinson
namespace UberAirRed
{
    //Time Standard Class: Jay Hinson
    public partial class time
    {
        public double calculateTime(double distance, double speed) //Calculates time in hrs
        {
            return distance/speed;
        }

        //Calculates the Time of Arrival
        static public void updateTime(Location start, Location end, ref int hours, ref int minutes)
        {

            string originCity = start.getCity; //Variables to hold input
            string originState = start.getState;
            string destinationCity = end.getCity;
            string destinationState = end.getState;
            double speed = 515;
            double distance = UberAirRed.flightplanner.DistanceEquation(start, end);
            double t = calculateTime(distance, speed);

            int a = 0; //Local Variables to get Hours(a) and Minutes(b)
            int b = 0;

            for(int i=1; i<t; i++)
            {
                a++;
            } 

            b = Convert.ToInt32((t-a)*60);

            //Console.WriteLine("A: "+a+" B: "+b);

            for(int j=0; j<a; j++)   //Updates Hours
            {
                hours++;
            }

            for(int k=0; k<b; k++)   //Updates Minutes
            {
                minutes++;
            } 

            //Checks to see if plane is changing Time Zones
            if((easternTime(originState) && centralTime(destinationState)) ||
                    (easternTime(originState) && String.ReferenceEquals(destinationCity, "Memphis")))
            {
                hours--;
            }

            if((centralTime(originState) && easternTime(destinationState)) ||
                    (centralTime(originState) && String.ReferenceEquals(destinationCity, "Johnson City")))
            {
                hours++;
            }

            //Changes to the next hour if minutes goes over 59
            if(minutes > 59)
            {
                minutes = minutes-60;
                hours++;
            }

            //So Hours aren't in Military Time
            if(hours > 12)
            {
                hours = hours-12;
            }

            //Console.WriteLine("Hours: "+hours+" Minutes: "+minutes);
        }

        static public bool easternTime(string state) //States in Eastern Time Zone
        {
            if(String.ReferenceEquals(state, "GA") || String.ReferenceEquals(state, "FL")
                    || String.ReferenceEquals(state, "SC") || String.ReferenceEquals(state, "NC")
                    || String.ReferenceEquals(state, "TN"))
            {
                return true;
            }
            else
                return false;
        }

        static public bool centralTime(string state) //States in Central Time Zone
        {
            if(String.ReferenceEquals(state, "AL") || String.ReferenceEquals(state, "MS")
                    || String.ReferenceEquals(state, "AR") || String.ReferenceEquals(state, "TN"))
            {
                return true;
            }
            else
                return false;
        }

        static public void printTime(int hours, int minutes) //Prints time in correct order
        {
            if(hours < 10 && minutes < 10)
            {
                Console.WriteLine("ETA: 0"+hours+":0"+minutes);
            }
            else if(hours < 10 && minutes >= 10)
            {
                Console.WriteLine("ETA: 0"+hours+":"+minutes);
            }
            else if(minutes < 10 && hours >= 10)
            {
                Console.WriteLine("ETA: "+hours+":0"+minutes);
            }
            else
                Console.WriteLine("ETA: "+hours+":"+minutes);
        }

        static public void Main()
        {
            string originCity; //Variables to hold input
            string originState;
            string destinationCity;
            string destinationState;
            string currentTime;
            int hours;
            int minutes;
            double speed = 515;
            double distance;

            time TimeStandard = new time();
            flightplanner FP = new flightplanner();
            Location gps = new Location();

            Console.WriteLine("Which City are you leaving from?");
            originCity = Console.ReadLine();

            Console.WriteLine("Which State is this City in? (Ex: GA)");
            originState = Console.ReadLine();

            Console.WriteLine("Which City are you going to?");
            destinationCity = Console.ReadLine();

            Console.WriteLine("Which State is this City in? (Ex: TN)");
            destinationState = Console.ReadLine();

            string lat1 = gps.getLatfromCity(@"""originCity""");
            string long1 = gps.getLongfromCity(@"""originCity""");
            string lat2 = gps.getLatfromCity(@"""destinationCity""");
            string long2 = gps.getLongfromCity(@"""destinationCity""");
            distance = FP.DistanceEquation(Convert.ToDouble(lat1), Convert.ToDouble(long1), Convert.ToDouble(lat2), Convert.ToDouble(long2));

            //Console.WriteLine("What is the time of the Flight? (hrs:min)");
            //Console.WriteLine("(If before 10am or after 12pm, put a '0' infront of the hour)");
            //currentTime = Console.ReadLine(); //Gets input as string and converts to ints
            hours = 6;
            minutes = 0;

            double t = TimeStandard.calculateTime(distance,speed); //time if flight in hrs is stored in t 
            updateTime(t,originState,destinationState,destinationCity,ref hours,ref minutes); //Updates hours and minutes

            Console.WriteLine(originCity+", "+originState+" to "+destinationCity+", "+destinationState);
            printTime(hours, minutes);
        }
    }
}
