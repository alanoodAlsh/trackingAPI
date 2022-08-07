using Microsoft.EntityFrameworkCore;
using trackingAPI.Models;

namespace trackingAPI.Data
{

    public class IssueDbContext:DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options)
        :base(options)
        {
            
        }
        public DbSet<Issue> Issues { get; set; }
    }
}