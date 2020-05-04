module EntityFrameworkCore

open Microsoft.EntityFrameworkCore
open Entities

type EfDbContext = 
    inherit DbContext

    new() = { inherit DbContext() }
    new(options: DbContextOptions<EfDbContext>) = { inherit DbContext(options) }

    override _.OnConfiguring options =
        options.UseSqlServer(Db.connectionString) |> ignore

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

let db = new EfDbContext()

let querySingleItem() =
    query {    
        for contact in db.Contact.AsNoTracking() do
        where (contact.Id  = 1)
    }
    |> Seq.head

let queryWithJoin() =
    query {    
        for contact in db.Contact.AsNoTracking() do
        join address in db.Address.AsNoTracking() on (contact.Id = address.ContactId)
        select (contact, address)
    }
    |> Seq.toArray