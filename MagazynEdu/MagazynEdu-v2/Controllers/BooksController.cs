using MagazynEdu.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazynEdu_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ApiControllerBase
    {

        public BooksController(IMediator mediator, ILogger<BooksController> logger) : base(mediator)
        {
            logger.LogInformation("We are in Books");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllBooks([FromQuery] GetBooksRequest request)
        {
            return this.HandleRequest<GetBooksRequest, GetBooksResponse>(request);
        }

        [HttpGet]
        [Route("{bookId}")]
        public Task<IActionResult> GetById([FromRoute] int bookId)
        {
            var request = new GetBookByIdRequest()
            {
                BookId = bookId
            };
            return this.HandleRequest<GetBookByIdRequest, GetBookByIdResponse>(request);
        }
    }
}
