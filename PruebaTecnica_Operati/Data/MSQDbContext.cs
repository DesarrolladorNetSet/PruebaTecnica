using Microsoft.EntityFrameworkCore;
using PruebaTecnica_Operati.Models;

namespace PruebaTecnica_Operati.Data
{
    public class MSQDbContext : DbContext
    {
        public MSQDbContext(DbContextOptions<MSQDbContext> options) :
            base(options)
        {

        }

        public DbSet<User> User { get; set; }
    }
}
