using MagazynEdu.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.DataAccess.CQRS.Commands
{
    public class AddBookCaseCommand : CommandBase<BookCase, BookCase>
    {
        public override async Task<BookCase> Execute(WarehouseStorageContext context)
        {
            await context.BookCases.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
