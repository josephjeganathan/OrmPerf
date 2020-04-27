# ORM Performance

Tested Performance between ORM, results

|                      Method |       Mean |     Error |     StdDev |     Median |        Min |         Max |
|---------------------------- |-----------:|----------:|-----------:|-----------:|-----------:|------------:|
|                DapperSingle |   478.3 us | 119.79 us |   267.9 us |   437.6 us |   242.9 us |  1,782.3 us |
|           DapperFharpSingle |   656.1 us | 111.05 us |   248.4 us |   607.5 us |   395.2 us |  1,999.3 us |
|               Linq2DbSingle | 1,575.3 us | 144.60 us |   323.4 us | 1,549.5 us | 1,116.5 us |  3,113.6 us |
| SqlClientTypeProviderSingle |   551.8 us |  84.82 us |   189.7 us |   482.2 us |   347.8 us |  1,291.2 us |
|                  DapperJoin |   642.7 us |  76.39 us |   170.9 us |   585.0 us |   445.2 us |  1,130.9 us |
|             DapperFharpJoin |   760.8 us | 121.52 us |   271.8 us |   656.2 us |   542.0 us |  2,274.9 us |
|                 Linq2DbJoin | 4,313.0 us | 659.73 us | 1,475.6 us | 3,930.1 us | 3,228.1 us | 13,748.5 us |
|   SqlClientTypeProviderJoin |   541.9 us |  47.18 us |   105.5 us |   511.5 us |   454.6 us |    997.2 us |


Note that the Linq2Db usage is using DbContext (purely because the current client is using with db context), it can be seen as a biased arragement, feel free to try your own combo.