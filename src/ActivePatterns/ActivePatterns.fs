namespace ActivePatterns

// ---------------------------------------------------------------
//         Matching On Abstractions
// ---------------------------------------------------------------

// Match on an abstraction of the data

// Day Of The Week
// Quarter
// Season
// New Years Eve
// Month End
// Holiday
// Weekend


// ---------------------------------------------------------------
//         Conversions     (|A|)
// ---------------------------------------------------------------

module Conversions =

    let (|Quarter|) date =
        match date with
        | (_, m, _) when m % 3 = 0 -> m/3
        | (_, m, _) -> (m/3) + 1


    let describeQuarter d =
        match d with
        | Quarter 1 -> "A New Start"
        | Quarter 2 -> "Resolutions Broken"
        | Quarter 3 -> "All the leaves are brown"
        | Quarter 4 -> "The Sky is Grey"
        | _ -> "Well, this is weird" 


    type Season = Spring | Summer | Autumn | Winter

    let (|Season|) (_, month, _) =
        match month with
        | m when m >= 3 && m <= 5 -> Spring
        | m when m >= 6 && m <= 8 -> Summer
        | m when m >= 9 && m <= 11 -> Autumn
        | _ -> Winter
        // Note: Catch all needed. Month is an integer

    let describeSeason d =
        match d with
        | Season Spring -> "Flowers are blooming"
        | Season Summer -> "Let's go to the beach"
        | Season Autumn -> "The days are shorter now"
        | Season Winter -> "It's cold, wet, and dark"
        // Note: DU, Exhaustive, no catch all needed, only 4 seasons


    let describeDate d =
        match d with
        | Quarter 1 & Season Spring -> "That can only be March"
        | Quarter 1 -> "January or February"
        | Season Spring -> "April or May"
        | Quarter q & Season s -> sprintf "Quarter %d And Season %A" q s
        // Change the first & to |, causes subsequent rule to be unreacable
        // Try describeDate (31,12,2015);;
        // Try changing second & to |, not allowed.


// ---------------------------------------------------------------
//         Multi-Case     (|A|B|)
// ---------------------------------------------------------------
    

module MultiCase =

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


    // Wrap an untity Enum in a neat Active Pattern
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


    let describeDate d =
        match d with
        | Q1 & Spring -> "That can only be March"
        | Q1 -> "January or February"
        | Spring -> "April or May"
        | (31,Dec,_) -> "New Years Eve"
        | _ -> "Whatever"


