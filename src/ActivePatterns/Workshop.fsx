// ---------------------------------------------------------------
// BASICS
//         Destructuring Assignment
// ---------------------------------------------------------------

// Destructure a tuple (1, 2, 3) into (a, b, c) : The shape must match

// Ignore one of the elements: Shape must still match, but don't need to match all elements


// ---------------------------------------------------------------
// PATTERN MATCHING
//
//         The Match Expression
// ---------------------------------------------------------------

// Use a tuple to represent a date

// Describe a date by destructuring the params 

// Convert to a match expression


// Add a clause for New Years Eve 1999
// Add a clause for any Christmas
// Extract and display which Christmas it is 


// Notice we need a catch all clause
// Notice how ease it is to represent an illegal date
// Notice we can only pattern match on numbers that are in the tuple


// ---------------------------------------------------------------
// ACTIVE PATTERNS
//
//         Matching On Abstractions
// ---------------------------------------------------------------

// Consider some abstractions over dates, how can we implement them?
// All dates translate to Day Of the Week, Quarter, Season
// Some Abstractions "may" be true of some dates, but not all 
// e.g. End Of Month, Tuesday

// Conversion
// -----------
// Quarter
    // Take a date, return an int 1, 2, 3, or 4

    // Notice we could write a function Quarter(date) and match 1, 2, 3, 4
    // But using an active pattern allows us to mix with other matches
    // E.g. add a match for Christmas

    // How would we implement 
    // Season:   String?
    // Day Of The Week:   String?  Int?


//  For Season, make a Discriminated Union
    //  Match on Season, notice we don't need a catch all
    //  Notice we can mix Quarter and Season
    //  Notice that like Quarter, Season returns a value, we name the Recognizer in the match
    //  Notice we can combine patterns Quarter & Season, Quarter | Season
    //  Noice the compiler will show unreachable clauses


// ---------------------------------------------------------------
// ACTIVE PATTERNS
//
//         Multiple Value Recognisers
// ---------------------------------------------------------------

//  Create a Multiple Recogniser Q1|Q2|Q3|Q4

    // Notice we match on month which is still an integer
    // So we need a catch all
    // Notice we can match directly on Q1, Q2 etc.


// ---------------------------------------------------------------
// Rethinking Date
//
//          Make illegal months unrepresentable
// ---------------------------------------------------------------

// Let's re-think Date
    // Use a Discriminated Union for Month
    // Now we can write exhaustive recognisers like Quarter and Season, without catch-alls


// ---------------------------------------------------------------
// Wrapping Enums
//
//          Enable pattern matching against enums
// ---------------------------------------------------------------

    // Wrap day of the week
    // Child's Destiny 


// ---------------------------------------------------------------
// MAYBE
//
//         Partial
// ---------------------------------------------------------------

// Define a Partial Active Recognizer for New Years Eve, use the Month DU defined above
// Define a Partial Active Recognizer for New Years Day, use the Month DU defined above

// Define partials for Weekend and Weekday
// Note matching on partials isn't exhaustive

// Define a multiple using Weekend and Weekday
// Note that matching on a multiple is exhaustive


// ---------------------------------------------------------------
// PARAMS
//
//         Partial
// ---------------------------------------------------------------

// Create Partial Recognisers for Multiples of 400, 100 and 4
// Implement a Partial Leap Year recogniser from these.

// Create a partial recogniser MultipleOf that takes two arguments
// Implement a Partial Leap Year recogniser from that.

// Show we can partially apply MultipleOf to create the others