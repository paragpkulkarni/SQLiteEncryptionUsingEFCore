# SQLiteEncryptionUsingEFCore
This is real life example which demostrates how to use SQLite encrypted database using Entity Framework Core (EFCore). 
Database is using SQLCipher encryption. Encryption is applied to the database using DBBrowser for SQLite. DBBrowser for SQLite is free and open source tool to edit the SQLite files. 

Steps for using Encrypted SQLite database in your .Net application with EFCore. This example is using .Net Core 2.0 with EFCore 2.0


1  Add the reference of Microsoft.EntityFrameworkCore.Design in your project.

2  Add the reference of Microsoft.EntityFrameworkCore.Sqlite.Core. This is really important step. Don't add the reference of Microsoft.EntityFrameworkCore.Sqlite. Otherwise it will not work.

3  Add the reference of SQLitePCLRaw.bundle_sqlcipher. For encryption it is required.

4  Add the following line 
   <PackageReference Include="SQLitePCLRaw.bundle_green" Version="1.1.8" ExcludeAssets="All" />
   ExcludeAssets="All" is important otherwise it will not work. For details refer to following link
  
     http://www.bricelam.net/2016/06/13/sqlite-encryption.html



