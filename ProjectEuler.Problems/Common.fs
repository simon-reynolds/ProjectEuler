module Common

open System
open System.IO
open System.Linq

let read_problem_file (n:int) =
    File.ReadAllLines(String.Format("..\\..\\..\\ProjectEuler.Problems\\Data\\Problem{0}.txt", n)).Where(String.IsNullOrWhiteSpace >> not)
    
let fib_seq = Seq.unfold(fun(x, y) -> Some(x+y, (y, x + y))) (0,1)

let factorsOf (n: int64) =
       let root = n |> float |> sqrt |> int64
       seq { for x in 2L .. root do if n % x = 0L then yield x; yield n / x }

let isPrime n =
    factorsOf n |> Seq.isEmpty

// greatest common denominator
let rec gcd (a:int64, b:int64) =
    match b with
    | x when x = 0L -> a
    | _ -> gcd(b, a%b)

// least common divisor
let rec lcm (a:int64, b:int64) =
    (a * b) / gcd (a,b)

let rec lcmlist (list: int64 list) =
    match list with
    | [] -> 1L
    | [a] -> a
    | [a;b] -> lcm(a,b)
    | h::t -> lcm(h, lcmlist t)