using System;
using System.Data.Entity;

namespace BalHealthDiet.Data
{
    public class Class1:DbContext
    {
        public Class1():base("CookBookDbConnection")
        {
                
        }
        public DbSet<Book> Books { get; set; }
        public class Book
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
        }
    }
}
