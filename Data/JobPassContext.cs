using JobPass.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPass.Api.Data;

public class JobPassDbContext : DbContext
{
    public JobPassDbContext(DbContextOptions<JobPassDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}
