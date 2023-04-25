using Microsoft.EntityFrameworkCore;
using Ppt23.Shared;

namespace Ppt23.Api.Data
{
    public class PptDbContext : DbContext
    {
        public PptDbContext(DbContextOptions<PptDbContext> options) : base(options)
        {
        }

        public DbSet<Equipment> Equipment => Set<Equipment>();
        public DbSet<Revision> Revisions => Set<Revision>();
    }
}