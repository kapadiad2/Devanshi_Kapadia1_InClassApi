using Devanshi_Kapadia1_InClassApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Devanshi_Kapadia1_InClassApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
    }
}
