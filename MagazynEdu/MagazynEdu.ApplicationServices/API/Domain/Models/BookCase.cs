using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.ApplicationServices.API.Domain.Models
{
    public class BookCase
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
