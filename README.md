## AppDocuments, sample MinimalApi and Blazor WebAssembly application with Keycloak 
AppDocuments is a sample application to manage documents which allows create, update, delete and browse registered metadata of documents.
Project is built with .NET6 MinimalApi as backend and Blazor WebAssembly as frontend. Both of services are secured by openId protocol and jwt authorizarion using 3rd party identity provider which is Keycloak.

![Documents dashboard](https://raw.githubusercontent.com/Kwazi1984/minimal-api-and-blazor/feature/assets/app-screen.jpg)

## Architecture
![Documents dashboard](https://raw.githubusercontent.com/Kwazi1984/minimal-api-and-blazor/feature/assets/diagram.jpg)

## Requirements
- [docker](https://www.docker.com/)
- [docker-compose](https://docs.docker.com/compose/install/)
- [.NET6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## How to start project
In docker folder please call command
```
docker-compose up -d
```
and in projects folders src/AppDocuments.Api and src/AppDocuments.Blazor please call
```
dotnet run
```
To run application in browser, call: [http://localhost:7032](http://localhost:7032)

To sign in use credentials:
`john.doe/Pass.123` or `mark.williams/Pass.123`

To manage users in Keycloak idp, call in browser: [http://localhost:8088](http://localhost:8088)

and sing in as admin using credentials:
`admin/admin`

## Technical stack
**[`.NET6`](https://dotnet.microsoft.com/download)** - Free. Cross-platform. Open source. A developer platform for building all your apps.

**[`Minimal API`](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio#overview)** as a backend.  Minimal APIs are architected to create HTTP APIs with minimal dependencies. They are ideal for microservices and apps that want to include only the minimum files, features, and dependencies in ASP.NET Core.

**[`Blazor Webassembly`](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)** as a frontend, Blazor is a feature of ASP.NET, the popular web development framework that extends the .NET developer platform with tools and libraries for building web apps.

**[`EF Core`](https://github.com/dotnet/efcore)** - Modern object-database mapper for .NET. It supports LINQ queries, change tracking, updates, and schema migrations. Used as ORM to manage SQLite.

**[`SQLite`](https://www.sqlite.org/i)** - a small, fast, self-contained, high-reliability, full-featured, SQL database engine. Used to store metadata of documents.

**[`Keycloak`](https://www.keycloak.org/)** - Keycloak is an Open Source Identity and Access Management solution for modern Applications and Services. Used as Identity provider in project.

**[`Radzen Blazor Components`](https://blazor.radzen.com/)** - A set of 60+ free and open source native Blazor UI controls. Used a few coopmonents RadzenDataGrid, RadzenMenu etc.



