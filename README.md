# Sicem Operation

## Overview
This project is a **ASP.NET Core Web Application** built using the .NET Core framework.

## Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core) (8.0)
- A database system (SQL Server, PostgreSQL, MySQL, etc. depending on your configuration)
- Entity Framework Core

## Getting Started

1. Rename the `appsettings.sample.json` file to `appsettings.json` and configure the settings properly:
    ```bash
    mv appsettings.sample.json appsettings.json
    ```

2. Restore dependencies and build the project:
    ```bash
    dotnet restore
    dotnet build
    ```

3. (Optional) scaffol the database using scafoll ef:
    ```bash
    //
    ```

## Build and Run
To build and run the project, use the following commands:

```bash
dotnet build
dotnet run
