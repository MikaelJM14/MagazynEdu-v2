using MagazynEdu.ApplicationServices.API.Domain;
using MagazynEdu.DataAccess;
using MagazynEdu.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazynEdu_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookCaseController : ApiControllerBase
    {
        public BookCaseController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddBookCase([FromBody] AddBookCaseRequest request)
        {
            return this.HandleRequest<AddBookCaseRequest, AddBookCaseResponse>(request);
        } 
    }
}
