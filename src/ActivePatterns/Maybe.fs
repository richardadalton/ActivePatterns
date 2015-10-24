namespace ActivePatterns

module Partial =

    type Month = Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec
       
    let (|NewYearsEve|_|) date = 
        match date with
        | (31, Dec, _) -> Some NewYearsEve
        | _ -> None

    let (|NewYearsDay|_|) date =
        match date with
        | (1,Jan,_) -> Some NewYearsDay
        | _ -> None
              
    let describeDate date =
        match date with
        | NewYearsEve -> "10..9..8..7.."
        | NewYearsDay -> "Time to hit the gym"
        | _ -> "Pfft ... Some other boring day"
       
       
       
module WeekdaysAndWeekends =
         
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

    let describeDate date =
        match date with
        | Weekend -> "It's party time"
        | Weekday-> "It's work time"




module LeapYearTheBadWay =

    let (|MultipleOf400|_|) n =
        if n % 400 = 0 then Some MultipleOf400
        else None

    let (|MultipleOf100|_|) n =
        if n % 100 = 0 then Some MultipleOf100
        else None

    let (|MultipleOf4|_|) n =
        if n % 4 = 0 then Some MultipleOf4
        else None

    let (|LeapYear|_|) year =
        match year with
        | MultipleOf400 -> Some LeapYear
        | MultipleOf100 -> None
        | MultipleOf4   -> Some LeapYear
        | _ -> None
 


module LeapYearABetterWay =

    let (|MultipleOf|_|) m n =
        if n % m = 0 then Some MultipleOf
        else None

    let (|LeapYear|_|) year =
        match year with
        | MultipleOf 400 -> Some LeapYear
        | MultipleOf 100 -> None
        | MultipleOf 4   -> Some LeapYear
        | _ -> None
         
    let (|MultipleOf400|_|) = (|MultipleOf|_|) 400
    





                        
               