using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LibraryApp.Core.Entities;

namespace LibraryApp.Infrastructure
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=libraryappconnectionstring")
        {

        }
        public DbSet<Book> Books { get; set; }   
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Book>().Property(x => x.Price).HasPrecision(16, 3);
        //}
        public DbSet<Auther> Authers { get; set; }

    }
}