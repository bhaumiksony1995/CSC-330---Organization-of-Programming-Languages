using System;

// C# checked on 10/28/17

class CSDiffusionPart
{
    public static void Main(String[] args)
    {
        Console.Write("Input cube size:  ");
        int maxsize = Convert.ToInt32(Console.ReadLine());
        Console.Write("Do you want to add a partition? (Y/N) ");
        string part = Console.ReadLine();
        int partsize = maxsize / 2;
        
        double[,,]cube = new double[maxsize,maxsize,maxsize];
        
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
        
        if (part == "Y" || part == "y")
        {
            for (int i = 0; i < maxsize; i++)
            {
                for (int j = 0; j < maxsize; j++)
                {
                    for (int k = 0; k < maxsize; k++)
                    {
                        if ((i == partsize - 1) && (j >= partsize - 1))
                        {
                            cube[i,j,k] = -1.0;
                        }
                    }
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
        double change = 0.0;

        //initialize first cell
        cube[0,0,0] = 1.0e21;
        double time = 0.0;
        double ratio = 0.0;
        
        do
        {
            for (int i = 0; i < maxsize; i++)
            {
                for (int j = 0; j < maxsize; j++)
                {
                    for (int k = 0; k < maxsize; k++)
                    {
                        if (cube[i,j,k] >= 0)
                        {
                            if (i != 0 && cube[i-1,j,k] != -1)
                            {
                                change = (cube[i,j,k] - cube[i-1,j,k]) * DTerm;
                                cube[i,j,k] = cube[i,j,k] - change;
                                cube[i-1,j,k] = cube[i-1,j,k] + change;
                            }
                            if (i != (maxsize - 1) && cube[i+1,j,k] != -1)
                            {
                                change = (cube[i,j,k] - cube[i+1,j,k]) * DTerm;
                                cube[i,j,k] = cube[i,j,k] - change;
                                cube[i+1,j,k] = cube[i+1,j,k] + change;
                            }
                            if (j != 0 && cube[i,j-1,k] != -1)
                            {
                                change = (cube[i,j,k] - cube[i,j-1,k]) * DTerm;
                                cube[i,j,k] = cube[i,j,k] - change;
                                cube[i,j-1,k] = (cube[i,j-1,k]) + change;
                            }
                            if (j != (maxsize - 1) && cube[i,j+1,k] != -1)
                            {
                                change = (cube[i,j,k] - cube[i,j+1,k]) * DTerm;
                                cube[i,j,k] = cube[i,j,k] - change;
                                cube[i,j+1,k] = cube[i,j+1,k] + change;
                            }
                            if (k != 0 && cube[i,j,k-1] != -1)
                            {
                                change = (cube[i,j,k] - cube[i,j,k-1]) * DTerm;
                                cube[i,j,k] = cube[i,j,k] - change;
                                cube[i,j,(k-1)] = cube[i,j,k-1] + change;
                            }
                            if (k != (maxsize - 1) && cube[i,j,k+1] != -1)
                            {
                                change = (cube[i,j,k] - cube[i,j,k+1]) * DTerm;
                                cube[i,j,k] = cube[i,j,k] - change;
                                cube[i,j,k+1] = cube[i,j,k+1] + change;
                            }
                        }   
                    }
                }
            }

            time = time + timestep;

            sumval = 0.0;
            double maxval = cube[0,0,0];
            double minval = cube[0,0,0];
           
            for (int i = 0; i < maxsize; i++)
            {
                for (int j = 0; j < maxsize; j++)
                {
                    for (int k = 0; k < maxsize; k++)
                    {
                        if (cube[i,j,k] != -1)
                        {
                            maxval = Math.Max(cube[i,j,k], maxval);
                            minval = Math.Min(cube[i,j,k], minval);
                            sumval += cube[i,j,k];
                        }
                    }
                }
            }
            
            ratio = minval / maxval;

            Console.Write("Time = {0}   Ratio = {1}    Cube = {2}", time, ratio, cube[0,0,0]);
            Console.Write("     CubeMax =  {0}", cube[maxsize-1,maxsize-1,maxsize-1]);
            Console.WriteLine("     Sumval =  {0}", sumval);
        }while (ratio < 0.99);

        Console.WriteLine("Check for mass consistency (should be 1e21): {0}", sumval);
        Console.WriteLine("Box equalibrated in {0} seconds of simulation time.", time);
    }
}
