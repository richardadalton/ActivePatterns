namespace ActivePatterns

module MaybePatterns =

    type Month = Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec
         
    let (|Q1|Q2|Q3|Q4|) (_, m, _) =
        match m with
        | Jan | Feb | Mar -> Q1
        | Apr | May | Jun -> Q2
        | Jul | Aug | Sep -> Q3
        | Oct | Nov | Dec -> Q4

    let (|Spring|Summer|Autumn|Winter|) (_, m, _) =
        match m with
        | Mar | Apr | May -> Spring
        | Jun | Jul | Aug -> Summer
        | Sep | Oct | Nov -> Autumn
        | Dec | Jan | Feb -> Winter

    let (|Mon|Tue|Wed|Thu|Fri|Sat|Sun|) (d, m, y) =
        let dateStr = sprintf "%d/%A/%d" d m y
        match System.DateTime.ParseExact(dateStr, "dd/MMM/yyyy", System.Globalization.CultureInfo.InvariantCulture).DayOfWeek with
        | System.DayOfWeek.Monday -> Mon
        | System.DayOfWeek.Tuesday -> Tue
        | System.DayOfWeek.Wednesday -> Wed
        | System.DayOfWeek.Thursday -> Thu
        | System.DayOfWeek.Friday -> Fri
        | System.DayOfWeek.Saturday -> Sat
        | _ -> Sun


    let (|NewYearsEve|_|) date = 
        match date with
        | (31, Dec, _) -> Some NewYearsEve
        | _ -> None

    let (|NewYearsDay|_|) date =
        match date with
        | (1,Jan,_) -> Some NewYearsDay
        | _ -> None


    let (|Weekend|_|) date = 
        match date with
        | Sat | Sun -> Some Weekend
        | _ -> None

    let (|Weekday|_|) date =
        match date with
        | Weekend -> None
        | _ -> Some Weekday
 
    let (|Weekend|Weekday|) date = 
        match date with
        | Sat | Sun -> Weekend
        | _ -> Weekday

                        
    let (|Holiday|_|) holidays date =
        match date with
        | (day, month, 2015) when holidays |> List.exists (fun d -> d = (day, month)) -> Some Holiday
        | _ -> None
       
    let holidayDates2015 = [(14,Feb); (17,Mar); (4,May)]
   
    let (|Holiday2015|_|) = (|Holiday|_|) holidayDates2015

 

 
    let (|MultipleOf|_|) m n =
        if n % m = 0 then Some MultipleOf
        else None

    let (|LeapYear|_|) year =
        match year with
        | MultipleOf 400 -> Some LeapYear
        | MultipleOf 100 -> None
        | MultipleOf 4   -> Some LeapYear
        | _ -> None
         

    let (|LastDayOfMonth|) (month, year) =
        let daysInMonth = Map.ofList [(Jan,31); (Feb,28); (Mar,31); (Apr,30); (May,31); (Jun,30); (Jul,31); (Aug,31); (Sep,30); (Oct,31); (Nov,30); (Dec,31);]

        match (month, year) with
        | (Feb, _) & (_, LeapYear) -> 29
        | (m,_) -> daysInMonth.[m]

    
    let (|MonthEnd|_|) (day, month, year) =
        match (month, year) with
        | LastDayOfMonth d when day = d -> Some MonthEnd
        | _ -> None

    // Note, it now knows that a date contains a month
    // And that the following is exhaustive
    let describeDate1 d =
        match d with
        | Q1 -> "A New Start"
        | Q2 -> "Resolutions Broken"
        | Q3 -> "All the leaves are brown"
        | Q4 -> "The Sky is Grey"


    let describeDate3 d =
        match d with
        | Holiday2015 -> "It's 2015, and it's a day off"
        | NewYearsEve -> "10..9..8..7..."
        | Q1 & Spring -> "That can only be March"
        | Weekend | Holiday2015 -> "Get out in the Sunshine"
        | Fri | (13, _, _) -> "Unlucky for some"
        | _ -> "Yada Yada, some other date"

               