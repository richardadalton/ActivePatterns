namespace ActivePatterns

module BinaryTree =

    type BinaryTree<'a> =
        | Tree of 'a * BinaryTree<'a> * BinaryTree<'a>
        | Empty

    let rec add value tree =
        match tree with
        | Empty -> Tree(value, Empty, Empty)
        | Tree (x, left, right) when value < x ->
            Tree(x, add value left, right)
        | Tree (x, left, right) ->
            Tree(x, left, add value right)


    let t1 = Empty
    let t2 = add 5 t1
    let t3 = add 6 t2


    let deepMatch t =
        match t with
        |Tree(_, Empty, Empty) -> "Just One Value"
        |Tree(_,_, Tree(6,_,_)) -> "A six on the right"
        | _ -> "NO MATCH"