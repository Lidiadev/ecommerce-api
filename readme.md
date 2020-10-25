[![Build Status](https://travis-ci.com/Lidiadev/ecommerce-api.svg?branch=master)](https://travis-ci.com/github/Lidiadev/ecommerce-api)

ECommerce is an ASP.NET Core Web API which serves the domain of Customers and Orders.

## Domain 

* Customer has Name and Email. 
* Customer can have multiple Orders. 
* Order can belong to only one Customer. 
* Order has at least two fields: Price and CreatedDate.

## Features

* Return a list of customers, without orders; 
* Return a customer and his orders; 
* Add a new Order for an existing Customer; 
* Add a new Customer.

## Prerequirements

* Visual Studio 2019 
* .NET Core 3.0.1 SDK 

## Frameworks used:
* .NET Core 3.1
* ASP .NET Core 3.1
* Entity Framework Core 3.1
* MediatR
* NUnit
* FluentAssertions

### Architecture Overview

The architecture patterns used for this application are based on DDD (Domain-Driven Design) approach 
following the principles of Clean Architecture.

![architecture overview](images/architecture.PNG)

### Domain

It is responsible for representing concepts of the business and business rules.
This contains all entities, interfaces, types and logic specific to the domain layer:

* domain entities with data and behaviour
* value objects
* repository contracts.


### Application

It is dependent on the domain layer, but has no dependencies on any other layer or project. 
This layer defines interfaces that are implemented by outside layers. This layer contains all application logic:

* commands and command handlers
* queries and query handlers.


### Infrastructure

This layer contains classes which are based on interfaces defined within the application layer:

* Data persistence infrastructure: repository implementation
* ORM: Entity Framework Core.

### Web API

This layer is a REST API with ASP.NET Core 3. 
This layer depends on both the Application and Infrastructure layers. However, the dependency on Infrastructure is only to support dependency injection. 
Therefore only *Startup.cs* references Infrastructure.

### Database Configuration
The solution is configured to use a MSSQL DB.

## Continuous Integration

**Travis CI** has been used to run the tests.
Each pushed commit runs the unit tests.

### Testability
* Unit tests
* Integration tests.
