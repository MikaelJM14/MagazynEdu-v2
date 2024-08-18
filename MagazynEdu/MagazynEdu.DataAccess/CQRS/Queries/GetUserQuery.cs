using MagazynEdu.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.DataAccess.CQRS.Queries
{
    public class GetUserQuery : QueryBase<User>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public override async Task<User> Execute(WarehouseStorageContext context)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == this.Id);
            return user;
        }
    }
}
