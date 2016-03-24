module Problem7

open Common

(*
By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

What is the 10 001st prime number?
*)

let Answer = Seq.initInfinite (fun i -> int64 i |> (*) 2L |> (+) 1L) // create infinite sequence of odd numbers
            |> Seq.filter (fun i -> isPrime i)
            |> Seq.nth 10000
