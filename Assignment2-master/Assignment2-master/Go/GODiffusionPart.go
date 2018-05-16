package main
import ("fmt"
        "math")

func main() {
    const maxsize int = 10; //change this variable to change cube size
    var partsize = maxsize / 2;
    var part = 'N'; //Change this to 'Y' or 'y' to add partition

    cube := make([][][]float64,maxsize)

    for i := 0; i < maxsize; i++ {
        cube[i] = make([][] float64, maxsize)
        for j := 0; j < maxsize; j++ {
            cube[i][j] = make([] float64,maxsize)
            for k := 0; k < maxsize; k++ {
                cube[i][j][k] = 0.0;
            }
        }
    }
    
    if((part == 'Y') || (part == 'y')) {
        for i := 0; i < maxsize; i++ {
            for j := 0; j < maxsize; j++ {
                for k := 0; k < maxsize; k++ {
                    if ((i == partsize - 1) && (j >= partsize - 1)) {
                        cube[i][j][k] = -1.0
                    }
                }
            }
        }
    }

    var diffusion_coefficient float64 = 0.175;
    var room_dimension float64 = 5.0;
    var speed_of_gas_molecules float64 = 250.0;
    var timestep float64 = (room_dimension / speed_of_gas_molecules) / 10;
    var distance_between_blocks float64 = (room_dimension / 10);
    var DTerm float64 = diffusion_coefficient * timestep / (distance_between_blocks * distance_between_blocks);
    var sum float64;
    var change float64;

    cube[0][0][0] = 1e21
    var ratio float64 = 0.0;
    var time float64 = 0.0;
    
    for ratio < 0.99 {
        for i := 0; i < maxsize; i++ {   
            for j := 0; j < maxsize; j++ {   
                for k := 0; k < maxsize; k++ {
                    if (cube[i][j][k] >= 0) {
                        if (i != 0 && cube[i-1][j][k] >= 0) {
                            change = (cube[i][j][k] - cube[i-1][j][k]) * DTerm;
                            cube[i][j][k] = cube[i][j][k] - change;
                            cube[i-1][j][k] = cube[i-1][j][k] + change;
                        }
                        if (i != (maxsize -1)  && cube[i+1][j][k] >= 0) {
                            change = (cube[i][j][k] - cube[i+1][j][k]) * DTerm;
                            cube[i][j][k] = cube[i][j][k] - change;
                            cube[i+1][j][k] = cube[i+1][j][k] + change;
                        }   
                        if (j != 0 && cube[i][j-1][k] >= 0) {
                            change = (cube[i][j][k] - cube[i][j-1][k]) * DTerm;
                            cube[i][j][k] = cube[i][j][k] - change;
                            cube[i][j-1][k] = cube[i][j-1][k] + change;
                        }
                        if (j != (maxsize -1)  && cube[i][j+1][k] >= 0) {
                            change = (cube[i][j][k] - cube[i][j+1][k]) * DTerm;
                            cube[i][j][k] = cube[i][j][k] - change
                            cube[i][j+1][k] = cube[i][j+1][k] + change;
                        }
                        if (k != 0 && cube[i][j][k-1] >= 0) {
                            change = (cube[i][j][k] - cube[i][j][k-1]) * DTerm;
                            cube[i][j][k] = cube[i][j][k] - change;
                            cube[i][j][k-1] = cube[i][j][k-1] + change;
                        }
                        if (k != (maxsize -1)  && cube[i][j][k+1] >= 0) {
                            change = (cube[i][j][k] - cube[i][j][k+1]) * DTerm;
                            cube[i][j][k] = cube[i][j][k] - change;
                            cube[i][j][k+1] = cube[i][j][k+1] + change;
                        }
                    }   
                }    
            }
        }   

        time = time + timestep;
        sum = 0.0;
        var maxval float64 = cube[0][0][0];
        var minval float64 = cube[0][0][0];


        for i := 0; i < maxsize; i++ {
            for j := 0; j < maxsize; j++ {
                for k := 0; k < maxsize; k++ {
                    if (cube[i][j][k] >= 0) {
                        maxval = math.Max(cube[i][j][k], maxval);
                        minval = math.Min(cube[i][j][k], minval);
                        sum = sum + cube[i][j][k];
                    }
                }
            }
        }

        ratio = minval / maxval;

        //uncomment these to see print statments after each interation in the loop
        //fmt.Print("Time = ", time, "\tRatio = ", ratio, "\tCube = ", cube[0][0][0]);
        //fmt.Println("\tCubemax = ", cube[maxsize-1][maxsize-1][maxsize-1]);
        //fmt.Println("Sum = ", sum);
    }

    fmt.Println("Check for mass consistency: ", sum);
    fmt.Println("Box equalibrated in ", time , "  seconds of simulation time.");
}
