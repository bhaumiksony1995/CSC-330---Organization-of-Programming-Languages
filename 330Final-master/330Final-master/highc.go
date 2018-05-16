package main
import ("fmt"
        )

func main() {

    fmt.Print("Input minimum value : ");
    var min int64 = 0;
    fmt.Scanf("%d", &min);

    fmt.Print("Input maximum value : ");
    var max int64 = 0;
    fmt.Scanf("%d", &max);
    
    var MinHighestCount int64 = 0;
    var MinseqCount int64 = 0;
    for min > 1 {
        if(min % 2 == 0) {
            min = min / 2;
        } else {
            min = 3 * min + 1;
        }
        MinseqCount = MinseqCount + 1;
        if min > MinHighestCount {
            MinHighestCount = min;
        }
    }

    var MaxHighestCount int64 = 0;
    var MaxseqCount int64 = 0;
    for max > 1 {
        if(max % 2 == 0) {
            max = max / 2;
        } else {
            max = 3 * max + 1;
        }
        MaxseqCount = MaxseqCount + 1;
        if max > MaxHighestCount {
            MaxHighestCount = max;
        }
    }

    if (MinHighestCount > MaxHighestCount) {
        fmt.Println(MinHighestCount);
    } else {
        fmt.Println(MaxHighestCount);
    }
}
    

