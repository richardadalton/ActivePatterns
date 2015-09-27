namespace ActivePatterns

// ---------------------------------------------------------------
//         Pattern Matching
// ---------------------------------------------------------------

module DescribeDate =

    let describeDate1 date =
        let (d, m, y) = date 
        sprintf "Day [%d], Month [%d], Year [%d]" d m y   


    let describeDate2 (d, m, y) = 
        sprintf "Day [%d], Month [%d], Year [%d]" d m y   


    let describeDate3 date =
        match date with
        | d, m, y -> sprintf "Day [%d], Month [%d], Year [%d]" d m y   


    let describeDate4 date =
        match date with
        | 31, 12, 1999 -> sprintf "Party like it's 1999"   
        | _, 25, y -> sprintf "Christmas, [%d]" y   
        | 1, 1, y when y % 10 = 0 -> sprintf "New Decade"   
        | 1, 1, y -> sprintf "New Years Day, [%d]" y   
        | 1, _, _ -> sprintf "New Month"  
        | d, m, y -> sprintf "Nothing special, just Day [%d], Month [%d], Year [%d]" d m y   