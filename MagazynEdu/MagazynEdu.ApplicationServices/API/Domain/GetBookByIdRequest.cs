using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.ApplicationServices.API.Domain
{
    public class GetBookByIdRequest : IRequest<GetBookByIdResponse>
    {
        public int BookId { get; set; }
    }
}
