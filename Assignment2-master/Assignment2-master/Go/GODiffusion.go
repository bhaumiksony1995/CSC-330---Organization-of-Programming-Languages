package main
import ("fmt"
        "math")
// Go checked on 10/28/17

func main() {
    fmt.Print("Input cube size :   ");
    const maxsize int = 10;
    fmt.Scanf("%d", maxsize)
    var cube [ maxsize ][ maxsize ][ maxsize ]float64

    for i := 0; i < maxsize; i++ {
        for j := 0; j < maxsize; j++ {
            for k := 0; k < maxsize; k++ {
                cube[i][j][k] = 0.0;
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
    //var maxval float64 = cube[0][0][0];
    //var minval float64 = cube[0][0][0];

    cube[0][0][0] = math.Pow(1, 21);
    var ratio float64 = 0.0;
    var time float64 = 0.0;

    for ratio < 0.99 {
        for i := 0; i < maxsize; i++ {   
            for j := 0; j < maxsize; j++ {   
                for k := 0; k < maxsize; k++ {   
                    for l := 0; l < maxsize; l++ {   
                        for m := 0; m < maxsize; m++ {   
                            for n := 0; n < maxsize; n++ {
                                if ( (i == l && j == m && k == n+1) || (i == l && j == m && k == n-1) || (i == l && j == m+1 && k == n) ||
                                     (i == l && j == m-1 && k == n) || 
                                     (i == l+1 && j == m && k == n) || 
                                     (i == l-1 && j == m && k == n) ) {
                                    var change float64 = (cube[i][j][k] - cube[l][m][n]) * DTerm;
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
        sum = 0.0;
        var maxval float64 = cube[0][0][0];
        var minval float64 = cube[0][0][0];


        for i := 0; i < maxsize; i++ {
            for j := 0; j < maxsize; j++ {
                for k := 0; k < maxsize; k++ {
                    maxval = math.Max(cube[i][j][k], maxval);
                    minval = math.Min(cube[i][j][k], minval);
                    sum = sum + cube[i][j][k];
                }
            }
        }

        ratio = minval / maxval;

        //fmt.Print("Time = ", time, "\tRatio = ", ratio, "\tCube = ", cube[0][0][0]);
        //fmt.Println("\tCubemax = ", cube[maxsize-1][maxsize-1][maxsize-1]);
        //fmt.Println("Sum = ", sum);
    }

    fmt.Println("Check for mass consistency: ", sum);
    fmt.Println("Box equalibrated in ", time , "  seconds of simulation time.");
}
