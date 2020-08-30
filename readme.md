## Technologies used:
* .NET Core 3.1
* ASP .NET Core 3.1
* Entity Framework Core 3.1
* MediatR
* NUnit
* FluentAssertions


### Domain

This contains all entities, interfaces, types and logic specific to the domain layer.


### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. 
This layer defines interfaces that are implemented by outside layers. 


### Infrastructure

This layer contains classes which are based on interfaces defined within the application layer.

### WebUI

This layer is a REST API with ASP.NET Core 3. 
This layer depends on both the Application and Infrastructure layers. However, the dependency on Infrastructure is only to support dependency injection. 
Therefore only *Startup.cs* references Infrastructure.