# Sensor Reading Backend

## Introduction
In this project, random sensor readings are generated every 20 seconds and saved to a localDB. There is an avilable `GET` http endopoint that provides the readings that were generated since the previous request. The previous request timestamp is stored in a static variable.

## Tech Details
- Project is written in `ASP.NET MVC Core 2` framework. Where I applied `MVC Pattern`. There is no view component since it's an API project.
- I applied repository pattern and [Dependency Injection principle](https://en.wikipedia.org/wiki/Dependency_injection)
- I used `Entity Framework Core` as an `Object Relational Mapper (ORM)`
- I used [Hangfire framework](https://www.hangfire.io/) to schedule the reading generating task for every 20 seconds. CRON string used: `0,20 * * * * *`

## Installation
- Clone the repository
- Open the `.sln` with `visual studio 2017` with `ASP.NET CORE2.1` framework installed
- Open the package manager console 
- Navigate the project root folder, same level of `Statup.cs` and type the command `dotnet ef database update`, it will create a local DB using the `Migrations` folder
- Run the project by pressing `CTRL` + `F5`, Visual Studio will attempt to install nuget packages ,create the localDB and create necessary tables
