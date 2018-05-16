program FDiffusion

!Checked Fortran on 11/8/17

    integer, parameter :: maxsize = 10 
    CHARACTER(len=32) :: arg

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
    print *, "Input cube size:  "
    DO i = 1, iargc()
        CALL getarg(maxsize, arg)
        WRITE (*,*) arg
    END DO

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

    cube(1,1,1) = 1E21
    ratio = 0.0
    time = 0.0

    do while (ratio .lt. 0.99)
        do i = 1, maxsize, 1
            do j = 1, maxsize, 1
                do k = 1, maxsize, 1
                    do l = 1, maxsize, 1
                        do m = 1, maxsize, 1
                            do n = 1, maxsize, 1
                                if(((i .eq. l) .and. (j .eq. m) .and. (k .eq. n+1)) .or. &
                                    ((i .eq. l) .and. (j .eq. m) .and. (k .eq. n-1)) .or. &
                                    ((i .eq. l) .and. (j .eq. m+1) .and. (k .eq. n)) .or. &
                                    ((i .eq. l) .and. (j .eq. m-1) .and. (k .eq. n)) .or. &
                                    ((i .eq. l+1) .and. (j .eq. m) .and. (k .eq. n)) .or. &
                                    ((i .eq. l-1) .and. (j .eq. m) .and. (k .eq. n))) then 
                                        change = (cube(i,j,k) - cube(l,m,n)) * DTerm
                                        cube(i,j,k) = cube(i,j,k) - change
                                        cube(l,m,n) = cube(l,m,n) + change
                                endif
                            end do
                        end do
                    end do
                end do
            end do
        end do

        time = time + timestep
        sumval = 0.0
        maximum = cube(1,1,1)
        minimum = cube(1,1,1)

        do i = 1, maxsize, 1
            do j = 1, maxsize, 1
                do k = 1, maxsize, 1
                    maximum = MAX(cube(i,j,k), maximum);
                    minimum = MIN(cube(i,j,k), minimum);
                    sumval = sumval + cube(i,j,k)
                end do
            end do 
        end do
        
        ratio = minimum / maximum;

        !print *, "Time = " ,time, " Ratio = " ,ratio, " Cube = " ,cube(1,1,1), "CubeMax = ", &
         !   cube(maxsize-1,maxsize-1,maxsize-1), "Sumval = ", sumval
    end do

    print *, "Check for mass consistency (should be 1e21): ",sumval
    print *, "Box equalibrated in " ,time, " seconds of simulation time."
end program FDiffusion
