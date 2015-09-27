namespace ActivePatterns

// ---------------------------------------------------------------
//         Functions & Partial Application 
// ---------------------------------------------------------------

module Functions =

    let negate x = -x

    let add x y = x + y

    let increment = add 1



// ---------------------------------------------------------------
//         Type Inference
// ---------------------------------------------------------------

module TypeInference =

    let anInteger = 10

    let aFloat = 10.5

    let aString = "Hello World"
 
    let aListOfIntegers = [ 0 .. 99 ]

    let aTuple = (26, "Sep", 2015)

    type MyDate = { Day: int; Month: string; Year: int }

    let today = { Day = 26; Month = "Sep"; Year = 2015 }


                
// ---------------------------------------------------------------
//         Destructuring Assignment
// ---------------------------------------------------------------

module Tuples =

    let (a, b, c) = (1, 2, 3)

    let (f, _, l) = (1, 2, 3)

    let shiftLeft t = 
        let (a, b, c) = t 
        (b, c, a)

    let simplerShiftLeft (a, b, c) = (b, c, a)

