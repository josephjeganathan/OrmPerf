module Entities

[<CLIMutable>]
type Contact = 
    { Id: int
      Name: string }

[<CLIMutable>]
type Address = 
    { Id: int
      ContactId: int
      Town: string }
