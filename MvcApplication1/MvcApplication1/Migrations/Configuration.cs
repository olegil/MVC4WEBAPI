using MvcApplication1.Models;

namespace MvcApplication1.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TestDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TestDB context)
        {
            context.Test.AddOrUpdate(v => v.Name,
                new Test { Name = "Test1", Number = 1 },
                new Test { Name = "Test2", Number = 2 }
                );
            context.SaveChanges();
        }
    }
}
