using BlockElementModifier.Api.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlockElementModifier.Api.Features
{
    public class GetCustomerById
    {
        public class Request : IRequest<Response> {  
            public Guid CustomerId { get; set; }        
        }

        public class Response
        {
            public CustomerDto Customer { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBlockElementModifierDbContext _context;

            public Handler(IBlockElementModifierDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                var customer = await _context.Customers.FindAsync(request.CustomerId);

                return new Response() { 
                    Customer = customer.ToDto()
                };
            }
        }
    }
}
