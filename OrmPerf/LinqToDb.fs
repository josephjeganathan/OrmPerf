module LinqToDatabase

open LinqToDB.Configuration
open LinqToDB
open LinqToDB.Data
open LinqToDB.Mapping
open Entities

type ConnectionStringSettings(connectionString: string, name: string, providerName: string) =
    interface IConnectionStringSettings with
        member _.ConnectionString : string = connectionString
        member _.Name : string = name
        member _.ProviderName = providerName
        member _.IsGlobal = false

let connection : IConnectionStringSettings =
    new ConnectionStringSettings(Db.connectionString, "ContactDb", "SqlServer") :> IConnectionStringSettings

type LinqToDBSettings() =
    interface ILinqToDBSettings with
        member _.DataProviders = Seq.empty
        member _.DefaultConfiguration = "SqlServer"
        member _.DefaultDataProvider = "SqlServer"
        member _.ConnectionStrings = seq { connection }

DataConnection.DefaultSettings <- new LinqToDBSettings()

let contactMapping (builder: FluentMappingBuilder) =
    builder
        .Entity<Contact>()
        .HasSchemaName("dbo")
        .Property(fun c -> c.Id :> obj).IsPrimaryKey().IsIdentity()
    |> ignore

let addressMapping (builder: FluentMappingBuilder) =
    builder
        .Entity<Address>()
        .HasSchemaName("dbo")
        .Property(fun c -> c.Id :> obj).IsPrimaryKey().IsIdentity()
    |> ignore

type LinqToDbContext() =
    inherit DataConnection("ContactDb")

    static do
        let builder = MappingSchema.Default.GetFluentMappingBuilder()
        [ contactMapping
          addressMapping ]
        |> List.iter (fun mapper -> mapper builder)
        printfn "mapping intialised"
    
    member this.Contacts : ITable<Contact> = this.GetTable<Contact>()
    member this.Addresses : ITable<Address> = this.GetTable<Address>()

let db = new LinqToDbContext()

let querySingleItem() =
    query {    
        for contact in db.Contacts do
        where (contact.Id  = 1)
    }
    |> Seq.head

let queryWithJoin() =
    query {    
        for contact in db.Contacts do
        join address in db.Addresses on (contact.Id = address.ContactId)
        select (contact, address)
    }
    |> Seq.toArray