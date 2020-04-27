module DapperFSharp

open Entities
open Dapper.FSharp
open System.Data.SqlClient
open Dapper.FSharp.MSSQL

let querySingleItem() =
    use connection = new SqlConnection(Db.connectionString)
    select {
        table "Contact"
        where (eq "Id" 1)
    } 
    |> connection.SelectAsync<Contact>
    |> (fun t -> t.GetAwaiter().GetResult())
    |> Seq.head

let queryWithJoin() =
    use connection = new SqlConnection(Db.connectionString)
    select {
        table "Contact"
        innerJoin "Address" "ContactId" "Contact.Id"      
    } 
    |> connection.SelectAsync<Contact, Address>
    |> (fun t -> t.GetAwaiter().GetResult())
    |> Seq.toArray