# Blockchain Event Stream Processor
## Develped by Vijay Thorat

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

A console app in C# that receives some subset of transactions, and processes them in such a way that enables the program to answer questions about NFT ownership.


## Features

- Read JSON transaction data from user from inline or file.
- Maintain state of application and shows details about wallet ownership.

## Prerequisite
- .NET 6 SDK [Download][df1] (Required)
- IDE - VS Code [Download][df2] or VS 2022 Community Edition  [Download][df3] (Optional)

Download and install above prerequisite on you windows or macOS. Windows is prefered as it's tested on windows platform. 

## How to build and run
- Open powershell or command prompt on windows
- Extract/Checkout the project source code in C:\. You can change this directory but make sure you change path in following commands too.
- Run Unit test cases - This step is optional
```sh
    cd C:\BlockChainTransactions\
	
    dotnet test "BlockChain.UnitTest\BlockChain.UnitTest.csproj"
```

- Run below command to build application
```sh
  dotnet build "BlockChainEventStreamProcessor\Program.csproj"
```
- Open directory where output is generated
```sh
cd "BlockChainEventStreamProcessor\bin\Debug\net6.0"
```
- full path would be C:\BlockChainTransactions\BlockChainEventStreamProcessor\bin\Debug\net6.0 This path will have Program.exe generated after successful build.

- Once you in output directory run your test. 

Some of sample commands are as below. 
```sh
program --read-file C:\BlockChainTransactions\BlockChainEventStreamProcessor\transactions.json
program --nft 0xA000000000000000000000000000000000000000
program --nft 0xB000000000000000000000000000000000000000
program --nft 0xC000000000000000000000000000000000000000
program --nft 0xD000000000000000000000000000000000000000
program --read-inline '{ "Type": "Mint", "TokenId":"0xD000000000000000000000000000000000000000", "Address":"0x1000000000000000000000000000000000000000" }'
program --nft 0xD000000000000000000000000000000000000000
program --wallet 0x3000000000000000000000000000000000000000
program —-reset
program --wallet 0x3000000000000000000000000000000000000000
```

## License

MIT

**Free Software**

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

   [df1]: <https://dotnet.microsoft.com/en-us/download/dotnet/6.0>
   [df2]: <https://code.visualstudio.com/download>
   [df3]: <https://visualstudio.microsoft.com/vs/community/>
   [df4]: <https://www.newtonsoft.com/json/help/html/serializingjson.htm>
   [df5]: <https://dillinger.io/>
