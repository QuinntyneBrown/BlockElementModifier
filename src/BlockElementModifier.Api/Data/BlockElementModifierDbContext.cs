using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BlockElementModifier.Api.Models;
using BlockElementModifier.Api.Interfaces;

namespace BlockElementModifier.Api.Data
{
    public class BlockElementModifierDbContext: DbContext, IBlockElementModifierDbContext
    {
        public BlockElementModifierDbContext(DbContextOptions options)
            :base(options) { }
        
        public DbSet<Customer> Customers { get; private set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
