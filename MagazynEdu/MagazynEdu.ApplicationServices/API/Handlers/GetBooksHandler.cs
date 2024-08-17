using AutoMapper;
using MagazynEdu.ApplicationServices.API.Domain;
using MagazynEdu.ApplicationServices.Components.OpenWeather;
using MagazynEdu.DataAccess;
using MagazynEdu.DataAccess.CQRS.Queries;
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
    public class GetBooksHandler : IRequestHandler<GetBooksRequest, GetBooksResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly IWeatherConnector weatherConnector;

        public GetBooksHandler(IMapper mapper, IQueryExecutor queryExecutor, IWeatherConnector weatherConnector)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.weatherConnector = weatherConnector;
        }

        public async Task<GetBooksResponse> Handle(GetBooksRequest request, CancellationToken cancellationToken)
        {
            var weather = await this.weatherConnector.Fetch("Brzeg");
            var query = new GetBooksQuery()
            {
                Title = request.Title
            };
            var books = await this.queryExecutor.Execute(query);
            var mappedBook = this.mapper.Map<List<Domain.Models.Book>>(books);
            var response = new GetBooksResponse()
            {
                Data = mappedBook
            };
            return response;
        }
    }
}
