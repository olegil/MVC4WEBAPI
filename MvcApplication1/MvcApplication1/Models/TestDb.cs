using System.Data.Entity;

namespace MvcApplication1.Models
{
    public class TestDB : DbContext
    {
        public DbSet<Test> Test { get; set; }

    }
}