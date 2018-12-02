# sweetlou
Demo QnA bot for http://universaldirect.com/help-center with the comic chit-chat, plus editorial.

## Requirements
The pakages.config is pretty self explenatory but I marked **bold** a few things I had to make a little effort on.

1. Create an Azure Resource Group and Storage Account (Standard General Purpose v2)
2. [qnamaker.ai](http://qnamaker.ai)

### For local deployment I recommend
**Note:** The Utils.GetAppSetting(string key) method is for bots running on Azure, to run your bot on local w/ AppSettings in Web.config use ConfigurationManager.AppSettings["key"]. Replace Utils.GetAppSetting("key") in QnAMakerDialog as I did.

1. [**.NET Framework 4.7**](https://dotnet.microsoft.com/download/dotnet-framework-runtime)
2. [Visual Studio 2017](https://visualstudio.microsoft.com/downloads)
3. VS Extensions & Updates: 
  * Enterprise Bot
  * Builder V4 SDK Template
4. VS Tools & Features (I have the following installed)
  * ASP.NET and web development
  * Azure development
  * Python development (not req.)
  * Node.js development (not req.)
  * Data storage and processing
  * Data science and analytical applications (not req.)
5. Individual components:
  * .NET Framework 4.7 SDK and Targeting Pack
  * .NET Framework 4.7.2 SDK and Targeting Pack

### Packages.config (NuGet Package Manager)
1. Autofac 3.5.2
2. Chronic.Signed 0.3.2
3. EntityFramework 6.1.3
4. Microsoft.AspNet.WebApi 5.2.3
5. Microsoft.AspNet.WebApi.Client 5.2.3
6. Microsoft.AspNet.WebApi.Core 5.2.3
7. Microsoft.AspNet.WebApi.WebHost 5.2.3
8. Microsoft.Azure.DocumentDB 1.22.0
9. Microsoft.Azure.KeyVault.Core 1.0.0
10. Microsoft.Bot.Builder 3.15.2.2 
11. **Microsoft.Bot.Builder.Azure 3.15.2.2** 
12. Microsoft.Bot.Builder.CognitiveServices 1.1.7 
13. Microsoft.Bot.Builder.History 3.15.2.2 
14. Microsoft.Bot.Connector 3.15.2.2 
15. Microsoft.CodeDom.Providers.DotNetCompilerPlatform 1.0.1 
16. Microsoft.Data.Edm 5.7.0 
17. Microsoft.Data.OData 5.7.0 
18. Microsoft.Data.Services.Client 5.7.0 
19. Microsoft.IdentityModel.Logging 1.1.4 
20. Microsoft.IdentityModel.Protocol.Extensions 1.0.4.403061554 
21. Microsoft.IdentityModel.Protocols 2.1.4 
22. Microsoft.IdentityModel.Protocols.OpenIdConnect 2.1.4 
23. Microsoft.IdentityModel.Tokens 5.1.4 
24. Microsoft.Net.Compilers 1.2.1 
25. Microsoft.Rest.ClientRuntime 2.3.2 
26. Microsoft.WindowsAzure.ConfigurationManager 3.2.1 
27. Newtonsoft.Json 9.0.1 
28. System.IdentityModel.Tokens.Jwt 5.1.4 
29. System.Spatial 5.7.0 
30. WindowsAzure.Storage 7.2.1 

Install the [Bot Builder Tools](https://github.com/Microsoft/botbuilder-tools) as seperate cmds. 
```
npm install -g chatdown 
npm install -g msbot 
npm install -g ludown 
npm install -g luis-apis 
npm install -g qnamaker 
npm install -g botdispatch 
npm install -g luisgen
```

## Use Azure app service editor

1. make code change in the online editor
2. open the console window and run

```
build.cmd
```

## Use Visual Studio 

### Build and debug
1. download source code zip and extract source in local folder
2. open {PROJ_NAME}.sln in Visual Studio
3. build and run the bot
4. download and run [botframework-emulator](https://emulator.botframework.com/)
5. connect the emulator to http://localhost:3987

### Publish back

In Visual Studio, right click on {PROJ_NAME} and select 'Publish'

For first time publish after downloading source code
1. In the publish profiles tab, click 'Import'
2. Browse to 'PostDeployScripts' and pick '{SITE_NAME}.publishSettings'


## Use continuous integration

If you have setup continuous integration, then your bot will automatically deployed when new changes are pushed to the source repository.



