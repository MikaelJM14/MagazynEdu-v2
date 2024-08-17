using AutoMapper;
using MagazynEdu.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.ApplicationServices.API.Mappings
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            this.CreateMap<MagazynEdu.DataAccess.Entities.Book, Book>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title));
        }
    }
}
