module DapperCore

open System.Data.SqlClient
open Entities
open Dapper
open System

let querySingleItem() =
    use connection = new SqlConnection(Db.connectionString)
    let sql = "SELECT * FROM Contact WHERE Id = 1"

    async {
        return! connection.QuerySingleAsync(sql) |> Async.AwaitTask
    } 
    |> Async.RunSynchronously

let queryWithJoin() =
    use connection = new SqlConnection(Db.connectionString)
    let sql = "SELECT * FROM Address a INNER JOIN Contact c ON a.ContactId = c.Id"
    let mapper (contact: Contact) (address: Address) = contact, address

    async {
        return! connection.QueryAsync(sql, Func<_,_,_>(mapper)) |> Async.AwaitTask
    } 
    |> Async.RunSynchronously
    |> Seq.toArray
