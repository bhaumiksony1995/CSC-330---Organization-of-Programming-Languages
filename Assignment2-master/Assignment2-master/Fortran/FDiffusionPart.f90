program FDiffusion

!Checked Fortran on 11/8/17

    integer, parameter :: maxsize = 10 !change this to change cube size
    integer :: partsize = maxsize / 2
    CHARACTER :: part = 'Y' !change this to Y if you want partition

    real(kind=8),dimension(0:maxsize, 0:maxsize, 0:maxsize) :: cube 
    real(kind=8) :: diffusion_coefficient
    real(kind=8) :: room_dimension
    real(kind=8) :: timestep
    real(kind=8) :: speed_of_molecules
    real(kind=8) :: distance_between_blocks
    real(kind=8) :: Dterm
    real(kind=8) :: sumval
    real(kind=8) :: time
    real(kind=8) :: ratio
    real(kind=8) :: maximum
    real(kind=8) :: minimum
    real(kind=8) :: change
    diffusion_coefficient = 0.175
    room_dimension = 5.0
    speed_of_molecules = 250.0
    timestep = (room_dimension / speed_of_molecules) / maxsize !h in seconds
    distance_between_blocks = room_dimension / maxsize
    Dterm = diffusion_coefficient * timestep / (distance_between_blocks * distance_between_blocks)
    
    do i = 1, maxsize, 1
        do j = 1, maxsize, 1
            do k = 1, maxsize, 1
                cube(i,j,k) = 0.0
            end do
        end do
    end do
    
    if(part .eq. 'Y') then
        do i = 1, maxsize, 1
            do j = 1, maxsize, 1
                do k = 1, maxsize, 1
                    if ((i .eq. (partsize)) .and. (j .ge. (partsize))) then 
                        cube(i,j,k) = -1.0
                    end if
                end do
            end do
        end do
    end if

    cube(1,1,1) = 1E21
    ratio = 0.0
    time = 0.0
    
    do while (ratio .le. 0.99)
        do i = 1, maxsize, 1
            do j = 1, maxsize, 1
                do k = 1, maxsize, 1
                    if (cube(i,j,k) .ge. 0) then
                        if ((i .ne. 1) .and. (cube(i-1,j,k) .ne. -1.0)) then
                            change = (cube(i,j,k) - cube(i-1,j,k)) * DTerm
                            cube(i,j,k) = cube(i,j,k) - change
                            cube(i-1,j,k) = cube(i-1,j,k) + change
                        end if
                        if ((i .ne. maxsize) .and. (cube(i+1,j,k) .ne. -1.0)) then
                            change = (cube(i,j,k) - cube(i+1,j,k)) * DTerm
                            cube(i,j,k) = cube(i,j,k) - change
                            cube(i+1,j,k) = cube(i+1,j,k) + change
                        end if
                        if ((j .ne. 1) .and. (cube(i,j-1,k) .ne. -1.0)) then
                            change = (cube(i,j,k) - cube(i,j-1,k)) * DTerm
                            cube(i,j,k) = cube(i,j,k) - change
                            cube(i,j-1,k) = cube(i,j-1,k) + change
                        end if
                        if ((j .ne. maxsize) .and. (cube(i,j+1,k) .ne. -1.0)) then
                            change = (cube(i,j,k) - cube(i,j+1,k)) * DTerm
                            cube(i,j,k) = cube(i,j,k) - change
                            cube(i,j+1,k) = cube(i,j+1,k) + change
                        end if
                        if ((k .ne. 1) .and. (cube(i,j,k-1) .ne. -1.0)) then
                            change = (cube(i,j,k) - cube(i,j,k-1)) * DTerm
                            cube(i,j,k) = cube(i,j,k) - change
                            cube(i,j,k-1) = cube(i,j,k-1) + change
                            end if
                        if ((k .ne. maxsize) .and. (cube(i,j,k+1) .ne. -1.0)) then
                            change = (cube(i,j,k) - cube(i,j,k+1)) * DTerm
                            cube(i,j,k) = cube(i,j,k) - change
                            cube(i,j,k+1) = cube(i,j,k+1) + change
                        end if
                    end if
                end do
            end do
        end do
        
        time = time + timestep
        !check for mass consistensy
        maximum = cube(1,1,1)
        minimum = cube(1,1,1)
        sumval = 0.0 

        do i = 1, maxsize, 1
            do j = 1, maxsize, 1
                do k = 1, maxsize, 1
                    if (cube(i,j,k) .ge. 0) then
                        maximum = MAX(cube(i,j,k), maximum);
                        minimum = MIN(cube(i,j,k), minimum);
                        sumval = sumval + cube(i,j,k)
                    end if
                end do
            end do 
        end do

        ratio = minimum / maximum;

        !print *, "Time = " ,time, " Ratio = " ,ratio, " Cube = " ,cube(1,1,1), "CubeMax = ", &
        !cube(maxsize-1,maxsize-1,maxsize-1), "Sumval = ", sumval
    end do

    print *, "Check for mass consistency (should be 1e21): ",sumval
    print *, "Box equalibrated in " ,time, " seconds of simulation time."
end program FDiffusion
