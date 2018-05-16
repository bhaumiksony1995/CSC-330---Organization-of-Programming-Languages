program Collatz
    integer :: num
    integer :: finish
    integer :: numCount
    integer :: numCountCopy
    integer :: longestSequence

    print *, "Enter the end of range integer of sequence (Eg. if input 100 = sequence ends at 100) : "
    read(*,*) finish
    do i = 2, finish, 1 !ONLY WORKS IF THERE IS A PRINT STATEMENT INSIDE LOOP
        num = i
        numCount = 0
        do while (num .ne. 1)
            if (MODULO(num, 2) .eq. 0) then !if even
                num = num / 2
                numCount = numCount + 1
            else if (MODULO(num, 2) .ne. 0) then !if odd
                num = (num * 3) + 1
                numCount = numCount + 1
            end if
        end do
        if (numCount .gt. numCountCopy) then
            longestSequence = i
            numCountCopy = numCount
        end if
        print *, num !PRINT STATEMENT NEEDED TO MAKE IT WORK
    end do

    print *, "Number with biggest sequence is : ", longestSequence
end program Collatz
