# Coffee_Vending_Machine

Project set up:
    Backend:
        The  whole project (the Console app, app libraries (.dlls) and the test project) are in .Net Core 10
        No need for any set up of the backend code (the consol app can be set up as Startup Project to be run)
    Database:
        Install SQL Server from https://www.microsoft.com/en-us/sql-server/sql-server-downloads.For the development purposes, SQL Server Developer Edition was used.
        Install SQL Server Management Studio (SSMS) from https://learn.microsoft.com/en-us/sql/ssms/install/install. Version used during development: SSMS 22
        Create the whole Database by running the 3 SQL scripts in order shown bellow that can be found in the root directory of this project
            1. CoffeeVendingMachine_Database.sql
            2. CoffeeVendingMachine_Tables_Schemas.sql
            3. CoffeeVendingMachine_Tables_Data.sql
        The SQL autnentication is Windows, at least for development purposes, connection string is set in appsettings.json in the Console app, this can be changed anytime

This should pass without any issues, but .... With this done the app can be started