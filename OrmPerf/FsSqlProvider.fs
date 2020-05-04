module FsSqlProvider

open FSharp.Data.Sql

type Sql = SqlDataProvider<Common.DatabaseProviderTypes.MSSQLSERVER, Db.connectionString>

let context = Sql.GetDataContext()

let querySingleItem() =
    query {    
        for contact in context.Dbo.Contact do
        where (contact.Id  = 1)
    }
    |> Seq.head

let queryWithJoin() =
    query {    
        for contact in context.Dbo.Contact do
        join address in context.Dbo.Address on (contact.Id = address.ContactId)
        select (contact, address)
    }
    |> Seq.toArray