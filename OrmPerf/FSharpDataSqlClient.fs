module FSharpDataSqlClient

open FSharp.Data

[<Literal>]
let querySingle = "SELECT * FROM Contact WHERE Id = 1"

let querySingleItem() =

    use cmd = new SqlCommandProvider<querySingle, Db.connectionString, ResultType.Tuples>(Db.connectionString)

    cmd.Execute() |> Seq.head

[<Literal>]
let query = """
    SELECT * 
    FROM Contact c
    INNER JOIN Address a ON c.Id = a.ContactId
"""

let queryWithJoin() =

    use cmd = new SqlCommandProvider<query, Db.connectionString, ResultType.Tuples>(Db.connectionString)

    cmd.Execute() |> Seq.toArray

