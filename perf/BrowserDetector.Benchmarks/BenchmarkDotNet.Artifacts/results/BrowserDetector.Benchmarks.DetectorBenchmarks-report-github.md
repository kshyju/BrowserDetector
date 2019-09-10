``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Xeon CPU E5-1650 v4 3.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.0.100-preview9-014004
  [Host]     : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT


```
|         Method |     Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |---------:|----------:|----------:|-------:|------:|------:|----------:|
| Chrome_Windows | 1.057 us | 0.0015 us | 0.0014 us | 0.0324 |     - |     - |     208 B |
| Safari_Windows | 1.093 us | 0.0205 us | 0.0192 us | 0.0286 |     - |     - |     192 B |
