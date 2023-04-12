using Microsoft.EntityFrameworkCore;
using RSS.Data.Models;

namespace RSS.Data
{
    public class RideSharingDbContext:DbContext
    {
        public RideSharingDbContext(DbContextOptions<RideSharingDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}