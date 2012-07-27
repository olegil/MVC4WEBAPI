using MvcApplication1.Models;

namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcApplication1.Models.TestDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcApplication1.Models.TestDB context)
        {
            context.Test.AddOrUpdate(v => v.Name,
                new TestModel(){Name = "Test1", Number = 1},
                new TestModel() {Name = "Test2", Number = 2}
                );
            context.SaveChanges();
        }
    }
}
