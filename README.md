# OnionFunc
[![Build status](https://ci.appveyor.com/api/projects/status/tlej4ujmt74jf5xe/branch/master?svg=true)](https://ci.appveyor.com/project/inasync/onionfunc/branch/master)
[![NuGet](https://img.shields.io/nuget/v/Inasync.OnionFunc.svg)](https://www.nuget.org/packages/Inasync.OnionFunc/)

***OnionFunc*** は middleware pattern によってパイプラインを構築する為の、非常にシンプルな .NET ヘルパーライブラリです。


## Target Frameworks
- .NET Standard 2.0+
- .NET Standard 1.0+
- .NET Framework 4.5+


## Usage
```cs
Func<int, bool> handler = num => true;
Assert.AreEqual(true, handler(24));

Func<int, bool> onionFunc = handler
    .Layer(next => num => (num % 3 == 0) && next(num))
    .Layer(next => num => (num % 4 == 0) && next(num))
    ;
Assert.AreEqual(true, onionFunc(24));
Assert.AreEqual(false, onionFunc(30));
```


## Licence
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
