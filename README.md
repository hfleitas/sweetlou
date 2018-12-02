# sweetlou
QnA bot for http://universaldirect.com/help-center with Comic chit-chat and Editorial.

## Requirements
1. **.Net Framework 4.7**
2. Autofac3.5.2
3. Chronic.Signed0.3.2
4. EntityFramework6.1.3
5. Microsoft.AspNet.WebApi5.2.3
6. Microsoft.AspNet.WebApi.Client5.2.3
7. Microsoft.AspNet.WebApi.Core5.2.3
8. Microsoft.AspNet.WebApi.WebHost5.2.3
9. Microsoft.Azure.DocumentDB1.22.0
10. Microsoft.Azure.KeyVault.Core1.0.0
11. Microsoft.Bot.Builder3.15.2.2
12. **Microsoft.Bot.Builder.Azure3.15.2.2**
13. Microsoft.Bot.Builder.CognitiveServices1.1.7
14. Microsoft.Bot.Builder.History3.15.2.2
15. Microsoft.Bot.Connector3.15.2.2
16. Microsoft.CodeDom.Providers.DotNetCompilerPlatform1.0.1
17. Microsoft.Data.Edm5.7.0
18. Microsoft.Data.OData5.7.0
19. Microsoft.Data.Services.Client5.7.0
20. Microsoft.IdentityModel.Logging1.1.4
21. Microsoft.IdentityModel.Protocol.Extensions1.0.4.403061554
22. Microsoft.IdentityModel.Protocols2.1.4
23. Microsoft.IdentityModel.Protocols.OpenIdConnect2.1.4
24. Microsoft.IdentityModel.Tokens5.1.4
25. Microsoft.Net.Compilers1.2.1
26. Microsoft.Rest.ClientRuntime2.3.2
27. Microsoft.WindowsAzure.ConfigurationManager3.2.1
28. Newtonsoft.Json9.0.1
29. System.IdentityModel.Tokens.Jwt5.1.4
30. System.Spatial5.7.0
31. WindowsAzure.Storage7.2.1


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



