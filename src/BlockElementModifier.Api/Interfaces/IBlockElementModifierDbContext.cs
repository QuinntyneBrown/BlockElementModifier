using Microsoft.EntityFrameworkCore;
using BlockElementModifier.Api.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BlockElementModifier.Api.Interfaces
{
    public interface IBlockElementModifierDbContext
    {
        DbSet<Customer> Customers { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
