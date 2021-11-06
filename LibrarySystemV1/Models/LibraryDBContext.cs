using System;
using System.Data.Entity;
using System.Linq;

namespace LibrarySystemV1.Models
{
    public class LibraryDBContext : DbContext
    {
        
        public LibraryDBContext()
            : base("name=LibraryDBContext")
        {
        }

     
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Borrower> Borrowers { get; set; }

    }

  
}