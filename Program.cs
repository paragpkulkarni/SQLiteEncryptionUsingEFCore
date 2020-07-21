using System;
using System.IO;
using System.Linq;

namespace ConsoleApp.SQLite
{
    public class Program
    {
        public static void Main()
        {
            // Tipp: SQLite Cipher databases can be created/explored manually using https://sqlitebrowser.org/ (or on GitHub https://github.com/sqlitebrowser/sqlitebrowser)
            const string newDatabaseFile = "newblogging.db";
            foreach (var databaseFile in File.Exists(BloggingContext.DEFAULTDBFILE)
                ? new[] { BloggingContext.DEFAULTDBFILE, newDatabaseFile }// If the default existing database exists
                : new[] { newDatabaseFile, BloggingContext.DEFAULTDBFILE }// The default existing database will be a copy of the new database from the first test
                )
            {
                // Prepare the test
                if (databaseFile == BloggingContext.DEFAULTDBFILE)
                {
                    // Use the existing database
                    if (!File.Exists(databaseFile))
                    {
                        // Copy the previously created new database as default existing database
                        Console.WriteLine("Use \"{0}\" as default existing database \"{1}\"", newDatabaseFile, databaseFile);
                        File.Copy(newDatabaseFile, databaseFile);
                    }
                    Console.WriteLine("Update existing database \"{0}\"", databaseFile);
                }
                else
                {
                    // Create a new database
                    if (File.Exists(databaseFile))
                    {
                        // Delete the previously created database (ensure we're creating a new database)
                        Console.WriteLine("Delete existing database \"{0}\"", databaseFile);
                        File.Delete(databaseFile);
                    }
                    Console.WriteLine("Test creating new database \"{0}\"", databaseFile);
                }

                // Initialize the database context (ensure the database is created, if it's a new database)
                using var db = new BloggingContext(databaseFile);
                if (databaseFile == newDatabaseFile) db.Database.EnsureCreated();

                // Add a blog URI
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                Console.WriteLine("{0} records saved to database", db.SaveChanges());

                // Display all blog URIs from the current database
                Console.WriteLine("All {0} blogs in database:", db.Blogs.Count());
                foreach (var blog in db.Blogs) Console.WriteLine(" - #{0} {1}", blog.BlogId, blog.Url);
            }
        }
    }
}