#define Default
using System;

// C# checked on 10/28/17

class CSDiffusion
{
    static void Main()
    {
        Console.Write("Input cube size:  ");
        int maxsize = Convert.ToInt32(Console.ReadLine());
        double[, ,] cube = new double[maxsize, maxsize, maxsize];

        for (int i = 0; i < maxsize; i++)
        {
            for (int j = 0; j < maxsize; j++)
            {
                for (int k = 0; k < maxsize; k++)
                {
                    cube[i,j,k] = 0.0;
                }
            }
        }

        double diffusion_coefficient = 0.175;
        double room_dimension = 5.0;
        double speed_of_gas_molecules = 250.0;
        double timestep = (room_dimension / speed_of_gas_molecules) / maxsize; //h in seconds
        double distance_between_blocks = (room_dimension / maxsize);
        double DTerm = diffusion_coefficient * timestep / (distance_between_blocks * distance_between_blocks);
        double sumval = 0.0;

        //initialize first cell
        cube[0,0,0] = 1.0e21;
        double time = 0.0;
        double ratio = 0.0;

        /*do
        {
            for (int i = 0; i < maxsize; i++)
            {
                for (int j = 0; j < maxsize; j++)
                {
                    for (int k = 0; k < maxsize; k++)
                    {
                        for (int l = 0; l < maxsize; l++)
                        {
                            for (int m = 0; m < maxsize; m++)
                            {
                                for (int n = 0; n < maxsize; n++)
                                {
                                    if ( ((i == l) && (j == m) && (k == n+1)) ||
                                        ((i == l) && (j == m) && (k == n-1)) ||
                                        ((i == l) && (j == m+1) && (k == n)) ||
                                        ((i == l) && (j == m-1) && (k == n)) ||
                                        ((i == l +1) && (j == m) & (k == n)) ||
                                        ((i == l-1) && (j == m) && (k == n)) )
                                    {
                                        double change = (cube[i,j,k] - cube[l,m,n]) * DTerm;
                                        cube[i,j,k] = cube[i,j,k] - change;
                                        cube[l,m,n] = cube[l,m,n] + change;
                                }
                            }
                        }
                    }
                }
            }
        }*/



        time = time + timestep;

        double maxval = cube[0,0,0];
        double minval = cube[0,0,0];
        for (int i = 0; i < maxsize; i++)
        {
            for (int j = 0; j < maxsize; j++)
            {
                for (int k = 0; k < maxsize; k++)
                {
                   maxval = Math.Max(cube[i,j,k], maxval);
                   minval = Math.Min(cube[i,j,k], minval);
                   //sumval += cube[i,j,k];
                }
            }
        }
        ratio = minval / maxval;

        //Console.Write("Time = {0}   Ratio = {1}    Cube = {2}", time, ratio, cube[0,0,0]);
        //Console.Write("     CubeMax =  {0}", cube[maxsize-1,maxsize-1,maxsize-1]);
        //Console.WriteLine("     Sumval =  {0}", sumval);
        }while (ratio < 0.99);

        for (int i = 0; i < maxsize; i++)
        {
            for (int j = 0; j < maxsize; j++)
            {
                for (int k = 0; k < maxsize; k++)
                {
                    sumval += cube[i,j,k];
                }
            }    
        }

        Console.WriteLine("Check for mass consistency (should be 1e21): {0}", sumval);
        Console.WriteLine("Box equalibrated in {0} seconds of simulation time.", time);
    }
}
