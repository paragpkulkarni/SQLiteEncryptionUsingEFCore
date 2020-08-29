# SQLiteEncryptionUsingEFCore

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/ab02b316a4d34167bacca95fbecb2ebf)](https://app.codacy.com/manual/paragpkulkarni/SQLiteEncryptionUsingEFCore?utm_source=github.com&utm_medium=referral&utm_content=paragpkulkarni/SQLiteEncryptionUsingEFCore&utm_campaign=Badge_Grade_Dashboard)

This is a real life example which demostrates how to use SQLite encrypted databases using Entity Framework Core (EFCore). 

## Tipp for creating/exploring SQLite databases with encryption manually

The database is using SQLCipher encryption. To create/explore SQLite databases with encrytion manually, you may use the open source **DB Browser for SQLite**, which you can find here https://sqlitebrowser.org/ or on GitHub https://github.com/sqlitebrowser/sqlitebrowser .

## Steps for using encrypted SQLite database in your .Net application with EFCore

This example is using **.Net Core 3.1** with **EFCore 3.1.6** and **SQLCipher 2.0.3**:

1. Add a NuGET reference to `Microsoft.EntityFrameworkCore` in your project
1. Add a NuGET reference to `Microsoft.EntityFrameworkCore.Design` in your project
1. Add a NuGET reference to `Microsoft.EntityFrameworkCore.Sqlite.Core` in your project **This is a really important step: DO NOT add a reference to _Microsoft.EntityFrameworkCore.Sqlite_, otherwise it will not work!**
1. Add a NuGET reference to `SQLitePCLRaw.bundle_e_sqlcipher`
1. Create a connection object (`SqliteConnection`), defining the database access password in the connection string (you can use `SqliteConnectionStringBuilder`) you give to the constructor
1. Give _the connection object_ to the `UseSqlite` method, when configuring the database context
