using AutoMapper;
using MagazynEdu.ApplicationServices.API.Domain;
using MagazynEdu.DataAccess.CQRS;
using MagazynEdu.DataAccess.CQRS.Commands;
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
    public class AddBookCaseHandler : IRequestHandler<AddBookCaseRequest, AddBookCaseResponse>
    {
        private readonly ICommandExecutor commandExecuter;
        private readonly IMapper mapper;

        public AddBookCaseHandler(ICommandExecutor commandExecuter, IMapper mapper)
        {
            this.commandExecuter = commandExecuter;
            this.mapper = mapper;
        }

        public async Task<AddBookCaseResponse> Handle(AddBookCaseRequest request, CancellationToken cancellationToken)
        {
            var bookCase = this.mapper.Map<BookCase>(request);
            var command = new AddBookCaseCommand() { Parameter = bookCase };
            var BookCaseFromDb = await this.commandExecuter.Execute(command);
            return new AddBookCaseResponse()
            {
                Data = this.mapper.Map<Domain.Models.BookCase>(BookCaseFromDb)
            };
        }
    }
}
