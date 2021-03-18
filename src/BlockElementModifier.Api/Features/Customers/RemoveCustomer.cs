using BlockElementModifier.Api.Interfaces;
using BlockElementModifier.Api.Models;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlockElementModifier.Api.Features
{
    public class RemoveCustomer
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {

            }
        }

        public class Request : IRequest<Unit> {  
            public Guid CustomerId { get; set; }
        }

        public class Response
        {
            public CustomerDto Customer { get; set; }
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IBlockElementModifierDbContext _context;

            public Handler(IBlockElementModifierDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken) {

                var customer = await _context.Customers.FindAsync(request.CustomerId);

                customer.Remove();

                await _context.SaveChangesAsync(cancellationToken);

                return new () { };
            }
        }
    }
}
