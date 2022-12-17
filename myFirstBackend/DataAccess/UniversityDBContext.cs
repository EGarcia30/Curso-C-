using Microsoft.EntityFrameworkCore;
using myFirstBackend.Models.DataModels;

namespace myFirstBackend.DataAccess
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options):base(options)
        {
        
        }

        // TODO: Add DbSets (Tables of our Data base)

        public DbSet<User>? Users { get; set; }

    }
}
