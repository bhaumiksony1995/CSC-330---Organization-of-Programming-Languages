program highc
    integer :: minimum = 10
    integer :: maximum = 11
    integer :: MinseqCount = 0
    integer :: MaxseqCount = 0
    real :: MinHighestCount = 0
    real :: MaxHighestCount = 0

    write(*,*)("Enter the minimum and maximum value (Format: min max)")
    read (*,*)minimum,maximum

    do while(minimum > 1)
        if (modulo(minimum, 2) == 0) then
            minimum = minimum / 2
        else
            minimum = 3 * minimum + 1
        end if
        MinseqCount = MinseqCount + 1
        if (minimum > MinHighestCount) then
            MinHighestCount = minimum
        end if
    end do


    do while(maximum > 1)
        if (modulo(maximum, 2) == 0) then
            maximum = maximum / 2
        else
            maximum = 3 * maximum + 1
        end if
        MaxseqCount = MaxseqCount + 1
        if (maximum > MaxHighestCount) then
            MaxHighestCount = maximum
        end if
    end do

    if (MinHighestCount > MaxHighestCount) then
        print *, MinHighestCount
    else
        print *, MaxHighestCount
    end if

end program highc

!recursive function Collatz(num) result(HighestCount)
!    real :: seqCount
!    real :: HighestCount
!    if (num > 1) then
!        if (modulo(num, 2) == 0) then
!            num = Collatz(num / 2)
!        else
!            num = Collatz((3 * num + 1))
!        end if
!        seqCount = seqCount + 1
!        print *, seqCount
!        if (HighestCount < seqCount) then
!            HighestCount = seqCount
!        end if
!    end if
!end function Collatz

