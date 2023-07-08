using Microsoft.EntityFrameworkCore;

namespace IOC.Models.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options):base(options)
        {

        }
    }
}
