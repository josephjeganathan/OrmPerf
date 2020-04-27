open System
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Engines


[<SimpleJob(RunStrategy.Monitoring, launchCount = 3, warmupCount = 10, targetCount = 20)>]
[<MinColumn; MaxColumn; MeanColumn; MedianColumn>]
type DapperBenchMark() =

    // Single

    [<Benchmark>]
    member _.DapperSingle() = DapperCore.querySingleItem() |> ignore

    [<Benchmark>]
    member _.DapperFharpSingle() = DapperFSharp.querySingleItem() |> ignore

    [<Benchmark>]
    member _.Linq2DbSingle() = LinqToDatabase.querySingleItem() |> ignore

    [<Benchmark>]
    member _.SqlClientTypeProviderSingle() = FSharpDataSqlClient.querySingleItem() |> ignore

    // Join

    [<Benchmark>]
    member _.DapperJoin() = DapperCore.queryWithJoin() |> ignore

    [<Benchmark>]
    member _.DapperFharpJoin() = DapperFSharp.queryWithJoin() |> ignore

    [<Benchmark>]
    member _.Linq2DbJoin() = LinqToDatabase.queryWithJoin() |> ignore

    [<Benchmark>]
    member _.SqlClientTypeProviderJoin() = FSharpDataSqlClient.queryWithJoin() |> ignore

[<EntryPoint>]
let main _ =
    
    BenchmarkRunner.Run<DapperBenchMark>() |> ignore

    Console.ReadLine() |> ignore
    0
