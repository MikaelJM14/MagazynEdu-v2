using MagazynEdu.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.DataAccess.CQRS.Queries
{
    public class GetBookCaseQuery : QueryBase<List<BookCase>>
    {
        public override Task<List<BookCase>> Execute(WarehouseStorageContext context)
        {
            return context.BookCases
                .Include(x => x.Books)
                .ToListAsync();
        }
    }
}
