using BlockElementModifier.Api.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlockElementModifier.Api.Features
{
    public class UpdateCustomer
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Customer).NotNull();
                RuleFor(request => request.Customer).SetValidator(new CustomerValidator());
            }
        }

        public class Request : IRequest<Response> {  
            public CustomerDto Customer { get; set; }
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

                var customer = await _context.Customers.FindAsync(request.Customer.CustomerId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Customer = customer.ToDto()
                };
            }
        }
    }
}
