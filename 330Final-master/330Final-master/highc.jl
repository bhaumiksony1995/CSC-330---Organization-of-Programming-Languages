print("Input minimum value : ")
minimum = parse(Int128, readline())

print("Input maximum value : ") 
maximum = parse(Int128, readline())

MinHighestCount = Int128(0)
MinseqCount = Int128(0)
MaxHighestCount = Int128(0)
MaxseqCount = Int128(0)

while ( minimum != 1 )
    if  ((minimum % 2) == 0)
    minimum = minimum / 2;
    else
    minimum = minimum * 3 + 1
    end
    MinseqCount = MinseqCount + 1
    if minimum > MinHighestCount
        MinHighestCount = minimum
    end
end

while ( maximum != 1 )
    if  ((maximum % 2) == 0)
    maximum = maximum / 2;
    else
    maximum = maximum * 3 + 1
    end
    MaxseqCount = MaxseqCount + 1
    if maximum > MaxHighestCount
        MaxHighestCount = maximum
    end
end

if (MinHighestCount > MaxHighestCount)
    println(MinHighestCount);
else
    println(MaxHighestCount);
end

exit(0)

