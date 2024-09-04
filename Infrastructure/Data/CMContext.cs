using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CMContext : DbContext
    {
        public CMContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Contact> Contact { get; set; }
        
    }
}