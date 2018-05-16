#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <string.h>
//
// C Code checked on 10/25/17

int main(int argc, char *argv[])
{
    const int maxsize;
    string part;
    printf("Input cube size\t");
    scanf ("%d", $maxsize);
    double* cube = malloc(maxsize*maxsize*maxsize*sizeof(double));

    printf("Would you like to add a partition? (Y/N)");
    scanf("%s", part);
    int partsize = (maxsize / 2);

    for (int i = 0; i < maxsize; i++)
    {
        for (int j = 0; j < maxsize; j++)
        {
            for (int k = 0; k < maxsize; k++)
            {
                *(cube+i*maxsize*maxsize+j*maxsize+k) = i*maxsize*maxsize+j*maxsize+k+1.0;
            }
        }
    }

    for (int i = 0; i < maxsize; i++)
    {
        for (int j = 0; j < maxsize; j++)
        {
            for (int k = 0; k < maxsize; k++)
            {
                *(cube+i*maxsize*maxsize+j*maxsize+k) = 0.0;
            }
        }
    }

    if (part == 'Y' || part == 'y')
    {
        for (int i = 0; i < maxsize; i++)
        {
            for (int j = 0; j < maxsize; j++)
            {
                for (int k = 0; k < maxsize; k++)
                {
                    if ((i == partsize - 1) && (j >= partsize - 1))
                    {
                        *(cube+i*maxsize*maxsize+j*maxsize+k) = -1.0;
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

    //initialize first cell
    *(cube+0*0*0) = 1.0e21;
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
                                    double difference = *(cube+i*maxsize*maxsize+j*maxsize+k) - *(cube+l*maxsize*maxsize+m*maxsize+n); 
                                    double change = difference * DTerm;
                                    *(cube+i*maxsize*maxsize+j*maxsize+k) = *(cube+i*maxsize*maxsize+j*maxsize+k) - change;
                                    *(cube+l*maxsize*maxsize+m*maxsize+n) = *(cube+l*maxsize*maxsize+m*maxsize+n) + change; 
                                }
                            }
                        }
                    }
                }
            }
        }

        time = time + timestep;

        //Check for mass consistency
        //double sumval = 0.0;
        double maxval = *(cube+0*0*0);
        double minval = *(cube+0*0*0);
        for (int i = 0; i < maxsize; i++)
        {
            for (int j = 0; j < maxsize; j++)
            {
                for (int k = 0; k < maxsize; k++)
                {
                   maxval = fmax(*(cube+i*maxsize*maxsize+j*maxsize+k), maxval);
                   minval = fmin(*(cube+i*maxsize*maxsize+j*maxsize+k), minval);
                   sumval += *(cube+i*maxsize*maxsize+j*maxsize+k);
                }
            }
        }
        ratio = minval / maxval;

        //printf("Time = %f   Ratio = %f  Cube = %f ", time, ratio, *(cube+0*0*0));
        //printf("    CubeMax =  %f",*(cube+maxsize*maxsize*maxsize-1));
        //printf("    Sumval =  %f\n", sumval);
        }while (ratio < 0.99);

    printf("Check for mass consistency: ", sumval);
    printf("Box equalibrated in %f seconds of simulation time.\n", time);
    free(cube);
}   

