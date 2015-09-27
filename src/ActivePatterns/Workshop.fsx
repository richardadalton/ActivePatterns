
// ---------------------------------------------------------------
// THE BASICS
//
//         Functions & Partial Application 
// ---------------------------------------------------------------

// Write a Negate Function, Look at it's signature


// Write a function (Add) that adds two integers, Look at it's signature
// Note that it is a function that returns a function.


// Write a function (Increment), that partially applies the Add function


// ---------------------------------------------------------------
//         Type Inference
// ---------------------------------------------------------------

// Use each of the following in a 'let' binding, and look at the inferred type
// 10, 1.5, "Hello World", [0 .. 99], (26, "Sep", 2015)





// ---------------------------------------------------------------
//         Destructuring Assignment
// ---------------------------------------------------------------

// Destructure a tuple (1, 2, 3) into (a, b, c)


// Destructure the same tuple but ignore one of the elements


// Write a function to shift the elements in a tuple to the left



// ---------------------------------------------------------------
// PATTERN MATCHING
//
//         The Match Expression
// ---------------------------------------------------------------

// Describe a date using a simple let binding and sprintf



// Describe a date by destructuring in the params 



// Describe a date using a match expression



// Add come clauses to the match expression: New Years Eve, Christmas, New Decade, New Month etc.



// Notice we need a catch all clause




// ---------------------------------------------------------------
// ACTIVE PATTERNS
//
//         Matching On Abstractions
// ---------------------------------------------------------------

// Consider some abstractions over dates, how can we implement them
// Note that all dates translate to Day Of the Week, Quarter, Season
// The rest "may" be true of some dates, but not all

// Conversion
// -----------
// Day Of The Week
// Quarter
// Season

// Maybe
// -----------
// New Years Eve
// Month End
// Holiday
// Weekend


// ---------------------------------------------------------------
//         Conversions
// ---------------------------------------------------------------

// Implement a conversion from a date to a Quarter



// Match on the 4 quarters. Notice we need a catch all clause.



// Create a Season Discriminated Union



// Implement a conversion from a date to a Season



// Match on the 4 seasons, note we don't need a catch all



// Quarter 1 and Season Spring -> "That can only be March"

// Quarter 1 -> "January or February"

// Season Spring

// Change the first & to |, causes subsequent rule to be unreacable


// ---------------------------------------------------------------
//         Multi-Case
// ---------------------------------------------------------------


// Define a Month Discriminated Union Jan, Feb, Mar...etc.
         

   
// Define a Multi-Case Active Recogniser for Q1, Q2, Q3 & Q4



// Define a Multi-Case Active Recogniser for Spring, Summer, Autumn, Winter



// Define a Multi-Case Active Recogniser for Mon, Tue Wed...etc.



// Rewrite the DescribeDate function from above using the new Active Recognisers




// ---------------------------------------------------------------
// MAYBE
//
//         Partial
// ---------------------------------------------------------------

// Define a Partial Active Recognizer for New Years Eve, use the Month DU defined above



// Define a Partial Active Recognizer for New Years Day, use the Month DU defined above



// Define a Partial Active Recognizer for Weekend, use the Day Multi-Case Recognizer defined above



// Define a Partial Active Recognizer for Weekday, use the Weekend Recognizer defined above



// Define a Multi-Case Active Recognizer for Weekend|Weekday


// ---------------------------------------------------------------
//         Partial Application
// ---------------------------------------------------------------

// Define a Partial Active Recognizer for Holiday, pass an extra arg, a list of holidays (Day, Month)



// Define a list of Holidays (Day, Month)



// Partially Apply the Holiday Recognizer with the list of holidays to create a Year Specific Recognizer



// Define a Partial Recognizer for MultipleOf



// Define a Partial Recognizer for Leap Year, that uses MultipleOf



// Define a conversion for LastDayOfMonth that matches on a (Month, Year)



// Define a partial recogniser for MonthEnd that uses LastDayOfMonth



// Write a Describe Date function that uses the various Recognisers and combines them.


