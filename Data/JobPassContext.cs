using Microsoft.EntityFrameworkCore;

namespace JobPass.Api.Data;

public class JobPassDbContext : DbContext
{
    public JobPassDbContext(DbContextOptions<JobPassDbContext> options)
        : base(options)
    {
    }

    // DbSets virão aqui depois
}
