module Problem4

open System.Linq

(*
A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

Find the largest palindrome made from the product of two 3-digit numbers.
*)

let is_palindrome (n) =
    let charArray = n.ToString().ToCharArray() // so we can pass in number directly
    let reversed = charArray |> Array.rev
    charArray.SequenceEqual(reversed)

let num = [100 .. 999]

let products = num |> Seq.collect (fun i -> num |> Seq.map(fun j -> i * j)) // C# equivalent = num.SelectMany(i => num.Select(j => i * j))

let palindromes = products |> Seq.filter(fun i -> is_palindrome i)
    
let Answer = palindromes |> Seq.max

