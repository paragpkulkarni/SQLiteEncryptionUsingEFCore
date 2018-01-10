using Microsoft.Data.Sqlite;
using System;

namespace ConsoleApp.SQLite
{
    public class Program
    {
        public static void Main()
        {
            // SQLCipher Encryption is applied to database using DBBrowser for SQLite.
            // DBBrowser for SQLite is free and open source tool to edit the SQLite files. 
            using (var db = new BloggingContext())            
            {
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }
            }
        }        
    }
}