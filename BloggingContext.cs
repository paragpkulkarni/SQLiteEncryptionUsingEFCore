using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.SQLite
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        private SqliteConnection connection;

        public BloggingContext()
        {
        }

        public BloggingContext(SqliteConnection sqliteConnection)
        {
            connection = sqliteConnection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            connection = InitializeSQLiteConnection();
            optionsBuilder.UseSqlite(connection);
        }

        // SQLCipher Encryption is applied to database using DBBrowser for SQLite.
        // DBBrowser for SQLite is free and open source tool to edit the SQLite files. 
        private static SqliteConnection InitializeSQLiteConnection()
        {
            var connection = new SqliteConnection("Data Source=blogging.db");
            connection.Open();
            var password = "Test123";
            var command = connection.CreateCommand();
            command.CommandText = "SELECT quote($password);";
            command.Parameters.AddWithValue("$password", password);
            var quotedPassword = (string)command.ExecuteScalar();

            command.CommandText = "PRAGMA key = " + quotedPassword;
            command.Parameters.Clear();
            var result = command.ExecuteNonQuery();
            return connection;
        }
    }
}
