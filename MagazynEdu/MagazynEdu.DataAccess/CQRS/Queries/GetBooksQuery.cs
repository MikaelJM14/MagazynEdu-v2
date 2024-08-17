using MagazynEdu.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.DataAccess.CQRS.Queries
{
    public class GetBooksQuery : QueryBase<List<Book>> 
    {
        public string Title { get; set; }

        public override Task<List<Book>> Execute(WarehouseStorageContext context)
        {
            //context.Books.ToListAsync()
            return context.Books.Where(x => x.Title == this.Title).ToListAsync();
        }
    }
}
