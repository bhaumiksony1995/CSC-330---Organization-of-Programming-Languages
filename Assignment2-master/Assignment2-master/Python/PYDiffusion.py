#!/usr/bin/python
import math
maxsize=input("Input cube size:   ")

# Checked python for mass consistency on 11/1/17

cube=[[[0.0 for k in range(maxsize)] for j in range(maxsize)] for i in range(maxsize)]

for i in range(0,maxsize):
    for j in range(0,maxsize):
        for k in range(0,maxsize):
            cube[i][j][k] = 0.0

diffusion_coefficient = 0.175
room_dimension = 5.0
speed_of_gas_molecules = 250.0
timestep = (room_dimension / speed_of_gas_molecules) / maxsize
distance_between_blocks = (room_dimension / maxsize)
DTerm = diffusion_coefficient * timestep / (distance_between_blocks * distance_between_blocks)
sumval = 0.0
time = 0.0
ratio = 0.0
cube[0][0][0] = 1.0e21

while ratio < 0.99:
    for i in range(0,maxsize):
        for j in range(0,maxsize):
            for k in range(0,maxsize):
                if (i != 0):
                    change = (cube[i][j][k] - cube[i-1][j][k]) * DTerm
                    cube[i][j][k]=cube[i][j][k] - change
                    cube[i-1][j][k]=cube[i-1][j][k] + change
                if (i != maxsize-1):
                    change = (cube[i][j][k] - cube[i+1][j][k]) * DTerm
                    cube[i][j][k]=cube[i][j][k] - change
                    cube[i+1][j][k]=cube[i+1][j][k] + change
                if (j != 0):
                    change = (cube[i][j][k] - cube[i][j-1][k]) * DTerm
                    cube[i][j][k]=cube[i][j][k] - change
                    cube[i][j-1][k]=cube[i][j-1][k] + change
                if (j != maxsize-1):
                    change = (cube[i][j][k] - cube[i][j+1][k]) * DTerm
                    cube[i][j][k]=cube[i][j][k] - change
                    cube[i][j+1][k]=cube[i][j+1][k] + change
                if (k != 0):
                    change = (cube[i][j][k] - cube[i][j][k-1]) * DTerm
                    cube[i][j][k]=cube[i][j][k] - change
                    cube[i][j][k-1]=cube[i][j][k-1] + change
                if (k != maxsize-1):
                    change = (cube[i][j][k] - cube[i][j][k+1]) * DTerm
                    cube[i][j][k]=cube[i][j][k] - change
                    cube[i][j][k+1]=cube[i][j][k+1] + change
    time = time + timestep

    #for mass consistency
    sumval = 0
    maxval = cube[0][0][0]
    minval = cube[0][0][0]

    for i in range(0,maxsize):
        for j in range(0,maxsize):
            for k in range(0,maxsize):
                maxval = max(cube[i][j][k], maxval)
                minval = min(cube[i][j][k], maxval)
                sumval = sumval + cube[i][j][k]

    ratio = minval/maxval

#    print "Time = " ,time, "\tRatio = " ,ratio, "\tCube = " ,cube[0][0][0], "\tCube max = " ,cube[maxsize-1][maxsize-1][maxsize-1], "\tSumval = " ,sumval

print "Check for mass consistency: ", sumval
print "Box equalibrated in " , time , "seconds of simulation time."
