module EF6

open System.Data.Entity
open System.Data.SqlClient
open System.ComponentModel.DataAnnotations.Schema

[<CLIMutable; Table("Contact")>]
type Contact = 
    { Id: int
      Name: string }

[<CLIMutable; Table("Address")>]
type Address = 
    { Id: int
      ContactId: int
      Town: string }

type EfDbContext(connString: string) = 
    inherit DbContext(connString)

    do
        Database.SetInitializer<EfDbContext>(null)

    [<DefaultValue>]
    val mutable contacts: DbSet<Contact>
    member x.Contact
        with get() = x.contacts 
        and set v = x.contacts <- v

    [<DefaultValue>]
    val mutable addresses: DbSet<Address>
    member x.Address
        with get() = x.addresses
        and set v = x.addresses <- v

let conn = new SqlConnectionStringBuilder(Db.connectionString)
let db = new EfDbContext(conn.ToString())

let querySingleItem() =
    query {    
        for contact in db.Contact do
        where (contact.Id  = 1)
    }
    |> Seq.head

let queryWithJoin() =
    query {    
        for contact in db.Contact do
        join address in db.Address on (contact.Id = address.ContactId)
        select (contact, address)
    }
    |> Seq.toArray