using MagazynEdu.DataAccess;
using MagazynEdu.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazynEdu_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookCaseController : ControllerBase
    {
        private readonly IRepository<BookCase> bookCaseRepository;

        public BookCaseController(IRepository<BookCase> bookCaseRepository)
        {
            this.bookCaseRepository = bookCaseRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<BookCase> GetAllBooks()
        {
            return this.bookCaseRepository.GetAll();
        }

        [HttpGet]
        [Route("{bookCaseId}")]
        public BookCase GetBookById(int bookCaseId)
        {
            return this.bookCaseRepository.GetById(bookCaseId);
        }
    }
}
