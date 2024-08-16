using MagazynEdu.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.DataAccess
{
    public class WarehouseStorageContext : DbContext
    {
        public WarehouseStorageContext(DbContextOptions opt) : base(opt)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCase> BookCases { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}
