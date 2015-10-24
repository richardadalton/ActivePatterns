namespace ActivePatterns

// ---------------------------------------------------------------
//         Pattern Matching
// ---------------------------------------------------------------

module DescribeDate =

    let describeDate1 (d, m, y) = 
        sprintf "Day [%d], Month [%d], Year [%d]" d m y   


    let describeDate2 date =
        match date with
        | d, m, y -> sprintf "Day [%d], Month [%d], Year [%d]" d m y   

    let describeDate3 date =
        match date with
        | 31, 12, 1999 -> sprintf "Party like it's 1999"   
        | 25, 12, y -> sprintf "Christmas, %d" y   
        | d, m, y -> sprintf "Nothing special, just Day [%d], Month [%d], Year [%d]" d m y   


