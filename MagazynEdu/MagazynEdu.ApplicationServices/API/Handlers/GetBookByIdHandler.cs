using AutoMapper;
using MagazynEdu.ApplicationServices.API.Domain;
using MagazynEdu.DataAccess;
using MagazynEdu.DataAccess.CQRS.Commands;
using MagazynEdu.DataAccess.CQRS.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MagazynEdu.ApplicationServices.API.Handlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdRequest, GetBookByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetBookByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetBookByIdResponse> Handle(GetBookByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBookQuery()
            {
                Id = request.BookId
            };
            var book = await this.queryExecutor.Execute(query);
            var mappedBook = this.mapper.Map<Domain.Models.Book>(book);
            var response = new GetBookByIdResponse()
            {
                Data = mappedBook
            };
            return response;
        }
    }
}
