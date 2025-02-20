import java.util.*;

public class JavaDiffusion
{
    public static void main(String[] args)
    {
        final int maxsize = 10;
        double[][][] cube = new double[maxsize][maxsize][maxsize];

        /* Zero the cube -- Question -- for which languages is this needed? */

        for (int i = 0; i < maxsize; i++)
        {
            for (int j = 0; j < maxsize; j++)
            {
                for (int k = 0; k < maxsize; k++)
                {
                    cube[i][j][k] = 0.0;
                }
            }
        }
        double diffusion_coefficient = 0.175;
        double room_dimension = 5;
        double speed_of_gas_molecules = 250.0;
        double timestep = (room_dimension / speed_of_gas_molecules) / maxsize; // h in seconds
        double distance_between_blocks = room_dimension / maxsize;

        double DTerm = diffusion_coefficient * timestep / (distance_between_blocks * distance_between_blocks);

        //initialize first cell
        cube[0][0][0] = 1.0e21;
        double time = 0.0; // to keep up with accumulated system time
        double ratio = 0.0;

        do
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
                                    if ( ((i == l) && (j == m) && (k == n+1)) || ((i ==l) && (j == m) && (k == n-1)) || ((i == l) && (j == m+1) && (k == n))                                      ||   ((i == l) && (j == m-1) && (k == n)) || ((i == l+1) && (j == m) & (k == n)) || ((i == l-1) && (j == m) && (k == n)) )                                    {
                                        double change = ((cube[i][j][k] - cube[l][m][n]) * DTerm);
                                        cube[i][j][k] = cube[i][j][k] - change;
                                        cube[l][m][n] = cube[l][m][n] + change;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        

            time = time + timestep;

            //Check for mass consistecy
            double sumval = 0.0;
            double maxval = cube[0][0][0];
            double minval = cube[0][0][0];

            for (int i =0; i < maxsize; i++)
            {
                for (int j = 0; j < maxsize; j++)
                {
                    for (int k = 0; k < maxsize; k++)
                    {
                        maxval = Math.max(cube[i][j][k], maxval);
                        minval = Math.min(cube[i][j][k], minval);
                        sumval += cube[i][j][k];
                    }
                }
            }

            ratio = minval / maxval;

            System.out.print("Time = " + time + "  Ratio = " + ratio  + "  Cube = " + cube[0][0][0]);
            System.out.print(" Cubemax =  " + cube[maxsize-1][maxsize-1][maxsize-1]);
            System.out.print(" Sumval = " + sumval + "\n");
        }while (ratio < 0.99);

        System.out.println("Box equalibrated in " + time + " seconds of simulation time.");
    }
}
