using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class TestDB : DbContext
    {
        public DbSet<TestModel> Test { get; set; }

    }
}