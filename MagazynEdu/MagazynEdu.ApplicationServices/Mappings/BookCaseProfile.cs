using AutoMapper;
using MagazynEdu.ApplicationServices.API.Domain;
using MagazynEdu.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.ApplicationServices.API.Mappings
{
    public class BookCaseProfile : Profile
    {
        public BookCaseProfile()
        {
            this.CreateMap<AddBookCaseRequest, BookCase>()
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number));

            this.CreateMap<BookCase, Domain.Models.BookCase>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
                .ForMember(x => x.BookTitles, y => y.MapFrom(z => z.Books != null ? z.Books.Select(x => x.Title) : new List<string>()));
        }
    }
}
