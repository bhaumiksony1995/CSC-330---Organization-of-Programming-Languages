#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <string.h>
//
// C Code checked on 10/25/17

int main(int argc, char *argv[])
{
    int input; //input read from user
    printf("Input cube size: ");
    int maxsize; //size of each cube
    scanf("%d", &input);
    maxsize =  input;

    double *** cube = malloc(maxsize*sizeof(double**)); //declaration of cube

    for (int i = 0; i < maxsize; i++)
    {
        cube[i] = malloc(maxsize*sizeof(double*));
        for (int j = 0; j < maxsize; j++)
        {
            cube[i][j] = malloc(maxsize*sizeof(double));
        }
    }

    char part[1];

    printf("Would you like to add a partition? (Y/N)? ");
    scanf("%s", &part);

    int partsize = floor(maxsize / 2);
    
    for (int i = 0; i < maxsize; i++) //zero out each cell in cube
    {
        for (int j = 0; j < maxsize; j++)
        {
            for (int k = 0; k < maxsize; k++)
            {
                cube[i][j][k] = 0.0;
            }
        }
    }

    if (part[0]== 'Y' || part[0] == 'y') // If the user sets a partition this sets wherever the parition should be to -1
    {
        for (int i = 0; i < maxsize; i++)
        {
            for (int j = 0; j < maxsize; j++)
            {
                for (int k = 0; k < maxsize; k++)
                {
                    if ((i == partsize - 1) && (j >= partsize - 1))
                    {
                        cube[i][j][k]  = -1.0;
                    }
                }
            }
        }
    }

    double diffusion_coefficient = 0.175;
    double room_dimension = 5.0;
    double speed_of_gas_molecules = 250.0;
    double timestep = (double) (room_dimension / speed_of_gas_molecules) / maxsize; //h in seconds
    double distance_between_blocks = (room_dimension / maxsize);
    double DTerm = diffusion_coefficient * timestep / (distance_between_blocks * distance_between_blocks);
    double sumval = 0.0;
    double change = 0.0;

    //initialize first cell
    cube[0][0][0] = 1e21;
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
                    if (cube[i][j][k] >= 0)
                    {
                        if (i != 0 && cube[i-1][j][k] >= 0)
                        {
                            change = (cube[i][j][k] - cube[i-1][j][k]) * DTerm;
                            cube[i][j][k] = cube[i][j][k] - change;
                            cube[i-1][j][k] = cube[i-1][j][k] + change;
                        }
                        if (i != (maxsize - 1) && cube[i+1][j][k] >= 0)
                        {
                            change = (cube[i][j][k] - cube[i+1][j][k]) * DTerm;
                            cube[i][j][k] = cube[i][j][k] - change;
                            cube[i+1][j][k] = cube[i+1][j][k] + change;
                        }
                        if (j != 0 && cube[i][j-1][k] >= 0)
                        {
                            change = (cube[i][j][k] - cube[i][j-1][k]) * DTerm;
                            cube[i][j][k] = cube[i][j][k] - change;
                            cube[i][j-1][k] = cube[i][j-1][k] + change;
                        }
                        if (j != (maxsize - 1) && cube[i][j+1][k] >= 0)
                        {
                            change = (cube[i][j][k] - cube[i][j+1][k]) * DTerm;
                            cube[i][j][k] = cube[i][j][k] - change;
                            cube[i][j+1][k] = cube[i][j+1][k] + change;
                        }
                        if (k != 0 && cube[i][j][k-1] >= 0)
                        {
                            change = (cube[i][j][k] - cube[i][j][k-1]) * DTerm;
                            cube[i][j][k] = cube[i][j][k] - change;
                            cube[i][j][k-1] = cube[i][j][k-1] + change;
                        }
                        if (k != (maxsize - 1) && cube[i][j][k+1] >= 0)
                        {
                            change = (cube[i][j][k] - cube[i][j][k+1]) * DTerm;
                            cube[i][j][k] = cube[i][j][k] - change;
                            cube[i][j][k+1] = cube[i][j][k+1] + change;
                        }
                    }   
                }
            }
        }
        time = time + timestep;

        //Check for mass consistency
        double sumval = 0.0;
        double maxval = cube[0][0][0];
        double minval = cube[0][0][0];

        for (int i = 0; i < maxsize; i++)
        {
            for (int j = 0; j < maxsize; j++)
            {
                for (int k = 0; k < maxsize; k++)
                {
                    if (cube[i][j][k] >= 0)
                    {
                        maxval = fmax(cube[i][j][k], maxval);
                        minval = fmin(cube[i][j][k], minval);
                        sumval = sumval + cube[i][j][k];
                    }
                }
            }
        }
        ratio = minval / maxval;
        //printf("Time = %f   Ratio = %f  Cube = %f ", time, ratio, cube[0][0][0]);
        //printf("    CubeLast =  %f", cube[maxsize-1][maxsize-1][maxsize-1]);
        //printf("    Sumval =  %f\n", sumval);
    }while (ratio < 0.99);

    printf("Check for mass consistency: ", sumval);
    printf("Box equalibrated in %f seconds of simulation time.\n", time);
    free(cube);
}   
