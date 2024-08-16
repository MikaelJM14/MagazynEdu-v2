using MagazynEdu.ApplicationServices.API.Domain;
using MagazynEdu.DataAccess;
using MagazynEdu.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MagazynEdu.ApplicationServices.API.Handlers
{
    public class GetBooksHandlers : IRequestHandler<GetBooksRequest, GetBooksResponse>
    {
        private readonly IRepository<Book> bookRepository;

        public GetBooksHandlers(IRepository<DataAccess.Entities.Book> bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Task<GetBooksResponse> Handle(GetBooksRequest request, CancellationToken cancellationToken)
        {
            var books = this.bookRepository.GetAll();

            var domainbooks = new List<Domain.Models.Book>();

            foreach (var book in books)
            {
                domainbooks.Add(new Domain.Models.Book()
                {
                    Id = book.Id,
                    Title = book.Title
                });
            }

            var response = new GetBooksResponse()
            {
                Data = domainbooks.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
