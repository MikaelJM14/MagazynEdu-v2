using MagazynEdu.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.DataAccess.CQRS.Queries
{
    public class GetBookQuery : QueryBase<Book> 
    {
        public int Id { get; set; }

        public override async Task<Book> Execute(WarehouseStorageContext context)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == this.Id);
            return book;
        }
    }
}
