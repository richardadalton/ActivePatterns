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
//         Single     (|A|)
// ---------------------------------------------------------------
module SingleTotal =

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

// d gets passed to the 'Quarter' Active Recogniser and matches on the value returned

    type Season = Spring|Summer|Autumn|Winter

    let (|Season|) (_, month, _) =
        match month with
        | m when m >= 3 && m <= 5 -> Spring
        | m when m >= 6 && m <= 8 -> Summer
        | m when m >= 9 && m <= 11 -> Autumn
        | _ -> Winter

    let describeSeason d =
        match d with
        | Quarter 1 -> "Q1"
        | Quarter 1 & Season Spring -> "Got to me March"
        | Quarter 1 | Season Autumn -> "Quarter 1 OR Autumn"
        | Season Spring -> "Daffodils"
        | Season Summer -> "Ice-Cream"
        | Season Autumn -> "Golden Leaves"
        | Season Winter -> "Snow"




// ---------------------------------------------------------------
//         Multi-Case     (|A|B|)
// ---------------------------------------------------------------

module Multiple =

    let (|Q1|Q2|Q3|Q4|) m =
        match m with
        | 1 | 2 | 3 -> Q1
        | 4 | 5 | 6 -> Q2
        | 7 | 8 | 9 -> Q3
        | 10 | 11 | 12 -> Q4
        | _ -> Q4


    let describeQuarter d =
        match d with
        | _, Q1, _ -> "A New Start"
        | _, Q2, _ -> "Resolutions Broken"
        | _, Q3, _ -> "All the leaves are brown"
        | _, Q4, _ -> "The Sky is Grey"






module BetterDate =

    type Month = Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec
         
    let christmas = (21, May, 2015)

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

    let describeTimeOfYear d =
        match d with
        | Q1 | Spring -> "A New Start"
        | Q2 | Summer -> "Resolutions Broken"
        | Q3 | Autumn -> "All the leaves are brown"
        | Q4 | Winter -> "The Sky is Grey"




module WrapEnum =
    type Month = Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec

    // Wrap an untidy Enum in a neat Active Pattern
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

    let ChildsDestiny birthday =
        match birthday with
        | Mon -> "Fair of face"
        | Tue -> "Full of grace"
        | Wed -> "Full of woe"
        | Thu -> "Far to go"
        | Fri -> "Loving and giving"
        | Sat -> "Works had for a living"
        | Sun -> "Fair, wise, and good in every way"


