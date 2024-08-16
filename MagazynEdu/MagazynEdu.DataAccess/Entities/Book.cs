using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.DataAccess.Entities
{
    public class Book : EntityBase
    {
        public int BookCaseId { get; set; }
        
        public BookCase BookCase { get; set; }

        public List<Author> Authors { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public int Year { get; set; }
    }
}
