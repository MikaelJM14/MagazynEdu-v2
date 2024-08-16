using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.DataAccess.Entities
{
    public class BookCase : EntityBase
    {
        public int Number { get; set; }

        public List<Book> Books { get; set; }
    }
}
