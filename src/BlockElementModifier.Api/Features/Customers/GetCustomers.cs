using BlockElementModifier.Api.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlockElementModifier.Api.Features
{
    public class GetCustomers
    {
        public class Request : IRequest<Response> {  }

        public class Response
        {
            public List<CustomerDto> Customers { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBlockElementModifierDbContext _context;

            public Handler(IBlockElementModifierDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new Response() { 
                    Customers = _context.Customers.Select(x => x.ToDto()).ToList()
                };
            }
        }
    }
}
