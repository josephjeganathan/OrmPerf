# ORM Performance

Tested Performance between ORM, results

|                      Method |       Mean |       Error |      StdDev |     Median |        Min |         Max |
|---------------------------- |-----------:|------------:|------------:|-----------:|-----------:|------------:|
|                DapperSingle |   527.1 us |    92.38 us |   206.63 us |   499.9 us |   238.4 us |  1,087.7 us |
|           DapperFharpSingle |   431.9 us |    57.96 us |   129.64 us |   419.2 us |   272.8 us |  1,046.9 us |
|               Linq2DbSingle | 1,840.7 us |   280.37 us |   627.08 us | 1,694.9 us | 1,439.7 us |  6,176.6 us |
| SqlClientTypeProviderSingle |   348.1 us |    42.37 us |    94.77 us |   313.8 us |   240.9 us |    676.2 us |
|           SqlProviderSingle | 2,245.3 us |   110.60 us |   247.38 us | 2,171.3 us | 1,781.5 us |  2,894.5 us |
|   EntityFrameworkCoreSingle | 2,759.6 us |   666.38 us | 1,490.44 us | 2,243.4 us | 1,800.0 us |  8,319.9 us |
|       EntityFrameworkSingle | 4,610.0 us | 2,160.87 us | 4,833.10 us | 3,258.4 us | 1,975.0 us | 35,346.9 us |
|                  DapperJoin |   516.6 us |   106.76 us |   238.78 us |   460.6 us |   269.3 us |  1,334.6 us |
|             DapperFharpJoin |   575.0 us |    63.16 us |   141.27 us |   536.6 us |   376.6 us |    922.4 us |
|                 Linq2DbJoin | 5,824.6 us | 1,241.57 us | 2,776.94 us | 4,561.5 us | 3,753.3 us | 16,450.5 us |
|   SqlClientTypeProviderJoin |   614.6 us |    96.51 us |   215.86 us |   560.9 us |   376.3 us |  1,603.2 us |
|             SqlProviderJoin | 5,974.2 us | 1,161.41 us | 2,597.65 us | 5,376.4 us | 3,913.3 us | 23,464.3 us |
|     EntityFrameworkCoreJoin | 5,447.1 us | 1,297.19 us | 2,901.34 us | 4,427.2 us | 3,682.3 us | 17,103.6 us |
|         EntityFrameworkJoin | 6,168.4 us | 1,478.89 us | 3,307.75 us | 4,970.8 us | 4,006.9 us | 20,772.4 us |


Note that the Linq2Db usage is using DbContext (purely because the current client is using with db context), it can be seen as a biased arragement, feel free to try your own combo.
