using LibraryDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryInfra.Connection
{
    class DbConnection : DbContext
    {

        public DbConnection(DbContextOptions<DbConnection> options) : base(options)
        {

        }

        DbSet<Book> Books { get; set; }
    }
}
